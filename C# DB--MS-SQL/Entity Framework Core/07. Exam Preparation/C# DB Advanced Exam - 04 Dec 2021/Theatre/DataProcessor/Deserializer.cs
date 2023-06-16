namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;
    using Trucks.Utilities;

    public class Deserializer
    {
        private static XmlHelper xmlHelper;
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";


    
        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            xmlHelper = new XmlHelper();
            List<string> genres = new List<string> { "Drama", "Comedy", "Romance", "Musical" };
            var minimumTime = new TimeSpan(1, 0, 0);
            ImportPlayDto[] playsDto =
                xmlHelper.Deserialize<ImportPlayDto[]>(xmlString, "Plays");
            ICollection<Play> validPlays = new List<Play>();
            
            foreach (var playDto in playsDto)
            {
                var currentTime = TimeSpan.ParseExact(playDto.Duration, "c", CultureInfo.InvariantCulture);
                if (!IsValid(playDto)||
                    (currentTime < minimumTime)
                    || !genres.Contains(playDto.Genre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Play validPlay = new Play {
                    Title = playDto.Title,
                    Duration = TimeSpan.ParseExact(playDto.Duration.ToString(), "c", CultureInfo.InvariantCulture),
                    Rating = playDto.Rating,
                    Genre = (Genre)Enum.Parse(typeof(Genre), playDto.Genre),
                    Description = playDto.Description,
                    Screenwriter = playDto.Screenwriter
                
                };

                validPlays.Add(validPlay);
                sb.AppendLine(String.Format(SuccessfulImportPlay, validPlay.Title,validPlay.Genre,validPlay.Rating));
            }
            context.AddRange(validPlays);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            xmlHelper = new XmlHelper();
            StringBuilder sb = new StringBuilder();
            ImportCastDto[] castsDto =
                xmlHelper.Deserialize<ImportCastDto[]>(xmlString, "Casts");
            List<Cast> validCasts = new List<Cast>();

            foreach (var cast in castsDto)
            {
                if (!IsValid(cast))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Cast validCast = new Cast
                {
                    FullName = cast.FullName,
                    IsMainCharacter = cast.IsMainCharacter,
                    PhoneNumber = cast.PhoneNumber,
                    PlayId = cast.PlayId

                };
                validCasts.Add(validCast);
                if (cast.IsMainCharacter)
                {
                    sb.AppendLine(String.Format(SuccessfulImportActor, cast.FullName, "main"));
                }
                else
                {
                    sb.AppendLine(String.Format(SuccessfulImportActor, cast.FullName, "lesser"));
                }
                
            }
            context.AddRange(validCasts);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportTeatherTicketsDto[] teathersDto =
                JsonConvert.DeserializeObject<ImportTeatherTicketsDto[]>(jsonString);
            var Validtheathers = new List<Theatre>();

            foreach (var theatre in teathersDto)
            {
                if (!IsValid(theatre))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Theatre validtheatre = new Theatre
                {
                    Name = theatre.Name,
                    NumberOfHalls = theatre.NumberOfHalls,
                    Director = theatre.Director,

                };
                var tickets = new List<Ticket>();
                foreach (var t in theatre.Tickets)
                {
                    if (!IsValid(t))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    Ticket validTickets = new Ticket
                    {
                        Price = t.Price,
                        RowNumber = t.RowNumber,
                        Theatre = validtheatre,
                        PlayId = t.PlayId
                    };

                    tickets.Add(validTickets);
                }
                validtheatre.Tickets = tickets;
                Validtheathers.Add(validtheatre);
                sb.AppendLine(String.Format(SuccessfulImportTheatre, validtheatre.Name, validtheatre.Tickets.Count()));
            }
            context.AddRange(Validtheathers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}

namespace Footballers.DataProcessor
{
    using Footballers.Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();
            CoachDto[] couches;
            XmlSerializer serializer = new XmlSerializer(typeof(CoachDto[]), new XmlRootAttribute("Coaches"));
            using (TextReader reader= new StringReader(xmlString))
            {
                couches = (CoachDto[])serializer.Deserialize(reader);
            }

            List<Coach> entities = new List<Coach>();

            foreach (var coach in couches)
            {
                Coach coachEntity = new Coach();

                coachEntity.Name = coach.Name??"";
                coachEntity.Nationality = coach.Nationality??"";

                if (!IsValid(coachEntity))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                entities.Add(coachEntity);
                foreach (var footballer in coach.Footballers)
                {
                    var footballerEntity = new Footballer();
                    try
                    {
                        footballerEntity.Name = footballer.Name ?? "";
                        footballerEntity.PositionType = (PositionType)footballer.PositionType;
                        footballerEntity.ContractStartDate =
                            DateTime.ParseExact(footballer.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        footballerEntity.ContractEndDate =
                          DateTime.ParseExact(footballer.ContractEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        footballerEntity.BestSkillType = (BestSkillType)footballer.BestSkillType;

                        if (!IsValid(footballerEntity)||footballerEntity.ContractEndDate<footballerEntity.ContractStartDate)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }
                    }
                    catch (Exception)
                    {

                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                   
                    coachEntity.Footballers.Add(footballerEntity);
                }
             sb.AppendLine(String.Format(SuccessfullyImportedCoach,coachEntity.Name,coachEntity.Footballers.Count));

            }
            context.Coaches.AddRange(entities);
            context.SaveChanges();
            return sb.ToString();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var teams = JsonConvert.DeserializeObject<TeamDto[]>(jsonString);
            var teamsEntities = new List<Team>();
            foreach (var team in teams)
            {
                Team teamEntity= new Team();
                teamEntity.Name = team.Name??"";
                teamEntity.Nationality = team.Nationality ?? "";

                if (!int.TryParse(team.Trophies, out var trophiesCount)||trophiesCount<0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                teamEntity.Trophies = int.Parse(team.Trophies);

                if (!IsValid(teamEntity))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                foreach (var footballer in team.Footballers.Distinct())
                {
                    Footballer? footballerEntity = context.Footballers.Find(footballer);
                    if (footballerEntity==null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                   
                        teamEntity.TeamsFootballers.Add(new TeamFootballer()
                        {
                            Footballer = footballerEntity,
                            FootballerId= footballer
                        });

                  

                }
                teamsEntities.Add(teamEntity); 
                sb.AppendLine(String.Format(SuccessfullyImportedTeam,teamEntity.Name,teamEntity.TeamsFootballers.Count));
            }
            context.Teams.AddRange(teamsEntities);
            context.SaveChanges();
            return sb.ToString();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}

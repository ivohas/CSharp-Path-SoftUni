namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using Trucks.Utilities;

    public class Deserializer
    {

        private static XmlHelper xmlHelper;
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        // Check 
        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            xmlHelper = new XmlHelper();
            StringBuilder sb  = new StringBuilder();

            CreatorDtoImport[] creatorsDto =
                xmlHelper.Deserialize<CreatorDtoImport[]>(xmlString, "Creators");

            List<Creator> validCreators = new List<Creator>();

            foreach (var creatorDto in creatorsDto)
            {
                if (!IsValid(creatorsDto)
                    || creatorDto.LastName.Length>7
                    || creatorDto.FirstName.Length>7
                    || creatorDto.FirstName.Length<2
                    || creatorDto.LastName.Length<2)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Creator validCreator = new Creator { 
                FirstName= creatorDto.FirstName,
                LastName= creatorDto.LastName
                
                };
                List<Boardgame> boardgames = new List<Boardgame>();
                foreach (var boardGame in creatorDto.Boardgames)
                {
                    if (!IsValid(boardGame))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    Boardgame boardgame = new Boardgame { 
                      Name= boardGame.Name,
                      Rating= boardGame.Rating,
                      YearPublished= boardGame.YearPublished,
                      CategoryType = (CategoryType)boardGame.CategoryType,
                      Mechanics= boardGame.Mechanics
                    
                    };
                    boardgames.Add(boardgame);

                }
                validCreator.Boardgames = boardgames;
                validCreators.Add(validCreator);
                sb.AppendLine(String.Format(SuccessfullyImportedCreator, validCreator.FirstName, validCreator.LastName, validCreator.Boardgames.Count()));
              
            
            }

            context.AddRange(validCreators);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            SellerDtoImport[] sellerDtos =
                JsonConvert.DeserializeObject<SellerDtoImport[]>(jsonString);
            List<Seller> validSellers= new List<Seller>();

            ICollection<int> existingGame = context.Boardgames
               .Select(t => t.Id)
               .ToArray();
            foreach (var seller in sellerDtos)
            {
                if (!IsValid(seller))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Seller validSeller = new Seller
                {
                    Name=seller.Name,
                    Address=seller.Address,
                    Country= seller.Country,
                    Website= seller.Website

                };
               
                foreach (var boardGame in seller.Boardgames.Distinct())
                {
                    if (!IsValid(boardGame))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (!existingGame.Contains(boardGame))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    BoardgameSeller bgs = new BoardgameSeller { 
                     BoardgameId= boardGame,
                     Seller= validSeller
                    };
                    validSeller.BoardgamesSellers.Add(bgs);
                }
                validSellers.Add(validSeller);
                sb.AppendLine(String.Format(SuccessfullyImportedSeller, validSeller.Name, validSeller.BoardgamesSellers.Count()));
            }
            context.AddRange(validSellers);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}

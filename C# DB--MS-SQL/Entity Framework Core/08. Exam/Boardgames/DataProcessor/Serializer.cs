namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ExportDto;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using Trucks.Utilities;

    public class Serializer
    {
        private static XmlHelper xmlHealper;
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {

            xmlHealper = new XmlHelper();
            var creators = context.Creators
                .ToArray()
                .Where(c => c.Boardgames.Count() > 1)
                .Select(c => new ExportCreatorDto
                {
                    CreatorName = c.FirstName + " " + c.LastName,
                    BoardgamesCount = c.Boardgames.Count().ToString(),
                    Boardgames = c.Boardgames.Select(b => new BoardGameExportDto
                    {
                        BoardgameName = b.Name,
                        BoardgameYearPublished = b.YearPublished.ToString()

                    }).
                    OrderBy(b => b.BoardgameName)
                    .ToArray()

                }).OrderByDescending(c => c.BoardgamesCount)
                .ThenBy(c => c.CreatorName)
                .ToArray();


            return xmlHealper.Serialize(creators, "Creators").ToString();
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {

            var result = context.Sellers
                .Include(s => s.BoardgamesSellers)
                .ThenInclude(bs => bs.Boardgame)
                .ToArray()
                .Where(s => s.BoardgamesSellers.Count() >= 1)
                .Where(s => s.BoardgamesSellers.Any(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating))
                .Select(s => new
                {
                    Name = s.Name,
                    Website = s.Website,
                    Boardgames = s.BoardgamesSellers
                    .Where(bs=> bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating)                  
                    .Select(bs => new {
                        Name=  bs.Boardgame.Name,
                       Rating = bs.Boardgame.Rating,
                        Mechanics =bs.Boardgame.Mechanics,
                        Category = bs.Boardgame.CategoryType.ToString()
                    })
                    .OrderByDescending(b=> b.Rating)
                    .ThenBy(b=> b.Name)
                    .ToArray()
                }).OrderByDescending(s=> s.Boardgames.Count())
                .ThenBy(s=> s.Name)
                .ToArray()
                .Take(5);


            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }
    }
}
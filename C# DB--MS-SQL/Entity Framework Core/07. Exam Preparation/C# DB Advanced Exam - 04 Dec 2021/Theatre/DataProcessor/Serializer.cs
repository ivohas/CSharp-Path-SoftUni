namespace Theatre.DataProcessor
{
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theaher = context.Theatres
                .ToArray()
                .Where(x => x.Tickets.Count() >= 20
                       && x.NumberOfHalls >= numbersOfHalls)
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets.Where(x => x.RowNumber <= 5).Sum(x => x.Price),
                    Tickets = t.Tickets
                    .Where(t=> t.RowNumber<=5)
                        .Select(tc=> new {
                            Price = tc.Price,
                            RowNumber = tc.RowNumber
                        })
                        .OrderByDescending(x => x.Price)
                        .ToArray()
                })
                .OrderByDescending(t=> t.Halls)
                .ThenBy(t=> t.Name);

            var result = JsonConvert.SerializeObject(theaher, Formatting.Indented);

            return result.Trim();
        }

        public static string ExportPlays(TheatreContext context, double raiting)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ExportPlayDto[]), new XmlRootAttribute("Plays"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (StringWriter stringWriter = new StringWriter(sb))
            {

                var result = context.Plays.Where(x => x.Rating <= raiting)
                .OrderBy(x => x.Title)
                .ThenByDescending(x => x.Genre)
                .Select(x => new ExportPlayDto
                {
                    Title = x.Title,
                    Duration = x.Duration.ToString("c"),
                    Rating = x.Rating == 0 ? "Premier" : x.Rating.ToString(),
                    Genre = x.Genre.ToString(),
                    Actors = x.Casts.Where(x => x.IsMainCharacter)
                    .Select(a => new ExportActorsDto
                    {
                        FullName = a.FullName,
                        MainCharacter = $"Plays main character in '{x.Title}'."
                    })
                    .OrderByDescending(x => x.FullName)
                    .ToArray()
                }).ToArray();


                xmlSerializer.Serialize(stringWriter, result, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}

using System.Text;
namespace StockMarket
{
    public class Stock
    {

        // CompanyName: string
        // Director: string
        //PricePerShare: decimal
        //TotalNumberOfShares: int
        //MarketCapitalization: decimal
        public string CompanyName { get; set; }
        public string Director { get; set; }
        public decimal PricePerShare { get; set; }
        public int TotalNumberOfShares { get; set; }
        public decimal MarketCapitalization { get; set; }

        public Stock(string companyName, string director, decimal pricePerShare, int totalNumberOfShares)
        {
            CompanyName = companyName;
            Director = director;
            PricePerShare = pricePerShare;
            TotalNumberOfShares = totalNumberOfShares;
            MarketCapitalization = TotalNumberOfShares * PricePerShare;
        }

        public override string ToString()
        {

            StringBuilder sr = new StringBuilder();
            sr.AppendLine($"Company: {CompanyName}");
            sr.AppendLine($"Director: {Director}");
            sr.AppendLine($"Price per share: ${PricePerShare}");
            sr.AppendLine($"Market capitalization: ${MarketCapitalization}");
            return sr.ToString();


            // The investor Peter Lynch with a broker Fidelity has stocks: 
            // Company: Tesla // Director: Elon Musk // Price per share: $743.17 
            // Market capitalization: $4845468.40 
            // Company: Twitter
            // Director: Jack Dorsey 
            // Price per share: $59.66 
            // Market capitalization: $668192.00
            // Company: Activision Blizzard
            // Director: Bobby Kotick
            // Price per share: $78.53
            // Market capitalization: $433485.60

        }
    }
}

using System.Collections.Generic;
using System.Text;

namespace StockMarket
{
    public class Investor
    {


        //FullName: string

        //EmailAddress: string

        //MoneyToInvest: decimal

        //BrokerName: string

        public List<Stock> Portfolio { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            Portfolio = new List<Stock>();
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
        }
        //methods
        public int Count()
        {
            return this.Portfolio.Count;
        }
        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization >= 10000 && MoneyToInvest >= stock.PricePerShare)
            {
                this.Portfolio.Add(stock);
                MoneyToInvest -= stock.PricePerShare;
            }

        }
        public string SellStock(string companyName, decimal sellPrice)
        {


           
            foreach (var item in this.Portfolio)
            {
                if ( item.CompanyName==companyName && item.MarketCapitalization == sellPrice)
                {

                    //намирам стоката
                    if (item.MarketCapitalization < item.PricePerShare)
                    {
                        return $"Cannot sell {companyName}.";
                    }
                    else
                    { 
                        Portfolio.Remove(item);
                        MoneyToInvest = +sellPrice;
                        return $"{companyName} was sold.";
                       
                      
                        
                    }

                }

            }
           
            return $"{companyName} does not exist.";
        }
        public Stock FindStock(string companyName)
        {

            foreach (var item in this.Portfolio)
            {
                if (item.CompanyName == companyName)
                {

                    return item;
                }
            }
            return null;
        }
        public Stock FindBiggestCompany()
        {
            if (Portfolio.Count <= 0)
            {
                return null;
            }
            Stock maxCapitalisation = null;
            decimal max = 0m;
            foreach (var item in this.Portfolio)
            {
                if (max < item.MarketCapitalization)
                {
                    max = item.MarketCapitalization;
                    maxCapitalisation = item;
                }
            }
            return maxCapitalisation;



        }
        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            foreach (var item in this.Portfolio)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }


    }
}

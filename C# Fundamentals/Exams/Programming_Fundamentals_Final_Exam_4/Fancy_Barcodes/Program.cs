using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Problem_2___Fancy_Barcodes
{
    class Barcode
    {
        public string Name { get; set; }

        public string Group { get; set; }

        public bool Validity { get; set; }

        public Barcode(string name, string group, bool validity)
        {
            this.Name = name;
            this.Group = group;
            this.Validity = validity;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Barcode> barcodes = new List<Barcode>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string barcodeName = Console.ReadLine();

                Barcode barcode = new Barcode(barcodeName, "", false);


                Regex barcodeValidator = new Regex(@"(\@\#+[A-Z]{1}[A-Za-z0-9]{4,}[A-Z]{1}\@\#+)");

                if (barcodeValidator.Match(barcode.Name).Success)
                {
                    foreach (char ch in barcode.Name)
                    {
                        if (char.IsDigit(ch))
                        {
                            barcode.Group += ch;
                        }
                    }
                    if (barcode.Group == "")
                    {
                        barcode.Group = "00";
                    }
                    barcode.Validity = true;

                    barcodes.Add(barcode);

                    Console.WriteLine($"Product group: {barcode.Group}");
                    continue;
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}

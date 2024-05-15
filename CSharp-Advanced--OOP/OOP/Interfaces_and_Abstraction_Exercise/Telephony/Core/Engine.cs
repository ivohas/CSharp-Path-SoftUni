using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Core
{
    using IO.Interfaces;
    using Models;
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly StationaryPhone stationaryPhone;
        private readonly SmartPhone smartPhone;

        private Engine()
        {
            this.stationaryPhone = new StationaryPhone();
            this.smartPhone = new SmartPhone();
        }
        public Engine(IReader reader, IWriter writer) : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Start()
        {
            string[] phoneNumbers = this.reader
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] urls = this.reader
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string phoneNumber in phoneNumbers)
            {
                if (!this.ValidateNumber(phoneNumber))
                {
                    this.writer.WriteLine("Invalid number!");
                }
                else if (phoneNumber.Length == 10)
                {
                   this.writer.WriteLine(this.smartPhone.Call(phoneNumber));
                }
                else if (phoneNumber.Length == 7)
                {
                    this.writer.WriteLine(this.stationaryPhone.Call(phoneNumber));
                }
            }

            foreach (string url in urls)
            {
                if (!this.ValidateURL(url))
                {
                    this.writer.WriteLine("Invalid URL!");
                }
                else
                {
                    this.writer.WriteLine(this.smartPhone.BrowseURL(url));
                }
            }
        }

        private bool ValidateNumber(string number)
        {
            foreach (char digit in number)
            {
                if (!Char.IsDigit(digit))
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidateURL(string url)
        {
            foreach (char ch in url)
            {
                if (Char.IsDigit(ch))
                {
                    return false;
                }
            }

            return true;
        }
    }
}

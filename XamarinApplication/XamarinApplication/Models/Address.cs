using System;

namespace XamarinApp.Models
{
    public class Address
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public Geo Geo { get; set; }
        
        public override string ToString()
        {
            return $"Street :{Street}" +
                   $"{Environment.NewLine}Suite :{Suite}" +
                   $"{Environment.NewLine}City :{City}" +
                   $"{Environment.NewLine}ZipCode :{ZipCode}" +
                   $"{Environment.NewLine}Geo :{Geo}";
        }

        public override bool Equals(object? obj)
        {
            return ToString() == obj.ToString();
        }

        public override int GetHashCode()
        {
            return ZipCode.GetHashCode();
        }
    }
}
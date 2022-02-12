using System;

namespace XamarinApp.Models
{
    public class Geo
    {
        public string Lat { get; set; }
        public string Lng { get; set; }
        
        public override string ToString()
        {
            return $"Lat :{Lat}" +
                   $"{Environment.NewLine}Lng :{Lng}";
        }

        public override bool Equals(object? obj)
        {
            return ToString() == obj.ToString();
        }

        public override int GetHashCode()
        {
            return Lng.GetHashCode();
        }
    }
}
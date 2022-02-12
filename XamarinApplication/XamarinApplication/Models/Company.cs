using System;

namespace XamarinApp.Models
{
    public class Company
    {
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }
        
        public override string ToString()
        {
            return $"Name :{Name}" +
                   $"{Environment.NewLine}CatchPhrase :{CatchPhrase}" +
                   $"{Environment.NewLine}Bs :{Bs}";
        }

        public override bool Equals(object? obj)
        {
            return ToString() == obj.ToString();
        }

        public override int GetHashCode()
        {
            return Bs.GetHashCode();
        }
    }
}
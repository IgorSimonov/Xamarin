using System;

namespace XamarinApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public string WebSite { get; set; }
        public Company Company { get; set; }
        
        public override string ToString()
        {
            return $"Name :{Name}" +
                   $"{Environment.NewLine}UserName :{UserName}" +
                   $"{Environment.NewLine}Email :{Email}" +
                   $"{Environment.NewLine}Address :{Address}" +
                   $"{Environment.NewLine}Phone :{Phone}" +
                   $"{Environment.NewLine}WebSite :{WebSite}" +
                   $"{Environment.NewLine}Company :{Company}";
        }

        public override bool Equals(object? o)
        {
            return ToString() == o?.ToString();
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
using System;

namespace Flight_Agency.model
{
    public class Employee : Entity<string>
    
    {
        public Employee(string password, string name)
        {
            Password = password;
            Name = name;
        }

        public String Password { get; set; }
        
        public String Name { get; set; }

        public override string ToString()
        {
            return string.Format("[username={0}, password={1}, name={2}", ID, Password, Name);
        }
    }
}
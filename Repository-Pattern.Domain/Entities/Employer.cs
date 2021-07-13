using System;

namespace Repository_Pattern.Domain.Entities
{
    public class Employer
    {
        public Employer() { }
        public Employer( string name, string email, string document)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Document = document;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }

        public void Update(string name, string email, string document)
        {
            Name = name;
            Email = email;
            Document = document;
        }

    }

}

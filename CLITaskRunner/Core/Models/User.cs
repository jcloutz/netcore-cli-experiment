using System;

namespace CLITaskRunner.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public UserAddress UserAddress { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public UserCompany UserCompany { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
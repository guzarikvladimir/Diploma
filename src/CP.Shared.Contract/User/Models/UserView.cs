using System;

namespace CP.Shared.Contract.User.Models
{
    public class UserView
    {
        public Guid Id { get; set; }
        
        public string Password { get; set; }
    }
}
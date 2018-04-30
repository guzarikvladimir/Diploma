﻿using System;
using CP.Shared.Contract.Core.Models;

namespace CP.Shared.Contract.User.Models
{
    public class UserView : IViewWithId<Guid>
    {
        public Guid Id { get; set; }
        
        public string Password { get; set; }
    }
}
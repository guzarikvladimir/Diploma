using System;
using CP.Platform.Crud.Models;

namespace CP.Shared.Contract.User.Models
{
    public class UserModel : IEntityModel<Guid?>
    {
        public Guid? Id { get; set; }

        public string Password { get; set; }
    }
}
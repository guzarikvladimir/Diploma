﻿using CP.Platform.Crud.Services;
using CP.Shared.Contract.User.Models;
using CP.Shared.Contract.User.Services;
using UserEntity = CP.Repository.Models.User;

namespace CP.Shared.User.Services
{
    public class UserModifyingService : 
        SimpleModifyingService<UserEntity, UserModel, UserView>,
        IUserModifyingService
    {
    }
}
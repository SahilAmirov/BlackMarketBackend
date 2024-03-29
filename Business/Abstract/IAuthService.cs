﻿using Core.Entities.DataEntity;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegister userForRegister, string password);
        IDataResult<User> Login(UserForLogin userForLogin);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user, int storeID);

        IResult CheckStoreName(string storeName);
        IResult RegisterStore(string storeName, int userID);

        IDataResult<DataInt> GetStoreIdByUserId(int userID);
    }
}

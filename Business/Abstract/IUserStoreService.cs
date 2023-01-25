﻿using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserStoreService
    {

        IResult CheckStoreId(int id);
        IDataResult<UserStore> GetUserStore(int userID);
    }
}
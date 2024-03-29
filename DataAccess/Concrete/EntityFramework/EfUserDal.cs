﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ContextDb>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user, int StoreID)
        {
            using (var context = new ContextDb())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.ID equals userOperationClaim.ID
                             where userOperationClaim.StoreID == StoreID && userOperationClaim.UserID == user.ID
                             select new OperationClaim
                             {
                                 ID = operationClaim.ID,
                                 Name = operationClaim.Name,
                             };
                return result.ToList();
            }
        }
    }
}

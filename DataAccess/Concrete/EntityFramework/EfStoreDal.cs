using Core.DataAccess.EntityFramework;
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
    public class EfStoreDal : EfEntityRepositoryBase<Store, ContextDb>, IStoreDal
    {
        public void UserStoreAdd(int userID, int storeID)
        {
            using (var context = new ContextDb())
            {
                UserStore userStore = new UserStore()
                {
                    UserID = userID,
                    StoreID = storeID,
                    AddedAt = DateTime.Now,
                    IsActive = true,
                };

                context.UserStores.Add(userStore);
                context.SaveChanges();
            }
        }

    }
}

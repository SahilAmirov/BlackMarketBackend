using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStoreService
    {
        IResult UserStoreAdd(int userID, int storeID);
        IResult CheckStoreName(string storeName);
        IResult AddStore(string storeName);
        IDataResult<Store> GetStoreByName(string storeName);
        IDataResult<Store> GetStoreById(int storeID);
    }
}

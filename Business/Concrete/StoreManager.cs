using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StoreManager: IStoreService
    {
        private readonly IStoreDal _storeDal;

        public StoreManager(IStoreDal storeDal)
        {
            _storeDal = storeDal;
        }



        public IResult AddStore(string storeName)
        {
            Store store = new Store()
            {
                StoreName = storeName,
                StoreAbout = "",
                StorePP = "default",
                AddedAt = DateTime.Now,
                IsActive = true,
            };
            _storeDal.Add(store);
            return new SuccessResult();
        }

        public IResult CheckStoreName(string storeName)
        {
            var result = _storeDal.Get(c => c.StoreName == storeName);

            if (result != null)
            {
                return new ErrorResult(Messages.StoreNameExists);
            }
            return new SuccessResult();
        }

        public IDataResult<Store> GetStoreById(int storeID)
        {
            var result = _storeDal.Get(c => c.ID == storeID);
            if (result != null)
            {
                return new SuccessDataResult<Store>(result);
            }
            return new ErrorDataResult<Store>(Messages.StoreNotFound);
        }

        public IDataResult<Store> GetStoreByName(string storeName)
        {
            var result = _storeDal.Get(c=>c.StoreName== storeName);
            if(result != null)
            {
                return new SuccessDataResult<Store>(result);
            }
            return new ErrorDataResult<Store>(Messages.StoreNotFound);
        }

        public IResult UserStoreAdd(int userID, int storeID)
        {
            _storeDal.UserStoreAdd(userID, storeID);
            return new SuccessResult();
        }
    }
}

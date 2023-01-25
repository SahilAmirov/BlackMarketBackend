using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserStoreManager: IUserStoreService
    {
        private readonly IUserStoreDal _userStoreDal;

        public UserStoreManager(IUserStoreDal userStoreDal)
        {
            _userStoreDal = userStoreDal;
        }



        public IResult CheckStoreId(int id)
        {
            var result = _userStoreDal.Get(c=>c.StoreID== id);
            if (result != null)
            {
                return new ErrorResult(Messages.StoreHasOwner);
            }

            return new SuccessResult();
        }

        public IDataResult<UserStore> GetUserStore(int userID)
        {
            var result = _userStoreDal.Get(c=>c.UserID==userID);

            if (result != null)
            {
                return new SuccessDataResult<UserStore>(result);
            }
            return new ErrorDataResult<UserStore>();
        }
    }
}

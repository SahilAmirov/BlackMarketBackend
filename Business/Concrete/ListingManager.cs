using Business.Abstract;
using Business.BusinessAspects;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Caching;
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
    public class ListingManager: IListingService
    {
        private readonly IListingDal _listingDal;

        public ListingManager(IListingDal listingDal)
        {
            _listingDal = listingDal;
        }

        [SecuredOperation("Listing.Add")]
        //[CacheRemoveAspect("Listing.Get")]
        [ValidationAspect(typeof(ListingValidator))]
        public IResult Add(Listing listing)
        {
            _listingDal.Add(listing);
            return new SuccessResult(Messages.AddedListing);
        }

        public IResult Delete(Listing listing)
        {
            _listingDal.Delete(listing);
            return new SuccessResult(Messages.DeletedListing);
        }

        public IDataResult<Listing> Get(int id)
        {
            return new SuccessDataResult<Listing>(_listingDal.Get(p => p.ID == id));
        }

        [CacheAspect(60)]
        public IDataResult<List<Listing>> GetList(int storeID)
        {
            return new SuccessDataResult<List<Listing>>(_listingDal.GetList(p =>p.StoreID == storeID));
        }

        [ValidationAspect(typeof(ListingValidator))]
        public IResult Update(Listing listing)
        {
            _listingDal.Update(listing);
            return new SuccessResult(Messages.UpdatedListing);
        }
    }
}

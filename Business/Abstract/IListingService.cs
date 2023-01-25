using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IListingService
    {
        IResult Add(Listing listing);
        IResult Update(Listing listing);
        IResult Delete(Listing listing);
        IDataResult<Listing> Get(int id);
        IDataResult<List<Listing>> GetList(int storeID);
    }
}

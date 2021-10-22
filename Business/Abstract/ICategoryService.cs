using Core.Utilities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICategoryService
    {
        IResult Add(Category category);
        IResult Update(Category category);
        IResult Delete(Category category);
        IDataResult<List<Category>> GetAll();
        IDataResult<List<Category>> GetAllOemId(int oemId);
        Category GetCategory(string categoryName , int oemId);
        IDataResult<List<Category>> GetAllByStatusOne();
    }
}

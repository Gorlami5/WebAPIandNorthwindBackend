using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            _categoryDal.add(category);
            return new SuccessResult("Category Added");
        }

        public IDataResult<Category> GetByCategory(int id)
        {
            return new SuccessDataResult<Category>(_categoryDal.GetById(p => p.CategoryID == id));
        }

        public IDataResult<List<Category>> GetList()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll().ToList());
        }
    }
}

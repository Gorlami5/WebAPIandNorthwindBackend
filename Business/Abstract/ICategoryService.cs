using Core.Utilities.Results;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        public IDataResult<List<Category>> GetList();

        public IDataResult<Category> GetByCategory(int id);

        IResult Add(Category category);
    }
}

using Core.Utilities.Results;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        public  IDataResult<List<Product>> GetList();

        public IDataResult<Product> GetByCategory(int id);

        public IDataResult<Product> GetByProductId(int id);

        IResult Add(Product product);

        IResult Delete(Product product);

        IResult Update(Product product);  

    }
}

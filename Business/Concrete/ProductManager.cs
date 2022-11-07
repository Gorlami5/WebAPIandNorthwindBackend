using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {

            _productDal = productDal;   
        }
        public IResult Add(Product product)
        {
                    
            _productDal.add(product);

            return new SuccessResult("Add successfull");
        }

        public IResult Delete(Product product)
        {
            _productDal.delete(product);
            return new SuccessResult("Delete successful");
        }

        public IDataResult<Product> GetByCategory(int id)
        {
            return new SuccessDataResult<Product>(_productDal.GetById(p => p.CategoryID == id));
        }

        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll().ToList());
        }

        public IResult Update(Product product)
        {
           _productDal.update(product);
            return new SuccessResult("Update successful");
        }

        public IDataResult<Product> GetByProductId(int id)
        {
          return new SuccessDataResult<Product>(_productDal.GetById(p => p.ProductID == id));
        }
    }
}

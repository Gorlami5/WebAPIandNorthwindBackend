using Business.Abstract;
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
        public void Add(Product product)
        {
                    
            _productDal.add(product);
        }

        public void Delete(Product product)
        {
            _productDal.delete(product);
        }

        public Product GetByCategory(int id)
        {
            return _productDal.GetById(p=>p.CategoryID == id);
        }

        public List<Product> GetList()
        {
           return _productDal.GetAll().ToList();
        }

        public void Update(Product product)
        {
           _productDal.update(product);
        }

        public Product GetByProductId(int id)
        {
          return  _productDal.GetById(p=>p.ProductID == id );
        }
    }
}

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
        public List<Product> GetList();

        public Product GetByCategory(int id);

        public Product GetByProductId(int id);

        void Add(Product product);

        void Delete(Product product);

        void Update(Product product);  

    }
}

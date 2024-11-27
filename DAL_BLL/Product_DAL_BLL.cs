using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class Product_DAL_BLL
    {
        HighlandCoffeeDataContext hl = new HighlandCoffeeDataContext();
        public Product_DAL_BLL()
        {

        }
        public List<Product> getListProducts()
        {
            return hl.Products.ToList<Product>();
        }
        public Product getProductById(int id)
        {
            return hl.Products.Where(t=>t.ProductId == id).FirstOrDefault();
        }
        public Product getProductByName(string name)
        {
            return hl.Products.Where(t=>t.Name == name).FirstOrDefault();
        }
        public List<Product> getListProductByType(int type_id)
        {
            return hl.Products.Where(t=>t.CategoryId == type_id).ToList<Product>();
        }
    }
}

using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class Type_DAL_BLL
    {
        HighlandCoffeeDataContext hl = new HighlandCoffeeDataContext();
        public Type_DAL_BLL() { }
        public List<Category> getAllTypes()
        {
            return hl.Categories.ToList<Category>();
        }
    }
}

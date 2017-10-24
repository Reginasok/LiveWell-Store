using Project.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace Project.Web.DAL
{ 
    public interface IProductDAL
    {
        List<Product> GetProducts();
        Product GetProduct(int id);
    }
}
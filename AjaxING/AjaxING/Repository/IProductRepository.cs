using AjaxING.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AjaxING.Repository
{
    public interface IProductRepository
    {
        ProductDetails ProductDetails(string userID, string productId);
    }
}

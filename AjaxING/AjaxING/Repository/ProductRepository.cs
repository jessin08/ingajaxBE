using AjaxING.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace AjaxING.Repository
{
    public class ProductRepository : IProductRepository
    {


        public ProductDetails ProductDetails(string userID, string productId)
        {
            ProductDetails objProductdetails = new ProductDetails();
            DBEntities dBEntities = new DBEntities();
            int user = Convert.ToInt32(userID);
            var userDetails = dBEntities.UserProductGroups.FirstOrDefault(m => m.UserId == user);
            objProductdetails.ProductGroupId = userDetails.ProductGroupId.Value;
            objProductdetails.ProductId = Convert.ToInt32(productId);
            int product = Convert.ToInt32(productId);
            var userProduct = dBEntities.UserProducts.Where(m => m.ProductId == product && m.UserId == userDetails.UserId).ToList();
            objProductdetails.UserProductDetails = new List<KeyValuePair<string, string>>();
            objProductdetails.UserProductDetails.Add(new KeyValuePair<string, string>("accountNumber", userProduct.FirstOrDefault().AccountNumber));
            objProductdetails.UserProductDetails.Add(new KeyValuePair<string, string>("balance", userProduct.FirstOrDefault().Balance.ToString()));
            if (userProduct.FirstOrDefault().DebitCardNumber != "")
                objProductdetails.UserProductDetails.Add(new KeyValuePair<string, string>("debitCardNumber", userProduct.FirstOrDefault().DebitCardNumber));

            return objProductdetails;
        }
    }
}
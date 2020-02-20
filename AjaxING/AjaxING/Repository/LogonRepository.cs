using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using AjaxING.Models.Product;


namespace AjaxING.Repository
{
    public class LogonRepository : ILogonRepository
    {
        public LoginData LoginUser(string userID, string password)
        {
            LoginData objLoginData = new LoginData();
            DBEntities dBEntities = new DBEntities();
            var userDetails = dBEntities.UserDetails.FirstOrDefault(m => m.UserName == userID && m.Password == password);
            if(userDetails != null)
            {
                objLoginData.UserType = dBEntities.UserTypes.FirstOrDefault(m=>m.UserTypeId == userDetails.UserType.UserTypeId).TypeName;
                objLoginData.ProductDetails = new List<ProductDetail>();
                var productDetails = dBEntities.UserProductGroups.Where(m => m.UserId == userDetails.UserId);
                foreach(var item in productDetails)
                {
                    var obj = new ProductDetail();
                    obj.ProductGroupId = item.ProductGroupId.Value;
                    obj.ProductGroupName = item.ProductGroup.ProductGroupName;
                    obj.Products = new List<AjaxING.Models.Product.Product>();

                    var userProducts = item.UserProducts.Where(m => m.ProductGroupId == item.ProductGroupId).ToList();
                    foreach(var product in userProducts)
                    {
                        var productItem = new AjaxING.Models.Product.Product();
                        productItem.ProductId = product.ProductId.Value;
                        productItem.ProductName = product.Product.ProductName;
                        obj.Products.Add(productItem);
                    }
                    objLoginData.ProductDetails.Add(obj);
                }
            }
            return objLoginData;
        }
    }
}
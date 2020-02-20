using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace AjaxING.Models.Product
{
    public class ProductGroup
    {
        public int ProductGroupID { get; set; }
        public string ProductName { get; set; }
    }



    public class ProductDetail
    {
        [JsonProperty("productGroupId")]
        public int ProductGroupId { get; set; }

        [JsonProperty("productGroupName")]
        public string ProductGroupName { get; set; }

        [JsonProperty("products")]
        public List<Product> Products { get; set; }
    }

    public class LoginData
    {
        [JsonProperty("userToken")]
        public string UserToken { get; set; }

        [JsonProperty("userType")]
        public string UserType { get; set; }

        [JsonProperty("productDetails")]
        public List<ProductDetail> ProductDetails { get; set; }
    }
}
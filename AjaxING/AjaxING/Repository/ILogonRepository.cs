using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AjaxING.Models.Product;

namespace AjaxING.Repository
{
    public interface ILogonRepository
    {
        LoginData LoginUser(string userID, string password);
    }
}

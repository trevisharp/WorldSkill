using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace back.Controllers
{
    public class HomeController : Controller
    {
    }

    public class testeController : Controller
    {
        [HttpGet]
        public object getTeste(string c, string s)
        {
            using (var context = new BancoEntities())
            {
                var con = context.tbUsuarios.FirstOrDefault(u => u.cpf == c && u.senha == s);
                return con;
            }
        }
    }
}

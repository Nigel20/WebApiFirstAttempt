using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiFirstAttempt.Models;

namespace WebApiFirstAttempt.Controllers
{
    public class ShoppingListController : ApiController
    {
        // GET: api/ShoppingList
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/ShoppingList/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/ShoppingList
        [HttpPost]
        public int Post([FromBody]ShoppingListModel SLM)
        {
            return SLM.DBItems(ShoppingListModel.DBOperation.Insert);
        }

        //// PUT: api/ShoppingList/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/ShoppingList/5
        //public void Delete(int id)
        //{
        //}
    }
}

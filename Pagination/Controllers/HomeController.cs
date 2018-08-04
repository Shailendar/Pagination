using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pagination.Models;
using Pagination.DA;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;

namespace Pagination.Controllers
{
    public class HomeController : Controller
    {
        UserDBContext db = new UserDBContext();
        // GET: Home
        public ActionResult Index(int? page)
        {
            var userList=db.User.Select(m => new UserViewModel 
            { 
                Id = m.Id, 
                FirstName = m.FirstName, 
                LastName = m.LastName, 
                Email = m.Email, 
                Address = m.Address, 
                Phone = m.Phone
            }).ToList();
            int pageSize = 1;
            int pageNumber = (page ?? 1);
            return View(userList.ToPagedList(pageNumber,pageSize));
        }
    }
}
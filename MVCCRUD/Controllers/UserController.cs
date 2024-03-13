using MVCCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCRUD.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserModal> users = UserDAL.UserList();
            return View(users);
        }

        public ActionResult Edit(int id)
        {
            UserModal modal = new UserModal
            {
                Id = id
            };
            modal = UserDAL.GetUser(modal);
            return View(modal);
        }
        [HttpPost]        
        
        public ActionResult Edit(UserModal modal)
        {
            
            modal = UserDAL.GetUser(modal);
            return View(modal);
        }
    }
}
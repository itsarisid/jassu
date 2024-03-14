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

        public ActionResult Create()
        {
            UserModal modal = new UserModal();
            return View(modal);
        }

        [HttpPost]
        public ActionResult Create(UserModal modal)
        {
            UserDAL.Create(modal);
            return View(new UserModal());
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
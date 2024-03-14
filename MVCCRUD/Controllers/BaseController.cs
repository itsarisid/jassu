using MVCCRUD.DAL;
using MVCCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCRUD.Controllers
{
    public class BaseController : Controller
	{
		#region Instance Creation
		/// <summary>
		/// Instance for EmpDAL
		/// </summary>
		private UserDAL _userDAL;
		
		
		public UserDAL UserDAL
		{
			get
			{
				if (_userDAL == null)
				{
                    _userDAL = new UserDAL();
					return _userDAL;
				}
				else
				{
					return _userDAL;
				}
			}
		}

		#endregion
	}
}
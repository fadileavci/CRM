using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace CRM.UI.Filters
{
	public class MyAuthenticationFilter: ActionFilterAttribute,IAuthenticationFilter
	{

		public void OnAuthentication(AuthenticationContext filterContext)
		{
			if (filterContext.HttpContext.Session["Login"] == null)
			{
				filterContext.Result = new RedirectResult("~/Login/LoginHata");
			}
			

		}

		public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
		{
			
		}
	}
}
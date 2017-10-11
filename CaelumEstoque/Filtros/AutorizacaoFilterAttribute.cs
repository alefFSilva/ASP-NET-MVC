﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CaelumEstoque.Filtros
{
    public class AutorizacaoFilterAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object usuario = filterContext.HttpContext.Session["UsuarioLogado"];
            if (usuario == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(
                                new { action = "Index", Controller = "Login" }));
            }
        }

    }
}
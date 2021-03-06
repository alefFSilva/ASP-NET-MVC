﻿using CaelumEstoque.DAO;
using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autenticar(string login, string senha)
        {
            UsuariosDAO dao = new UsuariosDAO();
            Usuario user = dao.Busca(login, senha);

            if(user != null)
            {
                Session["UsuarioLogado"] = user;
                Session["UsuarioNome"] = user.Nome;
                return RedirectToAction("Index", "Produtos");
            }
            else
            {
                return RedirectToAction("index");
            }
        }

    }
}
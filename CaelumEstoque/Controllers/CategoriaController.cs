using CaelumEstoque.DAO;
using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            CategoriasDAO cartegoriadao = new CategoriasDAO();
            IList<CategoriaDoProduto> categorias = cartegoriadao.Lista();
            ViewBag.categorias = categorias;
            return View();
        }


        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(CategoriaDoProduto categoria)
        {
            CategoriasDAO cDAO = new CategoriasDAO();
            cDAO.Adiciona(categoria);

            return RedirectToAction("Index");
        }

    }
}
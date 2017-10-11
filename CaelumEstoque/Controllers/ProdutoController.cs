using CaelumEstoque.DAO;
using CaelumEstoque.Filtros;
using CaelumEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaelumEstoque.Controllers
{
    [AutorizacaoFilter]
    public class ProdutoController : Controller
    {
        // GET: Produto
        [Route("produtos", Name = "ListaProdutos")]
        public ActionResult Index()
        {
            ProdutosDAO produtodao = new ProdutosDAO();
            IList<Produto> produtos = produtodao.Lista();

            return View(produtos);
        }

        [Route("produtos/Form", Name ="CadastroProduto")]
        public ActionResult Form()
        {
            CategoriasDAO cDAO = new CategoriasDAO();
            ViewBag.produto = new Produto();
            IList<CategoriaDoProduto> categorias = cDAO.Lista();
            ViewBag.categorias = categorias;
            return View();
        }

        [ValidateAntiForgeryToken]
       [HttpPost]
        public ActionResult Adiciona(Produto produto)
        {
            int idInformatica = 1;
            if(produto.CategoriaId.Equals(idInformatica) && produto.Preco < 100)
            {
                ModelState.AddModelError("produto.precoInformaticaInvalido", "O preço para o produto de informática é abaixo de 100");
            }

            if (ModelState.IsValid)
            {
                ProdutosDAO  pDAO = new ProdutosDAO();
                pDAO.Adiciona(produto);

                return RedirectToAction("Index", "Produto");
            }
            else
            {
                ViewBag.produto = produto;
                CategoriasDAO categoria = new CategoriasDAO();
                ViewBag.categorias = categoria.Lista();
                
                return View("Form");
            }

          

            

        }

   
        [Route("produtos/{id}",Name ="VisualizaProduto")]
        public ActionResult Visualiza(int id)
        {
            ProdutosDAO pDao = new ProdutosDAO();
            Produto produto = pDao.BuscaPorId(id);
            ViewBag.produto = produto;

            return View(produto);
        }

        public ActionResult DecrementaQtd(int id)
        {
            ProdutosDAO dao = new ProdutosDAO();
            Produto produto = dao.BuscaPorId(id);
            produto.Quantidade--;
            dao.Atualiza(produto);

            return Json(produto);

        }

    }
}
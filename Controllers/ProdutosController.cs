using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Mapping.ByCode.Impl;
using System.Diagnostics;
using Triade.Models;
using Web.Models;
using Web.Repositories;

namespace Web
{
    public class ProdutosController : Controller
    {
        private readonly ProdutoRepository _produtoRepository;
        public ProdutosController(NHibernate.ISession session) => _produtoRepository = new ProdutoRepository(session);
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _produtoRepository.GetAll() });
        }

        public async Task<IActionResult> Detail(int id)
        {
            return View(await _produtoRepository.GetOne(id));
        }
        
        public IActionResult Create()
        {
            return View(new Produtos());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Produtos produto)
        {
            produto.Created = DateTime.Now;
            produto.Updated = DateTime.Now;

            if (ModelState.IsValid)
            {
                await _produtoRepository.Add(produto);

                return Json(new { success = true, message = "Adicionado com Sucesso" });
            }

            return Json(new { success = false, message = "Falha ao adicionar. Verifique os campos!" });
        }
        
        public async Task<IActionResult> Editar(int id)
        {
            return View(await _produtoRepository.GetOne(id));
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Produtos produto)
        {
            if (ModelState.IsValid)
            {
                produto.Updated = DateTime.Now;
                await _produtoRepository.Update(produto);

                return Json(new { success = true, message = "Atualizado com Sucesso" });
            }

            return Json(new { success = false, message = "Falha ao adicionar. Verifique os campos!" });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _produtoRepository.Remove(id);
            return Json(new { success = true, message = "Deletado com Sucesso" });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

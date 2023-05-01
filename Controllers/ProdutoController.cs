using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Web.Repositories;

namespace Web
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoRepository _produtoRepository;
        public ProdutoController(NHibernate.ISession session) => _produtoRepository = new ProdutoRepository(session);
        
        public IActionResult Index()
        {
            var test = _produtoRepository.GetAll();
            return View(test);
        }
        
        public async Task<IActionResult> Detail(int id)
        {
            Produtos produto = await _produtoRepository.GetOne(id);
            return View(produto);
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produtos produto)
        {
            if (ModelState.IsValid)
            {
                await _produtoRepository.Add(produto);
                return RedirectToAction("Index");
            }

            return View(produto);
        }
        
        public async Task<IActionResult> Update(int id)
        {
            Produtos produto = await _produtoRepository.GetOne(id);
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Produtos produto)
        {
            if (ModelState.IsValid)
            {
                await _produtoRepository.Add(produto);
                return RedirectToAction("Index");
            }

            return View(produto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _produtoRepository.Remove(id);
            return RedirectToAction("Index");
        }
    }
}

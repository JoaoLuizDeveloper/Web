using Microsoft.AspNetCore.Mvc;
using Web.Repositories;

namespace Web
{
    public class HomeController : Controller
    {
        private readonly ProdutoRepository _produtoRepository;
        public HomeController(NHibernate.ISession session) => _produtoRepository = new ProdutoRepository(session);

        public IActionResult Index()
        {
            var test = _produtoRepository.GetAll();
            return View(test);
        }
    }
}

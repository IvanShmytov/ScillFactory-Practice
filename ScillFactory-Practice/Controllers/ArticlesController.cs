using Microsoft.AspNetCore.Mvc;
using ScillFactory_Practice.Models.Db;
using System.Threading.Tasks;

namespace ScillFactory_Practice.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IRepository<Article> _repo;

        public ArticlesController(IRepository<Article> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var articles = await _repo.GetAll();
            return View(articles);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Article newArticle)
        {
            await _repo.Add(newArticle);
            return View(newArticle);
        }
        [HttpGet]
        public async Task<IActionResult> GetArticleById(int id)
        {
            var article = await _repo.Get(id);
            return View(article);
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var article = await _repo.Get(id);
            await _repo.Delete(article);
            return RedirectToAction("Index", "Articles");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var article = await _repo.Get(id);
            return View(article);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmUpdating(Article article)
        {
            await _repo.Update(article);
            return RedirectToAction("Index", "Articles");
        }
    }
}

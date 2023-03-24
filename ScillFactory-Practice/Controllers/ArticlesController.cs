using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using ScillFactory_Practice.Models.Db;
using System.Threading.Tasks;

namespace ScillFactory_Practice.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IRepository<Article> _repo;
        private readonly ILogger<ArticlesController> _logger;

        public ArticlesController(IRepository<Article> repo, ILogger<ArticlesController> logger)
        {
            _repo = repo;
            _logger = logger; 
            _logger.LogDebug(1, "NLog injected into ArtController");
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var articles = await _repo.GetAll();
            _logger.LogInformation("ArticlesController - Index");
            return View(articles);
        }
        [HttpGet]
        public IActionResult Add()
        {
            _logger.LogInformation("ArticlesController - Add");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Article newArticle)
        {
            await _repo.Add(newArticle);
            _logger.LogInformation("ArticlesController - Add - complete");
            return View(newArticle);
        }
        [HttpGet]
        public async Task<IActionResult> GetArticleById(int id)
        {
            var article = await _repo.Get(id);
            _logger.LogInformation("ArticlesController - GetArticleById");
            return View(article);
        }

        [HttpGet]
        public IActionResult Delete()
        {
            _logger.LogInformation("ArticlesController - Delete");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var article = await _repo.Get(id);
            await _repo.Delete(article);
            _logger.LogInformation("ArticlesController - Delete - complete");
            return RedirectToAction("Index", "Articles");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var article = await _repo.Get(id);
            _logger.LogInformation("ArticlesController - Update");
            return View(article);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmUpdating(Article article)
        {
            await _repo.Update(article);
            _logger.LogInformation("ArticlesController - Update - complete");
            return RedirectToAction("Index", "Articles");
        }
    }
}

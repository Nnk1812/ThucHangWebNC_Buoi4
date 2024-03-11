using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ThucHangWebNC_Buoi4.Models;

namespace ThucHangWebNC_Buoi4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private DBBook _dBBook {  get; set; }

        public HomeController(ILogger<HomeController> logger, DBBook dBBook)
        {
            _logger = logger;
            this._dBBook = dBBook;
        }
        public IActionResult Views()
        {
            List<Book> books = this._dBBook.view().ToList();
            return View(books);
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("/Index/add")]
        public ActionResult addbook([FromBody]Book data)
        {
            if(ModelState.IsValid)
            {
                this._dBBook.addbook(data.sBookname, data.sAuthor, data.iYearPub, data.iNoOfPages);
                return RedirectToAction("Views");
            }
            return View("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

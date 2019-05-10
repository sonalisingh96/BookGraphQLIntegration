using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebClient.Client;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookHttp _httpClient;
        private readonly BookGraph _productGraphClient;
        public HomeController(BookHttp httpClient,
            BookGraph productGraphClient)
        {
            _httpClient = httpClient;
            _productGraphClient = productGraphClient;
        }
        public async Task<IActionResult> Index()
        {
            var responseModel = await _httpClient.GetBooks();
            responseModel.ThrowErrors();
            return View(responseModel.Data.Book);
        }

        public async Task<IActionResult> BookDetail(string bookIsbn)
        {
            var book = await _productGraphClient.GetBookByIsbn(bookIsbn);
            return View(book);
        }

        public IActionResult AddBook(string isbn)
        {
            return View(new BookModel { Isbn = isbn });
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(BookInputModel reviewModel)
        {
            await _productGraphClient.AddBook(reviewModel);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteBook(string isbn)
        {
            return View(new BookModel { Isbn = isbn });
        }
        [HttpPost]
        public async Task<IActionResult> DeleteBook(BookInputModel reviewModel)
        {
            await _productGraphClient.DeleteBook(reviewModel);
            return RedirectToAction("Index");
        }
       
      
    }
}

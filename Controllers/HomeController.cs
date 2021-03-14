using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Data.Contracts;
using UrlShortener.Services;

namespace UrlShortener.Controllers
{
    public class HomeController : Controller
    {
        private readonly IShortenedUrlsRepository _shortenedUrlsRepository;
        private readonly IShortenedUrlService _shortenedUrlService;

        public HomeController(IShortenedUrlService shortenedUrlService, IShortenedUrlsRepository shortenedUrlsRepository)
        {
            _shortenedUrlService = shortenedUrlService;
            _shortenedUrlsRepository = shortenedUrlsRepository;
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> Index(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View("Index", string.Empty);
            }
            
            var url = await _shortenedUrlService.GetExistingUrlByShortenedUrl(id);

            if (string.IsNullOrEmpty(url))
            {
                return RedirectToAction("Index", string.Empty);
            }

            return RedirectPermanent(url);
        }

        [HttpPost]
        public async Task<IActionResult> Index(Uri url)
        {
            var shortenedUrl = await _shortenedUrlService.GetShortenedUrl(url.ToString());
            return View("Index", shortenedUrl);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var list = await _shortenedUrlsRepository.GetAll();
            return View("List", list.ToList());
        }
    }
}
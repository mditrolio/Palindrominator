namespace Palindrominator.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using Models;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index(PalindromeModel model)
        {
            if (!string.IsNullOrWhiteSpace(model.Value))
            {
                model.Result = IsPalindrome(model.Value);
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        private static bool IsPalindrome(string value)
        {
            var startIndex = 0;
            var endIndex = value.Length - 1;
            var stopIndex = value.Length / 2;

            while (startIndex <= stopIndex)
            {
                if (value[startIndex] != value[endIndex])
                {
                    return false;
                }

                startIndex++;
                endIndex--;
            }

            return true;
        }
    }
}
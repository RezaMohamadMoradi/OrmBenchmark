using Microsoft.AspNetCore.Mvc;
using OrmBenchmark.Models;
using OrmBenchmark.Repository.Interface;
using System.Diagnostics;

namespace OrmBenchmark.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEfcoreRepository efcoreRepository;
        private readonly IDapperRepository dapperRepository;

        public HomeController(ILogger<HomeController> logger,IEfcoreRepository efcore, IDapperRepository dapperRepository)
        {
            _logger = logger;
            efcoreRepository = efcore;
            this.dapperRepository = dapperRepository;
        }

        public IActionResult Index()
        {
            return View();
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
        public IActionResult createwithEF()
        {
            var sw = Stopwatch.StartNew();
            Product product = new Product()
            {
                Name = "test"
            };
            efcoreRepository.create(product);
            sw.Stop();
            ViewBag.time = sw.ElapsedMilliseconds;
            return View();
        }
        public IActionResult createwithdapper()
        {
            var sw = Stopwatch.StartNew();
            Product product = new Product()
            {
                Name = "test"
            };
            dapperRepository.crate(product);
            sw.Stop();
            ViewBag.time = sw.ElapsedMilliseconds;
            return View();
        }
        public IActionResult readwithdapper()
        {
            var sw = Stopwatch.StartNew();
            
            dapperRepository.readall();
            sw.Stop();
            ViewBag.time = sw.ElapsedMilliseconds;
            return View();
        }
        public IActionResult readwithEF()
        {
            var sw = Stopwatch.StartNew();
          
            efcoreRepository.GetAll();
            sw.Stop();
            ViewBag.time = sw.ElapsedMilliseconds;
            return View();
        }
    }
}

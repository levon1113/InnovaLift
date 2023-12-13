using InnovaLift.Data;
using InnovaLift.Data.Entities;
using InnovaLift.Models;
using Microsoft.AspNetCore.Mvc;
using SendMail;
using System.Diagnostics;
using Service = SendMail.Service;

namespace InnovaLift.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly Service _service;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, Service service)
        {
            _logger = logger;
            _context = context;
            _service = service;
        }

        public IActionResult Index()
        {
            var texts = _context.Texts.ToList();
            var works = _context.Works.ToList();
            var partners = _context.Partners.ToList();
            var images = _context.Images.ToList();
            ViewBag.Texts = texts;
            ViewBag.Works= works;
            ViewBag.Partners= partners;
            ViewBag.Images = images;
                
            return View(texts);
        }
        public IActionResult Equipment()
        {
            var equipments = _context.Equipments.ToList();
            ViewBag.Equipments = equipments;
            var texts = _context.Texts.ToList();
            var images = _context.Images.ToList();
            ViewBag.Texts = texts;
            ViewBag.Images = images;
            return View();
        }

        public IActionResult Services()
        {
            var services = _context.Services.ToList();
            ViewBag.Services = services;
            var texts = _context.Texts.ToList();
            var images = _context.Images.ToList();
            ViewBag.Texts = texts;
            ViewBag.Images = images;
            return View();
        }

        public IActionResult DownloadPdf(int id)
        {
            var service = _context.Services.Find(id);

            if (service == null || service.Pdf == null)
            {
                return NotFound();
            }

            return File(service.Pdf, "application/pdf", $"{service.Name}.pdf");
        }

        public IActionResult Contacts()
        {
            var texts = _context.Texts.ToList();
            var images = _context.Images.ToList();
            ViewBag.Texts = texts;
            ViewBag.Images = images;

            return View();
        }

        public IActionResult SendEmail(EmailModel Model)
        {
            _service.SendEmail(Model);
            return RedirectToAction("Contacts");
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
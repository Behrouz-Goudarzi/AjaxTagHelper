using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AjaxTagHelper.Models;

namespace AjaxTagHelper.Controllers
{
    public class HomeController : Controller
    {
        private readonly AjaxTagheplerContext _dbContext;
        public HomeController(AjaxTagheplerContext persons)
        {
            _dbContext = persons;
            if (!_dbContext.Person.Any())
            {
                _dbContext.Person.Add(
                new PersonModel { Name = "Behrouz", Family = "Goudarzi", Email = "Behrouz.Goudarzi@Outlook.com" }
            );
                _dbContext.SaveChanges();
            }

        }
        public IActionResult Index()
        {

            return View(_dbContext.Person.ToList());
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var person = _dbContext.Person.FirstOrDefault(m => m.Id == id);
            _dbContext.Person.Remove(person ?? throw new ArgumentException("No Person"));
            _dbContext.SaveChanges();
            return new JsonResult(new { id = person.Id, Message = "Delete person=> " + person.FullName });
        }


        [HttpPost]
        public IActionResult Create(PersonModel model)
        {

            _dbContext.Person.Add(model);
            _dbContext.SaveChanges();
            return PartialView("_CreatePersonPartial", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

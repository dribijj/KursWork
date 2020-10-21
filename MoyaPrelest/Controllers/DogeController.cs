using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoyaPrelest.Mocks;
using MoyaPrelest.Models;

namespace MoyaPrelest.Controllers
{
    public class DogeController : Controller
    {

        [Route("")]
        public IActionResult TitlePage()
        {
            ViewBag.Title = "Title page";
            return View();
        }

        public IActionResult List()
        {
            return View(Startup.dm.dogs);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Add(string Breed, string Name, int Age, string Gender, string OwnersAddress)
        {
            Startup.dm.AddtoDataBase(new DogeModel { Breed = Breed, Name = Name, Age = Convert.ToInt32(Age), Gender = Gender, OwnersAddress = OwnersAddress });
            Startup.dm.LoadDataBase();
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Delete(string Name)
        {
            return View(Startup.dm.dogs.Find(t => t.Name == Name));
        }

        [HttpPost]
        public RedirectToActionResult Delete(string Name, bool isAgreed)
        {
            if (isAgreed)
            {
                Startup.dm.DeleteFromDataBase(Name);
                Startup.dm.LoadDataBase();
            }
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Edit(string Name)
        {
            DogeModel dog = Startup.dm.dogs.Find(t => t.Name == Name);
            return View(dog);
        }

        [HttpPost]
        public RedirectToActionResult Edit(string Name, string Breed, string NewName, int Age, string Gender, string OwnersAddress)
        {
            DogeModel dog = Startup.dm.dogs.Find(t => t.Name == Name);
            dog.Breed = Breed;
            dog.Name = NewName;
            dog.Age = Convert.ToInt32(Age);
            dog.Gender = Gender;
            dog.OwnersAddress = OwnersAddress;
            Startup.dm.SaveDataBase();
            Startup.dm.LoadDataBase();
            return RedirectToAction("List");
        }

        public IActionResult BreedGrouping()
        {
            return View(Startup.dm.BreedType());
        }
        [HttpPost]
        public RedirectToActionResult BreedGrouping(string SelectedBreed)
        {
            return RedirectToAction("BreedGroupingResult", new { PassSelectedBreed = SelectedBreed });
        }

        public IActionResult BreedGroupingResult(string PassSelectedBreed)
        {
            return View(Startup.dm.BreedGrouping(PassSelectedBreed));
        }

        public IActionResult AverageAge()
        {
            return View(Startup.dm.BreedType());
        }

        [HttpPost]
        public RedirectToActionResult AverageAge(string SelectedBreed)
        {
            return RedirectToAction("AverageAgeResult", new { PassSelectedBreed = SelectedBreed });
        }

        public IActionResult AverageAgeResult(string PassSelectedBreed)
        {
            return View(Startup.dm.BreedAverageAge(PassSelectedBreed));
        }

        public IActionResult AgeRanking()
        {
            return View(Startup.dm.BreedType());
        }

        [HttpPost]
        public RedirectToActionResult AgeRanking(string SelectedBreed)
        {
            return RedirectToAction("AgeRankingResult", new { PassSelectedBreed = SelectedBreed });
        }

        public IActionResult AgeRankingResult(string PassSelectedBreed)
        {
            return View(Startup.dm.AgeRanking(PassSelectedBreed));
        }
    }
}

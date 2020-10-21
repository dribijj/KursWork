using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace MoyaPrelest.Controllers
{
    public class DiagramController : Controller
    {
        public IActionResult BreedDiagramSelection()
        {
            return View(Startup.dm.BreedType());
        }

        [HttpPost]
        public RedirectToActionResult BreedDiagramSelection(string SelectedBreed)
        {
            using (StreamWriter sw = new StreamWriter("buf.txt"))
            {
                sw.Write(SelectedBreed);
            }
            return RedirectToAction("BreedDiagram", new { PassSelectedBreed = SelectedBreed });
        }

        public IActionResult BreedDiagram(string PassSelectedBreed)
        {
            ViewBag.breed = PassSelectedBreed;
            return View();
        }

        [HttpGet]
        public JsonResult AgeGroupQuantityDiagram()
        {
            string breed;
            using (StreamReader sr = new StreamReader("buf.txt"))
            {
                breed = sr.ReadToEnd().Trim();
            }
            return Json(Startup.dm.AgeGroupQuantityDiagramData(breed));
        }
        public IActionResult GenderSelection()
        {
            return View();
        }
        [HttpPost]
        public RedirectToActionResult GenderSelection(string selectedGender)
        {
            using (StreamWriter sw = new StreamWriter("buf.txt"))
            {
                sw.Write(selectedGender);
            }
            return RedirectToAction("GenderSelectionDiagram");
        }
        public IActionResult GenderSelectionDiagram()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GenderGroupQuantityDiagram()
        {
            string gender;
            using (StreamReader sr = new StreamReader("buf.txt"))
            {
                gender = sr.ReadToEnd().Trim();
            }
            return Json(Startup.dm.GenderGroupQuantityDiagramData(gender));
        }
        public IActionResult AllBreedDiagram()
        {
            return View();
        }
        [HttpGet]
        public JsonResult BreedQuantityDiagram()
        {
            return Json(Startup.dm.BreedGroupQuantityDiagramData());
        }
    }
}

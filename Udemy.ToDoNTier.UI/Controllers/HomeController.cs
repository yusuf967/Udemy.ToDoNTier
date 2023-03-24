using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Udemy.ToDoNTier.Business.Interfaces;
using Udemy.ToDoNTier.Common.ResponseObjects;
using Udemy.ToDoNTier.Dtos.WorkDtos;

namespace Udemy.ToDoNTier.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkService _workService;
        public HomeController(IWorkService workService)
        {
            this._workService = workService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var workList = await _workService.GetAll();
            return View(workList.Data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new WorkCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkCreateDto workCreateDto)
        {
            var response = await _workService.Create(workCreateDto);
            if (response.ResponseType == ResponseType.ValidationError)
            {
                foreach (var error in response.customValidatorErrors)
                {
                    ModelState.AddModelError(error.PropertyType, error.ErrorMessage);
                }
                return View(workCreateDto);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var response = await _workService.GetById<WorkUpdateDto>(id);
            if (response.ResponseType == ResponseType.NotFound)
                return NotFound();
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(WorkUpdateDto workUpdateDto)
        {
            var response = await _workService.Update(workUpdateDto);
            if (response.ResponseType == ResponseType.ValidationError)
            {
                foreach (var error in response.customValidatorErrors)
                {
                    ModelState.AddModelError(error.PropertyType, error.ErrorMessage);
                }
                return View(workUpdateDto);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {

            var response=await _workService.Remove(id);
            if(response.ResponseType == ResponseType.NotFound)
                return NotFound();
            return RedirectToAction("Index");
        }

        public async IActionResult NotFound(int code)
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Udemy.ToDoNTier.Business.Interfaces;
using Udemy.ToDoNTier.Common.ResponseObjects;
using Udemy.ToDoNTier.Dtos.WorkDtos;
using Udemy.ToDoNTier.UI.Extensions;

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
            return this.ResponseRedirectToAction(response, "Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var response = await _workService.GetById<WorkUpdateDto>(id);
            return this.ResponseView(response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(WorkUpdateDto workUpdateDto)
        {
            var response = await _workService.Update(workUpdateDto);
            return this.ResponseRedirectToAction(response, "Index");
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            var response = await _workService.Remove(id);
            return this.ResponseRedirectToAction(response, "Index");
        }

        public IActionResult NotFound(int code)
        {
            return View();
        }
    }
}

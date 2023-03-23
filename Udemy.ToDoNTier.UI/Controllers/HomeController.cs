﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Udemy.ToDoNTier.Business.Interfaces;
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
            return View(workList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new WorkCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkCreateDto workCreateDto)
        {
            await _workService.Create(workCreateDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            return View(await _workService.GetById<WorkUpdateDto>(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(WorkUpdateDto workUpdateDto)
        {
            await _workService.Update(workUpdateDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {

            await _workService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}

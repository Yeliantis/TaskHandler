using MetersReader.Data;
using MetersReader.Models;
using MetersReader.Services;
using MetersReader.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace MetersReader.Controllers
{
    public class UserTaskController : Controller
    {
        private readonly ITaskService _taskService;
        public UserTaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        public async Task<IActionResult> Index()
        {
            var tasks = await _taskService.GetAllTaskAsync();
            var result = tasks.Where(x=>x.isDone==false).ToList();
            return View(result);
        }

        public  IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserTask task) //Пофиксить ошибку - свойство Description почему-то Required
        {
            if (task.Name==task.Description)
            {
                ModelState.AddModelError("taskNameError", "Название задачи и её описание не могу совпадать");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    await _taskService.CreateTaskAsync(task);
                    return RedirectToAction("Index");
                }
                

            }
            return View(task);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id==null || id==0)
            {
                return NotFound();
            }
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserTask task)
        {
            if (task.Name==task.Description)
            {
                ModelState.AddModelError("name", "Название и описание задачи не могут быть одинаковыми");
            }
           if (ModelState.IsValid)
            {
               await _taskService.UpdateTaskAsync(task);
                return RedirectToAction("Index");
            }
            return View(task);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _taskService.DeleteTaskAsync(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CompleteTask(int id)
        {
            var task = await _taskService.CompleteTaskAsync(id);
            return RedirectToAction("Index");
        }
    }
}

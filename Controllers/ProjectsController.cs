using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_management.Data;
using Project_management.Models;


namespace Project_management.Controllers
{
    [Authorize] 
    public class ProjectsController : Controller
    {

        private ApplicationDbContext context;


        public ProjectsController(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return View(context.Projects.ToList());
        }

        [BindProperty]
        public Project? project { get; set; }

        public IActionResult Details(int id)
        {
            var project = context.Projects.FirstOrDefault(t => t.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            var associatedTickets = context.Tickets.Where(t => t.ProjectId == project.Id).ToList();
            
            project.Tickets = associatedTickets;

            return View(project);
        }


        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Add(Project project)
        {
            context.Projects.Add(project);
            context.SaveChanges();
            ViewBag.Count = context.Projects.Count();
            ViewBag.Projects = context.Projects.ToList();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var project = context.Projects.FirstOrDefault(t => t.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }


        public IActionResult Edit(Project project)
        {
            var oproject = context.Projects.FirstOrDefault(t => t.Id == project.Id);
            if (oproject == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                oproject.Name = project.Name;
                
                
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(oproject);
        }

         public IActionResult Delete(int id)
    {
        var project = context.Projects.FirstOrDefault(t => t.Id == id);
        if (project == null)
        {
            return NotFound();
        }
        return View(project);
    }


        [HttpPost]
    public IActionResult DeleteConfirm(int id)
    {
        var project = context.Projects.FirstOrDefault(t => t.Id == id);
        if (project == null)
        {
            return NotFound();
        }
        context.Projects.Remove(project);
        context.SaveChanges();
        return RedirectToAction("Index");
    }
}
}

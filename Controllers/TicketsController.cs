using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project_management.Data;
using Project_management.Models;


namespace Project_management.Controllers;

    [Authorize] 
    public class TicketsController : Controller
    {

        private ApplicationDbContext context;


        public TicketsController(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return View(context.Tickets.ToList());
        }

        [BindProperty]
        public Ticket? ticket { get; set; }

        public IActionResult Details(int id)
        {
            var tickets = context.Tickets.FirstOrDefault(t => t.Id == id);
            if (tickets == null)
            {
                return NotFound();
            }

            return View(tickets);
        }

        public IActionResult Create()
        {
            var users = context.Users.ToList();
            Console.WriteLine(users.Count);
            foreach (var u in users)
            {
                Console.WriteLine(u.Email);
                
            }
            ViewBag.Projects = context.Projects.ToList();
            return View();
        }

        public IActionResult Add(Ticket ticket)
        {
            Console.WriteLine(ticket.ProjectId);
            context.Tickets.Add(ticket);
            context.SaveChanges();
            ViewBag.Count = context.Tickets.Count();
            ViewBag.Projects = context.Tickets.ToList();
            return RedirectToAction("Index");
        }


public IActionResult Update(int id)
{
    var ticket = context.Tickets.FirstOrDefault(t => t.Id == id);
    if (ticket == null)
    {
        return NotFound();
    }
    return View(ticket);
}


public IActionResult Edit(Ticket ticket)
{
    var oticket = context.Tickets.FirstOrDefault(t => t.Id == ticket.Id);
    
    if (oticket == null)
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        oticket.Title = ticket.Title;
        oticket.Status = ticket.Status;
        
        context.SaveChanges();
        return RedirectToAction("Index");
    }

    return View(oticket);
}


         public IActionResult Delete(int id)
    {
        var ticket = context.Tickets.FirstOrDefault(t => t.Id == id);
        if (ticket == null)
        {
            return NotFound();
        }
        return View(ticket);
    }


        [HttpPost]
    public IActionResult DeleteConfirm(int id)
    {
        var ticket = context.Tickets.FirstOrDefault(t => t.Id == id);
        if (ticket == null)
        {
            return NotFound();
        }
        context.Tickets.Remove(ticket);
        context.SaveChanges();
        return RedirectToAction("Index");
    }
}


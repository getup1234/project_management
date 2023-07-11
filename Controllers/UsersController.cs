using Microsoft.AspNetCore.Mvc;
using Project_management.Data;
using Microsoft.AspNetCore.Authorization;

/**********************/
using Microsoft.AspNetCore.Identity;




namespace Project_management.Controllers

{
    [Authorize] 
    public class UsersController : Controller

    {

        private readonly ApplicationDbContext _context;




        public UsersController(ApplicationDbContext context)

        {

            _context = context;

        }




        public IActionResult Index()

        {

            return View(_context.Users.ToList());

        }




        public IActionResult Create()

        {

            return View();

        }

        /************************************************/
     

        [HttpPost]
        public IActionResult Add(IdentityUser user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        public IActionResult Edit(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult Update(IdentityUser user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Update(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        public IActionResult Delete(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }

}
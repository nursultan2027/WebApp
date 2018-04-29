using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employee.ToListAsync());
        }
        
        public IActionResult IndexClient(bool Chbx1, bool Chbx2, bool Chbx3, bool Chbx4, bool Chbx5,string searchString)
        {
            ViewBag.Count = _context.Employee.Count();
            var courses = from c in _context.Employee
                            select c;
            if(!string.IsNullOrEmpty(searchString))
            {
               courses = courses.Where(c=> c.Name.Contains(searchString)||c.Category.Contains(searchString)||c.Discription.Contains(searchString));
            }
            if(!Chbx5)
            {
                if(Chbx1)
                {
                    courses = courses.Where(c=> c.Category == "Офис");
                    
                }
                else {
                    if (Chbx2)
                    {
                            courses = courses.Where(c=> c.Category == "Ремонт дома" );
                    }
                    else
                    {
                        if (Chbx3)
                        {
                            courses = courses.Where(c=> c.Category == "Авто");
                        }
                    }
                }
            }    
            else
            {
                courses = from c in _context.Employee
                            select c;
            }
            return View(courses);
        }
        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employees = await _context.Employee
                .SingleOrDefaultAsync(m => m.Id == id);
            if (employees == null)
            {
                return NotFound();
            }

            return View(employees);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Discription,Category,TelNumber,ImgRes,Price,Owner")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employees);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Redirect("/Employees/IndexClient");
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employees = await _context.Employee.SingleOrDefaultAsync(m => m.Id == id);
            if (employees == null)
            {
                return NotFound();
            }
            return View(employees);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Discription,Category,TelNumber,ImgRes,Price")] Employees employees)
        {
            if (id != employees.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employees);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeesExists(employees.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employees);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employees = await _context.Employee
                .SingleOrDefaultAsync(m => m.Id == id);
            if (employees == null)
            {
                return NotFound();
            }

            return View(employees);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employees = await _context.Employee.SingleOrDefaultAsync(m => m.Id == id);
            _context.Employee.Remove(employees);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeesExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }
    }
}

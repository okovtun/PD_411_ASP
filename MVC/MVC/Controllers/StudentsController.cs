using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly MVCContext _context;

        public StudentsController(MVCContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
			ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
			ViewData["DateSortParam"] = sortOrder == "Date" ? "date_desc" : "Date";
			ViewData["CurrentFilter"] = searchString;

			IQueryable<Student> students = from s in _context.Students select s;
			if (!String.IsNullOrEmpty(searchString))
				students = students.Where(s => s.LastName.Contains(searchString) || s.FirstName.Contains(searchString));
			switch (sortOrder)
			{
				default:			students = students.OrderBy(s => s.LastName);					break;
				case "name_desc":	students = students.OrderByDescending(s => s.LastName);			break;
				case "date_desc":	students = students.OrderByDescending(s => s.EnrollmentDate);	break;
				case "Date":		students = students.OrderBy(s => s.EnrollmentDate);				break;
			}

            return View(students);
            //return View(await _context.Students.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
				.Include(s => s.Enrollments)
					.ThenInclude(e => e.Course)
				.AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LastName,FirstName,EnrollmentDate")] Student student)
        {
			try
			{
				if (ModelState.IsValid)
				{
					_context.Add(student);
					await _context.SaveChangesAsync();
					return RedirectToAction(nameof(Index));
				}
			}
			catch (Exception ex)
			{
				ModelState.AddModelError
					(
					"",
					"Невозможно сохранить изменения, обратитесь к системному администратору"
					);
			}
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

		// POST: Students/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost, ActionName("Edit")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditPost(int? id)
		{ 
			if(id == null) return NotFound();
			Student student = await _context.Students.FirstOrDefaultAsync(s => s.ID == id);

			bool success = await TryUpdateModelAsync<Student>
				(
				student,
				"",
				s => s.FirstName, s => s.LastName, student => student.EnrollmentDate
				);
			if (success)
			{
				try
				{
					await _context.SaveChangesAsync();
					return RedirectToAction(nameof(Details), new { id = id });
				}
				catch (Exception ex)
				{
					ModelState.AddModelError("", ex.Message);
				}
			}

			return View(student);
		}
        /*public async Task<IActionResult> Edit(int id, [Bind("ID,LastName,FirstName,EnrollmentDate")] Student student)
        {
            if (id != student.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.ID))
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
            return View(student);
        }*/

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
				.AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }
			if (saveChangesError.GetValueOrDefault())
				ViewData["ErrorMessage"] = "Что-то пошло не так, обратитесь к системному администратору";
            return View(student);
        }

		// POST: Students/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{ 
			Student student = await _context.Students.FindAsync(id);
			if(student == null)return RedirectToAction(nameof(Index));

			try
			{
				_context.Students.Remove(student);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
			}
		}
        /*public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }*/

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.ID == id);
        }
    }
}

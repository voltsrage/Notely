using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NotelyApp.Models;
using NotelyApp.Repository;

namespace NotelyApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly INoteRepository np;

        public HomeController(INoteRepository Np)
        {
            this.np = Np;
        }

        public IActionResult Index()
        {
           var notes = np.GetAllNotes().Where(n=>n.IsDeleted == false);
            return View(notes);
        }

        public IActionResult NoteDetail(Guid id)
        {
            Note note = np.FindNoteById(id);
            return View(note);
        }

        public IActionResult NoteEditor(Guid Id = default)
        {
            if(Id != null)
            {
                var note = np.FindNoteById(Id);
                return View(note);
            }
          
            return View();
            
        }

        [HttpPost]
        public IActionResult NoteEditor(Note note)
        {
            
            if(ModelState.IsValid)
            {
                var date = DateTime.Now;

                if (note != null && note.NoteID == Guid.Empty)
                {
                    note.NoteID = Guid.NewGuid();
                    note.CreatedDate = date;
                    note.LastModifiedDate = date;

                    np.SaveNote(note);
                }
                else
                {
                    var note2 = np.FindNoteById(note.NoteID);
                    note2.LastModifiedDate = date;
                    note2.Subject = note.Subject;
                    note2.Detail = note.Detail;
                }

                return RedirectToAction("Thanks");
            }
            else
            {
                return View();
            }
        }

        public IActionResult DeleteNote(Guid Id)
        {
            var note = np.FindNoteById(Id);
            note.IsDeleted = true;
            return RedirectToAction("Index");
        }

        public IActionResult Thanks(Guid Id)
        {
            var note = np.FindNoteById(Id);
            return View(note);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

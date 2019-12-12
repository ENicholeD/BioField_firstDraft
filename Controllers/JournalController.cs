using Microsoft.AspNetCore.Mvc;
using BioField.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Net;

namespace BioField.Controllers
{
    public class JournalsController : Controller
    {
        private readonly BioFieldContext _db;

        public JournalsController(BioFieldContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Journals> model = _db.Journals.ToList();
            return View(model);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Journals journal)
        {
            _db.Journals.Add(journal);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Info(int id)
        {
            var thisJournal = _db.Journals
            .Include(journal => journal.Entries)
            .ThenInclude(join => join.Entries)
            .FirstOrDefault(journal => journal.JournalId == id);
            Console.WriteLine(thisJournal);
            return View(thisJournal);
        }

        public ActionResult Edit(int id)
        {
            var thisJournal = _db.Journals.FirstOrDefault(journal => journal.JournalId == id);
            return View(thisJournal);
        }
        [HttpPost]
        public ActionResult Edit(JournalsController journal)
        {
                _db.Entry(journal).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var thisJournal = _db.Journals
             .FirstOrDefault(journal => journal.JournalId == id);
            return View(thisJournal);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisJournal = _db.Journals.FirstOrDefault(journal => journal.JournalId == id);
            _db.Journals.Remove(thisJournal);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
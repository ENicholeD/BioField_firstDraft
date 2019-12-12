using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BioField.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;

namespace BioField.Controllers
{
    public class EntriesController : Controller
    {
        private readonly BioFieldContext _db;

        public EntriesController(BioFieldContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            List<Entries> model = _db.Entries.ToList();
            return View(model);
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.JournalId = new SelectList(_db.Journals, "JournalId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Entries entry)
        {
            _db.Entries.Add(entry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [HttpGet("/entry/info/{id}")]
        public ActionResult Info(int id)
        {
            var thisEntry = _db.Entries
            .FirstOrDefault(entry => entry.EntryId == id);
            return View(thisEntry);
        }
    public ActionResult Edit(int id)
    {
        var thisEntry = _db.Entries.FirstOrDefault(entry => entry.EntryId == id);
        ViewBag.JournalId = new SelectList(_db.Journals, "JournalId", "Name");
        return View(thisEntry);
    }
    [HttpPost]
    public ActionResult Edit(Entries entry)
    {
        _db.Entry(entry).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
        public ActionResult Delete(int id)
        {
            var thisEntry = _db.Entries.FirstOrDefault(entry => entry.EntryId == id);
            return View(thisEntry);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisEntry = _db.Entries.FirstOrDefault(entry => entry.EntryId == id);
            _db.Entries.Remove(thisEntry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
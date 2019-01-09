using Dogs.Entities;
using Dogs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dogs.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            DogsDbContext context = new DogsDbContext();
            List<Dog> items = context.Dogs.ToList();
            return View(items);
        }

        public ActionResult Delete(int id)
        {
            DogsDbContext context = new DogsDbContext();
            Dog item = context.Dogs.Where(d => d.Id == id).FirstOrDefault();
            context.Dogs.Remove(item);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            DogsDbContext context = new DogsDbContext();
            Dog item = null;
            if (id == null)
            {
                item = new Dog();
            }
            else
            {
                item = context.Dogs.Where(d => d.Id == id.Value).FirstOrDefault();
            }
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(Dog item)
        {
            DogsDbContext context = new DogsDbContext();
            if (item.Age > 100)
            {
                return View(item);
            }
            int count = context.Dogs
                .Where(d => d.Type == item.Type && d.Id != item.Id)
                .Count();
            if (item.Id <= 0)
            {
                context.Dogs.Add(item);
            }
            else
            {
                context.Entry(item).State = System.Data.Entity.EntityState.Modified;
            }

            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class DetailsController : Controller
    {
        ApplicationDbContext context;

        public DetailsController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Details/index
        public ActionResult Index()
        {
            if (Session["email"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            string my_email = Session["email"].ToString();

            List<Details> all_details_in_db = context.Details.ToList();
            List<Details> my_details = new List<Details>();

            foreach (Details singleDetail in all_details_in_db)
            {
                if (singleDetail.UserId == my_email)
                {
                    my_details.Add(singleDetail);
                }
            }

            return View(my_details);
        }

        // GET: /Details/Create
        public ActionResult Create()
        {
            return View(new Details());
        }

        // POST: /Details/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Details model)
        {
            if (ModelState.IsValid)
            {
                model.UserId = Session["email"].ToString();
                context.Details.Add(model);
                await context.SaveChangesAsync();
                return RedirectToAction("/index");
            }
            return View();
        }

        // GET: Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Details model = context.Details.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // Post: Details/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Url,Email,Password,Description,UserId")] Details model)
        {
            if(ModelState.IsValid)
            {
                context.Entry(model).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("/index");
            }
            return View(model);
        }


        // GET: Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                
            }
            Details model = context.Details.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // Post: Details/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Details model = context.Details.Find(id);
            context.Details.Remove(model);
            context.SaveChanges();
            return RedirectToAction("/index");
        }




    }
}
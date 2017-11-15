using System;
using System.Collections.Generic;
using System.Linq;
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
        // GET: Deatils
        public ActionResult Index()
        {
            if (Session["email"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            string my_email = Session["email"].ToString();

            List<Details> all_details_in_db = context.Details.ToList();
            List<Details> my_details = new List<Details>();

            foreach(Details singleDetail in all_details_in_db)
            {
                if(singleDetail.UserId == my_email)
                {
                    my_details.Add(singleDetail);
                }
            }

            return View(my_details);
        }

        public ActionResult Create()
        {
            return View(new Details());
        }

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

    }
}
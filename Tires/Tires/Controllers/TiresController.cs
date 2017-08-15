using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tires.Models;

namespace Tires.Controllers
{
    public class TiresController : Controller
    {
        // GET: Tires
        [HttpGet]
        public ActionResult Index()
        {
            using (TireDBContext ctx = new TireDBContext())
            {
                List<Tire> tires = ctx.Tires.ToList();
                return View(tires);

            }
        }

        public ActionResult Purchase(int id)
        {
            Purchase model = new Purchase();
            model.TireId = id;
            if (ModelState.IsValid)
            {
                using (TireDBContext ctx = new TireDBContext())
                {
                    Tire t = ctx.Tires.Single(ss => ss.TireId == id);
                    char ch = t.Number[0]; // assumes label is not empty; get first character of string
                    if(ch != '/')
                    {
                        --ch; // increment; use -- to decrement instead
                        t.Number = ch.ToString(); // back to string                   
                        ctx.Purchases.Add(model);
                        ctx.SaveChanges();
                        List<Tire> tires = ctx.Tires.ToList();
                        return View("Index", tires);
                    }
                    return new HttpStatusCodeResult(403);


                }

            }
            return new HttpStatusCodeResult(403);
           

        }

        [HttpGet]
        public ActionResult Search()
        {
            using(TireDBContext ctx = new TireDBContext())
            {
                List<string> heights = new List<string>();
                List<string> weights = new List<string>();
                List<string> diameters = new List<string>();
                List<string> types = new List<string>();
                List<string> brands = new List<string>();

                List<Category> categories = ctx.Categories.ToList();
                ViewBag.categories = categories;
                List<Tire> tires = ctx.Tires.ToList();
                foreach( var item in tires)
                {
                    heights.Add(item.TireHeight);
                    weights.Add(item.TireWeight);
                    diameters.Add(item.TireDiameter);
                    types.Add(item.TireType);
                    brands.Add(item.Brand);
                }
                List<string> uniqueH = heights.Distinct().ToList();
                List<string> uniqueW = weights.Distinct().ToList();
                List<string> uniqueD = diameters.Distinct().ToList();
                List<string> uniqueT = types.Distinct().ToList();
                List<string> uniqueB = brands.Distinct().ToList();

                ViewBag.diameters = uniqueD;
                ViewBag.heights = uniqueH;
                ViewBag.weights = uniqueW;
                ViewBag.types = uniqueT;
                ViewBag.brands = uniqueB;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Search( Search model)
        {
            using (TireDBContext ctx = new TireDBContext())
            {
                IEnumerable<Tire> tires = ctx.Tires.ToList();
                if (model.Brand != null)
                {
                    tires = tires.Where(t => t.Brand == model.Brand).ToList();
                }
                if (model.TireDiameter != null)
                {
                    tires = tires.Where(t => t.TireDiameter == model.TireDiameter).ToList();
                }
                if (model.TireHeight != null)
                {
                    tires = tires.Where(t => t.TireHeight == model.TireHeight).ToList();
                }
                if (model.TireWeight != null)
                {
                    tires = tires.Where(t => t.TireWeight == model.TireWeight).ToList();
                }
                if (model.TireType != null)
                {
                    tires = tires.Where(t => t.TireType == model.TireType).ToList();
                }
                if (model.CategoryId != null)
                {
                    tires = tires.Where(t => t.CategoryId == model.CategoryId).ToList();
                }

                return View("Index", tires);
            }
        }
       
    }
}
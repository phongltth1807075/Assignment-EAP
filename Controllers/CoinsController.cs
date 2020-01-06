using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment_EAP_Coin.Models;

namespace Assignment_EAP_Coin.Controllers
{
    public class CoinsController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Coins
        public ActionResult Index(string search,string MarketId, string currentFilter)
        {

            //var coins = db.Coins.Include(c => c.Market);
            //return View(coins.ToList());
            if (search == null)
            {
                search = currentFilter;
            }

            ViewBag.CurrentFilter = search;

            var coins = db.Coins.Where(s => s.Status!= Coin.CoinStatus.Deleted);

            if (!String.IsNullOrEmpty(search))
            {
                coins = coins.Where(s => s.CoinName.Contains(search));
            }

            ViewBag.MarketID = new SelectList(db.Markets, "Id", "Name", MarketId);
            if (String.IsNullOrEmpty(MarketId))
            {
                return View(coins.ToList());
            }
                
            var id = (int?)Convert.ToInt32(MarketId);

            //coins = coins.Where(x => x.MarketId.MarketId == id);

            return View(coins.ToList());
        }

        // GET: Coins/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coin coin = db.Coins.Find(id);
            if (coin == null)
            {
                return HttpNotFound();
            }
            return View(coin);
        }

        // GET: Coins/Create
        public ActionResult Create()
        {
            ViewBag.MarketId = new SelectList(db.Markets, "MarketId", "MarketName");
            return View();
        }

        // POST: Coins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CoinId,CoinName,BaseAsset,QuoteAsset,LastPrice,Volumn24h,MarketId")] Coin coin)
        {
            if (ModelState.IsValid)
            {
                
                db.Coins.Add(coin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MarketId = new SelectList(db.Markets, "MarketId", "MarketName", coin.MarketId);
            return View(coin);
        }

        // GET: Coins/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coin coin = db.Coins.Find(id);
            if (coin == null)
            {
                return HttpNotFound();
            }
            ViewBag.MarketId = new SelectList(db.Markets, "MarketId", "MarketName", coin.MarketId);
            return View(coin);
        }

        // POST: Coins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CoinId,CoinName,BaseAsset,QuoteAsset,LastPrice,Volumn24h,MarketId")] Coin coin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MarketId = new SelectList(db.Markets, "MarketId", "MarketName", coin.MarketId);
            return View(coin);
        }

        // GET: Coins/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coin coin = db.Coins.Find(id);
            if (coin == null)
            {
                return HttpNotFound();
            }
            return View(coin);
        }

        // POST: Coins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Coin coin = db.Coins.Find(id);
            db.Coins.Remove(coin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

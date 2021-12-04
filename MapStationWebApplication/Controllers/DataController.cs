using Newtonsoft.Json;
using StationShowApplication.Models;
using StationShowApplication.Models.Bots.Restaurant;
using StationShowApplication.Models.Bots.Stations;
using StationShowApplication.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StationShowApplication.Controllers
{
    public class DataController : Controller
    {
        private StationDb db = new StationDb();
        public ActionResult TurkiyePetrolIstasyonlari()
        {
            return View(TurkiyePetrol.getData());
        }
        public ActionResult BpIstasyonlari()
        {
            Bp.getFuelPriceList();
            return View(Bp.getData());
        }
        public ActionResult ShellStation()
        {
            return View(Shell.getData());
        }
        public ActionResult Burger()
        {
            return View(BurgerKing.getData());
        }

        public ActionResult TurkiyePetrolStationFuelPrice()
        {
            TurkiyePetrol.getFuelPrice();
            return View(db.FuelPrice.Where(x => x.fuelTypeId == 1).ToList());
        }

        public void PointBotUpdateTable()
        {
            var pointTypeIds = db.StationType.ToList();
            for (int i = 0; i < pointTypeIds.Count; i++)
            {
                PointBotUpdateTable p = new PointBotUpdateTable();
                var pointGroup = db.DataStation.Where(x => x.stationTypeId == pointTypeIds[i].stationTypeId);
                
            }
        }

    }

    public class PointBotUpdateTable{
        public string name { get; set; }
        public string updateDate { get; set; }
        public string link { get; set; }

    }
}
using EntityLayer.SqlQuery;
using EntityLayer;
using KargoTakipApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

namespace KargoTakipApp.Controllers
{
    public class InterfaceController : Controller
    {

        public ActionResult Takip()
        {
            List<Orders> orders = GetOrders();
            return View();
        }


        public ActionResult Details()
        {
           
            return View();
        }

        [HttpGet]
        public ActionResult Datas(Orders order)
        {
            string ORDER_FNUM = TempData["ORDER_FNUM"] as string;

            if (string.IsNullOrEmpty(ORDER_FNUM))
            {
                return RedirectToAction("Search");
            }

            var fulldataResult = MvcDbHelper.Repository.GetFnumDetails<Alls>(QueryWareHouse.Alls.GetFnumDetails, new { ORDER_FNUM = ORDER_FNUM }).ToList();
           var date = fulldataResult[0].ORDER_CREATE_DATE.ToString();
            TempData.Clear();
          
            try
            {
                var data = new
                {
                    DataList = fulldataResult,
                    DateValue = date
                };

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Search(Orders order)
        {
            Debug.WriteLine(order.ORDER_FNUM);

            
            List<Orders> orders = GetOrders();

            //elemanların içini kontrol ediliyor
            List<string> orderFnums = orders.Select(o => o.ORDER_FNUM).ToList();

            if (!orderFnums.Contains(order.ORDER_FNUM))
            {
                ViewBag.ErrorMessage = "Aradığınız sipariş bulunamadı.";
                return Json(new { redirect = false, message = "Aradığınız sipariş bulunamadı." });
            }
            else
            {
                TempData["ORDER_FNUM"] = order.ORDER_FNUM;
                return Json(new { redirect = true });
            }
        }

       

        public List<Senders> GetSenders()
        {
            var senderResault = MvcDbHelper.Repository.GetAll<Senders>(QueryWareHouse.Senders.GetAll).ToList();
            return senderResault;
        }

        public List<Receivers> GetReceivers()
        {
            var receiverResault = MvcDbHelper.Repository.GetAll<Receivers>(QueryWareHouse.Receviers.GetAll).ToList();
            return receiverResault;
        }

        public List<Cargos> GetCargos()
        {
            var cargoResault = MvcDbHelper.Repository.GetAll<Cargos>(QueryWareHouse.Cargos.GetAll).ToList();
            return cargoResault;
        }

        public List<Orders> GetOrders()
        {
            var orderResult = MvcDbHelper.Repository.GetAll<Orders>(QueryWareHouse.Orders.GetAll).ToList();
            return orderResult;
        }



        [HttpGet]
        public ActionResult GetCities()
        {
            var citiesResult = MvcDbHelper.Repository.GetAll<Cities>(QueryWareHouse.Cities.GetAll).ToList();
            return Json(citiesResult, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult GetDistricts(int SehirId)
        {
            var districtResault = MvcDbHelper.Repository.GetById<Districts>(QueryWareHouse.Districts.GetById, new { Id = SehirId }).ToList();
            return Json(districtResault, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetNeighbors(int ilceId)
        {
            var neighborResault = MvcDbHelper.Repository.GetById<Neighbors>(QueryWareHouse.Neighbors.GetById, new { Id = ilceId }).ToList();
            return Json(neighborResault, JsonRequestBehavior.AllowGet);
        }


    }
}
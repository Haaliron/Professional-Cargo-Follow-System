using Dapper;
using EntityLayer;
using EntityLayer.SqlQuery;
using KargoTakipApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace KargoTakipApp.Controllers
{
    public class AdminController : Controller
    {

        //private readonly string connectionString = "Data Source=HALIRON\\SQLEXPRESS;Initial Catalog=KargoTakipSQL;Integrated Security=True;";

        //[HttpPost]
        //public ActionResult CreateOrder(FormCollection form)
        //{
        //    var radioDatas = new { radio1 = form["options1"], radio2 = form["receiveroptions1"] };
        //    if (radioDatas.radio1 == "option1" && radioDatas.radio2 == "receiveroption1")
        //    {
        //        //Bireysel-Bireysel
        //        var deliveryType = new { deliveryType = form["deliveryType"] };
        //        if (deliveryType.deliveryType == "eve")
        //        {
        //            //senderOffice Şimdilik kaydedilmiyor

        //            var senderParameters = new { senderTC = form["senderTC"], senderPhone = form["senderPhone"], senderName = form["senderName"], senderSurname = form["senderSurname"], senderCity = form["senderCity"], senderDistrict = form["senderDistrict"], senderNeighborhood = form["senderNeighborhood"], senderAdress = form["senderAdress"], senderOffice = form["senderOffice"] };
        //            var cargoParameters = new { cargoWidth = form["cargoWidth"], cargoSize = form["cargoSize"], cargoHeight = form["cargoHeight"], cargoWeight = form["cargoWeight"], cargoDesi = form["desiBox"], cargoPrice = form["priceBox"], payType = form["payType"] };
        //            var receiverParameters = new { receiverTC = form["receiverTC"], receiverPhone = form["receiverPhone"], receiverName = form["receiverName"], receiverSurname = form["receiverSurname"], receiverCity = form["receiverCity"], receiverDistrict = form["receiverDistrict"], receiverNeighborhood = form["receiverNeighborhood"], receiverAdress = form["receiverAdress"] };
        //            string senderInfos = "INSERT INTO CUSTOMERS (CUSTOMER_TC, CUSTOMER_PHONE, CUSTOMER_NAME, CUSTOMER_SURNAME, CUSTOMER_CITY, CUSTOMER_DISTRICT, CUSTOMER_NEIGHBOR, CUSTOMER_ADRESS) VALUES  (@senderTC, @senderPhone, @senderName, @senderSurname, @senderCity, @senderDistrict, @senderNeighborhood, @senderAdress)";
        //            string cargoInfos = "INSERT INTO CARGOINFOS (CARGO_WIDTH, CARGO_SIZE, CARGO_HEIGHT, CARGO_WEIGHT, CARGO_DESI, CARGO_PRICE,PAY_TYPE) VALUES  (@cargoWidth, @cargoSize, @cargoHeight, @cargoWeight, @cargoDesi, @cargoPrice, @payType)";
        //            string receiverInfos = "INSERT INTO CUSTOMERS (CUSTOMER_TC, CUSTOMER_PHONE, CUSTOMER_NAME, CUSTOMER_SURNAME, CUSTOMER_CITY, CUSTOMER_DISTRICT, CUSTOMER_NEIGHBOR, CUSTOMER_ADRESS) VALUES  (@receiverTC, @receiverPhone, @receiverName, @receiverSurname, @receiverCity, @receiverDistrict, @receiverNeighborhood, @receiverAdress)";
        //            using (IDbConnection connection = new SqlConnection(connectionString))
        //            {
        //                connection.Open();
        //                connection.Query(senderInfos, senderParameters);
        //                connection.Query(cargoInfos, cargoParameters);
        //                connection.Query(receiverInfos, receiverParameters);
        //                connection.Close();
        //            }
        //        }
        //        else if (deliveryType.deliveryType == "subeden")
        //        {
        //            //senderOffice Şimdilik kaydedilmiyor
        //            var senderParameters = new { senderTC = form["senderTC"], senderPhone = form["senderPhone"], senderName = form["senderName"], senderSurname = form["senderSurname"], senderCity = form["senderCity"], senderDistrict = form["senderDistrict"], senderNeighborhood = form["senderNeighborhood"], senderAdress = form["senderAdress"], senderOffice = form["senderOffice"] };
        //            var cargoParameters = new { cargoWidth = form["cargoWidth"], cargoSize = form["cargoSize"], cargoHeight = form["cargoHeight"], cargoWeight = form["cargoWeight"], cargoDesi = form["desiBox"], cargoPrice = form["priceBox"], payType = form["payType"] };
        //            var receiverParameters = new { receiverTC = form["receiverTC"], receiverPhone = form["receiverPhone"], receiverName = form["receiverName"], receiverSurname = form["receiverSurname"], receiverCity = form["receiverCity"], receiverDistrict = form["receiverDistrict"], receiverNeighborhood = form["receiverNeighborhood"] };
        //            string senderInfos = "INSERT INTO CUSTOMERS (CUSTOMER_TC, CUSTOMER_PHONE, CUSTOMER_NAME, CUSTOMER_SURNAME, CUSTOMER_CITY, CUSTOMER_DISTRICT, CUSTOMER_NEIGHBOR, CUSTOMER_ADRESS) VALUES  (@senderTC, @senderPhone, @senderName, @senderSurname, @senderCity, @senderDistrict, @senderNeighborhood, @senderAdress)";
        //            string cargoInfos = "INSERT INTO CARGOINFOS (CARGO_WIDTH, CARGO_SIZE, CARGO_HEIGHT, CARGO_WEIGHT, CARGO_DESI, CARGO_PRICE,PAY_TYPE) VALUES  (@cargoWidth, @cargoSize, @cargoHeight, @cargoWeight, @cargoDesi, @cargoPrice, @payType)";
        //            string receiverInfos = "INSERT INTO CUSTOMERS (CUSTOMER_TC, CUSTOMER_PHONE, CUSTOMER_NAME, CUSTOMER_SURNAME, CUSTOMER_CITY, CUSTOMER_DISTRICT, CUSTOMER_NEIGHBOR, CUSTOMER_ADRESS) VALUES  (@receiverTC, @receiverPhone, @receiverName, @receiverSurname, @receiverCity, @receiverDistrict, @receiverNeighborhood,NULL)";
        //            using (IDbConnection connection = new SqlConnection(connectionString))
        //            {
        //                connection.Open();
        //                connection.Query(senderInfos, senderParameters);
        //                connection.Query(cargoInfos, cargoParameters);
        //                connection.Query(receiverInfos, receiverParameters);
        //                connection.Close();
        //            }
        //        }
        //    }

        //    if (radioDatas.radio1 == "option1" && radioDatas.radio2 == "receiveroption2")
        //    {
        //        //Bireysel-Kurumsal
        //        var deliveryType = new { deliveryType = form["deliveryType"] };
        //        if (deliveryType.deliveryType == "eve")
        //        {
        //            //senderOffice Şimdilik kaydedilmiyor
        //            var senderParameters = new { senderTC = form["senderTC"], senderPhone = form["senderPhone"], senderName = form["senderName"], senderSurname = form["senderSurname"], senderCity = form["senderCity"], senderDistrict = form["senderDistrict"], senderNeighborhood = form["senderNeighborhood"], senderAdress = form["senderAdress"], senderOffice = form["senderOffice"] };
        //            var cargoParameters = new { cargoWidth = form["cargoWidth"], cargoSize = form["cargoSize"], cargoHeight = form["cargoHeight"], cargoWeight = form["cargoWeight"], cargoDesi = form["desiBox"], cargoPrice = form["priceBox"], payType = form["payType"] };
        //            var receiverParameters = new { receiverCompanyTax = form["receiverCompanyTax"], receiverCompanyPhone = form["receiverCompanyPhone"], receiverCompanyName = form["receiverCompanyName"], receiverCompanyCity = form["receiverCompanyCity"], receiverCompanyDistrict = form["receiverCompanyDistrict"], receiverNeighborhoodCompany = form["receiverNeighborhoodCompany"], receiverCompanyAdress = form["receiverCompanyAdress"] };
        //            string senderInfos = "INSERT INTO CUSTOMERS (CUSTOMER_TC, CUSTOMER_PHONE, CUSTOMER_NAME, CUSTOMER_SURNAME, CUSTOMER_CITY, CUSTOMER_DISTRICT, CUSTOMER_NEIGHBOR, CUSTOMER_ADRESS) VALUES  (@senderTC, @senderPhone, @senderName, @senderSurname, @senderCity, @senderDistrict, @senderNeighborhood, @senderAdress)";
        //            string cargoInfos = "INSERT INTO CARGOINFOS (CARGO_WIDTH, CARGO_SIZE, CARGO_HEIGHT, CARGO_WEIGHT, CARGO_DESI, CARGO_PRICE,PAY_TYPE) VALUES  (@cargoWidth, @cargoSize, @cargoHeight, @cargoWeight, @cargoDesi, @cargoPrice, @payType)";
        //            string receiverInfos = "INSERT INTO CUSTOMERCOMPANYS (C_CUSTOMER_TAX, C_CUSTOMER_PHONE, C_CUSTOMER_NAME, C_CUSTOMER_CITY, C_CUSTOMER_DISTRICT,C_CUSTOMER_NEIGHBOR,C_CUSTOMER_ADRESS) VALUES (@receiverCompanyTax, @receiverCompanyPhone, @receiverCompanyName, @receiverCompanyCity, @receiverCompanyDistrict, @receiverNeighborhoodCompany, @receiverCompanyAdress)";
        //            using (IDbConnection connection = new SqlConnection(connectionString))
        //            {
        //                connection.Open();
        //                connection.Query(senderInfos, senderParameters);
        //                connection.Query(cargoInfos, cargoParameters);
        //                connection.Query(receiverInfos, receiverParameters);
        //                connection.Close();
        //            }
        //        }
        //        else if (deliveryType.deliveryType == "subeden")
        //        {
        //            //senderOffice Şimdilik kaydedilmiyor
        //            var senderParameters = new { senderTC = form["senderTC"], senderPhone = form["senderPhone"], senderName = form["senderName"], senderSurname = form["senderSurname"], senderCity = form["senderCity"], senderDistrict = form["senderDistrict"], senderNeighborhood = form["senderNeighborhood"], senderAdress = form["senderAdress"], senderOffice = form["senderOffice"] };
        //            var cargoParameters = new { cargoWidth = form["cargoWidth"], cargoSize = form["cargoSize"], cargoHeight = form["cargoHeight"], cargoWeight = form["cargoWeight"], cargoDesi = form["desiBox"], cargoPrice = form["priceBox"], payType = form["payType"] };
        //            var receiverParameters = new { receiverCompanyTax = form["receiverCompanyTax"], receiverCompanyPhone = form["receiverCompanyPhone"], receiverCompanyName = form["receiverCompanyName"], receiverCompanyCity = form["receiverCompanyCity"], receiverCompanyDistrict = form["receiverCompanyDistrict"], receiverNeighborhoodCompany = form["receiverNeighborhoodCompany"], receiverCompanyAdress = form["receiverCompanyAdress"] };
        //            string senderInfos = "INSERT INTO CUSTOMERS (CUSTOMER_TC, CUSTOMER_PHONE, CUSTOMER_NAME, CUSTOMER_SURNAME, CUSTOMER_CITY, CUSTOMER_DISTRICT, CUSTOMER_NEIGHBOR, CUSTOMER_ADRESS) VALUES  (@senderTC, @senderPhone, @senderName, @senderSurname, @senderCity, @senderDistrict, @senderNeighborhood, @senderAdress)";
        //            string cargoInfos = "INSERT INTO CARGOINFOS (CARGO_WIDTH, CARGO_SIZE, CARGO_HEIGHT, CARGO_WEIGHT, CARGO_DESI, CARGO_PRICE,PAY_TYPE) VALUES  (@cargoWidth, @cargoSize, @cargoHeight, @cargoWeight, @cargoDesi, @cargoPrice, @payType)";
        //            string receiverInfos = "INSERT INTO CUSTOMERCOMPANYS (C_CUSTOMER_TAX, C_CUSTOMER_PHONE, C_CUSTOMER_NAME, C_CUSTOMER_CITY, C_CUSTOMER_DISTRICT,C_CUSTOMER_NEIGHBOR,C_CUSTOMER_ADRESS) VALUES (@receiverCompanyTax, @receiverCompanyPhone, @receiverCompanyName, @receiverCompanyCity, @receiverCompanyDistrict, @receiverNeighborhoodCompany, NULL)";
        //            using (IDbConnection connection = new SqlConnection(connectionString))
        //            {
        //                connection.Open();
        //                connection.Query(senderInfos, senderParameters);
        //                connection.Query(cargoInfos, cargoParameters);
        //                connection.Query(receiverInfos, receiverParameters);
        //                connection.Close();
        //            }
        //        }
        //    }

        //    else if (radioDatas.radio1 == "option2" && radioDatas.radio2 == "receiveroption1")
        //    {
        //        //Kurumsal-Bireysel
        //        var deliveryType = new { deliveryType = form["deliveryType"] };
        //        if (deliveryType.deliveryType == "eve")
        //        {
        //            //senderOffice Şimdilik kaydedilmiyor
        //            var senderParameters = new { senderCompanyTax = form["senderCompanyTax"], senderCompanyPhone = form["senderCompanyPhone"], senderCompanyName = form["senderCompanyName"], senderCompanyCity = form["senderCompanyCity"], senderCompanyDistrict = form["senderCompanyDistrict"], senderNeighborhoodCompany = form["senderNeighborhoodCompany"], senderCompanyAdress = form["senderCompanyAdress"] };

        //            var cargoParameters = new { cargoWidth = form["cargoWidth"], cargoSize = form["cargoSize"], cargoHeight = form["cargoHeight"], cargoWeight = form["cargoWeight"], cargoDesi = form["desiBox"], cargoPrice = form["priceBox"], payType = form["payType"] };

        //            var receiverParameters = new { receiverTC = form["receiverTC"], receiverPhone = form["receiverPhone"], receiverName = form["receiverName"], receiverSurname = form["receiverSurname"], receiverCity = form["receiverCity"], receiverDistrict = form["receiverDistrict"], receiverNeighborhood = form["receiverNeighborhood"], receiverAdress = form["receiverAdress"] };


        //            string senderInfos = "INSERT INTO CUSTOMERCOMPANYS (C_CUSTOMER_TAX, C_CUSTOMER_PHONE, C_CUSTOMER_NAME, C_CUSTOMER_CITY, C_CUSTOMER_DISTRICT,C_CUSTOMER_NEIGHBOR,C_CUSTOMER_ADRESS) VALUES (@senderCompanyTax, @senderCompanyPhone, @senderCompanyName, @senderCompanyCity, @senderCompanyDistrict, @senderNeighborhoodCompany, @senderCompanyAdress)";

        //            string cargoInfos = "INSERT INTO CARGOINFOS (CARGO_WIDTH, CARGO_SIZE, CARGO_HEIGHT, CARGO_WEIGHT, CARGO_DESI, CARGO_PRICE,PAY_TYPE) VALUES  (@cargoWidth, @cargoSize, @cargoHeight, @cargoWeight, @cargoDesi, @cargoPrice, @payType)";

        //            string receiverInfos = "INSERT INTO CUSTOMERS (CUSTOMER_TC, CUSTOMER_PHONE, CUSTOMER_NAME, CUSTOMER_SURNAME, CUSTOMER_CITY, CUSTOMER_DISTRICT, CUSTOMER_NEIGHBOR, CUSTOMER_ADRESS) VALUES  (@receiverTC, @receiverPhone, @receiverName, @receiverSurname, @receiverCity, @receiverDistrict, @receiverNeighborhood, @receiverAdress)";


        //            using (IDbConnection connection = new SqlConnection(connectionString))
        //            {
        //                connection.Open();
        //                connection.Query(senderInfos, senderParameters);
        //                connection.Query(cargoInfos, cargoParameters);
        //                connection.Query(receiverInfos, receiverParameters);
        //                connection.Close();
        //            }
        //        }
        //        else if (deliveryType.deliveryType == "subeden")
        //        {
        //            //senderOffice Şimdilik kaydedilmiyor
        //            var senderParameters = new { senderCompanyTax = form["senderCompanyTax"], senderCompanyPhone = form["senderCompanyPhone"], senderCompanyName = form["senderCompanyName"], senderCompanyCity = form["senderCompanyCity"], senderCompanyDistrict = form["senderCompanyDistrict"], senderNeighborhoodCompany = form["senderNeighborhoodCompany"], senderCompanyAdress = form["senderCompanyAdress"] };

        //            var cargoParameters = new { cargoWidth = form["cargoWidth"], cargoSize = form["cargoSize"], cargoHeight = form["cargoHeight"], cargoWeight = form["cargoWeight"], cargoDesi = form["desiBox"], cargoPrice = form["priceBox"], payType = form["payType"] };

        //            var receiverParameters = new { receiverTC = form["receiverTC"], receiverPhone = form["receiverPhone"], receiverName = form["receiverName"], receiverSurname = form["receiverSurname"], receiverCity = form["receiverCity"], receiverDistrict = form["receiverDistrict"], receiverNeighborhood = form["receiverNeighborhood"], receiverAdress = form["receiverAdress"] };


        //            string senderInfos = "INSERT INTO CUSTOMERCOMPANYS (C_CUSTOMER_TAX, C_CUSTOMER_PHONE, C_CUSTOMER_NAME, C_CUSTOMER_CITY, C_CUSTOMER_DISTRICT,C_CUSTOMER_NEIGHBOR,C_CUSTOMER_ADRESS) VALUES (@senderCompanyTax, @senderCompanyPhone, @senderCompanyName, @senderCompanyCity, @senderCompanyDistrict, @senderNeighborhoodCompany, @senderCompanyAdress)";

        //            string cargoInfos = "INSERT INTO CARGOINFOS (CARGO_WIDTH, CARGO_SIZE, CARGO_HEIGHT, CARGO_WEIGHT, CARGO_DESI, CARGO_PRICE,PAY_TYPE) VALUES  (@cargoWidth, @cargoSize, @cargoHeight, @cargoWeight, @cargoDesi, @cargoPrice, @payType)";

        //            string receiverInfos = "INSERT INTO CUSTOMERS (CUSTOMER_TC, CUSTOMER_PHONE, CUSTOMER_NAME, CUSTOMER_SURNAME, CUSTOMER_CITY, CUSTOMER_DISTRICT, CUSTOMER_NEIGHBOR, CUSTOMER_ADRESS) VALUES  (@receiverTC, @receiverPhone, @receiverName, @receiverSurname, @receiverCity, @receiverDistrict, @receiverNeighborhood, NULL)";


        //            using (IDbConnection connection = new SqlConnection(connectionString))
        //            {
        //                connection.Open();
        //                connection.Query(senderInfos, senderParameters);
        //                connection.Query(cargoInfos, cargoParameters);
        //                connection.Query(receiverInfos, receiverParameters);
        //                connection.Close();
        //            }
        //        }
        //    }

        //    else if (radioDatas.radio1 == "option2" && radioDatas.radio2 == "receiveroption2")
        //    {
        //        //Kurumsal-Kurumsal
        //        var deliveryType = new { deliveryType = form["deliveryType"] };
        //        if (deliveryType.deliveryType == "eve")
        //        {
        //            //Ofis bilgileri Kaydedilmiyor
        //            var senderParameters = new { senderCompanyTax = form["senderCompanyTax"], senderCompanyPhone = form["senderCompanyPhone"], senderCompanyName = form["senderCompanyName"], senderCompanyCity = form["senderCompanyCity"], senderCompanyDistrict = form["senderCompanyDistrict"], senderNeighborhoodCompany = form["senderNeighborhoodCompany"], senderCompanyAdress = form["senderCompanyAdress"] };

        //            var cargoParameters = new { cargoWidth = form["cargoWidth"], cargoSize = form["cargoSize"], cargoHeight = form["cargoHeight"], cargoWeight = form["cargoWeight"], cargoDesi = form["desiBox"], cargoPrice = form["priceBox"], payType = form["payType"] };

        //            var receiverParameters = new { receiverCompanyTax = form["receiverCompanyTax"], receiverCompanyPhone = form["receiverCompanyPhone"], receiverCompanyName = form["receiverCompanyName"], receiverCompanyCity = form["receiverCompanyCity"], receiverCompanyDistrict = form["receiverCompanyDistrict"], receiverNeighborhoodCompany = form["receiverNeighborhoodCompany"], receiverCompanyAdress = form["receiverCompanyAdress"] };

        //            string senderInfos = "INSERT INTO CUSTOMERCOMPANYS (C_CUSTOMER_TAX, C_CUSTOMER_PHONE, C_CUSTOMER_NAME, C_CUSTOMER_CITY, C_CUSTOMER_DISTRICT,C_CUSTOMER_NEIGHBOR,C_CUSTOMER_ADRESS) VALUES (@senderCompanyTax, @senderCompanyPhone, @senderCompanyName, @senderCompanyCity, @senderCompanyDistrict, @senderNeighborhoodCompany, @senderCompanyAdress)";

        //            string cargoInfos = "INSERT INTO CARGOINFOS (CARGO_WIDTH, CARGO_SIZE, CARGO_HEIGHT, CARGO_WEIGHT, CARGO_DESI, CARGO_PRICE,PAY_TYPE) VALUES  (@cargoWidth, @cargoSize, @cargoHeight, @cargoWeight, @cargoDesi, @cargoPrice, @payType)";

        //            string receiverInfos = "INSERT INTO CUSTOMERCOMPANYS (C_CUSTOMER_TAX, C_CUSTOMER_PHONE, C_CUSTOMER_NAME, C_CUSTOMER_CITY, C_CUSTOMER_DISTRICT,C_CUSTOMER_NEIGHBOR,C_CUSTOMER_ADRESS) VALUES (@receiverCompanyTax, @receiverCompanyPhone, @receiverCompanyName, @receiverCompanyCity, @receiverCompanyDistrict, @receiverNeighborhoodCompany, @receiverCompanyAdress)";
        //            using (IDbConnection connection = new SqlConnection(connectionString))
        //            {
        //                connection.Open();
        //                connection.Query(senderInfos, senderParameters);
        //                connection.Query(cargoInfos, cargoParameters);
        //                connection.Query(receiverInfos, receiverParameters);
        //                connection.Close();
        //            }
        //        }
        //        else if (deliveryType.deliveryType == "subeden")
        //        {
        //            // Ofis Bilgileri kaydedilmiyor
        //            var senderParameters = new { senderCompanyTax = form["senderCompanyTax"], senderCompanyPhone = form["senderCompanyPhone"], senderCompanyName = form["senderCompanyName"], senderCompanyCity = form["senderCompanyCity"], senderCompanyDistrict = form["senderCompanyDistrict"], senderNeighborhoodCompany = form["senderNeighborhoodCompany"], senderCompanyAdress = form["senderCompanyAdress"] };

        //            var cargoParameters = new { cargoWidth = form["cargoWidth"], cargoSize = form["cargoSize"], cargoHeight = form["cargoHeight"], cargoWeight = form["cargoWeight"], cargoDesi = form["desiBox"], cargoPrice = form["priceBox"], payType = form["payType"] };

        //            var receiverParameters = new { receiverCompanyTax = form["receiverCompanyTax"], receiverCompanyPhone = form["receiverCompanyPhone"], receiverCompanyName = form["receiverCompanyName"], receiverCompanyCity = form["receiverCompanyCity"], receiverCompanyDistrict = form["receiverCompanyDistrict"], receiverNeighborhoodCompany = form["receiverNeighborhoodCompany"], receiverCompanyAdress = form["receiverCompanyAdress"] };

        //            string senderInfos = "INSERT INTO CUSTOMERCOMPANYS (C_CUSTOMER_TAX, C_CUSTOMER_PHONE, C_CUSTOMER_NAME, C_CUSTOMER_CITY, C_CUSTOMER_DISTRICT,C_CUSTOMER_NEIGHBOR,C_CUSTOMER_ADRESS) VALUES (@senderCompanyTax, @senderCompanyPhone, @senderCompanyName, @senderCompanyCity, @senderCompanyDistrict, @senderNeighborhoodCompany, @senderCompanyAdress)";

        //            string cargoInfos = "INSERT INTO CARGOINFOS (CARGO_WIDTH, CARGO_SIZE, CARGO_HEIGHT, CARGO_WEIGHT, CARGO_DESI, CARGO_PRICE,PAY_TYPE) VALUES  (@cargoWidth, @cargoSize, @cargoHeight, @cargoWeight, @cargoDesi, @cargoPrice, @payType)";

        //            string receiverInfos = "INSERT INTO CUSTOMERCOMPANYS (C_CUSTOMER_TAX, C_CUSTOMER_PHONE, C_CUSTOMER_NAME, C_CUSTOMER_CITY, C_CUSTOMER_DISTRICT,C_CUSTOMER_NEIGHBOR,C_CUSTOMER_ADRESS) VALUES (@receiverCompanyTax, @receiverCompanyPhone, @receiverCompanyName, @receiverCompanyCity, @receiverCompanyDistrict, @receiverNeighborhoodCompany, NULL)";
        //            using (IDbConnection connection = new SqlConnection(connectionString))
        //            {
        //                connection.Open();
        //                connection.Query(senderInfos, senderParameters);
        //                connection.Query(cargoInfos, cargoParameters);
        //                connection.Query(receiverInfos, receiverParameters);
        //                connection.Close();
        //            }
        //        }
        //    }

        //    return View();
        //}


        public ActionResult CreateOrder()
        {
            //GetCities();
            //GetDistricts();
            //GetNeighbors();
            return View();

        }


        [HttpPost]
        public ActionResult SaveData(EntityLayer.Senders senders, EntityLayer.Receivers receivers, EntityLayer.Cargos cargo, EntityLayer.Orders orders)
        {
            // Ajax Verileri Geliyor

            int numberOfDigits = 12;
            string randomNumber;

            do
            {
                randomNumber = GenerateRandomNumber(numberOfDigits);
            } while (CheckForDuplicate(randomNumber));

            orders.ORDER_FNUM = randomNumber;
            orders.OFFICE_ID = Convert.ToInt32(senders.SENDER_CITY);
            orders.VEHICLE_ID = orders.OFFICE_ID;
            orders.PERSON_ID = orders.OFFICE_ID;
            orders.ORDER_CREATE_DATE = DateTime.Now;
            orders.ORDER_STATE = 1;


            MvcDbHelper.Repository.Insert(QueryWareHouse.Orders.Insert, orders);
            senders.ORDER_ID = orders.ORDER_ID;
            receivers.ORDER_ID = orders.ORDER_ID;

            MvcDbHelper.Repository.Insert(QueryWareHouse.Senders.Insert, senders);
            MvcDbHelper.Repository.Insert(QueryWareHouse.Receviers.Insert, receivers);

            orders.SENDER_ID = senders.CUSTOMER_ID;
            orders.RECEIVER_ID = receivers.CUSTOMER_ID;
            orders.ORDER_ID = orders.ORDER_ID;

            MvcDbHelper.Repository.Update(QueryWareHouse.Orders.Update, orders);

            cargo.ORDER_ID = orders.ORDER_ID;
            MvcDbHelper.Repository.Insert(QueryWareHouse.Cargos.Insert, cargo);

            return View();
        }

        static string GenerateRandomNumber(int length)
        {
            Random random = new Random();
            string numbers = "0123456789";
            char[] result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = numbers[random.Next(numbers.Length)];
            }

            return new string(result);
        }

        static bool CheckForDuplicate(string number)
        {

            var orderResult = MvcDbHelper.Repository.GetColumn<Orders>(QueryWareHouse.Orders.GetColumn).ToList();

            string[] previousNumbers = orderResult.Select(order => order.ORDER_FNUM).ToArray();

            foreach (string previousNumber in previousNumbers)
            {
                if (number == previousNumber)
                {
                    return true; // Tekrar oluşturulmuş, tekrar deneyelim.
                }
            }

            return false; // Yeni ve benzersiz sayı oluşturulmuş.
        }


        public ActionResult _partialActiveOrders()
        {
            // Eylem yöntemi işlemleri
            return PartialView();
        }

        public ActionResult _partialPassiveOrders()
        {
            // Eylem yöntemi işlemleri
            return PartialView();
        }

        public ActionResult Login()
        {
            return View();
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
        [HttpGet]
        public ActionResult GetList(datatableRequest request,string arama)
            {
            //OFFSET, ORDER, Filtreleme

            var datatableResult = MvcDbHelper.Repository.GetAll<FullDatas>(QueryWareHouse.FullDatas.GetAll).ToList();

            try
            {
                var data = new
                {
                    DataList = datatableResult
                };

                Debug.WriteLine(Json(new { data = datatableResult }, JsonRequestBehavior.AllowGet));
                return Json(new { data = datatableResult, recordsTotal = 1000, recordsFiltered = 10 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public class datatableRequest
        {
            public int draw { get; set; }
            public int start { get; set; }
            public int length { get; set; } 
            public searchModel search { get; set; }

        }
        public class searchModel
        {
                public string value { get; set; }
                public string regex { get; set; }
            }

        ////[HttpPost]
        //public ActionResult SaveData(DataModels data)
        //{


        //    // input1 ve input2 değerlerini kullanarak SQL Server'a veri kaydetme işlemlerini yapın
        //    if (data.senderRadioData != null && data.receiverRadioData != null)
        //    {
        //        //bireysel-bireysel

        //        //   using (var connection = new SqlConnection(connectionString))
        //        //   {
        //        //       connection.Open();
        //        //       var query = "INSERT INTO Customers (CUSTOMER_TC, CUSTOMER_PHONE, CUSTOMER_NAME, CUSTOMER_SURNAME, CUSTOMER_CITY, CUSTOMER_DISTRICT, CUSTOMER_NEIGHBOR, CUSTOMER_ADRESS) " +
        //        //"VALUES (@senderTCData, @senderPhoneData, @senderNameData, @senderSurnameData, @senderCityData, @senderDistrictData, @senderNeigborData, @senderAdressData)";
        //        //       connection.Execute(query, data);

        //        //   }
        //        return Json(new { success = true });
        //    }

        //    else if (data.senderRadioData != null && data.receiverRadioData == null)
        //    {
        //        //bireysel-kurumsal
        //    }

        //    else if (data.senderRadioData == null && data.receiverRadioData != null)
        //    {
        //        //kurumsal-bireysel
        //    }

        //    else if (data.senderRadioData == null && data.receiverRadioData == null)
        //    {
        //        //kurumsal-kurumsal
        //    }

        //    return RedirectToAction("Index"); // İstediğiniz başka bir sayfaya yönlendirme yapabilirsiniz.
        //}


    }


}
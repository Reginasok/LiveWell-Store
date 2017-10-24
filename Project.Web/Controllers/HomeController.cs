using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Web.Models;
using System.Web.Mvc;
using Project.Web.DAL;


namespace Project.Web.Controllers
{
    public class HomeController : Controller
    {
        private IProductDAL dal;

        public HomeController(IProductDAL productDal)
        {
            this.dal = productDal;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MeditationList()
        {
            //MeditationListModel model = new MeditationListModel();
            List<Product> meditation = dal.GetProducts();
            return View("MeditationList", meditation);
        }

        public ActionResult ExerciseList()
        {
            ExerciseListModel model = new ExerciseListModel();
            return View("ExerciseList", model);
        }

        public ActionResult BodyCareList()
        {
            BodyCareListModel model = new BodyCareListModel();
            return View("BodyCareList", model);
        }

        public ActionResult StressReliefList()
        {
            StressReliefListModel model = new StressReliefListModel();
            return View("StressReliefList", model);
        }
    }
}
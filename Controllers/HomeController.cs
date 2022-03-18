using Microsoft.AspNetCore.Mvc;
using Prova.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.Controllers
{
    

    public class HomeController : Controller
    {      
       
        public ActionResult<dynamic> Index()
        {

            return View();


        }


    }
}

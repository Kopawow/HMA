﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgataKondraczykLab5.Models;

namespace AgataKondraczykLab5.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddToShoppingCart(List<Pizza> selectectPizzas)
        {


            return Index();
        }
    }
}
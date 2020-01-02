using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsPublish.Model.Response;
using NewsPublish.Service;
using NewsPublish.Web.Models;

namespace NewsPublish.Web.Controllers
{
    public class HomeController : Controller
    {
        private NewsService _newsService;
        private BannerService _bannerService;


        public HomeController(NewsService newsService,BannerService bannerService)
        {
            this._newsService = newsService;
            this._bannerService = bannerService;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "首页";
            return View(_newsService.GetNewsClassifyList());
        }
        [HttpGet]
        public JsonResult GetBanner()
        {
            return Json(_bannerService.GetBannerList());
        }
        [HttpGet]
        public JsonResult GetTotalNews()
        {
            return Json(_newsService.GetNewsCount(x=>true));
        }

        [HttpGet]
        public JsonResult GetHomeNews()
        {
            return Json(_newsService.GetNewsList(x=>true,7));
        }

        [HttpGet]
        public JsonResult GetTopCommentNews()
        {
            return Json(_newsService.GetNewCommentNewsList(x=>true,6));
        }

        [HttpGet]
        public JsonResult SearchOneNews(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return Json(new ResponseModel { code=0,result="关键字不能为空"});
           return Json(_newsService.GetSearchOneNews(x=>x.Title.Contains(keyword)));
        }

        public ActionResult Wrong()
        {
            return View();
        }
    }
}

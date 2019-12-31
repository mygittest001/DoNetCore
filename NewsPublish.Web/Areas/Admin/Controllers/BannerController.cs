using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsPublish.Model.Request;
using NewsPublish.Model.Response;
using NewsPublish.Service;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace NewsPublish.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BannerController : Controller
    {
        private BannerService _bannerService;
        private IHostingEnvironment _host;//获取主机环境参数
        public BannerController(BannerService bannerService,IHostingEnvironment host)
        {
            this._bannerService = bannerService;
            this._host = host;
        }

        // GET: Banner
        public ActionResult Index()
        {
            var banner = _bannerService.GetBannerList();

            return View(banner);
        }

        // GET: Banner/Details/5
        public ActionResult BannerAdd()
        {
            return View();
        }

        //IFormCollection collection接受图片参数
        [HttpPost]
        public async Task<JsonResult> AddBanner(AddBanner banner, IFormCollection collection)
        {
            var files = collection.Files;
            if (files.Count > 0)
            {
                var webRootPath = _host.WebRootPath;//需要nuget Microsoft.AspNetCore.Hosting并且using Microsoft.AspNetCore.Hosting;
                string relativeDirPath = "\\BannerPic";//相对路径
                string absolutePath = webRootPath+relativeDirPath;//图片存放路径
                string[] fileTypes = new string[] { ".gif",".jpg",".jpeg",".png",".bmp"};
                string extension = Path.GetExtension(files[0].FileName);

                if(fileTypes.Contains(extension.ToLower()))
                {
                    if(!Directory.Exists(absolutePath))Directory.CreateDirectory(absolutePath);
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                    var filePath = absolutePath +"\\"+ fileName;
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await files[0].CopyToAsync(stream);
                    }
                    banner.Image = "/BannerPic/"+fileName;
                    return Json(_bannerService.AddBanner(banner));
                }
                return Json(new ResponseModel { code=0,result="图片格式有误"});
            }
            return Json(new ResponseModel {code=0,result="请选择一张图片" });
        }


        [HttpPost]
        public JsonResult DleteBanner(int ID)
        {
            if (ID <= 0)
                return Json(new ResponseModel { code=0,result="ID不正确"});
            return Json(_bannerService.DeleteBanner(ID));
        }

        
    }
}
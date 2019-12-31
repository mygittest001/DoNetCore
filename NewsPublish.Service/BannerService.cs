using NewsPublish.Model.Entity;
using NewsPublish.Model.Request;
using NewsPublish.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewsPublish.Service
{
    public class BannerService
    {
        private Db _db;
        public BannerService(Db db)
        {
            this._db = db;
        }
        /// <summary>
        /// 添加banner
        /// </summary>
        /// <param name="banner"></param>
        /// <returns></returns>
        public ResponseModel AddBanner(AddBanner banner)
        {
            var ba = new Banner { AddTime = DateTime.Now, Image = banner.Image, Url = banner.Url, Remark = banner.Remark };
            _db.Add(ba);
            int i = _db.SaveChanges();
            if (i > 0)
                return new ResponseModel { code = 200, result = "Banner添加成功" };
            else
                return new ResponseModel { code = 0, result = "Banner添加失败" };
        }

        /// <summary>
        /// 获取banner集合
        /// </summary>
        /// <returns></returns>
        public ResponseModel GetBannerList()
        {
            var banners = _db.Banner.ToList().OrderByDescending(c => c.AddTime);
            var response = new ResponseModel();
            response.code = 200;
            response.result = "Banner集合获取成功";
            response.data = new List<BannerModel>();

            foreach (var banner in banners)
            {
                response.data.Add(new BannerModel()
                {
                    Id = banner.Id,
                    Image = banner.Image,
                    Url = banner.Url,
                    Remark = banner.Remark
                });
            }

            return response;
        }
        /// <summary>
        /// 删除banner
        /// </summary>
        /// <param name="bannerID"></param>
        /// <returns></returns>
        public ResponseModel DeleteBanner(int bannerID)
        {
            var banner = _db.Banner.Find(bannerID);
            if (banner == null)
                return new ResponseModel { code = 0, result = "Banner为空" };
            _db.Banner.Remove(banner);
            int i = _db.SaveChanges();
            if (i > 0)
                return new ResponseModel { code = 200, result = "Banner删除成功" };
            else
                return new ResponseModel { code = 0, result = "Banner删除失败" };
        }
    }
}

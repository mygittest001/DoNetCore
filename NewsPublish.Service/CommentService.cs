using Microsoft.EntityFrameworkCore;
using NewsPublish.Model.Entity;
using NewsPublish.Model.Request;
using NewsPublish.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NewsPublish.Service
{
    public class CommentService
    {
        public Db _db;
        public NewsService _newsService;
        public CommentService(Db db, NewsService newsService)
        {
            this._db = db;
            this._newsService = newsService;
        }

        /// <summary>
        /// 添加评论
        /// </summary>
        /// <returns></returns>
        public ResponseModel AddComment(AddNewsComment comment)
        {
            var news = _newsService.GetOneNews(comment.NewsId);
            if (news == null)
                return new ResponseModel { code = 0, result = "News不存在" };
            var com = new NewsComment { NewsId = comment.NewsId, Contents = comment.Contents, AddTime = DateTime.Now };
            _db.NewsComment.Add(com);
            int i = _db.SaveChanges();
            if (i > 0)
            {
                return new ResponseModel
                {
                    code = 200,
                    result = "NewsComment添加成功",
                    ////第一种写法
                    //data = new NewsCommentModel
                    //{
                    //    Contents = comment.Contents,
                    //    Floor = "#" + news.data.CommentCount + 1,//楼层
                    //    AddTime = DateTime.Now
                    //}
                    //第二种写法
                    data = new
                    {
                        contents = comment.Contents,
                        floor = "#" + news.data.CommentCount + 1,//楼层
                        addTime = DateTime.Now
                    }
                };
            }
            return new ResponseModel { code = 0, result = "NewsComment添加失败" };
        }
        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ResponseModel DelComment(int ID)
        {
            var comment = _db.NewsComment.Find(ID);
            if(comment==null)
                return new ResponseModel { code = 0, result = "NewsComment不存在" };
            _db.NewsComment.Remove(comment);
            int i = _db.SaveChanges();
            if (i > 0)
                return new ResponseModel { code = 200, result = "NewsComment添加成功" };
            else
                return new ResponseModel { code = 0, result = "NewsComment添加失败" };
        }

        /// <summary>
        /// 获取评论集合
        /// </summary>
        /// <returns></returns>
        public ResponseModel GetCommentList(Expression<Func<NewsComment,bool>> where)
        {
            var comments = _db.NewsComment.Include("News").Where(where).OrderBy(x => x.AddTime).ToList();
            var response = new ResponseModel {
                code = 200,
                result = "newConmmentList获取成功",
                data = new List<NewsCommentModel>()
            };
            int f = 1;
            foreach (var comment in comments)
            {
                response.data.Add(new NewsCommentModel {
                    Id = comment.Id,
                    NewsName = comment.News.Title,
                    Contents = comment.Contents,
                    AddTime = comment.AddTime,
                    Remark = comment.Remark,
                    Floor = "#" + f
                });
                f++;
            }

            response.data.Reverse();//反转,12345变成54321
            return response;
        }
    }
}

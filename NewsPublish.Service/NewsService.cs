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
    public class NewsService
    {
        public Db _db;
        public NewsService(Db db)
        {
            this._db = db;
        }

        #region 新闻类别
        public ResponseModel AddNewsClassify(AddNewsClassify addNewsClassify)
        {
            //根据新闻类别名称查找是否已经存在新闻类别
            var exist = _db.NewsClassify.FirstOrDefault(x => x.Name == addNewsClassify.Name) != null;
            if (exist)
                return new ResponseModel { code = 0, result = "新闻类别已存在" };

            var nc = new NewsClassify { Name = addNewsClassify.Name, Sort = addNewsClassify.Sort, Remark = addNewsClassify.Remark };
            _db.NewsClassify.Add(nc);
            int i = _db.SaveChanges();
            if (i > 0)
                return new ResponseModel { code = 200, result = "NewsClassify添加成功" };
            else
                return new ResponseModel { code = 0, result = "NewsClassify添加失败" };
        }


        public ResponseModel GetOneNewsClassify(int ID)
        {
            var classify = _db.NewsClassify.Find(ID);
            if (classify == null)
                return new ResponseModel { code = 0, result = "NewsClassify不存在" };
            return new ResponseModel
            {
                code = 200,
                result = "NewsClassify获取成功",
                data = new NewsClassify
                {
                    Id = classify.Id,
                    Name = classify.Name,
                    Sort = classify.Sort,
                    Remark = classify.Remark
                }
            };
        }
        /// <summary>
        /// 根据条件获取一个新闻类别
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        private NewsClassify GetOneNewsClassify(Expression<Func<NewsClassify, bool>> where)
        {
            return _db.NewsClassify.FirstOrDefault(where);
        }
        /// <summary>
        /// 编辑新闻类别
        /// </summary>
        /// <param name="editNewsClassify"></param>
        /// <returns></returns>
        public ResponseModel EditNewsClassify(EditNewsClassify editNewsClassify)
        {
            var classify = GetOneNewsClassify(x => x.Id == editNewsClassify.ID);
            if (classify == null)
                return new ResponseModel { code = 0, result = "NewsClassify不存在" };
            classify.Name = editNewsClassify.Name;
            classify.Sort = editNewsClassify.Sort;
            classify.Remark = editNewsClassify.Remark;
            _db.NewsClassify.Update(classify);
            int i = _db.SaveChanges();
            if (i > 0)
                return new ResponseModel { code = 200, result = "NewsClassify更新成功" };
            else
                return new ResponseModel { code = 0, result = "NewsClassify更新失败" };

        }
        /// <summary>
        /// 获取新闻类别集合
        /// </summary>
        /// <returns></returns>
        public ResponseModel GetNewsClassifyList()
        {
            var classifys = _db.NewsClassify.OrderByDescending(x => x.Sort).ToList();
            var response = new ResponseModel { code = 200, result = "NewsClassify列表获取成功" };
            response.data = new List<NewsClassifyModel>();
            foreach (var classify in classifys)
            {
                response.data.Add(new NewsClassifyModel { Id = classify.Id, Name = classify.Name, Remark = classify.Remark,Sort=classify.Sort });
            }
            return response;
        }
        #endregion



        /// <summary>
        /// 添加新闻
        /// </summary>
        /// <param name="news"></param>
        /// <returns></returns>
        public ResponseModel AddNews(AddNews news)
        {
            var classify = this.GetOneNewsClassify(x => x.Id == news.NewsClassifyId);
            if(classify==null)
                return new ResponseModel { code = 0, result = "添加新闻NewsClassify不存在" };
            var ne = new News { NewsClassifyId = classify.Id,Image = news.Image, Title = news.Title,Contents=news.Contents,Remark=news.Remark,PublishDate = DateTime.Now };
            _db.News.Add(ne);
            int i = _db.SaveChanges();
            if (i > 0)
                return new ResponseModel { code = 200, result = "News添加成功" };
            else
                return new ResponseModel { code = 0, result = "New添加失败" };
        }

        public ResponseModel GetOneNews(int ID)
        {
            //有外键的用Include导入
            var news = _db.News.Include("NewsClassify").Include("NewsComment").FirstOrDefault(x=>x.Id==ID);
            if (news == null)
                return new ResponseModel { code = 0, result = "News不存在" };
            return new ResponseModel
            {
                code = 200,
                result = "News获取成功",
                data = new NewsModel
                {
                    Id = news.Id,
                    Title = news.Title,
                    Image = news.Image,
                    NewsClassifyName = news.NewsClassify.Name,
                    Contents = news.Contents,
                    PublishDate = news.PublishDate.ToString("yyyy-MM-dd"),
                    CommentCount = news.NewsComment.Count(),
                    Remark = news.Remark
                }
            };
        }

        /// <summary>
        /// 删除一个新闻
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ResponseModel DelOnwNews(int ID)
        {
            var news = _db.News.FirstOrDefault(x=>x.Id ==ID);
            if (news == null)
                return new ResponseModel { code=0,result="删除News不存在"};
            _db.News.Remove(news);
            int i = _db.SaveChanges();
            if (i > 0)
                return new ResponseModel { code = 200, result = "News删除成功" };
            else
                return new ResponseModel { code = 0, result = "News删除失败" };
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns>
        public ResponseModel GetNewsPageQuery(int PageSize,int PageIndex,out int Total,List<Expression<Func<News,bool>>> where)
        {
            var list = _db.News.Include("NewsClassify").Include("NewsComment");
            foreach (var item in where)
            {
                list = list.Where(item);
            }
            Total = list.Count();
            //Skip跳过多少条,PageIndex等于1的话,PageSize * (PageIndex - 1)=0,就是逃过0条,PageIndex等于2的话,PageSize * (PageIndex - 1)=10,就是逃过10条
            //Take就是跳过多少条之后抓取多少条,这里是抓取pagesize条,也就是每页的数据条数
            var PageData = list.OrderByDescending(x => x.PublishDate).Skip(PageSize * (PageIndex - 1)).Take(PageSize).ToList();

            var response = new ResponseModel {
                code=200,
                result="分页成功",
                 };
            response.data = new List<NewsModel>();
            foreach (var model in PageData)
            {
                response.data.Add(new NewsModel {
                    Id = model.Id,
                    NewsClassifyName = model.NewsClassify.Name,
                    Title = model.Title,
                    Image = model.Image,
                    Contents = model.Contents,
                    PublishDate = model.PublishDate.ToString("yyyy-MM-dd"),
                    CommentCount = model.NewsComment.Count(),
                    Remark = model.Remark
                });
            }
            return response;
        }

        /// <summary>
        /// 查询新闻列表(固定条数数据)
        /// </summary>
        /// <param name="where"></param>
        /// <param name="topCount"></param>
        /// <returns></returns>
        public ResponseModel GetNewsList(Expression<Func<News, bool>> where,int topCount)
        {
            var list = _db.News.Include("NewsClassify").Include("NewsComment").Where(where).OrderByDescending(x=>x.PublishDate).Take(topCount);
            var response = new ResponseModel
            {
                code = 200,
                result = "新闻列表获取成功",
            };
            response.data = new List<NewsModel>();
            foreach (var model in list)
            {
                response.data.Add(new NewsModel
                {
                    Id = model.Id,
                    NewsClassifyName = model.NewsClassify.Name,
                    Title = model.Title,
                    Image = model.Image,
                    Contents = model.Contents.Length>50?model.Contents.Substring(0,50):model.Contents,
                    PublishDate = model.PublishDate.ToString("yyyy-MM-dd"),
                    CommentCount = model.NewsComment.Count(),
                    Remark = model.Remark
                });
            }
            return response;
        }
        /// <summary>
        /// 获取最新评论的新闻集合
        /// </summary>
        /// <param name="where"></param>
        /// <param name="topCount"></param>
        /// <returns></returns>
        public ResponseModel GetNewCommentNewsList(Expression<Func<News, bool>> where, int topCount)
        {
            //根据评论时间排序,取topCount条新闻ID,select(x=>x.Key)的意思就是取新闻ID
            var newsIDs = _db.NewsComment.OrderByDescending(x => x.AddTime).GroupBy(x => x.NewsId).Select(x => x.Key).Take(topCount); 

            var list = _db.News.Include("NewsClassify").Include("NewsComment").Where(x=>newsIDs.Contains(x.Id)).OrderByDescending(x => x.PublishDate);
            var response = new ResponseModel
            {
                code = 200,
                result = "最新评论新闻列表获取成功",
            };
            response.data = new List<NewsModel>();
            foreach (var model in list)
            {
                response.data.Add(new NewsModel
                {
                    Id = model.Id,
                    NewsClassifyName = model.NewsClassify.Name,
                    Title = model.Title,
                    Image = model.Image,
                    Contents = model.Contents.Length > 50 ? model.Contents.Substring(0, 50) : model.Contents,
                    PublishDate = model.PublishDate.ToString("yyyy-MM-dd"),
                    CommentCount = model.NewsComment.Count(),
                    Remark = model.Remark
                });
            }
            return response;
        }
        /// <summary>
        /// 搜索一条新闻
        /// </summary>
        /// <returns></returns>
        public ResponseModel GetSearchOneNews(Expression<Func<News,bool>> where)
        {
            var news = _db.News.Where(where).FirstOrDefault();
            if(news == null)
                return new ResponseModel { code = 0, result = "搜索一条News不存在" };

            return new ResponseModel { code=200,result= "搜索一条News成功",data = news.Id };

        }
        /// <summary>
        /// 获取新闻数量
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public ResponseModel GetNewsCount(Expression<Func<News,bool>> where)
        {
            var count = _db.News.Where(where).Count();
            return new ResponseModel { code=200,result="新闻数量获取成功",data=count};
        }
        /// <summary>
        /// 获取推荐列表
        /// </summary>
        /// <param name="newsID"></param>
        /// <returns></returns>
        public ResponseModel GetRecommendNewsList(int newsID)
        {
            var news = _db.News.FirstOrDefault(x => x.Id == newsID);
            if (news == null)
                return new ResponseModel { code = 0, result = "新闻不存在" };
            var newslist = _db.News.Include("NewsComment").Where(x => x.NewsClassifyId == news.NewsClassifyId&&x.Id!=newsID)
                .OrderByDescending(x=>x.PublishDate).OrderByDescending(x=>x.NewsComment.Count).Take(6).ToList();

            var response = new ResponseModel
            {
                code = 200,
                result = "新闻列表获取成功",
            };
            response.data = new List<NewsModel>();
            foreach (var model in newslist)
            {
                response.data.Add(new NewsModel
                {
                    Id = model.Id,
                    NewsClassifyName = model.NewsClassify.Name,
                    Title = model.Title,
                    Image = model.Image,
                    Contents = model.Contents.Length > 50 ? model.Contents.Substring(0, 50) : model.Contents,
                    PublishDate = model.PublishDate.ToString("yyyy-MM-dd"),
                    CommentCount = model.NewsComment.Count(),
                    Remark = model.Remark
                });
            }
            return response;
        }
    }
}

﻿using ConsoleApp1._17bang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1.Method
{
    public static class UsedLinq
    {
        public static void Do()
        {
            Keyword sql = new Keyword() { KeywordName = "SQL" };
            Keyword js = new Keyword() { KeywordName = "JS" };
            Keyword html = new Keyword() { KeywordName = "html" };
            Keyword css = new Keyword() { KeywordName = "css" };
            Keyword csharp = new Keyword() { KeywordName = "C#" };
            Keyword net = new Keyword() { KeywordName = ".NET" };


            Article article1 = new Article()
            {
                Author = new User() { Name = "飞哥" },
                Title = "飞哥真帅",
                KeyWords = new List<Keyword> { sql, css, csharp }
            };
            new ContentService().Publish(article1);

            Article article2 = new Article()
            {
                Author = new User() { Name = "小于" },
                Title = "源栈之花",
                KeyWords = new List<Keyword> { js }
            };
            new ContentService().Publish(article2);

            Article article3 = new Article()
            {
                Author = new User() { Name = "阿泰" },
                Title = "沙区扛把子",
                KeyWords = new List<Keyword> { net, html }
            };
            new ContentService().Publish(article3);

            Comment comment1 = new Comment(article1) { Contents = "帅" };
            Comment comment2 = new Comment(article1) { Contents = "真帅" };
            Comment comment3 = new Comment(article1) { Contents = "非常帅" };
            Comment comment4 = new Comment(article2) { Contents = "源栈之花啊" };
            Comment comment5 = new Comment(article3) { Contents = "大佬" };

            article1.Comments = new List<Comment> { comment1, comment2, comment3 };
            article2.Comments = new List<Comment> { comment4 };
            article3.Comments = new List<Comment> { comment5 };

            IEnumerable<Article> articles = new List<Article> { article1, article2, article3 };

            //找出“飞哥”发布的文章
            var fgPaper = from a in articles
                          where a.Author.Name == "飞哥"
                          select a;
            foreach (var item in fgPaper)
            {
                Console.WriteLine(item.Title);
            }

            //找出2019年1月1日以后“小鱼”发布的文章
            var xyPpaper = from a in articles
                           where a.Author.Name == "小于" && a.PublishTime > new DateTime(2019, 1, 1)
                           select a;
            foreach (var item in xyPpaper)
            {
                Console.WriteLine(item.Title);
            }

            //按发布时间升序 / 降序排列显示文章
            var time = from a in articles
                       orderby a.PublishTime ascending //升序
                                                       //orderby a.PublishTime descending  //降序
                       select a;
            foreach (var item in time)
            {
                Console.WriteLine(item.Title);
            }

            //统计每个用户各发布了多少篇文章
            var articlesNum = from a in articles
                              group a by a.Author into ua
                              select new
                              {
                                  name = ua.Key.Name,
                                  num = ua.Count()
                              };
            foreach (var item in articlesNum)
            {
                Console.WriteLine(item.name + ":" + item.num);
            }

            //找出包含关键字“C#”或“.NET”的文章
            var papers = from a in articles
                         where a.KeyWords.Contains(csharp) || a.KeyWords.Contains(net)
                         select a;
            foreach (var item in papers)
            {
                Console.WriteLine(item.Title);
            }

            //找出评论数量最多的文章
            var max = from a in articles
                      orderby a.Comments.Count() descending
                      select a;
            Console.WriteLine(max.ToList().First().Title);
        }


        //public static void ArticlesOfFg(List<Article> articles)
        //{
            
        //}
        //public static void ArticlesOfXy(List<Article> articles)
        //{
            
        //}

        //public static void TimeSort(List<Article> articles)
        //{
            
        //}

        //public static void ArticlesNum(List<Article> articles)
        //{
           
        //}

        //public static void FindArticle(List<Article> articles)
        //{
           
        //}

        //public static void Max(List<Article> articles)
        //{
            
        //}    
    }
}
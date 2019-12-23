﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ConsoleApp1.LinqToXML
{
    class XMLAdvanced
    {
        //代码生成一个XML的users对象，能够存放用户的id、name和password，然后并存放到磁盘
        //扩展user和articles的内容，使其能够完成以下操作：
        //根据用户名查找他发布的全部文章
        //统计出每个用户各发表了多少篇文章
        //查出每个用户最近发布的一篇文章
        //每个用户评论最多的一篇文章
        //删除没有发表文章的用户
        public static void UserData()
        {
            XElement UserDatas =
            new XElement("UserDatas",
            new XComment("以下存放用户数据"),
            new XElement("user",
                new XAttribute("id", 1),
            new XElement("name", "飞哥"),
            new XElement("password",1111),
            new XElement("articlesId", "1")),
            new XElement("user",
                new XAttribute("id", 2),
            new XElement("name", "小于"),
            new XElement("password",2222),
            new XElement("articlesId", "2")),
            new XElement("user",
                new XAttribute("id", 1),
            new XElement("name", "飞哥"),
            new XElement("password",1111),
            new XElement("articlesId", "3")),
            new XElement("user",
                new XAttribute("id", 3),
            new XElement("name", "阿泰"),
            new XElement("password",3333),
            new XElement("articlesId", "4"))


                        );
            Console.WriteLine(UserDatas);
            XDocument document = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), UserDatas);
            document.Save("E://UserDatas.xml");


        }
        

    }
}
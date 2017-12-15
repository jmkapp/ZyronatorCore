﻿using System;
using System.Collections.Generic;

namespace ZyronatorCore.Models
{
    public class RootUserLists
    {
        public Pagination Pagination { get; set; }
        public List<List> Lists { get; set; }
    }

    public class Pagination
    {
        public int Per_Page { get; set; }
        public int Items { get; set; }
        public int Page { get; set; }
        public Urls Urls { get; set; }
        public int Pages { get; set; }
    }

    public class Urls
    {
        public string Last { get; set; }
        public string Next { get; set; }
        public string Prev { get; set; }
        public string First { get; set; }
    }

    public class List
    {
        public bool Public { get; set; }
        public string Name { get; set; }
        public DateTime Date_Changed { get; set; }
        public DateTime Date_Added { get; set; }
        public string Resource_Url { get; set; }
        public string Uri { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public class DatabaseUserList
    {
        public int Id { get; set; }
        public int DiscogsId { get; set; }
        public string Name { get; set; }
        public string ResourceUrl { get; set; }
        public string Uri { get; set; }
        public string Description { get; set; }
    }
}

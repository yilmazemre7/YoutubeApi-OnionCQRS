﻿using YoutubeApi.Domain.Common;

namespace YoutubeApi.Domain.Entities
{
    public class Category : EntityBase
    {
        public Category()
        {
            Details = new HashSet<Detail>();
        }
        public Category(int parentId, string name, int priority)
        {
            ParentId = parentId;
            Name = name;
            Priority = priority;
        }
        public  int ParentId { get; set; }
        public  string Name { get; set; }
        public  int Priority { get; set; }
        public ICollection<Detail> Details { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}

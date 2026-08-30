using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;

namespace FROM_DB.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("server=localhost; database=magazine_db_ders; trusted_connection=true; trustservercertificate=true;")
        {

        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
    }

    public abstract class Base
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public bool Active { get; set; } = true;
        public bool Deleted { get; set; } = false;
    }
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }

    public class Comment : Base
    {
        public string Content { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public bool? Reaction { get; set; } = null;
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }

    public class Category : Base
    {
        public string Name { get; set; }
        public virtual ICollection<Article> Articles { get; set; } = new HashSet<Article>();
    }

    public class Article : Base
    {
        public string Title { get; set; }
        public string ShortContent { get; set; }
        public string Content { get; set; }
        public string CoverImagePath { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public DateTime? PublishDate { get; set; }
        public bool Draft { get; set; } = true;
        public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get;set;}
        public DbSet<Post> Posts { get;set;}


        public string DbPath {get; private set;}

        public BloggingContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            string path = Environment.GetFolderPath(folder);
            // DbPath on windows could be: C:\Users\GilbertS\AppData\Local\blogging.db
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}blogging.db";
        }
        
        // Configures EF to create a Sqlite database file in the
        // special local folder for the platform
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }
        
    }
}
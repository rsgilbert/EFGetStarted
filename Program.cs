using System;
using System.Linq;
using System.Collections.Generic;

namespace EFGetStarted
{
    internal class Program
    {
        private static void Main()
        {
            using (var db = new BloggingContext())
            {
                Console.WriteLine("##### BLOGGING APP #####");
                // Create
                Blog b = new Blog 
                {
                    Url = "http://blogs.msdn.com/adonet"
                };
                db.Add(b);
                db.SaveChanges();

                // Read
                Console.WriteLine("Querying for a blog");
                var blog = db.Blogs
                    .OrderByDescending(b => b.BlogId)
                    .First();
                Console.WriteLine($"Found blog: {blog.BlogId}, {blog.Url}");

                // Update
                Console.WriteLine("Updating the blog and adding a post");
                blog.Url = "http://localhost:3000/camps";

                Post p = new Post
                {
                    Title = "Hello there, how are you",
                    Content = "I am the new post"
                };

                blog.Posts.Add(p);
                db.SaveChanges();

                // Read posts
                List<Post> posts = db.Posts.ToList();
                Console.WriteLine($"We have {posts.Count()} posts");
                Console.WriteLine($"First post is {posts.First().Title}, last is {posts.Last().Title}");

                // Delete
                Console.WriteLine($"Before we have {db.Posts.Count()} posts and {db.Blogs.Count()} blogs");

                Console.WriteLine("Delete blog");
                var firstBlog = db.Blogs.First();
                db.Remove(firstBlog);
                db.SaveChanges();

                Console.WriteLine($"We have {db.Posts.Count()} posts and {db.Blogs.Count()} blogs");

                Console.WriteLine($"Database path: {db.DbPath}");
                Console.WriteLine("#### BYE ####");
            }            
        }
    }
}

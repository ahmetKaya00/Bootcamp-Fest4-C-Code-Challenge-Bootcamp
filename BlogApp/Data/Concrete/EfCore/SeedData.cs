using Microsoft.EntityFrameworkCore;
using BlogApp.Entity;

namespace BlogApp.Data.Concrete.EfCore{

    public static class SeedData{

        public static void TestVerileriniDoldur(IApplicationBuilder app){

            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if(context != null){
                if(context.Database.GetPendingMigrations().Any()){
                    context.Database.Migrate();
                }
                if(!context.Tags.Any()){
                    context.Tags.AddRange(
                        new Tag { Text = "backend programlama"},
                        new Tag { Text = "game"},
                        new Tag { Text = "fullstack"},
                        new Tag { Text = "frontend"},
                        new Tag { Text = "Augmented Realty"}
                    );
                    context.SaveChanges();
                }
                if(!context.Users.Any()){
                    context.Users.AddRange(
                        new User {UserName = "AhmetKaya"},
                        new User {UserName = "EmreSahin"}
                    );
                    context.SaveChanges();
                }
                if(!context.Posts.Any()){
                    context.Posts.AddRange(
                        new Post{
                            Title = "Asp.net Core",
                            Content = "Güzel içerikler",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            UserId = 1
                        },
                        new Post{
                            Title = "Unity Game",
                            Content = "Güzel içerikler",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-4),
                            Tags = context.Tags.Take(4).ToList(),
                            UserId = 1
                        },
                        new Post{
                            Title = "Frontend",
                            Content = "Güzel içerikler",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-11),
                            Tags = context.Tags.Take(2).ToList(),
                            UserId = 2
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
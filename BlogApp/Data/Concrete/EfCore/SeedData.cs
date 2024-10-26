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
                        new Tag { Text = "backend programlama", Url = "backend-programlama", Color = TagColors.primary},
                        new Tag { Text = "game", Url = "game", Color = TagColors.danger},
                        new Tag { Text = "fullstack", Url = "full-stack", Color = TagColors.info},
                        new Tag { Text = "frontend", Url = "fronted-programlama", Color = TagColors.success},
                        new Tag { Text = "Augmented Realty", Url = "augmented-realty", Color = TagColors.warning}
                    );
                    context.SaveChanges();
                }
                if(!context.Users.Any()){
                    context.Users.AddRange(
                        new User {UserName = "AhmetKaya", Name = "Ahmet Kaya", Email= "info@ahmetkaya.com", Password="123456", Image = "p1.jpg"},
                        new User {UserName = "EmreSahin", Name = "Emre Şahin", Email= "info@emresahin.com", Password="123456", Image = "p2.jpg"}
                    );
                    context.SaveChanges();
                }
                if(!context.Posts.Any()){
                    context.Posts.AddRange(
                        new Post{
                            Title = "Asp.net Core",
                            Description = "Güzel içerikler var",
                            Content = "Güzel içerikler",
                            IsActive = true,
                            Url = "asp-net-core",
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            Image = "1.png",
                            UserId = 1
                        },
                        new Post{
                            Title = "Unity Game",
                            Description = "Güzel içerikler var",
                            Content = "Güzel içerikler",
                            IsActive = true,
                            Url = "unity-game",
                            PublishedOn = DateTime.Now.AddDays(-4),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "2.png",
                            UserId = 1,
                            Comments = new List<Comment>{
                                new Comment {Text = "başarılı", PublishedOn = new DateTime(),UserId = 1},
                                new Comment {Text = "tebrikler", PublishedOn = new DateTime(),UserId = 2}
                            }
                        },
                        new Post{
                            Title = "Frontend",
                            Description = "Güzel içerikler var",
                            Content = "Güzel içerikler",
                            IsActive = true,
                            Url = "Frontend",
                            PublishedOn = DateTime.Now.AddDays(-11),
                            Tags = context.Tags.Take(2).ToList(),
                            Image = "3.png",
                            UserId = 2
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
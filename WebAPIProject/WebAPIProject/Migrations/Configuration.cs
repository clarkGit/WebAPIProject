namespace WebAPIProject.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebAPIProject.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebAPIProject.Models.BookAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebAPIProject.Models.BookAPIContext context)
        {
            context.Authors.AddOrUpdate(new Author[]{
        new Author() { AuthorId = 1, Name = "Ralls, Kim" },
        new Author() { AuthorId = 2, Name = "Corets, Eva" },
        new Author() { AuthorId = 3, Name = "Randall, Cynthia" },
        new Author() { AuthorId = 4, Name = "Thurman, Paula" }
        });

            context.Books.AddOrUpdate(new Book[]{
        new Book() { BookId = 1, Title = ".NET",genre="clark",PublishDate=new DateTime(2015,01,01),AuthorId=1,Description="",Price=100 },
        });
        }
    }
}

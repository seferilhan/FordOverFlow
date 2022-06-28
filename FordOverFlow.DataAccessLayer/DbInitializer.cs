using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FordOverFlow.CommonEntities;
namespace FordOverFlow.DataAccessLayer
{
    public class DbInitializer
    {
        public static void Initializer(DatabaseContext dbContext)
        {
          ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();
            if (dbContext.Users.Any()) return;                //Önceden seed atıldıysa tekrardan aynı işlemleri yapmıyoruz.

            var departments = new Department[]
            {
                new Department{DepartmentName = "Yazılım Geliştirme"},
                new Department{DepartmentName = "İnsan Kaynakları"}
            };
            
            foreach(var department in departments)
                 dbContext.Departments.Add(department);
            dbContext.SaveChanges();                    //Departman tablosu örnek kullanım için dolduruldu

            var categories = new Category[]
            {
                new Category{CategoryName = "Best Practice"},
                new Category{CategoryName = "Soru"},
                new Category{CategoryName = "Paylaşım"}
            };

            foreach(var category in categories)
                dbContext.Categories.Add(category);    //Category Tablosu
            dbContext.SaveChanges();

            var votes = new Votes[]                    //Oylar eklendi
            {
                new Votes{VoteType = "UpVote"},
                new Votes{VoteType = "DownVote"}
            };

            foreach(var vote in votes)
                dbContext.Votes.Add(vote);
            dbContext.SaveChanges();


            var tags = new Tags[]                    //Örnek Tagler
            {
                new Tags{TagName = "Örnek Tag1"},
                new Tags{TagName = "Örnek Tag2"}
            };

            foreach (var tag in tags)
                dbContext.Tags.Add(tag);
            dbContext.SaveChanges();


            var users = new User[]
            {
                new User{
                    Name = "Sefer",
                    SurName = "İlhan",
                    Password = "12345",
                    Email = "seferilhan41@gmailcom",
                    IsAdmin = true,
                    Department = departments[0]                  
                }
            };

            foreach (var user in users)
                dbContext.Users.Add(user);
            dbContext.SaveChanges();


            //var usertags = new UserTags[]
            //{
            //    new UserTags{UserID = users[0].UserID, TagID = tags[0].TagID },
            //    new UserTags{UserID = users[0].UserID, TagID = tags[2].TagID}
            //};

            //foreach (var usertag in usertags)
            //{
            //    dbContext.UserTags.Add(usertag);
            //    var editUser = dbContext.Users.SingleOrDefault(x => x.UserID == users[0].UserID);
            //    editUser.UserTags.Add(usertag);
            //    dbContext.SaveChanges();
            //}
            //dbContext.SaveChanges();        İlk Yöntem için 
            //İkinci yöntem için ??


            

        }
    }
}

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
                new Department{DepartmentName = "Yazılım Geliştirme"}
            };
            
            foreach(var department in departments)
                 dbContext.Departments.Add(department);
            dbContext.SaveChanges();                    //Departman tablosu örnek kullanım için dolduruldu



            var tags = new Tags[]
            {
                new Tags{TagName = "Tag1"},
                new Tags{TagName = "Tag2"},
                new Tags{TagName = "Tag3"},
                new Tags{TagName = "Tag4"},
                new Tags{TagName = "Tag5"}
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
                    Department = departments[0],
                    
                },
                new User
                {
                    Name="Emre",
                    SurName="Güzel",
                    Password="12345",
                    Email ="emrreguzel@gmail.com",
                    IsAdmin=true,
                    Department= departments[0]                  
                }
            };
            foreach(var user in users)
                dbContext.Users.Add(user);
            dbContext.SaveChanges();

            var usertags = new UserTags[]
            {
                new UserTags{UserID=users[0].UserID, TagID=tags[0].TagID},
                new UserTags{UserID=users[0].UserID, TagID=tags[1].TagID},
                new UserTags{UserID=users[0].UserID, TagID=tags[2].TagID},
                new UserTags{UserID=users[1].UserID, TagID=tags[3].TagID},
                new UserTags{UserID=users[1].UserID, TagID=tags[4].TagID}
            };
            foreach (var usertag in usertags)
            {
                dbContext.UserTags.Add(usertag);
                dbContext.SaveChanges();
                var editUser = dbContext.Users.FirstOrDefault(u => u.UserID == usertag.UserID);
                editUser.UserTags.Add(usertag);
                dbContext.SaveChanges();
            }
            dbContext.SaveChanges();

            var categories = new Category[]
            {
                new Category{CategoryName = "Category1"},
                new Category{CategoryName = "Category2"},
                new Category{CategoryName = "Category3"}
            };
            foreach (var category in categories)
                dbContext.Categories.Add(category);
            dbContext.SaveChanges();

            var votes = new Votes[]
            {
                new Votes{VoteType="UpVote"},
                new Votes{VoteType="DownVote"}
            };
            foreach (var vote in votes)
                dbContext.Votes.Add(vote);
            dbContext.SaveChanges();

            for (int i=0; i<10; i++)
            {
                var posts = new Post()
                {
                    Category = categories[FakeData.NumberData.GetNumber(0, 2)],
                    Title = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 2)),
                    Text = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 7)),
                    EditDate = DateTime.Now,
                    PublishDate = DateTime.Now,
                    User = (i % 2 == 0) ? users[0] : users[1],
                    IsFavorite = FakeData.BooleanData.GetBoolean(),
                    IsSolved = FakeData.BooleanData.GetBoolean()                   
                };
                   dbContext.Posts.Add(posts);
                   dbContext.SaveChanges();
                for (int k = 0; k<FakeData.NumberData.GetNumber(4, 10); k++)
                {
                    var comments = new Comment()
                    {
                        Text = FakeData.TextData.GetSentence(),
                        PublishDate = DateTime.Now,
                        EditDate = DateTime.Now,
                        IsFavorite = FakeData.BooleanData.GetBoolean(),
                        ownerPostID = posts.PostID,
                        commentOwnerID = (k % 2 == 0) ? users[0].UserID : users[1].UserID,
                        Post = posts,
                        User = (k % 2 == 0) ? users[0] : users[1]
                    };
                    dbContext.Comments.Add(comments);
                    dbContext.SaveChanges();
                    
                    for (int n = 0; n < FakeData.NumberData.GetNumber(5, 15); n++)
                    {
                        var commentVotes = new CommentVotes()
                        {
                            Comment = comments,
                            CommentID = comments.ID,
                            User = (n % 2 == 0) ? users[0] : users[1],
                            UserID = (n % 2 == 0) ? users[0].UserID : users[1].UserID,
                            Vote = (n % 2 == 0) ? votes[0] : votes[1],
                            VoteID = (n % 2 == 0) ? votes[0].ID : votes[1].ID
                        };
                        dbContext.CommentVotes.Add(commentVotes);
                        dbContext.SaveChanges();
                        comments.CommentVotes.Add(commentVotes);
                        dbContext.SaveChanges();
                    }
                    dbContext.Comments.Update(comments);
                    dbContext.SaveChanges();
                    posts.Comments.Add(comments);
                    
                    
                }

                for (int j = 0; j<FakeData.NumberData.GetNumber(1,5); j++)
                {   int x = FakeData.NumberData.GetNumber(0, 4);
                    var posttags = new PostTags()
                    {
                        Post = posts,
                        PostID= posts.PostID,
                        TagID = tags[x].TagID,
                        Tags = tags[x]                    
                    };
                    dbContext.PostTags.Add(posttags);
                    dbContext.SaveChanges();
                    posts.PostTags.Add(posttags);
                    
                }

                for (int m = 0; m<FakeData.NumberData.GetNumber(5,15); m++)
                {
                    var postvotes = new PostVotes()
                    {
                       Post = posts,
                       PostID=posts.PostID,
                       User = (m % 2 == 0) ? users[0] : users[1],
                       UserID = (m % 2 == 0) ? users[0].UserID : users[1].UserID,
                       Vote = (m % 2== 0) ? votes[0] : votes[1],
                       VoteID = (m % 2 == 0) ? votes[0].ID : votes[1].ID
                    };
                    dbContext.PostVotes.Add(postvotes);
                    dbContext.SaveChanges();
                    posts.PostVotes.Add(postvotes);
                }
                dbContext.Posts.Update(posts);
                dbContext.SaveChanges();
            }

            dbContext.SaveChanges();
        }
    }
}

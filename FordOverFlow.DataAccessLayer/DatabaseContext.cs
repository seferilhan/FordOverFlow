 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FordOverFlow.CommonEntities;
using Microsoft.EntityFrameworkCore;

namespace FordOverFlow.DataAccessLayer
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //İlk Yöntem için
            //modelBuilder.Entity<UserTags>()
            //      .HasKey(e => new { e.UserID, e.TagID });  //User - Tag arasındaki m-m ilişki için UserTag tablosu
            //modelBuilder.Entity<PostTags>()
            //      .HasKey(e => new { e.PostID, e.TagID });  //Post - Tag arası m-m ilişki.


            //İkinci Yöntem için

            ///////////////////////UserTags/////////////////////////
            modelBuilder.Entity<UserTags>()
                .HasOne(u => u.User)
                .WithMany(ut => ut.UserTags)
                .HasForeignKey(ui => ui.UserID);
            modelBuilder.Entity<UserTags>()
                .HasOne(t => t.Tags)
                .WithMany(ut => ut.UserTags)
                .HasForeignKey(ti => ti.TagID);
            ///////////////////////PostTags/////////////////////////
            modelBuilder.Entity<PostTags>()
                .HasOne(p => p.Post)
                .WithMany(pt => pt.PostTags)
                .HasForeignKey(pi => pi.PostID);
            modelBuilder.Entity<PostTags>()
                .HasOne(t => t.Tags)
                .WithMany(pt => pt.PostTags)
                .HasForeignKey(ti => ti.TagID);
            ///////////////////////Comment/////////////////////////
            modelBuilder.Entity<Comment>()
                .HasOne(u => u.User)
                .WithMany(c => c.Comments)
                .HasForeignKey(ui => ui.commentOwnerID)
                .OnDelete(DeleteBehavior.NoAction);            //Sebep olabileceği sonuçları araştır. Bunun sayesinde şimdilik hata yok => Sql Cascade Araştır
            modelBuilder.Entity<Comment>()
                .HasOne(p => p.Post)
                .WithMany(c => c.Comments)
                .HasForeignKey(pi => pi.ownerPostID);
            ///////////////////////CommentVotes/////////////////////////
            modelBuilder.Entity<CommentVotes>()
                .HasOne(u => u.User)
                .WithMany(cv => cv.CommentVotes)
                .HasForeignKey(ui => ui.UserID)
                .OnDelete(DeleteBehavior.NoAction);            //Sebep olabileceği sonuçları araştır. Bunun sayesinde şimdilik hata yok => Sql Cascade araştır
            modelBuilder.Entity<CommentVotes>()
                .HasOne(c => c.Comment)
                .WithMany(cv => cv.CommentVotes)
                .HasForeignKey(ci => ci.CommentID);
            modelBuilder.Entity<CommentVotes>()
                .HasOne(v => v.Vote)
                .WithMany(cv => cv.CommentVotes)
                .HasForeignKey(vi => vi.VoteID);
            ///////////////////////PostVotes/////////////////////////
            modelBuilder.Entity<PostVotes>()
                .HasOne(u => u.User)
                .WithMany(pv => pv.PostVotes)
                .HasForeignKey(ui => ui.UserID)
                .OnDelete(DeleteBehavior.NoAction);            //Sebep olabileceği sonuçları araştır. Bunun sayesinde şimdilik hata yok => Sql Cascade Araştır
            modelBuilder.Entity<PostVotes>()
                .HasOne(p => p.Post)
                .WithMany(pv => pv.PostVotes)
                .HasForeignKey(pi => pi.PostID);
            modelBuilder.Entity<PostVotes>()
                .HasOne(v => v.Vote)
                .WithMany(pv => pv.PostVotes)
                .HasForeignKey(vi => vi.VoteID);


        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentVotes> CommentVotes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTags> PostTags { get; set; }
        public DbSet<PostVotes> PostVotes { get; set; }
        public DbSet<Tags> Tags { get; set; }   
        public DbSet<User> Users { get; set; }
        public DbSet<UserTags> UserTags { get; set; }   
        public DbSet<Votes> Votes { get; set; }
    }


}

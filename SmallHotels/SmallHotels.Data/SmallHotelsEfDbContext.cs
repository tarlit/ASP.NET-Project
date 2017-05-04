using SmallHotels.Data.Contracts;
using SmallHotels.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System;

namespace SmallHotels.Data
{
    public class SmallHotelsEfDbContext : DbContext, ISmallHotelsEfDbContextSaveChanges
    {
        public SmallHotelsEfDbContext()
            : base("SmallHotels")
        {
        }

        public new IDbSet<T> Set<T>()
            where T : class
        {
            return base.Set<T>();
        }

        public IDbSet<Hotel> Hotels { get; set; }
        public IDbSet<HotelInfo> HotelInfos { get; set; }
        public IDbSet<Region> Regions { get; set; }
        public IDbSet<Room> Rooms { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<Like> Likes { get; set; }
        public IDbSet<BookRoom> BookRooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.OnHotelCreating(modelBuilder);
            this.OnHotelInfoCreating(modelBuilder);
            this.OnRegionCreating(modelBuilder);
            this.OnRoomCreating(modelBuilder);
            this.OnCommentCreating(modelBuilder);
            this.OnLikeCreating(modelBuilder);
            this.OnBookRoomCreating(modelBuilder);
        }       

        private void OnHotelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>()
                .Property(h => h.Name).IsRequired();

            modelBuilder.Entity<Hotel>()
                .Property(h => h.ImageUrl).IsRequired();

            modelBuilder.Entity<Hotel>()
               .HasRequired(hi => hi.HotelInfo)
               .WithRequiredPrincipal(h => h.Hotel);

            modelBuilder.Entity<Hotel>()
                .HasRequired(h => h.Region)
                .WithMany(c => c.Hotels);
        }

        private void OnHotelInfoCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelInfo>()
                .HasRequired(h => h.Hotel)
                .WithRequiredPrincipal(hi => hi.HotelInfo);
        }

        private void OnRegionCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>()
                .Property(b => b.Name).IsRequired();
        }

        private void OnRoomCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
                .Property(r => r.RoomType).IsRequired();

            modelBuilder.Entity<Room>()
                .Property(r => r.PricePerNight).IsRequired();

            modelBuilder.Entity<Room>()
                .HasRequired(r => r.Hotel)
                .WithMany(c => c.Rooms);
        }

        private void OnCommentCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .Property(c => c.Content).IsRequired();

            modelBuilder.Entity<Comment>()
                .HasRequired(r => r.HotelInfo)
                .WithMany(h => h.Comments);
        }

        private void OnLikeCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Like>()
                .HasRequired(l => l.HotelInfo)
                .WithMany(h => h.Likes);
        }

        private void OnBookRoomCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookRoom>()
                .Property(b => b.StartDate).IsRequired();

            modelBuilder.Entity<BookRoom>()
                .Property(b => b.NightsCount).IsRequired();
        }       
    }
}
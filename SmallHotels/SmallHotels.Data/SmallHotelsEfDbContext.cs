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
                .WithMany(c => c.Hotels)
                .HasForeignKey(h => h.RegionId);
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

        private void OnBookRoomCreating(DbModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }

        private void OnLikeCreating(DbModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }

        private void OnCommentCreating(DbModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }

        private void OnRoomCreating(DbModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }
    }
}
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using System;
//using System.Collections.Generic;
//using System.Security.Claims;
//using System.Threading.Tasks;

//namespace SmallHotels.Auth.Models
//{
//    public class User : IdentityUser
//    {
//        private ICollection<BookRoom> bookRooms;

//        public User()
//            : base()
//        {
//            this.IsDeleted = false;
//            this.RegisteredOn = DateTime.Now;
//            this.bookRooms = new HashSet<BookRoom>();
//        }

//        public string FirstName { get; set; }

//        public string LastName { get; set; }

//        public DateTime RegisteredOn { get; set; }

//        public bool IsDeleted { get; set; }

//        public string Address { get; set; }

//        public virtual IEnumerable<BookRoom> BookRooms { get; set; }

//        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
//        {
//            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
//            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
//            // Add custom user claims here
//            return userIdentity;
//        }
//    }
//}

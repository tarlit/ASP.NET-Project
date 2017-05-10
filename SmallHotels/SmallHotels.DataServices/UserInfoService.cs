namespace SmallHotels.DataServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Bytes2you.Validation;

    using SmallHotels.Auth.Models;
    using SmallHotels.Data.Models;
    using SmallHotels.Common.Constants;
    using SmallHotels.DataServices.Contracts;

    public class UserInfoService : IUserInfoService
    {
        private readonly ApplicationDbContext context;

        public UserInfoService(ApplicationDbContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = this.context.Users.ToList();

            return users;
        }

        public User GetById(string userId)
        {
            Guard.WhenArgument(userId, "userId").IsNull().Throw();

            var user = this.context.Users.Find(userId);

            return user;
        }

        public int GetPagesCount(string query)
        {
            int usersCount;
            if (!string.IsNullOrEmpty(query))
            {
                usersCount = this.context.Users
                    .Where(x => x.Email.ToLower().Contains(query.ToLower()) ||
                     x.FirstName.ToLower().Contains(query.ToLower()) ||
                     x.LastName.ToLower().Contains(query.ToLower()) ||
                     x.Address.ToLower().Contains(query.ToLower()))
                    .Count();
            }
            else
            {
                usersCount = this.context.Users
                    .Count();
            }

            int pagesCount;
            if (usersCount == 0)
            {
                pagesCount = 1;
            }
            else
            {
                pagesCount = (int)Math.Ceiling((decimal)usersCount / PageConstants.UsersPageSize);
            }

            return pagesCount;
        }

        public IEnumerable<User> GetUsersByPage(string query, int page, int pageSize)
        {
            var users = new List<User>();
            if (!string.IsNullOrEmpty(query))
            {
                users = this.context.Users
                     .Where(x => x.Email.ToLower().Contains(query.ToLower()) ||
                     x.FirstName.ToLower().Contains(query.ToLower()) ||
                     x.LastName.ToLower().Contains(query.ToLower()) ||
                     x.Address.ToLower().Contains(query.ToLower()))
                     //.ToList()
                     .OrderByDescending(x => x.RegisteredOn)
                     .Skip((page - 1) * pageSize)
                     .Take(pageSize)
                     .ToList();
            }
            else
            {
                users = this.context.Users
                    //.ToList()
                    .OrderByDescending(x => x.RegisteredOn)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
            }

            return users;
        }

        public void UpdateUserInfo(string userId, string email, string firstName, string lastName, string phone, string address, bool isDeleted)
        {
            Guard.WhenArgument(userId, "userId").IsNull().Throw();
            Guard.WhenArgument(email, "email").IsNull().Throw();

            var user = this.context.Users.Find(userId);
            if (user == null)
            {
                throw new InvalidOperationException();
            }

            user.Email = email;
            user.FirstName = firstName;
            user.LastName = lastName;
            user.PhoneNumber = phone;
            user.Address = address;
            user.IsDeleted = isDeleted;

            this.context.SaveChanges();
        }

        public void UpdateUserInfoByUser(string userId, string firstName, string lastName, string phone, string address)
        {
            Guard.WhenArgument(userId, "userId").IsNull().Throw();

            var user = this.context.Users.Find(userId);
            if (user == null)
            {
                throw new InvalidOperationException();
            }

            user.FirstName = firstName;
            user.LastName = lastName;
            user.PhoneNumber = phone;
            user.Address = address;

            this.context.SaveChanges();
        }

        public void ActivateAccount(string userId)
        {
            Guard.WhenArgument(userId, "userId").IsNull().Throw();

            var user = this.context.Users.Find(userId);
            if (user == null)
            {
                throw new InvalidOperationException();
            }

            user.IsDeleted = false;
            this.context.SaveChanges();
        }

        public void DeactivateAccount(string userId)
        {
            Guard.WhenArgument(userId, "userId").IsNull().Throw();

            var user = this.context.Users.Find(userId);
            if (user == null)
            {
                throw new InvalidOperationException();
            }

            user.IsDeleted = true;
            this.context.SaveChanges();
        }
    }
}

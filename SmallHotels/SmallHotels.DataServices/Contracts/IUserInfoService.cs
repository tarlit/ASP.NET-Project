using SmallHotels.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallHotels.DataServices.Contracts
{
    public interface IUserInfoService
    {
        IEnumerable<User> GetAllUsers();

        User GetById(string userId);

        void DeactivateAccount(string userId);

        void ActivateAccount(string userId);

        int GetPagesCount(string query);

        IEnumerable<User> GetUsersByPage(string query, int page, int pageSize);

        void UpdateUserInfo(string userId, string email, string firstName, string lastName, string phone, string address, bool isDeleted);

        void UpdateUserInfoByUser(string userId, string firstName, string lastName, string phone, string address);
    }
}

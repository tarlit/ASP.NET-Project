﻿using SmallHotels.Auth.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmallHotels.Data.Models;

namespace SmallHotels.Auth.Contracts
{
    // Revise whether this should be disposable!
    public interface ISignInService : IDisposable
    {
        Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent, bool shouldLockout);

        Task<bool> HasBeenVerifiedAsync();

        Task SignInAsync(User user, bool isPersistent, bool rememberBrowser);
       
        Task<SignInStatus> TwoFactorSignInAsync(string provider, string code, bool isPersistent, bool rememberBrowser);

        Task<string> GetVerifiedUserIdAsync();

        Task<bool> SendTwoFactorCodeAsync(string provider);

        Task<SignInStatus> ExternalSignInAsync(ExternalLoginInfo loginInfo, bool isPersistent);
    }
}
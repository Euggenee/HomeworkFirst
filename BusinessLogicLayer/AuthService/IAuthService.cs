using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.AuthService
{
   public interface IAuthService
    {
        public bool UserIdentification(Login login);
        public string GetToken();
        void AddUser(CheckIn checkIn);
    }
}

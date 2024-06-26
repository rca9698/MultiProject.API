using Application.LoginSgnup.Command;
using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interface
{
    public interface ILoginSignupRepository
    {
        public Task<ReturnType<UserDetail>> Login(LoginCommand entity);
        public Task<ReturnType<string>> Signup(SignupCommand entity);
        public Task<ReturnType<Otp_Login_Model>> Generate_Otp(string MobileNumber);
        public Task<ReturnType<string>> getRoles(long userId);
    }
}

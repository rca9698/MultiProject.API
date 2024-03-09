using Application.LoginSgnup.Command;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interface
{
    public interface ILoginSignupRepository
    {
        public Task<ReturnType<bool>> Login(LoginCommand entity);
        public Task<ReturnType<bool>> Signup(SignupCommand entity);
    }
}

using Application.AccountDetails.Command;
using Application.Common.Interface;
using Application.UserDetails.Command;
using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<ReturnType<UserDetail>> GetUsers()
        {
            ReturnType<UserDetail> returnType = new ReturnType<UserDetail>();
            try
            {

            }
            catch (Exception ex)
            {

            }
            return returnType;
        }
        public async Task<ReturnType<bool>> AddUser(AddUserCommand entity)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {

            }
            catch (Exception ex)
            {

            }
            return returnType;
        }
        public async Task<ReturnType<bool>> DeleteUser(DeleteUserCommand entity)
        {
            ReturnType<bool> returnType = new ReturnType<bool>();
            try
            {

            }
            catch (Exception ex)
            {

            }
            return returnType;
        }
    }
}

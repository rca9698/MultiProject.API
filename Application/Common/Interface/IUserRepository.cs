using Application.UserDetails.Command;
using Application.UserDetails.Query;
using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interface
{
    public interface IUserRepository
    {
        Task<ReturnType<UserDetail>> GetUsers(GetUsersQuery entity);
        Task<ReturnType<string>> AddUser(AddUserCommand entity);
        Task<ReturnType<string>> DeleteUser(DeleteUserCommand entity);
        Task<ReturnType<string>> UpdateUser(UpdateUserCommand entity);
    }
}

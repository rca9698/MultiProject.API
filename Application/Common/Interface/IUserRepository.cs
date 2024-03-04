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
        Task<ReturnType<bool>> AddUser(AddUserCommand entity);
        Task<ReturnType<bool>> DeleteUser(DeleteUserCommand entity);
    }
}

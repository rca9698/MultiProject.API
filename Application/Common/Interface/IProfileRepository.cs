using Application.Profile.Command;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interface
{
    public interface IProfileRepository
    {
        Task<ReturnType<string>> ChangePassword(ChangePasswordCommand entity);
    }
}

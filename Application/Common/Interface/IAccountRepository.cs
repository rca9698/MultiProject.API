using Application.AccountDetails.Command;
using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interface
{
    public interface IAccountRepository
    {
        Task<ReturnType<AccountDetail>> GetAccounts();
        Task<ReturnType<bool>> AddAccount(AddAccountCommand entity);
        Task<ReturnType<bool>> DeleteAccount(DeleteAccountCommand entity);
    }
}

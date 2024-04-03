using Application.AccountDetails.Command;
using Application.AccountDetails.Query;
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
        Task<ReturnType<AccountDetail>> GetAccounts(GetAccountsQuery entity);
        Task<ReturnType<AccountRequest>> AccountRequestList(AccountRequestListQuery entity);
        Task<ReturnType<AccountRequest>> AccountRequestDetails(AccountRequestDetailsQuery entity);
        Task<ReturnType<bool>> AddAccount(AddAccountCommand entity);
        Task<ReturnType<bool>> AddAccountRequest(AddAccountRequestCommand entity);
        Task<ReturnType<bool>> DeleteAccount(DeleteAccountCommand entity);
    }
}

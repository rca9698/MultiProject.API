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
        Task<ReturnType<string>> AddAccount(AddAccountCommand entity);
        Task<ReturnType<string>> AddAccountRequest(AddAccountRequestCommand entity);
        Task<ReturnType<string>> DeleteAccount(DeleteAccountCommand entity);
        Task<ReturnType<string>> DeleteAccountRequest(DeleteAccountRequestCommand entity);
    }
}

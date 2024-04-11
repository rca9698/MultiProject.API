using Application.BankAccount.Command;
using Application.BankAccount.Query;
using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interface
{
    public interface IBankAccountRepository
    {
        Task<ReturnType<BankDetails>> GetBankAccounts(GetBankAccountQuery entity);
        Task<ReturnType<BankDetails>> SetDefaultBankAccount(long sessionUser, long BankDetailID);
        Task<ReturnType<string>> AddBankAccount(AddBankAccountCommand entity);
        Task<ReturnType<string>> DeleteBankAccount(DeleteBankAccountCommand entity);
        Task<ReturnType<string>> DeleteAdminBankAccount(DeleteAdminBankAccountCommand entity);
        Task<ReturnType<string>> updateBankAccount(UpdateBankAccountCommand entity);
        Task<ReturnType<string>> AddUpdateAdminBankAccount(AddUpdateAdminBankAccountCommand entity);
        Task<ReturnType<BankDetails>> GetAdminBankAccounts();
    }
}

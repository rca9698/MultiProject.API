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
        Task<ReturnType<bool>> AddBankAccount(AddBankAccountCommand entity);
        Task<ReturnType<bool>> DeleteBankAccount(DeleteBankAccountCommand entity);
        Task<ReturnType<bool>> updateBankAccount(UpdateBankAccountCommand entity);
    }
}

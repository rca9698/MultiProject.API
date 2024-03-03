using Application.AccountDetails.Command;
using Application.Common.Interface;
using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public async Task<ReturnType<AccountDetail>> GetAccounts()
        {
            ReturnType<AccountDetail> returnType = new ReturnType<AccountDetail>();
            try
            {

            }
            catch (Exception ex)
            {

            }
            return returnType;
        }
        public async Task<ReturnType<bool>> AddAccount(AddAccountCommand entity)
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
        public async Task<ReturnType<bool>> DeleteAccount(DeleteAccountCommand entity)
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

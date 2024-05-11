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
    public interface IIDRepository
    {
        Task<ReturnType<IDDetail>> GetIDs(GetIDsQuery entity);
        Task<ReturnType<IDRequest>> IDRequestList(IDRequestListQuery entity);
        Task<ReturnType<IDRequest>> IDRequestDetails(IDRequestDetailsQuery entity);
        Task<ReturnType<string>> AddID(AddIDCommand entity);
        Task<ReturnType<string>> AddIDRequest(AddIDRequestCommand entity);
        Task<ReturnType<string>> DeleteID(DeleteIDCommand entity);
        Task<ReturnType<string>> DeleteIDRequest(DeleteIDRequestCommand entity);

        Task<ReturnType<IDDetail>> ListIDChangePassword(ListIDChangePasswordQuery entity);
        Task<ReturnType<IDDetail>> ListIDCloseRequest(ListIDCloseRequestCommand entity);
        Task<ReturnType<string>> AddChangeIDPassword(AddChangeIDPasswordCommand entity);
        Task<ReturnType<string>> AddCloseID(AddCloseIDCommand entity);
        Task<ReturnType<string>> ConfirmChangeIDPassword(ConfirmChangeIDPasswordCommand entity);
        Task<ReturnType<string>> ConfirmCloseID(ConfirmCloseIDCommand entity);
    }
}

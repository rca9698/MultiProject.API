using Application.Passbook.Query;
using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interface
{
    public interface IPassbookHistoryRepository
    {
        Task<ReturnType<PassbookDetailModel>> GetPassbookHistory(GetPassbookHistoryQuery entity);
    }
}

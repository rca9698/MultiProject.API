using Domain.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Passbook.Query
{
    public class GetPassbookHistoryQuery : IRequest<ReturnType<PassbookDetailModel>>
    {
        public long UserId { get; set; }
        public int SiteId { get; set; }
        public long SessionUser { get; set; }
    }
}

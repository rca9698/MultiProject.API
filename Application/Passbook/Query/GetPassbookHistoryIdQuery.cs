using Domain.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Passbook.Query
{
    public class GetPassbookHistoryIdQuery : IRequest<ReturnType<PassbookDetailModel>>
    {
        public string PassbookId { get; set; }
        public long SessionUser { get; set; }
    }
}

using Application.Common.Interface;
using Application.Notification.Query;
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
    public class GetPassbookHistoryHandler: IRequestHandler<GetPassbookHistoryQuery,ReturnType<PassbookDetailModel>>
    {
        private readonly IPassbookHistoryRepository _passbookHistoryRepository;
        public GetPassbookHistoryHandler(IPassbookHistoryRepository passbookHistoryRepository)
        {
            _passbookHistoryRepository = passbookHistoryRepository;
        }

        public async Task<ReturnType<PassbookDetailModel>> Handle(GetPassbookHistoryQuery request, CancellationToken cancellationToken)
        {
            return await _passbookHistoryRepository.GetPassbookHistory(request);
        }
    }
}

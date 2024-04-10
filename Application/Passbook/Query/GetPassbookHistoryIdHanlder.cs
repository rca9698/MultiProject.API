using Application.Common.Interface;
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
    public class GetPassbookHistoryIdHanlder : IRequestHandler<GetPassbookHistoryIdQuery,ReturnType<PassbookDetailModel>>
    {
        private readonly IPassbookHistoryRepository _passbookHistoryRepository;
        public GetPassbookHistoryIdHanlder(IPassbookHistoryRepository passbookHistoryRepository)
        {
            _passbookHistoryRepository = passbookHistoryRepository;
        }

        public async Task<ReturnType<PassbookDetailModel>> Handle(GetPassbookHistoryIdQuery request, CancellationToken cancellationToken)
        {
            return await _passbookHistoryRepository.GetPassbookHistoryById(request);
        }
    }
}

using Application.CoinsDetail.Common.Interface;
using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CoinsDetail.Command
{
    public class DeleteAccountRequestCoinsHandler : IRequestHandler<DeleteAccountRequestCoinsCommand, ReturnType<string>>
    {
        private readonly ICoinRepository _coinRepository;
        public DeleteAccountRequestCoinsHandler(ICoinRepository coinRepository)
        {
            _coinRepository = coinRepository;
        }

        public async Task<ReturnType<string>> Handle(DeleteAccountRequestCoinsCommand request, CancellationToken cancellationToken)
        {
            return await _coinRepository.DeleteAccountRequestCoins(request);
        }
    }
}

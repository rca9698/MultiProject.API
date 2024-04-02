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
    public class AddCoinsHandler : IRequestHandler<AddCoinsCommand,ReturnType<string>>
    {
        private readonly ICoinRepository _coinRepository;
        public AddCoinsHandler(ICoinRepository coinRepository)
        {
            _coinRepository = coinRepository;
        }

        public async Task<ReturnType<string>> Handle(AddCoinsCommand request, CancellationToken cancellationToken)
        {
           return await _coinRepository.AddCoins(request);
        }
    }
}

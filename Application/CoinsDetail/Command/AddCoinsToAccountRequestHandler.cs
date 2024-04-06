﻿using Application.CoinsDetail.Common.Interface;
using Application.Common.Interface;
using Application.Site.Query;
using Domain.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CoinsDetail.Command
{
    public class AddCoinsToAccountRequestHandler : IRequestHandler<AddCoinsToAccountRequestCommand, ReturnType<string>>
    {
        private readonly ICoinRepository _coinRepository;
        public AddCoinsToAccountRequestHandler(ICoinRepository coinRepository)
        {
            _coinRepository = coinRepository;
        }

        public async Task<ReturnType<string>> Handle(AddCoinsToAccountRequestCommand request, CancellationToken cancellationToken)
        {
            return await _coinRepository.AddCoinsToAccountRequest(request);
        }
    }
}

﻿using Application.CoinsDetail.Common.Interface;
using Application.Common.Interface;
using Domain.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CoinsDetail.Query
{
    public class ListCoinsDetailHandler : IRequestHandler<ListCoinsDetailQuery,ReturnType<CoinsRequestModel>>
    {
        private readonly ICoinRepository _coinRepository;
        public ListCoinsDetailHandler(ICoinRepository coinRepository)
        {
            _coinRepository = coinRepository;
        }

        public Task<ReturnType<CoinsRequestModel>> Handle(ListCoinsDetailQuery request, CancellationToken cancellationToken)
        {
            return _coinRepository.ListCoinsDetail(request);
        }
    }
}

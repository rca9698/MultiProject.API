using Application.Common.Interface;
using Domain.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Site.Query
{
    public class ViewThisSiteDetailsHandler : IRequestHandler<ViewThisSiteDetailsQuery, ReturnType<AccountDetail>>
    {
        private readonly ISiteDetailRepository _siteDetailRepository;
        public ViewThisSiteDetailsHandler(ISiteDetailRepository siteDetailRepository)
        {
            _siteDetailRepository = siteDetailRepository;
        }

        public async Task<ReturnType<AccountDetail>> Handle(ViewThisSiteDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _siteDetailRepository.ViewThisSiteDetails(request);
        }
    }
}

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
    public class GetUserListSiteByIdHandler : IRequestHandler<GetUserListSiteByIdQuery, ReturnType<SiteDetail>>
    {
        private readonly ISiteDetailRepository _siteDetailRepository;
        public GetUserListSiteByIdHandler(ISiteDetailRepository siteDetailRepository)
        {
            _siteDetailRepository = siteDetailRepository;
        }

        public Task<ReturnType<SiteDetail>> Handle(GetUserListSiteByIdQuery request, CancellationToken cancellationToken)
        {
            return _siteDetailRepository.GetUserListSiteById(request);
        }
    }
}

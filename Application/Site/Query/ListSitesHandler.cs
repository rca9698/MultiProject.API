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
    public class ListSitesHandler : IRequestHandler<ListSitesCommand,ReturnType<SiteDetail>>
    {
        private readonly ISiteDetailRepository _siteDetailRepository;
        public ListSitesHandler(ISiteDetailRepository siteDetailRepository)
        {
            _siteDetailRepository = siteDetailRepository;
        }

        public Task<ReturnType<SiteDetail>> Handle(ListSitesCommand request, CancellationToken cancellationToken)
        {
            return _siteDetailRepository.Getsites(request);
        }
    }
}

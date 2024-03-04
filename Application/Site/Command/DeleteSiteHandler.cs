using Application.Common.Interface;
using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Site.Command
{
    public class DeleteSiteHandler : IRequestHandler<DeleteSiteCommand, ReturnType<bool>>
    {
        private readonly ISiteDetailRepository _siteDetailRepository;
        public DeleteSiteHandler(ISiteDetailRepository siteDetailRepository)
        {
            _siteDetailRepository = siteDetailRepository;
        }

        public Task<ReturnType<bool>> Handle(DeleteSiteCommand request, CancellationToken cancellationToken)
        {
            return _siteDetailRepository.DeleteSite(request);
        }
    }
}

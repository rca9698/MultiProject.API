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
    public class UpdateSiteHandler : IRequestHandler<UpdateSiteCommand, ReturnType<string>>
    {
        private readonly ISiteDetailRepository _siteDetailRepository;
        public UpdateSiteHandler(ISiteDetailRepository siteDetailRepository)
        {
            _siteDetailRepository = siteDetailRepository;
        }

        public Task<ReturnType<string>> Handle(UpdateSiteCommand request, CancellationToken cancellationToken)
        {
            return _siteDetailRepository.UpdateSite(request);
        }
    }
}

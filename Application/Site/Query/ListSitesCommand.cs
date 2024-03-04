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
    public class ListSitesCommand : IRequest<ReturnType<SiteDetail>>
    {
        public long SessionUser { get; set; }
    }
}

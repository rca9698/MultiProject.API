using Domain.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Site.Command
{
    public class DeleteSiteCommand : IRequest<ReturnType<bool>>
    {
        public int SiteId { get; set; }
        public long SessionUser { get; set; }
    }
}

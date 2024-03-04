using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Site.Command
{
    public class AddSiteCommand : IRequest<ReturnType<bool>>
    {
        public string SiteName { get; set; }
        public string SiteURL { get; set; }
        public long SessionUser { get; set; }
    }
}

using Application.AccountDetails.Command;
using Application.AccountDetails.Query;
using Application.Site.Command;
using Application.Site.Query;
using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interface
{
    public interface ISiteDetailRepository
    {
        Task<ReturnType<SiteDetail>> Getsites(ListSitesCommand entity);
        Task<ReturnType<bool>> AddSite(AddSiteCommand entity);
        Task<ReturnType<bool>> DeleteSite(DeleteSiteCommand entity);
    }
}

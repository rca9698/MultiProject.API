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
        Task<ReturnType<AccountDetail>> ViewThisSiteDetails(ViewThisSiteDetailsQuery entity);
        Task<ReturnType<string>> AddSite(AddSiteCommand entity);
        Task<ReturnType<string>> DeleteSite(DeleteSiteCommand entity);
        Task<ReturnType<string>> UpdateSite(UpdateSiteCommand entity);
        Task<ReturnType<SiteDetail>> GetUserListSiteById(GetUserListSiteByIdQuery entity);
        Task<ReturnType<SiteDetail>> GetUserListSites();
    }
}

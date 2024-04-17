using Application.Home.Command;
using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interface
{
    public interface IHomeRepository
    {
        Task<ReturnType<DashboardImages>> GetDashboardImages();
        Task<ReturnType<string>> InsertDashboardImages(InsertDashboardImagesCommand entity);
        Task<ReturnType<string>> DeleteDahboardImages(string DocId);
    }
}

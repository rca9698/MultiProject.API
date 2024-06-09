using Application.Common.Interface;
using Application.LoginSgnup.Command;
using Domain.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Home.Command
{
    public class InsertDashboardImageHandler : IRequestHandler<InsertDashboardImagesCommand,ReturnType<string>>
    {
        private readonly IHomeRepository _homeRepository;
        public InsertDashboardImageHandler(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public async Task<ReturnType<string>> Handle(InsertDashboardImagesCommand request, CancellationToken cancellationToken)
        {
            ReturnType<string> result = new ReturnType<string>();
            try
            {
                return await _homeRepository.InsertDashboardImages(request);
            }
            catch (Exception ex)
            {

            }
            return result;
        }
    }
}

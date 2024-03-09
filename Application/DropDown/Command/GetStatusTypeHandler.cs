using Application.Common.Interface;
using Domain.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DropDown.Command
{
    public class GetStatusTypeHandler : IRequestHandler<GetStatusTypeCommand, ReturnType<DropDownDetails>>
    {
        private readonly IDropDownRepository _dropDownRepository;
        public GetStatusTypeHandler(IDropDownRepository dropDownRepository)
        {
            _dropDownRepository = dropDownRepository;
        }

        public Task<ReturnType<DropDownDetails>> Handle(GetStatusTypeCommand request, CancellationToken cancellationToken)
        {
            return _dropDownRepository.StatusTypes(request);
        }
    }
}

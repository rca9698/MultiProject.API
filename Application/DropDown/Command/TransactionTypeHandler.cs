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
    public class TransactionTypeHandler : IRequestHandler<TransactionTypeCommand, ReturnType<DropDownDetails>>
    {
        private readonly IDropDownRepository _dropDownRepository;
        public TransactionTypeHandler(IDropDownRepository dropDownRepository)
        {
            _dropDownRepository = dropDownRepository;
        }
        public async Task<ReturnType<DropDownDetails>> Handle(TransactionTypeCommand request, CancellationToken cancellationToken)
        {
            return await _dropDownRepository.TransactionTypes(request);
        }
    }
}

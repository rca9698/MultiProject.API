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
    public class TransactionTypeCommand : IRequest<ReturnType<DropDownDetails>>
    {
        public long SessionUser { get; set; }
    }
}

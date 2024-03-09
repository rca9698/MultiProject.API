using Application.DropDown.Command;
using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interface
{
    public interface IDropDownRepository
    {
        Task<ReturnType<DropDownDetails>> TransactionTypes(TransactionTypeCommand entity);
        Task<ReturnType<DropDownDetails>> StatusTypes(GetStatusTypeCommand entity);
    }
}

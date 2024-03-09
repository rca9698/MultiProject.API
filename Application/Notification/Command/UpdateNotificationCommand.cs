using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Notification.Command
{
    public class UpdateNotificationCommand : IRequest<ReturnType<bool>>
    {
        public long NotificationId { get; set; }
        public string NotificationDescription { get; set; }
    }
}

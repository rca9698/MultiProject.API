using Domain.Common;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Notification.Query
{
    public class GetNotificationQuery : IRequest<ReturnType<NotificationDetail>>
    {
        public long UserId { get; set; }
    }
}

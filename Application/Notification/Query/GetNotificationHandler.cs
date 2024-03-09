using Application.Common.Interface;
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
    public class GetNotificationHandler : IRequestHandler<GetNotificationQuery, ReturnType<NotificationDetail>>
    {
        private readonly INotificationRepository _notificationRepository;
        public GetNotificationHandler(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<ReturnType<NotificationDetail>> Handle(GetNotificationQuery request, CancellationToken cancellationToken)
        {
            return await _notificationRepository.GetNotifications(request);
        }
    }
}

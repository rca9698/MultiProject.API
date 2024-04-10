using Application.Common.Interface;
using Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Notification.Command
{
    public class UpdateNotificationHandler : IRequestHandler<UpdateNotificationCommand, ReturnType<string>>
    {
        private readonly INotificationRepository _notificationRepository;
        public UpdateNotificationHandler(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<ReturnType<string>> Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
        {
            return await _notificationRepository.UpdateNotification(request);
        }
    }
}

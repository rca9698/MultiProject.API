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
    public class DeleteNotificationHandler : IRequestHandler<DeleteNotificationCommand, ReturnType<bool>>
    {
        private readonly INotificationRepository _notificationRepository;
        public DeleteNotificationHandler(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<ReturnType<bool>> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
        {
             return await _notificationRepository.DeleteNotification(request);
        }
    }
}

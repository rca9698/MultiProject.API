using Application.Notification.Command;
using Application.Notification.Query;
using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interface
{
    public interface INotificationRepository
    {
        Task<ReturnType<bool>> InsertNotification(InsertNotificationCommand entity);
        Task<ReturnType<bool>> UpdateNotification(UpdateNotificationCommand entity);
        Task<ReturnType<bool>> DeleteNotification(DeleteNotificationCommand entity);
        Task<ReturnType<NotificationDetail>> GetNotifications(GetNotificationQuery entity);
    }
}

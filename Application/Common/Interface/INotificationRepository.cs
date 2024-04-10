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
        Task<ReturnType<string>> InsertNotification(InsertNotificationCommand entity);
        Task<ReturnType<string>> UpdateNotification(UpdateNotificationCommand entity);
        Task<ReturnType<string>> DeleteNotification(DeleteNotificationCommand entity);
        Task<ReturnType<NotificationDetail>> GetNotifications(GetNotificationQuery entity);
    }
}

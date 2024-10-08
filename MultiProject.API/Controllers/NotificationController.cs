﻿using Application.AccountDetails.Command;
using Application.Notification.Command;
using Application.Notification.Query;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MultiProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : BaseAPIController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<UserController> _logger;
        public NotificationController(IMediator mediator, ILogger<UserController> logger, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Route("GetNotifications")]
        public async Task<ReturnType<NotificationDetail>> GetNotifications(GetNotificationQuery request)
        {
            ReturnType<NotificationDetail> returnType = new ReturnType<NotificationDetail>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at NotificationController > GetNotifications");
            }
            return returnType;
        }

        [HttpPost]
        [Route("InsertNotification")]
        public async Task<ReturnType<string>> InsertNotification(InsertNotificationCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at NotificationController > InsertNotification");
            }
            return returnType;
        }

        [HttpPost]
        [Route("DeleteNotification")]
        public async Task<ReturnType<string>> DeleteNotification(DeleteNotificationCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at NotificationController > DeleteNotification");
            }
            return returnType;
        }

        [HttpPost]
        [Route("UpdateNotification")]
        public async Task<ReturnType<string>> UpdateNotification(UpdateNotificationCommand request)
        {
            ReturnType<string> returnType = new ReturnType<string>();
            try
            {
                returnType = await _mediator.Send(request);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception Occured at NotificationController > UpdateNotification");
            }
            return returnType;
        }

    }
}

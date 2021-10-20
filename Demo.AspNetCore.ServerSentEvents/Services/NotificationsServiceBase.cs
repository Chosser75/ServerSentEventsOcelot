﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Threading.Tasks;
using Lib.AspNetCore.ServerSentEvents;

namespace Demo.AspNetCore.ServerSentEvents.Services
{
    internal abstract class NotificationsServiceBase
    {
        #region Fields
        private INotificationsServerSentEventsService _notificationsServerSentEventsService;
        #endregion

        #region Constructor
        protected NotificationsServiceBase(INotificationsServerSentEventsService notificationsServerSentEventsService)
        {
            _notificationsServerSentEventsService = notificationsServerSentEventsService;
        }
        #endregion

        #region Methods
        protected Task SendSseEventAsync(string notification, bool alert)
        {
            return _notificationsServerSentEventsService.SendEventAsync(new ServerSentEvent
            {
                Type = alert ? "alert" : null,
                Data = new List<string>(notification.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None))
            });
        }

        protected List<string> GetClients()
        {
            var clients = _notificationsServerSentEventsService.GetClients();
            Debug.WriteLine($"----------------------------- Clients {JsonSerializer.Serialize(clients)} --------------------------------------");
            var clientsList = new List<string>();

            foreach (var client in clients)
            {
                clientsList.Add(JsonSerializer.Serialize(client));
            }
            return clientsList;
        }

        #endregion
    }
}

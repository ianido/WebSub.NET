﻿using System.Threading.Tasks;
using Lib.AspNetCore.ServerSentEvents;
using WebSub.AspNetCore.Services;

namespace Demo.AspNetCore.WebSub.Services
{
    internal class ServerSentEventWebSubSubscriptionsService : IWebSubSubscriptionsService
    {
        #region Fields
        private readonly IServerSentEventsService _serverSentEventsService;
        #endregion

        #region Constructor
        public ServerSentEventWebSubSubscriptionsService(IServerSentEventsService serverSentEventsService)
        {
            _serverSentEventsService = serverSentEventsService;
        }
        #endregion

        #region Methods
        public Task OnInvalidSubscribeIntentVerificationAsync(WebSubSubscription subscription, IWebSubSubscriptionsStore subscriptionsStore)
        {
            return _serverSentEventsService.SendEventAsync($"OnInvalidSubscribeIntentVerificationAsync ({subscription.Id})");
        }

        public async Task<bool> OnSubscribeIntentVerificationAsync(WebSubSubscription subscription, IWebSubSubscriptionsStore subscriptionsStore)
        {
            await _serverSentEventsService.SendEventAsync($"OnSubscribeIntentVerificationAsync ({subscription.Id})");

            return true;
        }
        #endregion
    }
}

﻿using System;
using System.Threading;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http.Authentication;
using WebSub.AspNetCore.Services;

namespace Test.WebSub.AspNetCore.WebHooks.Receivers.Subscriber.Filters.Infrastructure
{
    internal class IntentVerificationHttpContext : HttpContext
    {
        private const string HTTP_CONTEXT_ITEMS_SUBSCRIPTION_KEY = "WebSub.AspNetCore.WebHooks.Receivers.Subscriber-" + nameof(WebSubSubscription);

        private IDictionary<object, object> _items = new Dictionary<object, object>();

        public override IFeatureCollection Features => throw new NotImplementedException();

        public override HttpRequest Request { get; }

        public override HttpResponse Response => throw new NotImplementedException();

        public override ConnectionInfo Connection => throw new NotImplementedException();

        public override WebSocketManager WebSockets => throw new NotImplementedException();

        public override AuthenticationManager Authentication => throw new NotImplementedException();

        public override ClaimsPrincipal User { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override IDictionary<object, object> Items { get { return _items; } set { _items = value; } }

        public override IServiceProvider RequestServices { get; set; }

        public override CancellationToken RequestAborted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override string TraceIdentifier { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override ISession Session { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IntentVerificationHttpContext(string mode, string topic, string challenge, string leaseSeconds, string reason, WebSubSubscription subscription = null, IServiceProvider requestServices = null)
        {
            Request = new IntentVerificationHttpRequest(this, mode, topic, challenge, leaseSeconds, reason);
            Items[HTTP_CONTEXT_ITEMS_SUBSCRIPTION_KEY] = subscription;
            RequestServices = requestServices;
        }

        public override void Abort()
        {
            throw new NotImplementedException();
        }
    }
}

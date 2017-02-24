// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.AspNetCore.Authentication
{
    public class AuthenticationScheme
    {
        public AuthenticationScheme(string name, Type handlerType, IReadOnlyDictionary<string, object> settings)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            if (!typeof(IAuthenticationHandler).IsAssignableFrom(handlerType))
            {
                throw new ArgumentException("handlerType must implement IAuthenticationSchemeHandler.");
            }
            HandlerType = handlerType ?? throw new ArgumentNullException(nameof(handlerType));
            Settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public string Name { get; }
        public Type HandlerType { get; }

        // Holds things like the configured options instances for the handler
        // Also replacement for AuthenticationDescription
        public IReadOnlyDictionary<string, object> Settings { get; }
    }
}
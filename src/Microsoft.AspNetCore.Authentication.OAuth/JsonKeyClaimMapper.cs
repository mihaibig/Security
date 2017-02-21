﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Security.Claims;
using Newtonsoft.Json.Linq;

namespace Microsoft.AspNetCore.Authentication.OAuth
{
    /// <summary>
    /// A JsonClaimMapper that selects a top level value from the json user data with the given key name and adds it as a Claim.
    /// This no-ops if the key is not found or the value is empty.
    /// </summary>
    public class JsonKeyClaimMapper : JsonClaimMapper
    {
        /// <summary>
        /// Creates a new JsonKeyClaimMapper.
        /// </summary>
        /// <param name="claimType">The value to use for Claim.Type when creating a Claim.</param>
        /// <param name="valueType">The value to use for Claim.ValueType when creating a Claim.</param>
        /// <param name="jsonKey">The top level key to look for in the json user data.</param>
        public JsonKeyClaimMapper(string claimType, string valueType, string jsonKey)
            : base(claimType, valueType)
        {
            JsonKey = jsonKey;
        }

        /// <summary>
        /// The top level key to look for in the json user data.
        /// </summary>
        public string JsonKey { get; }

        /// <inheritdoc />
        public override void Map(JObject userData, ClaimsIdentity identity, string issuer)
        {
            var value = userData.Value<string>(JsonKey);
            if (!string.IsNullOrEmpty(value))
            {
                identity.AddClaim(new Claim(ClaimType, value, ValueType, issuer));
            }
        }
    }
}

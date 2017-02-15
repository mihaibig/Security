﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.AspNetCore.Authentication
{
    public class ClaimMapperCollection<T> : IEnumerable<ClaimMapper<T>>
    {
        private IList<ClaimMapper<T>> Mappers { get; } = new List<ClaimMapper<T>>();

        public void Clear() => Mappers.Clear();

        public void Remove(string claimName)
        {
            var itemsToRemove = Mappers.Where(map => string.Equals(claimName, map.ClaimName, StringComparison.OrdinalIgnoreCase)).ToList();
            itemsToRemove.ForEach(map => Mappers.Remove(map));
        }

        public void Add(ClaimMapper<T> mapper)
        {
            Mappers.Add(mapper);
        }

        public IEnumerator<ClaimMapper<T>> GetEnumerator()
        {
            return Mappers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Mappers.GetEnumerator();
        }
    }
}
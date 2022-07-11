﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using System;

namespace Microsoft.PowerFx.Preview
{
    /// <summary>
    /// Hosts can enable these flags to try out early features. 
    /// Any flags will eventually default to true and then get removed once the feature is finalized. 
    /// Removing a flag is a breaking change and requires a semver update. 
    /// Flags can only be set once. 
    /// </summary>
    public static class FeatureFlags
    {
        private static bool _stringInterpolation = false;

        /// <summary>
        /// Enable String Interpolation feature. 
        /// Added 3rd Dec 2021.
        /// </summary>
        public static bool StringInterpolation
        {
            get => _stringInterpolation;
            set => _stringInterpolation = ProtectedSet(value);
        }

        private static bool ProtectedSet(bool @value)
        {
            if (!value)
            {
                throw new NotSupportedException("Can't change field after it's set");
            }

            return @value;
        }
    }
}

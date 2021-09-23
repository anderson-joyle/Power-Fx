﻿//------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System.Collections.Generic;

namespace Microsoft.AppMagic.Authoring.Texl
{
    // StartsWith(text:s, start:s):b
    // Checks if the text starts with the start string.
    internal sealed class StartsWithFunction : StringTwoArgFunction
    {
        public override DelegationCapability FunctionDelegationCapability {  get { return DelegationCapability.StartsWith;  } }

        public StartsWithFunction()
            : base("StartsWith", TexlStrings.AboutStartsWith)
        { }

        public override bool IsRowScopedServerDelegatable(CallNode callNode, TexlBinding binding, OperationCapabilityMetadata metadata)
        {
            Contracts.AssertValue(callNode);
            Contracts.AssertValue(binding);
            Contracts.AssertValue(metadata);

            return IsRowScopedServerDelegatableHelper(callNode, binding, metadata);
        }

        public override IEnumerable<TexlStrings.StringGetter[]> GetSignatures()
        {
            yield return new[] { TexlStrings.StartsWithArg1, TexlStrings.StartsWithArg2 };
        }

        // TASK: 856362
        // Add overload for single-column table as the input.
    }
}
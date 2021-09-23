//------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Microsoft.AppMagic.Authoring.Texl
{
    internal partial class Intellisense
    {
        internal abstract class ErrorNodeSuggestionHandlerBase : NodeKindSuggestionHandler
        {
            public ErrorNodeSuggestionHandlerBase(NodeKind kind)
                : base(kind)
            { }

            internal override bool TryAddSuggestionsForNodeKind(IntellisenseData intellisenseData)
            {
                Contracts.AssertValue(intellisenseData);

                // For Error Kind, suggest top level values only in the context of a callNode and
                // ThisItemProperties only in the context of thisItem.
                TexlNode curNode = intellisenseData.CurNode;

                // Three methods that implement custom behavior here, one that adds suggestions before
                // top level suggestions are added, one after, and one to handle the case where there aren't
                // any top level suggestions to add.
                if (intellisenseData.AddSuggestionsBeforeTopLevelErrorNodeSuggestions())
                    return true;

                if (!IntellisenseHelper.AddSuggestionsForTopLevel(intellisenseData, curNode))
                {
                    intellisenseData.AddAlternativeTopLevelSuggestionsForErrorNode();
                }

                intellisenseData.AddSuggestionsAfterTopLevelErrorNodeSuggestions();
                return true;
            }
        }
    }
}
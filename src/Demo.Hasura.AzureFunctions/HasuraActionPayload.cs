using System;
using System.Collections.Generic;

namespace Demo.Hasura.AzureFunctions;

internal class HasuraActionPayload
{
    public HasuraActionPayload(
        Dictionary<string, string> action,
        Dictionary<string, string> sessionVariables
    )
    {
        Action = action
            ?? throw new ArgumentNullException(nameof(action));
        SessionVariables = sessionVariables;
    }

    public Dictionary<string, string> Action { get; }

    public Dictionary<string, string> SessionVariables { get; }
}

internal class HasuraActionPayload<TRequest> where TRequest : class
{
    public HasuraActionPayload(
        Dictionary<string, string> action,
        TRequest input,
        Dictionary<string, string> sessionVariables
    )
    {
        Action = action
            ?? throw new ArgumentNullException(nameof(action));
        Input = input
            ?? throw new ArgumentNullException(nameof(input));
        SessionVariables = sessionVariables;
    }

    public Dictionary<string, string> Action { get; }

    public TRequest Input { get; }

    public Dictionary<string, string> SessionVariables { get; }
}
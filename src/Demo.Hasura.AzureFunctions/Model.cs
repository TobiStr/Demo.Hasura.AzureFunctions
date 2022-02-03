namespace Demo.Hasura.AzureFunctions;

internal record HasuraDemoRequest(HasuraDemoInput Input);

internal record HasuraDemoInput(string Username, string Message);

internal record Result(bool Success, string Message);
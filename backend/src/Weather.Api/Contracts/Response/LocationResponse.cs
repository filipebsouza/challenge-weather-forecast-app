namespace Weather.Api.Contracts.Response;

public record LocationResponse(LocationAddressResponse[] addresses);

public record LocationAddressResponse(decimal latitude, decimal longitude, string completeAddress);
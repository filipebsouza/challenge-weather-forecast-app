namespace Weather.Api.Contracts.Response;

public record LocationApiResponse(LocationApiAddressResponse[] addresses);

public record LocationApiAddressResponse(double latitude, double longitude, string completeAddress);
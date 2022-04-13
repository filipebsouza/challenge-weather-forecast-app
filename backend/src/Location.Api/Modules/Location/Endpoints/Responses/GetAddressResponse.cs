namespace Location.Api.Modules.Location.Endpoints.Responses;

public record GetAddressResponse(GetAddressItemResponse[] Addresses);
public record GetAddressItemResponse(double Latitude, double Longitude, string CompleteAddress);
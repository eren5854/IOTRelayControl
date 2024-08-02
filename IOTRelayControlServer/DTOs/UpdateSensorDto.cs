namespace IOTRelayControlServer.DTOs;

public sealed record UpdateSensorDto(
    Guid Id,
    string Name,
    float Data);

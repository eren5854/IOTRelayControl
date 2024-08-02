namespace IOTRelayControlServer.DTOs;

public sealed record CreateSensorDto(
    string Name,
    float Data);

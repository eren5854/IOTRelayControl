namespace IOTRelayControlServer.Models;

public sealed class Sensor
{
    public Sensor()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public float Data { get; set; } = 0;
    public bool IsDeleted { get; set; } = false;
}
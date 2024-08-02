using IOTRelayControlServer.DTOs;
using IOTRelayControlServer.Models;

namespace IOTRelayControlServer.Services;

public interface ISensorService
{
    string Create(CreateSensorDto request);
    string Update(UpdateSensorDto request);
    string DeleteById(Guid id);
    List<Sensor> GetAll();
}

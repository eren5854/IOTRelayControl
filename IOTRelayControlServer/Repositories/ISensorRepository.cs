using IOTRelayControlServer.DTOs;
using IOTRelayControlServer.Models;

namespace IOTRelayControlServer.Repositories;

public interface ISensorRepository
{
    void CreateSensor(Sensor request);
    void UpdateSensor(Sensor request);
    IQueryable<Sensor> GetAll();
    void DeleteById(Guid Id);
    Sensor? GetSensorById(Guid Id);
}

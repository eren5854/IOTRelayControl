using IOTRelayControlServer.Context;
using IOTRelayControlServer.DTOs;
using IOTRelayControlServer.Models;

namespace IOTRelayControlServer.Repositories;

public sealed class SensorRepository(
    ApplicationDbContext context) : ISensorRepository
{
    public void CreateSensor(Sensor request)
    {
        context.Add(request);
        context.SaveChanges();
    }

    public void DeleteById(Guid Id)
    {
        Sensor? sensor = GetSensorById(Id);
        if (sensor is not null)
        {
            sensor.IsDeleted = true;
            context.SaveChanges();
        }
    }

    public IQueryable<Sensor> GetAll()
    {
        return context.Sensors.AsQueryable();
    }

    public Sensor? GetSensorById(Guid Id)
    {
        return context.Sensors.Where(p => p.Id == Id).FirstOrDefault();
    }

    public void UpdateSensor(Sensor request)
    {
        context.Update(request);
        context.SaveChanges();
    }
}

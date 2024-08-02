using AutoMapper;
using IOTRelayControlServer.DTOs;
using IOTRelayControlServer.Models;
using IOTRelayControlServer.Repositories;

namespace IOTRelayControlServer.Services;

public sealed class SensorService(
    IMapper mapper,
    ISensorRepository sensorRepository) : ISensorService
{
    public string Create(CreateSensorDto request)
    {
        Sensor sensor = mapper.Map<Sensor>(request);
        sensorRepository.CreateSensor(sensor);

        return "Create is successful";
    }

    public string DeleteById(Guid id)
    {
        Sensor? sensor = sensorRepository.GetSensorById(id);
        if (sensor is null)
        {
            return "Sensor not found";
        }
        sensorRepository.DeleteById(id);
        return "Delete is successful";
    }

    public List<Sensor> GetAll()
    {
        List<Sensor> sensors = sensorRepository.GetAll().ToList();
        return sensors;
    }

    public string Update(UpdateSensorDto request)
    {
        Sensor? sensor = sensorRepository.GetSensorById(request.Id);
        if (sensor is null)
        {
            return "Sensor not found";
        }
        mapper.Map(request, sensor);
        sensorRepository.UpdateSensor(sensor);
        return "Update is successful";
    }
}

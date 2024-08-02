using IOTRelayControlServer.Abstractions;
using IOTRelayControlServer.DTOs;
using IOTRelayControlServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace IOTRelayControlServer.Controllers;

public class SensorsController(
    ISensorService sensorService) : ApiController
{
    [HttpGet]
    public IActionResult Create(CreateSensorDto request)
    {
        string result = sensorService.Create(request);
        return Ok(new { Message = result });
    }

    [HttpGet]
    public IActionResult Update(UpdateSensorDto request)
    {
        string result = sensorService.Update(request);
        return Ok(new { Message = result });
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var result = sensorService.GetAll();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult DeleteById(Guid id)
    {
        string result = sensorService.DeleteById(id);
        return Ok(new { Message = result });
    }
}

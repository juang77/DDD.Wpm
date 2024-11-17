using Microsoft.AspNetCore.Mvc;
using Wpm.Clinic.Api.Application;

namespace Wpm.Clinic.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ClinicController(ILogger<ClinicController> logger, ClinicAplicationService applicationService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Post(StartConsultationCommand command)
    {
		try
		{
			var id = await applicationService.Handle(command);
			return Ok(id);

        }
		catch (Exception ex)
		{
            logger.LogError(ex.Message);
            return BadRequest();
        }
    }

    [HttpPost("end")]
    public async Task<ActionResult> Post(FinalizeConsultationCommand command)
    {
        try
        {
            await applicationService.Handle(command);
            return Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return BadRequest();
        }
    }

    [HttpPut("diagnosis")]
    public async Task<ActionResult> Put(SetDiagnosticCommand command)
    {
        try
        {
            await applicationService.Handle(command);
            return Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return BadRequest();
        }
    }

    [HttpPut("treatment")]
    public async Task<ActionResult> Put(SetTreatmentCommand command)
    {
        try
        {
            await applicationService.Handle(command);
            return Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return BadRequest();
        }
    }

    [HttpPut("weight")]
    public async Task<ActionResult> Put(SetWeightCommand command)
    {
        try
        {
            await applicationService.Handle(command);
            return Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return BadRequest();
        }
    }

    [HttpPut("administerDrug")]
    public async Task<ActionResult> Put(AdministerDrugsCommand command)
    {
        try
        {
            await applicationService.Handle(command);
            return Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return BadRequest();
        }
    }

    [HttpPut("registerVitalSigns")]
    public async Task<ActionResult> Put(RegisterVitalSignsCommand command)
    {
        try
        {
            await applicationService.Handle(command);
            return Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return BadRequest();
        }
    }

    [HttpGet("PatientHistory")]
    public ActionResult Get(PatientConsutationsReadingCommand command)
    {
        try
        {
            var result = applicationService.Handle(command);
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return BadRequest();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Wpm.Management.Api.Application;

namespace Wpm.Management.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ManagementController(ILogger<ManagementController> logger, ManagementApplicationService applicationService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Post(CreatePetCommand command)
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

    [HttpPut]
    public async Task<ActionResult> PutWeight(SetWeightCommand command)
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
}

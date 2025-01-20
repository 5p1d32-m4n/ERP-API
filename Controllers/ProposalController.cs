using ErpApi.Models.Projects.Proposals;
using ErpApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ErpApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProposalController: Controller
{
    private readonly IProposalRepository _proposalRepository;

    public ProposalController(IProposalRepository proposalRepository)
    {
        _proposalRepository = proposalRepository;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Proposal>))]
    public async Task<IActionResult> GetProposals()
    {
        try
        {
        var proposals =await _proposalRepository.GetAllProposalsAsync();
        var properties = proposals.GetType().GetProperties();
        foreach (var property in properties)
        {
            if(property.PropertyType == typeof(Action) || property.PropertyType.Name.Contains("Action"))
            {
                Console.WriteLine($"Non-serializable property found: {property}");
            }
        }
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        return Ok(proposals);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
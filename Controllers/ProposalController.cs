using ErpApi.Models.Projects.Proposals;
using ErpApi.Models.Projects;
using ErpApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ErpApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProposalController : Controller
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
            var proposals = await _proposalRepository.GetAllProposalsAsync();
            var properties = proposals.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(Action) || property.PropertyType.Name.Contains("Action"))
                {
                    Console.WriteLine($"Non-serializable property found: {property}");
                }
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(proposals);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(200, Type = typeof(Proposal))]
    public async Task<IActionResult> GetProposalById(int id)
    {
        try
        {
            var proposal = await _proposalRepository.GetProposalByIdAsync(id);
            if (proposal == null)
            {
                return NotFound();
            }
            return Ok(proposal);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet]
    [Route("proposalTypes")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<ProposalType>))]
    public async Task<IActionResult> GetProposalTypes()
    {
        try
        {
            var proposalTypes = await _proposalRepository.GetProposalTypesAsync();
            return Ok(proposalTypes);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet]
    [Route("projectTypes")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<ProjectType>))]
    public async Task<IActionResult> GetProjectTypes()
    {
        try
        {
            var projectTypes = await _proposalRepository.GetProjectTypesAsync();
            return Ok(projectTypes);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet]
    [Route("serviceTypes")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<ServiceType>))]
    public async Task<IActionResult> GetServiceTypes()
    {
        try
        {
            var serviceTypes = await _proposalRepository.GetServiceTypesAsync();
            return Ok(serviceTypes);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [HttpGet]
    [Route("serviceDeliverableCategories")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<ServiceDeliverableCategory>))]
    public async Task<IActionResult> GetServiceDeliverableCategories()
    {
        try
        {
            var serviceDeliverableCategories = await _proposalRepository.GetServiceDeliverableCategoriesAsync();
            return Ok(serviceDeliverableCategories);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}

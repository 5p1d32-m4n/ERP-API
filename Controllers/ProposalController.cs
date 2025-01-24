using ErpApi.Models.Projects.Proposals;
using ErpApi.Models.Projects.Projects;
using ErpApi.Models.Projects;
using ErpApi.Models.Business;
using ErpApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ErpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProposalController : Controller
    {
        private readonly IProposalRepository _proposalRepository;

        public ProposalController(IProposalRepository proposalRepository)
        {
            _proposalRepository = proposalRepository;
        }

        // Read Endpoints
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Proposal>))]
        public async Task<IActionResult> GetProposals()
        {
            var proposals = await _proposalRepository.GetAllProposalsAsync();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(proposals);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Proposal))]
        public async Task<IActionResult> GetProposalById(int id)
        {
            var proposal = await _proposalRepository.GetProposalByIdAsync(id);
            if (proposal == null)
                return NotFound();
            return Ok(proposal);
        }

        [HttpGet("proposalTypes")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProposalType>))]
        public async Task<IActionResult> GetProposalTypes()
        {
            var proposalTypes = await _proposalRepository.GetProposalTypesAsync();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(proposalTypes);
        }

        [HttpGet("projectTypes")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProjectType>))]
        public async Task<IActionResult> GetProjectTypes()
        {
            var projectTypes = await _proposalRepository.GetProjectTypesAsync();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(projectTypes);
        }

        [HttpGet("serviceTypes")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ServiceType>))]
        public async Task<IActionResult> GetServiceTypes()
        {
            var serviceTypes = await _proposalRepository.GetServiceTypesAsync();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(serviceTypes);
        }

        [HttpGet("complexities")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Complexity>))]
        public async Task<IActionResult> GetComplexities()
        {
            var complexities = await _proposalRepository.GetComplexitiesAsync();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(complexities);
        }

        [HttpGet("impacts")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Impact>))]
        public async Task<IActionResult> GetImpacts()
        {
            var impacts = await _proposalRepository.GetImpactsAsync();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(impacts);
        }

        [HttpGet("sectors")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Sector>))]
        public async Task<IActionResult> GetSectors()
        {
            var sectors = await _proposalRepository.GetSectorsAsync();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(sectors);
        }

        [HttpGet("sectorCategories")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SectorCategory>))]
        public async Task<IActionResult> GetSectorCategories()
        {
            var sectorCategories = await _proposalRepository.GetSectorCategoriesAsync();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(sectorCategories);
        }

        [HttpGet("serviceDeliverableCategories")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ServiceDeliverableCategory>))]
        public async Task<IActionResult> GetServiceDeliverableCategories()
        {
            var serviceDeliverableCategories = await _proposalRepository.GetServiceDeliverableCategoriesAsync();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(serviceDeliverableCategories);
        }

        [HttpGet("proposalStatuses")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProposalStatus>))]
        public async Task<IActionResult> GetProposalStatuses()
        {
            var proposalStatuses = await _proposalRepository.GetProposalStatusesAsync();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(proposalStatuses);
        }

        [HttpGet("statusOptions")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<StatusOption>))]
        public async Task<IActionResult> GetStatusOptions()
        {
            var statusOptions = await _proposalRepository.GetStatusOptionsAsync();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(statusOptions);
        }

        [HttpGet("proposalFormats")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProposalFormat>))]
        public async Task<IActionResult> GetProposalFormats()
        {
            var proposalFormats = await _proposalRepository.GetProposalFormatsAsync();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(proposalFormats);
        }

        [HttpGet("proposalResources")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProjectResource>))]
        public async Task<IActionResult> GetProposalResources()
        {
            var proposalResources = await _proposalRepository.GetProposalResourcesAsync();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(proposalResources);
        }

        [HttpGet("additionalCosts")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AdditionalCost>))]
        public async Task<IActionResult> GetAdditionalCosts()
        {
            var additionalCosts = await _proposalRepository.GetProposalAdditionalCostsAsync();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(additionalCosts);
        }

        // Create Endpoints
        [HttpPost("proposalType")]
        public async Task<IActionResult> InsertProposalType([FromBody] ProposalType proposalType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _proposalRepository.InsertProposalTypeAsync(proposalType);
            return Ok(id);
        }

        [HttpPost("projectType")]
        public async Task<IActionResult> InsertProjectType([FromBody] ProjectType projectType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _proposalRepository.InsertProjectTypeAsync(projectType);
            return Ok(id);
        }

        [HttpPost("serviceType")]
        public async Task<IActionResult> InsertServiceType([FromBody] ServiceType serviceType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _proposalRepository.InsertServiceTypeAsync(serviceType);
            return Ok(id);
        }

        [HttpPost("complexity")]
        public async Task<IActionResult> InsertComplexity([FromBody] Complexity complexity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _proposalRepository.InsertComplexityAsync(complexity);
            return Ok(id);
        }

        [HttpPost("impact")]
        public async Task<IActionResult> InsertImpact([FromBody] Impact impact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _proposalRepository.InsertImpactAsync(impact);
            return Ok(id);
        }

        [HttpPost("sector")]
        public async Task<IActionResult> InsertSector([FromBody] Sector sector)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _proposalRepository.InsertSectorAsync(sector);
            return Ok(id);
        }

        [HttpPost("sectorCategory")]
        public async Task<IActionResult> InsertSectorCategory([FromBody] SectorCategory sectorCategory)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _proposalRepository.InsertSectorCategoryAsync(sectorCategory);
            return Ok(id);
        }

        [HttpPost("serviceDeliverableCategory")]
        public async Task<IActionResult> InsertServiceDeliverableCategory([FromBody] ServiceDeliverableCategory serviceDeliverableCategory)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _proposalRepository.InsertServiceDeliverableCategoryAsync(serviceDeliverableCategory);
            return Ok(id);
        }

        [HttpPost("proposalStatus")]
        public async Task<IActionResult> InsertProposalStatus([FromBody] ProposalStatus proposalStatus)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _proposalRepository.InsertProposalStatusAsync(proposalStatus);
            return Ok(id);
        }

        [HttpPost("statusOption")]
        public async Task<IActionResult> InsertStatusOption([FromBody] StatusOption statusOption)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _proposalRepository.InsertStatusOptionAsync(statusOption);
            return Ok(id);
        }

        [HttpPost("proposalFormat")]
        public async Task<IActionResult> InsertProposalFormat([FromBody] ProposalFormat proposalFormat)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _proposalRepository.InsertProposalFormatAsync(proposalFormat);
            return Ok(id);
        }

        [HttpPost("proposalResource")]
        public async Task<IActionResult> InsertProposalResource([FromBody] ProjectResource proposalResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _proposalRepository.InsertProposalResourceAsync(proposalResource);
            return Ok(id);
        }

        [HttpPost("additionalCost")]
        public async Task<IActionResult> InsertAdditionalCost([FromBody] AdditionalCost additionalCost)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _proposalRepository.InsertAdditionalCostAsync(additionalCost);
            return Ok(id);
        }

        // Update Endpoints
        [HttpPut("proposalType")]
        public async Task<IActionResult> UpdateProposalType([FromBody] ProposalType proposalType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _proposalRepository.UpdateProposalTypeAsync(proposalType);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpPut("projectType")]
        public async Task<IActionResult> UpdateProjectType([FromBody] ProjectType projectType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _proposalRepository.UpdateProjectTypeAsync(projectType);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpPut("serviceType")]
        public async Task<IActionResult> UpdateServiceType([FromBody] ServiceType serviceType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _proposalRepository.UpdateServiceTypeAsync(serviceType);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpPut("complexity")]
        public async Task<IActionResult> UpdateComplexity([FromBody] Complexity complexity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _proposalRepository.UpdateComplexityAsync(complexity);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpPut("impact")]
        public async Task<IActionResult> UpdateImpact([FromBody] Impact impact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _proposalRepository.UpdateImpactAsync(impact);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpPut("sector")]
        public async Task<IActionResult> UpdateSector([FromBody] Sector sector)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _proposalRepository.UpdateSectorAsync(sector);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpPut("sectorCategory")]
        public async Task<IActionResult> UpdateSectorCategory([FromBody] SectorCategory sectorCategory)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _proposalRepository.UpdateSectorCategoryAsync(sectorCategory);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpPut("serviceDeliverableCategory")]
        public async Task<IActionResult> UpdateServiceDeliverableCategory([FromBody] ServiceDeliverableCategory serviceDeliverableCategory)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _proposalRepository.UpdateServiceDeliverableCategoryAsync(serviceDeliverableCategory);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpPut("proposalStatus")]
        public async Task<IActionResult> UpdateProposalStatus([FromBody] ProposalStatus proposalStatus)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _proposalRepository.UpdateProposalStatusAsync(proposalStatus);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpPut("statusOption")]
        public async Task<IActionResult> UpdateStatusOption([FromBody] StatusOption statusOption)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _proposalRepository.UpdateStatusOptionAsync(statusOption);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpPut("proposalFormat")]
        public async Task<IActionResult> UpdateProposalFormat([FromBody] ProposalFormat proposalFormat)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _proposalRepository.UpdateProposalFormatAsync(proposalFormat);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpPut("proposalResource")]
        public async Task<IActionResult> UpdateProposalResource([FromBody] ProjectResource proposalResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _proposalRepository.UpdateProposalResourceAsync(proposalResource);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpPut("additionalCost")]
        public async Task<IActionResult> UpdateAdditionalCost([FromBody] AdditionalCost additionalCost)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _proposalRepository.UpdateAdditionalCostAsync(additionalCost);
            if (!result)
                return NotFound();
            return Ok();
        }

        // Delete Endpoints
        [HttpDelete("proposalType/{id}")]
        public async Task<IActionResult> DeleteProposalType(int id)
        {
            var result = await _proposalRepository.DeleteProposalTypeAsync(id);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpDelete("projectType/{id}")]
        public async Task<IActionResult> DeleteProjectType(int id)
        {
            var result = await _proposalRepository.DeleteProjectTypeAsync(id);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpDelete("serviceType/{id}")]
        public async Task<IActionResult> DeleteServiceType(int id)
        {
            var result = await _proposalRepository.DeleteServiceTypeAsync(id);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpDelete("complexity/{id}")]
        public async Task<IActionResult> DeleteComplexity(int id)
        {
            var result = await _proposalRepository.DeleteComplexityAsync(id);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpDelete("impact/{id}")]
        public async Task<IActionResult> DeleteImpact(int id)
        {
            var result = await _proposalRepository.DeleteImpactAsync(id);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpDelete("sector/{id}")]
        public async Task<IActionResult> DeleteSector(int id)
        {
            var result = await _proposalRepository.DeleteSectorAsync(id);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpDelete("sectorCategory/{id}")]
        public async Task<IActionResult> DeleteSectorCategory(int id)
        {
            var result = await _proposalRepository.DeleteSectorCategoryAsync(id);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpDelete("serviceDeliverableCategory/{id}")]
        public async Task<IActionResult> DeleteServiceDeliverableCategory(int id)
        {
            var result = await _proposalRepository.DeleteServiceDeliverableCategoryAsync(id);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpDelete("proposalStatus/{id}")]
        public async Task<IActionResult> DeleteProposalStatus(int id)
        {
            var result = await _proposalRepository.DeleteProposalStatusAsync(id);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpDelete("statusOption/{id}")]
        public async Task<IActionResult> DeleteStatusOption(int id)
        {
            var result = await _proposalRepository.DeleteStatusOptionAsync(id);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpDelete("proposalFormat/{id}")]
        public async Task<IActionResult> DeleteProposalFormat(int id)
        {
            var result = await _proposalRepository.DeleteProposalFormatAsync(id);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpDelete("proposalResource/{id}")]
        public async Task<IActionResult> DeleteProposalResource(int id)
        {
            var result = await _proposalRepository.DeleteProposalResourceAsync(id);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpDelete("additionalCost/{id}")]
        public async Task<IActionResult> DeleteAdditionalCost(int id)
        {
            var result = await _proposalRepository.DeleteAdditionalCostAsync(id);
            if (!result)
                return NotFound();
            return Ok();
        }
    }
}
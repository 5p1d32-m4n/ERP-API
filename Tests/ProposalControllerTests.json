using ErpApi.Controllers;
using ErpApi.Interfaces;
using ErpApi.Models.Projects.Proposals;
using ErpApi.Models.Projects.Projects;
using ErpApi.Models.Projects;
using ErpApi.Models.Business;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ErpApi.Tests
{
    public class ProposalControllerTests
    {
        private readonly Mock<IProposalRepository> _mockRepo;
        private readonly ProposalController _controller;

        public ProposalControllerTests()
        {
            _mockRepo = new Mock<IProposalRepository>();
            _controller = new ProposalController(_mockRepo.Object);
        }

        // Read Endpoints
        [Fact]
        public async Task GetProposals_ReturnsOkResult_WithListOfProposals()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetAllProposalsAsync()).ReturnsAsync(new List<Proposal>());

            // Act
            var result = await _controller.GetProposals();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<Proposal>>(okResult.Value);
        }

        [Fact]
        public async Task GetProposalById_ReturnsOkResult_WithProposal()
        {
            // Arrange
            var proposalId = 1;
            _mockRepo.Setup(repo => repo.GetProposalByIdAsync(proposalId)).ReturnsAsync(new Proposal());

            // Act
            var result = await _controller.GetProposalById(proposalId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<Proposal>(okResult.Value);
        }

        [Fact]
        public async Task GetProposalById_ReturnsNotFoundResult_WhenProposalNotFound()
        {
            // Arrange
            var proposalId = 1;
            _mockRepo.Setup(repo => repo.GetProposalByIdAsync(proposalId)).ReturnsAsync((Proposal)null);

            // Act
            var result = await _controller.GetProposalById(proposalId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetProposalTypes_ReturnsOkResult_WithListOfProposalTypes()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetProposalTypesAsync()).ReturnsAsync(new List<ProposalType>());

            // Act
            var result = await _controller.GetProposalTypes();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<ProposalType>>(okResult.Value);
        }

        // Add similar tests for other read endpoints...

        // Create Endpoints
        [Fact]
        public async Task InsertProposalType_ReturnsOkResult_WithNewProposalTypeId()
        {
            // Arrange
            var proposalType = new ProposalType();
            _mockRepo.Setup(repo => repo.InsertProposalTypeAsync(proposalType)).ReturnsAsync(1);

            // Act
            var result = await _controller.InsertProposalType(proposalType);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(1, okResult.Value);
        }

        // Add similar tests for other create endpoints...

        // Update Endpoints
        [Fact]
        public async Task UpdateProposalType_ReturnsOkResult_WhenUpdateIsSuccessful()
        {
            // Arrange
            var proposalType = new ProposalType();
            _mockRepo.Setup(repo => repo.UpdateProposalTypeAsync(proposalType)).ReturnsAsync(true);

            // Act
            var result = await _controller.UpdateProposalType(proposalType);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task UpdateProposalType_ReturnsNotFoundResult_WhenUpdateFails()
        {
            // Arrange
            var proposalType = new ProposalType();
            _mockRepo.Setup(repo => repo.UpdateProposalTypeAsync(proposalType)).ReturnsAsync(false);

            // Act
            var result = await _controller.UpdateProposalType(proposalType);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        // Add similar tests for other update endpoints...

        // Delete Endpoints
        [Fact]
        public async Task DeleteProposalType_ReturnsOkResult_WhenDeleteIsSuccessful()
        {
            // Arrange
            var proposalTypeId = 1;
            _mockRepo.Setup(repo => repo.DeleteProposalTypeAsync(proposalTypeId)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteProposalType(proposalTypeId);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task DeleteProposalType_ReturnsNotFoundResult_WhenDeleteFails()
        {
            // Arrange
            var proposalTypeId = 1;
            _mockRepo.Setup(repo => repo.DeleteProposalTypeAsync(proposalTypeId)).ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteProposalType(proposalTypeId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteProposalResource_ReturnsOkResult_WhenDeleteIsSuccessful()
        {
            // Arrange
            var proposalResourceId = 1;
            _mockRepo.Setup(repo => repo.DeleteProposalResourceAsync(proposalResourceId)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteProposalResource(proposalResourceId);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task DeleteProposalResource_ReturnsNotFoundResult_WhenDeleteFails()
        {
            // Arrange
            var proposalResourceId = 1;
            _mockRepo.Setup(repo => repo.DeleteProposalResourceAsync(proposalResourceId)).ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteProposalResource(proposalResourceId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteAdditionalCost_ReturnsOkResult_WhenDeleteIsSuccessful()
        {
            // Arrange
            var additionalCostId = 1;
            _mockRepo.Setup(repo => repo.DeleteAdditionalCostAsync(additionalCostId)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteAdditionalCost(additionalCostId);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task DeleteAdditionalCost_ReturnsNotFoundResult_WhenDeleteFails()
        {
            // Arrange
            var additionalCostId = 1;
            _mockRepo.Setup(repo => repo.DeleteAdditionalCostAsync(additionalCostId)).ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteAdditionalCost(additionalCostId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        // Add similar tests for other delete endpoints...
    }
}
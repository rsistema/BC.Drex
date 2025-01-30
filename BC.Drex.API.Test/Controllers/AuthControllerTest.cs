using Moq;
using BC.Drex.API.Dtos;
using BC.Drex.API.Controllers;
using BC.Drex.API.Dtos.Auth;
using Microsoft.AspNetCore.Mvc;
using BC.Drex.API.AppServices.Interfaces;

namespace BC.Drex.API.Test.Controllers
{
    public class AuthControllerTest
    {
        private readonly Mock<IAuthAppService> _mockAuthAppService;
        private readonly AuthController _controller;

        public AuthControllerTest()
        {
            _mockAuthAppService = new Mock<IAuthAppService>();
            _controller = new AuthController(_mockAuthAppService.Object);
        }

        [Fact]
        public async Task RegisterAsync_ReturnsOkResult()
        {
            // Arrange
            var request = new RegisterRequest { Name = "Mock User", Password = "mock@2025", Email = "mock@bc.com.br" };
            var result = new ResultResponse<string> { Success = true };
            _mockAuthAppService.Setup(service => service.RegisterAsync(request)).ReturnsAsync(result);

            // Act
            var response = await _controller.RegisterAsync(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(response);
            Assert.Equal(result, okResult.Value);
        }

        [Fact]
        public async Task RegisterAsync_ReturnsBadRequestResult()
        {
            // Arrange
            var request = new RegisterRequest { Name = "Mock User", Password = "Mock@2025", Email = "mock@bc.com.br" };
            var result = new ResultResponse<string> { Success = false };
            _mockAuthAppService.Setup(service => service.RegisterAsync(request)).ReturnsAsync(result);

            // Act
            var response = await _controller.RegisterAsync(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(response);
            Assert.Equal(result, badRequestResult.Value);
        }

        [Fact]
        public async Task LoginAsync_ReturnsOkResult()
        {
            // Arrange
            var request = new LoginRequest { Email = "mock@bc.com.br", Password = "mock@2025" };
            var token = "testtoken";
            _mockAuthAppService.Setup(service => service.LoginAsync(request)).ReturnsAsync(token);

            // Act
            var response = await _controller.LoginAsync(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task LoginAsync_ReturnsBadRequestResult()
        {
            // Arrange
            var request = new LoginRequest { Email = "mock@bc.com.br", Password = "mcok@2025" };
            _mockAuthAppService.Setup(service => service.LoginAsync(request)).ReturnsAsync((string)null!);

            // Act
            var response = await _controller.LoginAsync(request);

            // Assert
            Assert.IsType<BadRequestResult>(response);
        }
    }
}


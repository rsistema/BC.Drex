using Moq;
using Xunit;
using System.Threading.Tasks;
using BC.Drex.API.Controllers;
using BC.Drex.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BC.Drex.API.AppServices.Interfaces;
using BC.Drex.API.Dtos.User;
using BC.Drex.API.Dtos;

namespace BC.Drex.API.Test.Controllers
{
    public class UserControllerTest
    {
        private readonly Mock<IUserAppService> _mockUserAppService;
        private readonly UserController _controller;

        public UserControllerTest()
        {
            _mockUserAppService = new Mock<IUserAppService>();
            _controller = new UserController(_mockUserAppService.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsOkResult()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var user = new UserResponse { UserId = userId, Name = "Test User", Email = "test@bc.com.br", Created = DateTime.Now, Changed = DateTime.Now };
            var resultResponse = new ResultResponse<UserResponse> { Data = user, Success = true };
            _mockUserAppService.Setup(service => service.GetUserByIdAsync(userId)).ReturnsAsync(resultResponse);

            // Act
            var result = await _controller.GetByIdAsync(userId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedResponse = Assert.IsType<UserResponse>(okResult.Value);
            Assert.Equal(userId, returnedResponse.UserId);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsNotFoundResult_WhenUserNotFound()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var resultResponse = new ResultResponse<UserResponse> { Success = false };
            _mockUserAppService.Setup(service => service.GetUserByIdAsync(userId)).ReturnsAsync(resultResponse);

            // Act
            var result = await _controller.GetByIdAsync(userId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsOkResult_WithListOfUsers()
        {
            // Arrange
            var users = new List<UserResponse>
            {
                new UserResponse { UserId = Guid.NewGuid(), Name = "Test User 1", Email = "test1@bc.com.br", Created = DateTime.Now, Changed = DateTime.Now },
                new UserResponse { UserId = Guid.NewGuid(), Name = "Test User 2", Email = "test2@bc.com.br", Created = DateTime.Now, Changed = DateTime.Now }
            };
            var resultResponse = new ResultResponse<IEnumerable<UserResponse>> { Data = users, Success = true };
            _mockUserAppService.Setup(service => service.GetAllUsersAsync()).ReturnsAsync(resultResponse);

            // Act
            var result = await _controller.GetAllAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedResponse = Assert.IsType<ResultResponse<IEnumerable<UserResponse>>>(okResult.Value);
            Assert.Equal(users.Count, returnedResponse.Data.Count());
        }

        [Fact]
        public async Task GetAllAsync_ReturnsNoContentResult_WhenNoUsersFound()
        {
            // Arrange
            var resultResponse = new ResultResponse<IEnumerable<UserResponse>> { Success = false };
            _mockUserAppService.Setup(service => service.GetAllUsersAsync()).ReturnsAsync(resultResponse);

            // Act
            var result = await _controller.GetAllAsync();

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsOkResult()
        {
            // Arrange
            var userRequest = new UserRequest { UserId = Guid.NewGuid(), Name = "Updated User" };
            var resultResponse = new ResultResponse<UserResponse> { Success = true };
            _mockUserAppService.Setup(service => service.UpdateUserAsync(userRequest)).ReturnsAsync(resultResponse);

            // Act
            var result = await _controller.UpdateAsync(userRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(resultResponse, okResult.Value);
        }

        [Fact]
        public async Task UpdateAsync_ReturnsBadRequestResult()
        {
            // Arrange
            var userRequest = new UserRequest { UserId = Guid.NewGuid(), Name = "Updated User" };
            var resultResponse = new ResultResponse<UserResponse> { Success = false };
            _mockUserAppService.Setup(service => service.UpdateUserAsync(userRequest)).ReturnsAsync(resultResponse);

            // Act
            var result = await _controller.UpdateAsync(userRequest);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(resultResponse, badRequestResult.Value);
        }
    }
}
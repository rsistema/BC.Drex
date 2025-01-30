using System.Text;
using System.Security.Claims;
using BC.Drex.Domain.Entities;
using BC.Drex.Domain.Interfaces.Repositories;
using BC.Drex.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace BC.Drex.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _repository;
        private readonly IConfiguration _configuration;
        public AuthService(IUserRepository repository, IConfiguration configuration)
        {
            _repository = repository;   
            _configuration = configuration;
        }

        public async Task<ServiceResult<string>> RegisterAsync(string name, string email, string password)
        {
            try
            {
                var exists = await _repository.GetByEmail(email);
                if (exists)
                    return ServiceResult<string>.FailureResult("User already exists.");

                var user = new User
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Email = email,
                    Password = BCrypt.Net.BCrypt.HashPassword(password)
                };
                await _repository.AddAsync(user);
                var token = GenerateJwtToken(user);
                return ServiceResult<string>.SuccessResult("User created.");
            }
            catch (Exception ex)
            {
                return ServiceResult<string>.FailureResult($"Error, {ex.Message}");
            }
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var user = await _repository.FindAsync(u => u.Email == email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }
            return GenerateJwtToken(user);
        }

        private string GenerateJwtToken(User user)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("UserId", user.Id.ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(30),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}


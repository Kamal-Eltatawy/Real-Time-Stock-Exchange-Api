using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApplicationService.Services.TokkenServices
{
    public class TokkenServices : ITokkenServices
    {
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;

        public TokkenServices(UserManager<User> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;

        }

        public async Task<string> CreateJwtToken(User user)
        {
           
            var userClaims = await userManager.GetClaimsAsync(user);
            var roles = await userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();
            if (roles is not null)
            {


                foreach (var role in roles)
                    roleClaims.Add(new Claim("roles", role));
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.NameId,user.Id ),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            }
            .Union(userClaims);
            if (roleClaims.Any())
            {
                claims = claims
               .Union(roleClaims);
            }

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: configuration["JWT:Issuer"],
                audience: configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(Convert.ToDouble(configuration["JWT:DurationInHours"])),
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Domain.DTO;
using Domain.Entities;
using ApplicationService.Services.TokkenServices;

namespace ApplicationService.Services.AuthServices
{
    public class AuthServices : IAuthServices
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;
        private readonly ITokkenServices tokkenServices;
        private readonly IMapper mapper;

        public AuthServices(UserManager<User> userManager, RoleManager<IdentityRole> roleManager ,  IConfiguration configuration, ITokkenServices tokkenServices, IMapper mapper)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
            this.tokkenServices = tokkenServices;
            this.mapper = mapper;
        }

        public async Task<LoginResponse> LoginAsync(LoginModel loginModel)
        {

            var user = await userManager.FindByEmailAsync(loginModel.Email);
            if (user is null)
            {

                return new LoginResponse
                {
                    Message = "Email IS Not Exists"
                };
            }

            if (!userManager.CheckPasswordAsync(user, loginModel.Password).Result)
            {
                return new LoginResponse
                {
                    Message = "Password Is Not Correct"
                };
            }

            return new LoginResponse
            {
                Email = loginModel.Email,
                ExpireDate = DateTime.Today.AddDays(Convert.ToDouble(configuration["JWT:DurationInDays"])),
                IsAuthenticated = true,
                Message = "Logged In",
                Roles = userManager.GetRolesAsync(user).Result.ToList(),
                Tokken = tokkenServices.CreateJwtToken(user).Result

            };



        }

        public async Task<AuthModel> RegisterAsync(RegisterModel registerModel)
        {
            var errors = string.Empty;

            if (userManager.FindByEmailAsync(registerModel.Email).Result is not null)
            {
                return new AuthModel { Message = " Email IS Already Exists", };
            }

            if (userManager.FindByNameAsync(registerModel.UserName).Result is not null)
            {
                return new AuthModel { Message = " UserName IS Already Exists", };
            }
            foreach (var role in registerModel.Roles)
            {
                if ( await roleManager.FindByNameAsync(role) is null)
                {
                    return new AuthModel { Message = $" Role {role} IS Not Exists", };
                }
            }

            var user = mapper.Map<User>(registerModel);

            var result = await userManager.CreateAsync(user, registerModel.Password);
            if (!result.Succeeded)
            {
                return new AuthModel { Message = WriteEroors(errors, result) };
            }

            var roleResult = await userManager.AddToRolesAsync(user, registerModel.Roles);
            if (!roleResult.Succeeded)
            {
                return new AuthModel { Message = WriteEroors(errors, roleResult) };
            }

            return new AuthModel
            {
                Email = registerModel.Email,
                ExpireDate = DateTime.Today.AddDays(Convert.ToDouble(configuration["JWT:DurationInDays"])),
                IsAuthenticated = true,
                Message = "Created",
                Roles = (await userManager.GetRolesAsync(user)).ToList(),
                UserName = registerModel.UserName,
                Tokken = await tokkenServices.CreateJwtToken(user)
            };
        }



        private string WriteEroors(string eroorMessage, IdentityResult identityResult)
        {
            foreach (var eroor in identityResult.Errors)
            {
                eroorMessage += $"{eroor.Description},";
            }
            return eroorMessage;
        }
    }
}

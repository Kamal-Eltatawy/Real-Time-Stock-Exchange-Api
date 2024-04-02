using Domain.Entities;

namespace ApplicationService.Services.TokkenServices
{
    public interface ITokkenServices
    {
        public Task<string> CreateJwtToken(User user);

    }
}

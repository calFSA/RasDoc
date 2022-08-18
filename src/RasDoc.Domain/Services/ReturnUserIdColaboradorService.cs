using Microsoft.AspNetCore.Identity;
using RasDoc.Domain.Interfaces;

namespace RasDoc.Domain.Services
{
    public class ReturnUserIdColaboradorService : IReturnUserIdColaboradorService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ReturnUserIdColaboradorService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public Task<bool> HasUserColaborador(Guid id)
        {
            var user = _userManager.Users.Where(x => x.Id.ToUpper() == id.ToString().ToUpper()).ToList();

            return Task.FromResult(user.Count > 0);
        }
    }
}

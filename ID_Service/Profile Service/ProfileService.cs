using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using ID_Service.Model;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ID_Service.Profile_Service
{
    public class ProfileService : IProfileService
    {
        protected UserManager<User> _userManager;

        public ProfileService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }


        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            try
            {

                var transaction = context.RequestedResources.ParsedScopes.FirstOrDefault(x => x.ParsedName == "transaction");
                if (transaction?.ParsedParameter != null)
                {
                    context.IssuedClaims.Add(new Claim("transaction_id", transaction.ParsedParameter));
                }
                var user = await _userManager.GetUserAsync(context.Subject);

                var claims = new List<Claim>();

                if (user.ID != null)
                    claims.Add(new Claim(JwtClaimTypes.Id, user.ID));

                if (user.Role != null)
                    claims.Add(new Claim(JwtClaimTypes.Role, user.Role));

                var accesstokenClaim = context.Subject.Claims.FirstOrDefault(e => e.Type == "accesstoken");
                if (accesstokenClaim != null)
                {
                    string Value = accesstokenClaim.Value;
                    if (accesstokenClaim != null)
                    {
                        claims.Add(new Claim("accesstoken", accesstokenClaim.Value));
                    }
                }


                context.IssuedClaims.AddRange(claims);

                //return Task.FromResult(0);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        //public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        //{
        //    var user = await _userManager.GetUserAsync(context.Subject);
        //    var accesstokenClaim123 = context.Subject.Claims.FirstOrDefault(e => e.Type == "accesstoken");



        //}

        public async Task IsActiveAsync(IsActiveContext context)
        {
            //>Processing
            var user = await _userManager.GetUserAsync(context.Subject);

            context.IsActive = (user != null) && user.IsActive.Value;
        }
    }
}

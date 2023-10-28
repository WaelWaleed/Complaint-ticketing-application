using Duende.IdentityServer.Test;
using Duende.IdentityServer;
using IdentityModel;
using System.Security.Claims;
using System.Text.Json;
using Microsoft.AspNetCore.Identity;

namespace ID_Service.Model
{
    public class User:TestUser
    {
        public string? ID { get; set; }
        public string? Role { get; set; }
        public bool? IsActive { get; set; }
        public static List<TestUser> Users
        {
            get
            {

                return new List<TestUser>
                {
                    new User
                    {
                        ID = "1",
                        Role = "Admin",
                        IsActive = true,
                        SubjectId = "818727",
                        Username = "Admin",
                        Password = "Admin_123",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Id, "1"),
                            new Claim(JwtClaimTypes.Name, "Admin Admin"),
                            new Claim(JwtClaimTypes.GivenName, "Admin"),
                            new Claim(JwtClaimTypes.FamilyName, "Admin"),
                            new Claim(JwtClaimTypes.Email, "Admin@example.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        }
                    },
                    new User
                    {
                        ID = "2",
                        Role = "User",
                        IsActive = true,
                        SubjectId = "88421113",
                        Username = "User",
                        Password = "User_123",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "User User"),
                            new Claim(JwtClaimTypes.GivenName, "User"),
                            new Claim(JwtClaimTypes.FamilyName, "User"),
                            new Claim(JwtClaimTypes.Email, "User@example.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        }
                    }
                };
            }
        }
    }
}

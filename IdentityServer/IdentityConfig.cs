using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace ApiServer
{
    public static class IdentityConfig
    {
        public static List<TestUser> GetTestUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "alice",
                    Password = "password",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Alice Cooper"),
                        new Claim(JwtClaimTypes.Email, "alice.cooper@example.org")
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "bob",
                    Password = "password",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Bob Dylan")
                    }
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            yield return new ApiResource("api1", "My API", new List<string>
            {
                JwtClaimTypes.Name,
                JwtClaimTypes.Email
            });
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            yield return new IdentityResources.OpenId();
            yield return new IdentityResources.Profile();
        }

        public static IEnumerable<Client> GetClients()
        {
            yield return new Client
            {
                ClientId = "client",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = {"api1"}
            };

            yield return new Client
            {
                ClientId = "ro.client",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },

                AllowedScopes = {"api1", "openid", "profile"}
            };
        }
    }
}

using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfDotnet.IdentitySrv
{
    public class Config
    {
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId="1",
                    Username="Ashraf",
                    Password="password"
                },
                new TestUser
                {
                    SubjectId="2",
                    Username="Zaman",
                    Password="password"
                }
            };
        }

        public static IEnumerable<ApiResource> GetAllApiResources()
        {
            return new List<ApiResource>
            {
            new ApiResource("bankOfDotnetApi","Customer Api for BankOfDotnet")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
              new  Client
              {
                  ClientId="Client",
                  AllowedGrantTypes= GrantTypes.ClientCredentials,
                  ClientSecrets=
                  {
                  new Secret("Secret".Sha256())
                  },
                  AllowedScopes={ "bankOfDotnetApi" }
              },

              new  Client
              {
                  ClientId="ro.Client",
                  AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,
                  ClientSecrets=
                  {
                  new Secret("Secret".Sha256())
                  },
                  AllowedScopes={ "bankOfDotnetApi" }
              }
            };
        }
    }
}

using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankOfDotnet.IdentitySrv
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetAllApiResources()
        {
            return new List<ApiResource>
            {
            new ApiResource("bankOfDotnet","Customer Api for BankOfDotnet")
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
                  AllowedScopes={ "bankOfDotnet" }
              }
            };
        }
    }
}

﻿using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extension
{
    public static class ClaimExtensions
    {
        public static void AddNameIdentitfier(this ICollection<Claim> claims, string nameIdentitfier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentitfier));
        }

        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email,email));
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role=>claims.Add(new Claim(ClaimTypes.Role, role)));
        }

        public static void AddStore(this ICollection<Claim> claims, string store)
        {
            claims.Add(new Claim(ClaimTypes.Anonymous, store));
        }

    }
}

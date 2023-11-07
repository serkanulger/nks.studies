﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace nks.core.Security;

public static class ClaimExtensions
{
    public static void AddEmail(this ICollection<Claim> claims, string email)
    {
        // claims.Add(new Claim(ClaimTypes.Email,email));
        claims.Add(new Claim(JwtRegisteredClaimNames.Email,email));
    }

    public static void AddName(this ICollection<Claim> claims, string name)
    {
        // claims.Add(new Claim(ClaimTypes.Name,name));
        claims.Add(new Claim(JwtRegisteredClaimNames.Name, name));
    }

    public static void AddSurname(this ICollection<Claim> claims, string name)
    {
        // claims.Add(new Claim(ClaimTypes.Surname,name));
        claims.Add(new Claim(JwtRegisteredClaimNames.FamilyName, name));
    }

    public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
    {
        claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
    }

    public static void AddRoles(this ICollection<Claim> claims, string[] roles)
    {
        roles.ToList().ForEach(role=>claims.Add(new Claim(ClaimTypes.Role, role)));
    }
}

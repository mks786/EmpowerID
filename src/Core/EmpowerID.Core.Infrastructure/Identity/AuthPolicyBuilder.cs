﻿namespace EmpowerID.Core.Infrastructure.Identity;

public static class AuthPolicyBuilder
{
    public static AuthorizationPolicy M2MAccess =>
        new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .RequireClaim("scope", "EmpowerID-api.scope")
            .Build();

    public static AuthorizationPolicy CanRead =>
        new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .RequireClaim("scope", "read")
            .Build();

    public static AuthorizationPolicy CanWrite =>
        new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .RequireClaim("scope", "write")
            .Build();

    public static AuthorizationPolicy CanDelete =>
        new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .RequireClaim("scope", "delete")
            .Build();
}

using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

public abstract class AdministratorHandler : AuthorizationHandler<AdministratorRequirment>
{


    protected abstract Task HandleRequirmentAsync(AuthorizationHandlerContext context, AdministratorRequirment requirment);
}
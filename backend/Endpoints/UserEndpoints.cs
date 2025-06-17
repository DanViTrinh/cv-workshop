using backend.Data.Mappers;
using backend.Data.Requests;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this WebApplication app)
    {
        // GET /users
        app.MapGet(
                "/users",
                async (ICvService cvService) =>
                {
                    var users = await cvService.GetAllUsersAsync();
                    var userDtos = users.Select(u => u.ToDto()).ToList();

                    return Results.Ok(userDtos);
                }
            )
            .WithName("GetAllUsers")
            .WithTags("Users");

        // GET /users/{id}
        app.MapGet(
            "/users/{id}",
            async (string id, ICvService cvService) =>
            {
                var user = await cvService.GetUserByIdAsync(Guid.Parse(id.ToString()));
                if (user == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(user.ToDto());
            }
        )
        .WithName("GetUserById")
        .WithTags("Users");

        // Retrieve all cvs that include any of the wanted skills
        app.MapPost(
                "/users/skills",
                async () =>
                {
                    // TODO: Oppgave 4
                    return Results.Ok();
                }
            )
            .WithName("GetUsersWithDesiredSkill")
            .WithTags("Users");
    }
}

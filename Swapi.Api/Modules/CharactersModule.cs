using Microsoft.AspNetCore.Http.HttpResults;
using SWapi.Data.Models;
using SWapi.Services.Interfaces;

namespace SWapi.Api.Modules;

public static partial class Modules
{
    // Search Fields:
    //
    // name

    public static RouteGroupBuilder CharactersModule(this RouteGroupBuilder group)
    {
        group
            .MapGet(
                "/{id}",
                async (IPersonService personService, int id) =>
                {
                    var res = await personService.GetById(id);
                    return res is null ? Results.NotFound() : Results.Ok(res);
                }
            )
            .Produces<Ok<Person>>()
            .Produces(StatusCodes.Status404NotFound);

        group
            .MapGet(
                "/search/{name}",
                async (IPersonService personService, string name) =>
                {
                    var res = await personService.GetByName(name);

                    return !res.Any() ? Results.NotFound() : Results.Ok(res);
                }
            )
            .Produces<Ok<IEnumerable<Person>>>()
            .Produces(StatusCodes.Status404NotFound);

        group
            .MapPut(
                "/{id}",
                async (IPersonService personService, int id, Person person) =>
                {
                    try
                    {
                        await personService.UpdatePerson(id, person);
                    }
                    catch (Exception ex)
                    {
                        //_logger.log(exception)
                        return Results.BadRequest(ex.Message);
                    }

                    return Results.NoContent();
                }
            )
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest);

        group
            .MapPost(
                "/person",
                async (IPersonService personService, Person person) =>
                {
                    try
                    {
                        var createdPerson = await personService.CreatePerson(person);

                        return Results.Created($"/api/person/{createdPerson.Id}", createdPerson);
                    }
                    catch (Exception ex)
                    {
                        //_logger.log(exception)
                        return Results.BadRequest(ex.Message);
                    }
                }
            )
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

        return group;
    }
}

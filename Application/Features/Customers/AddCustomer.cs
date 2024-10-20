using API.Abstractions;
using Carter;
using Domain.Models.Customers;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Qowaiv;

namespace Application.Features.Customers;

public sealed class Endpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("customers", async (AddCustomer command, ISender sender) =>
        {
            return Results.Ok(await sender.Send(command));
        });
    }
}

public record AddCustomer : ICommand<CustomerId>
{
    public required CustomerName Name { get; init; }
    public required EmailAddress EmailAddress { get; init; }
}

public sealed class AddCustomerHandler : ICommandHandler<AddCustomer, CustomerId>
{
    public Task<CustomerId> Handle(AddCustomer request, CancellationToken cancellationToken)
    {
        Customer.AddCustomer(request.Name, request.EmailAddress);
    }
}
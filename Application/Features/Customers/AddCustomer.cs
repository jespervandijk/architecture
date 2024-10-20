using API.Abstractions;
using Carter;
using Domain.Models.Customers;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Application.Features.Customers;

public sealed class Endpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("customers", async (AddCustomer command, ISender sender) =>
        {
            var customerId = await sender.Send(command);

            return Results.Ok(customerId);
        });
    }
}

public class AddCustomer : ICommand<CustomerId>
{
    
}

public sealed class AddCustomerHandler : ICommandHandler<AddCustomer, CustomerId>
{
    public Task<CustomerId> Handle(AddCustomer request, CancellationToken cancellationToken)
    {
        Customer.
    }
}
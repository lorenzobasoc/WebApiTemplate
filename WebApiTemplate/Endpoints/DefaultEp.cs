using WebApiTemplate.Constants;
using WebApiTemplate.Endpoints.Requests;

namespace WebApiTemplate.Endpoints;

public class DefaultEp : Endpoint<DefaultReq, DefaultRes>
{
    public override void Configure() {
        Get(ApiRoutes.DefaultRoute);
        AllowAnonymous();
    }

    public override async Task HandleAsync(DefaultReq req, CancellationToken ct) {
        await SendAsync(new DefaultRes(), cancellation: ct);
    }
}
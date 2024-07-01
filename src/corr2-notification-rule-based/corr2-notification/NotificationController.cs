using Corr2.Notification.PoC.Messaging.SignalR.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Corr2.Notification.PoC;

[ApiController]
[Route("api/[controller]")]
public class NotificationController(IHubContext<NotificationHub> hubContext) : ControllerBase
{
    [HttpPost("send")]
    public async Task<IActionResult> SendNotification([FromBody] string message)
    {
        // Send the message to all connected clients for now but in real case we have to send it to a specific user group which is identified by the tenant id
        await hubContext.Clients.All.SendAsync(Constants.SignalR.ReceiveNotification, message);
        return Ok();
    }
}

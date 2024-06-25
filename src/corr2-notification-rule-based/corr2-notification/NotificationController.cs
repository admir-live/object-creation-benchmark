using corr2_notification.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace corr2_notification;

[ApiController]
[Route("api/[controller]")]
public class NotificationController(IHubContext<NotificationHub> hubContext) : ControllerBase
{
    [HttpPost("send")]
    public async Task<IActionResult> SendNotification([FromBody] string message)
    {
        await hubContext.Clients.All.SendAsync("ReceiveNotification", message);
        return Ok();
    }
}

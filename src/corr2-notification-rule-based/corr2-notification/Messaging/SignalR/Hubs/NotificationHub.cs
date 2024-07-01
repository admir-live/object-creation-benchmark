using Microsoft.AspNetCore.SignalR;

namespace Corr2.Notification.PoC.Messaging.SignalR.Hubs;

public class NotificationHub : Hub, INotificationHub
{
    public override Task OnConnectedAsync()
    {
        // Add the connection to the group of the tenant id and user id
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        // Remove the connection from the group of the tenant id and user id
        return base.OnDisconnectedAsync(exception);
    }
}

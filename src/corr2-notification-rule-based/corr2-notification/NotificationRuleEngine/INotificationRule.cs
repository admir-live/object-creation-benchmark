using Corr2.Notification.PoC.Entities;

namespace Corr2.Notification.PoC.NotificationRuleEngine;

public interface INotificationRule
{
    bool IsSatisfiedBy(Result result);
    string GetMessage(Result result);
}

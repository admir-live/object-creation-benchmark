using Corr2.Notification.PoC.Entities;

namespace Corr2.Notification.PoC.NotificationRuleEngine;

public class NotificationRuleEngine
{
    private readonly List<INotificationRule> _rules = [];

    public void AddRule(INotificationRule rule)
    {
        _rules.Add(rule);
    }

    public List<string> Evaluate(Result result)
    {
        return (from rule in _rules where rule.IsSatisfiedBy(result) select rule.GetMessage(result)).ToList();
    }
}

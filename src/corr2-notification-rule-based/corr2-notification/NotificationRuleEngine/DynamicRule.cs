using System.Globalization;
using Corr2.Notification.PoC.Entities;
using NCalc;

namespace Corr2.Notification.PoC.NotificationRuleEngine;

public class DynamicRule(string expressionString, string messageTemplate) : INotificationRule
{
    public bool IsSatisfiedBy(Result result)
    {
        Expression expression = new(expressionString)
        {
            Parameters =
            {
                ["QntResult"] = result.QntResult,
                ["QltResult"] = result.QltResult,
                ["Customer"] = result.Customer,
                ["SampleForm"] = result.SampleForm,
                ["SampleType"] = result.SampleType,
                ["Test"] = result.Test,
                ["IsSuccess"] = result.IsSuccess
            }
        };
        return (bool)expression.Evaluate();
    }

    public string GetMessage(Result result)
    {
        return messageTemplate
            .Replace("{QntResult}", result.QntResult.ToString(CultureInfo.InvariantCulture))
            .Replace("{QltResult}", result.QltResult.ToString(CultureInfo.InvariantCulture))
            .Replace("{Customer}", result.Customer)
            .Replace("{SampleForm}", result.SampleForm)
            .Replace("{SampleType}", result.SampleType)
            .Replace("{Test}", result.Test)
            .Replace("{IsSuccess}", result.IsSuccess.ToString());
    }
}

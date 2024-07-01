namespace Corr2.Notification.PoC.Entities;

public class NotificationCriteria
{
    public Guid Id { get; set; }
    public string Expression { get; set; }
    public bool IsActive { get; set; }
    public string MessageTemplate { get; set; }
    public Guid TemplateId { get; set; }
    public NotificationTemplate Template { get; set; }

    public class Builder
    {
        private readonly NotificationCriteria _criteria = new();

        public Builder WithId(Guid id)
        {
            _criteria.Id = id;
            return this;
        }

        public Builder WithExpression(string expression)
        {
            _criteria.Expression = expression;
            return this;
        }

        public Builder WithIsActive(bool isActive)
        {
            _criteria.IsActive = isActive;
            return this;
        }

        public Builder WithMessageTemplate(string messageTemplate)
        {
            _criteria.MessageTemplate = messageTemplate;
            return this;
        }

        public Builder WithTemplateId(Guid templateId)
        {
            _criteria.TemplateId = templateId;
            return this;
        }

        public NotificationCriteria Build()
        {
            return _criteria;
        }
    }
}

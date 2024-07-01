namespace Corr2.Notification.PoC.Entities;

public class NotificationTemplate
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<NotificationCriteria> Criteria { get; set; } = [];
    public User Recipient { get; set; } = new();
    public Guid RecipientId { get; set; }

    public class Builder
    {
        private readonly NotificationTemplate _template = new();

        public Builder WithId(Guid id)
        {
            _template.Id = id;
            return this;
        }

        public Builder WithName(string name)
        {
            _template.Name = name;
            return this;
        }

        public Builder WithCriteria(List<NotificationCriteria> criteria)
        {
            _template.Criteria = criteria;
            return this;
        }

        public Builder WithRecipients(User recipient)
        {
            _template.Recipient = recipient;
            return this;
        }

        public NotificationTemplate Build()
        {
            return _template;
        }
    }
}

namespace Corr2.Notification.PoC.Entities;

public class Notification
{
    public Guid Id { get; set; }
    public User User { get; set; }
    public NotificationTemplate Template { get; set; }
    public string Message { get; set; }
    public bool IsSent { get; set; }
    public DateTime Timestamp { get; set; }
    public Dictionary<string, string> Tokens { get; set; } = new();

    public class Builder
    {
        private readonly Notification _notification = new();

        public Builder WithId(Guid id)
        {
            _notification.Id = id;
            return this;
        }

        public Builder WithUser(User user)
        {
            _notification.User = user;
            return this;
        }

        public Builder WithTemplate(NotificationTemplate template)
        {
            _notification.Template = template;
            return this;
        }

        public Builder WithMessage(string message)
        {
            _notification.Message = message;
            return this;
        }

        public Builder WithIsSent(bool isSent)
        {
            _notification.IsSent = isSent;
            return this;
        }

        public Builder WithTimestamp(DateTime timestamp)
        {
            _notification.Timestamp = timestamp;
            return this;
        }

        public Builder WithTokens(Dictionary<string, string> tokens)
        {
            _notification.Tokens = tokens;
            return this;
        }

        public Notification Build()
        {
            return _notification;
        }
    }
}

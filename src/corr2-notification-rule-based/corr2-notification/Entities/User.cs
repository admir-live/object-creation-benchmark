namespace Corr2.Notification.PoC.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public List<NotificationTemplate> NotificationTemplates { get; set; } = [];

    public class Builder
    {
        private readonly User _user = new();

        public Builder WithId(Guid id)
        {
            _user.Id = id;
            return this;
        }

        public Builder WithUsername(string username)
        {
            _user.Username = username;
            return this;
        }

        public Builder WithEmail(string email)
        {
            _user.Email = email;
            return this;
        }

        public Builder WithNotificationTemplates(List<NotificationTemplate> templates)
        {
            _user.NotificationTemplates = templates;
            return this;
        }

        public User Build()
        {
            return _user;
        }
    }
}

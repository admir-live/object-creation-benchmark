using Corr2.Notification.PoC.Entities;

namespace Corr2.Notification.PoC.Infrastructure.Seed;

public static class SeedData
{
    public static IEnumerable<User> Users => new List<User>
    {
        new()
        {
            Id = new Guid("BA55E946-BF02-4740-9677-647AC552C16B"),
            Username = "john_doe",
            Email = "john.doe@example.com",
            NotificationTemplates =
            [
                new NotificationTemplate
                {
                    Id = new Guid("2CE41A3E-685F-4F80-84F1-65A7DB7D7FA1"),
                    Name = "John's Alerts",
                    Criteria =
                    [
                        new NotificationCriteria
                        {
                            Id = new Guid("14D2DDA8-E1D7-4A84-89B6-D226AFCD700F"),
                            Expression = "(QntResult > 50 && Test == 'positive') || (IsSuccess == true)",
                            IsActive = true,
                            MessageTemplate = "Alert: Quantity result is {QntResult}, and test is {Test}. Success: {IsSuccess}."
                        },

                        new NotificationCriteria
                        {
                            Id = new Guid("3257585A-8CED-46FB-94E7-FC4E7D5C09B3"),
                            Expression = "SampleType == 'Blood' && QltResult > 0.8",
                            IsActive = true,
                            MessageTemplate = "Blood sample quality is high: {QltResult}."
                        },

                        new NotificationCriteria
                        {
                            Id = new Guid("CA87EF5D-7C32-46F9-9910-8D077A62DFCB"),
                            Expression = "SampleForm == 'Liquid' && QntResult >= 30",
                            IsActive = true,
                            MessageTemplate = "Liquid sample quantity meets the threshold: {QntResult}."
                        }
                    ]
                }
            ]
        },
        new()
        {
            Id = new Guid("3895B00A-9E54-4B48-8196-349691938E9B"),
            Username = "jane_smith",
            Email = "jane.smith@example.com",
            NotificationTemplates =
            [
                new NotificationTemplate
                {
                    Id = new Guid("DEFAE825-1ACB-4A03-9BBE-FB65050976DC"),
                    Name = "Jane's Notifications",
                    Criteria =
                    [
                        new NotificationCriteria
                        {
                            Id = new Guid("0FE2D3C5-AC7D-45D1-AE11-A6A875F36E6D"),
                            Expression = "QntResult < 20 || (IsSuccess == false && Test == 'negative')",
                            IsActive = true,
                            MessageTemplate = "Notification: Quantity result is below 20 or the test is negative and unsuccessful."
                        },

                        new NotificationCriteria
                        {
                            Id = new Guid("9A1E4F5C-4D4E-4D57-9479-9E1E5F6C3D4E"),
                            Expression = "Customer == 'VIP' && (QntResult > 70 || QltResult > 0.9)",
                            IsActive = true,
                            MessageTemplate = "VIP customer alert: High quantity or quality result."
                        },

                        new NotificationCriteria
                        {
                            Id = new Guid("B3A5F6D8-8C2F-4E68-8F2B-A6C5D8E2F7A9"),
                            Expression = "Test == 'negative' && SampleType == 'Urine' && IsSuccess == false",
                            IsActive = true,
                            MessageTemplate = "Negative urine test with unsuccessful result."
                        }
                    ]
                }
            ]
        }
    };
}

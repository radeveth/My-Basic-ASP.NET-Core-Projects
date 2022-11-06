namespace ForumSystem.Services.Data.NotificationsService
{
    using ForumSystem.Data;

    public class NotificationService : INotificationService
    {
        private readonly ApplicationDbContext dbContext;

        public NotificationService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}

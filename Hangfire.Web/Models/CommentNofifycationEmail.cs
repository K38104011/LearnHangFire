using Postal;

namespace Hangfire.Web.Models
{
    public class CommentNotificationEmail : Email
    {
        public string To { get; set; }
        public string Username { get; set; }
        public string Comment { get; set; }
    }
}
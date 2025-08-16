namespace MyPage.Models
{
    public class MailRequest
    {
        public  string? Name { get; set; }
        public  string? Surname { get; set; }
        public  string? SenderMail { get; set; }
        public string ReceiverMail { get; set; } = "muratdervisoglu2002@gmail.com";

        public string? Subject { get; set; }
        public  string? Phone { get; set; }
        public  string? Content { get; set; }
    }
}

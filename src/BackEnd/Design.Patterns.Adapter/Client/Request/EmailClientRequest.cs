namespace Design.Patterns.Adapter.Client.Request
{
    public class EmailClientRequest
    {
        public EmailClientRequest(string email, string bodyJson)
        {
            Email = email;
            BodyJson = bodyJson;
        }

        public string Email { get; set; }
        public string BodyJson { get; set; }
    }
}

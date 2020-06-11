namespace Design.Patterns.Adapter.Adaptee.Request
{
    public class EmailAdapteeRequest
    {
        public EmailAdapteeRequest(string email, string bodyJson)
        {
            Email = email;
            BodyJson = bodyJson;
        }

        public string Email { get; set; }
        public string BodyJson { get; set; }
    }
}

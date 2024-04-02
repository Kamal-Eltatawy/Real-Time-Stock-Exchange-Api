namespace Domain.DTO
{
    public class AuthModel
    {
        public string Message { get; set; }

        public string UserName { get; set; }

        public bool IsAuthenticated { get; set; }

        public string Email { get; set; }
        public string Tokken { get; set; }

        public List<string> Roles { get; set; }

        public DateTime ExpireDate { get; set; }
    }
}

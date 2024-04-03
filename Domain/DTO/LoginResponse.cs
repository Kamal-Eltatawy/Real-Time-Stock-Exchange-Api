namespace Domain.DTO
{
    public class LoginResponse
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Email { get; set; }
        public string Tokken { get; set; }

        public List<string> Roles { get; set; }

        public string UserID { get; set; }

        public DateTime ExpireDate { get; set; }
    }
}

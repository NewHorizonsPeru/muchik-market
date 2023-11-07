namespace midis.muchik.market.application.dto.security
{
    public class SignUpRequestDto
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string RoleId { get; set; } = null!;
    }
}

namespace midis.muchik.market.application.dto.security
{
    public class UpdatePasswordDto
    {
        public string Email { get; set; } = null!;
        public string OldPassword { get; set; } = null!;
        public string NewPassword { get; set; } = null!;
    }
}

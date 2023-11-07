using midis.muchik.market.application.dto.security;

namespace midis.muchik.market.application.interfaces
{
    public interface ISecurityService
    {
        void SignUp(SignUpRequestDto signUpRequestDto); 
    }
}

using midis.muchik.market.application.dto;
using midis.muchik.market.application.dto.security;
using midis.muchik.market.crosscutting.models;

namespace midis.muchik.market.application.interfaces
{
    public interface ISecurityService
    {
        GenericResponse<UserDto> SignUp(SignUpRequestDto signUpRequestDto);
        GenericResponse<UserDto> SignIn(SignInRequestDto signInRequestDto);
        GenericResponse<string> ForgetPassword(ForgetPasswordDto forgetPasswordDto);
        GenericResponse<string> UpdatePassword(UpdatePasswordDto updatePasswordDto, string forgetPasswordToken);
    }
}

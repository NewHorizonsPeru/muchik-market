using AutoMapper;
using midis.muchik.market.application.dto.security;
using midis.muchik.market.application.interfaces;
using midis.muchik.market.crosscutting.bcrypt;
using midis.muchik.market.crosscutting.interfaces;
using midis.muchik.market.domain.entities;
using midis.muchik.market.domain.interfaces;

namespace midis.muchik.market.application.services
{
    public class SecurityService : ISecurityService
    {
        private readonly IMapper _mapper;
        private readonly IJwtManger _jwtManger;
        private readonly IUserRepository _userRepository;

        public SecurityService(IMapper mapper, IJwtManger jwtManger, IUserRepository userRepository)
        {
            _mapper = mapper;
            _jwtManger = jwtManger;
            _userRepository = userRepository;
        }

        public void SignUp(SignUpRequestDto signUpRequestDto)
        {
            /**
             * VALIDAR SI EL USUARIO EXISTE
            **/
            
            var userEntity = _mapper.Map<User>(signUpRequestDto);
            userEntity.Password = BcryptManager.Hash(userEntity.Password);
            _userRepository.Add(userEntity);
            _userRepository.Save();
        }
    }
}

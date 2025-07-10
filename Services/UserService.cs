using Abcloudz.Domain.Entities;
using Abcloudz.Domain.Repositories.Interfaces;
using AbcloudzWebAPI.DTO;
using AbcloudzWebAPI.Services.Interfaces;
using AutoMapper;

namespace AbcloudzWebAPI.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(UserDto user)
        {
            var userEntity = _mapper.Map<User>(user);
            var id = await _userRepository.CreateAsync(userEntity);

            return id;
        }

        public async Task<IEnumerable<UserDto>> GetAsync()
        {
            var users = await _userRepository.GetAsync();

            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
    }
}

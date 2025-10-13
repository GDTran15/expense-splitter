using System.Threading.Tasks;
using WebApplication1.DTO.User;
using WebApplication1.IRepositories;
using WebApplication1.Model;

namespace WebApplication1.Service
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        internal async Task CreateNewUser(RegisterRequestDTO requestDTO)
        {
            var userExist = await _userRepository.IsExistByUsernameOrEmailAsync(requestDTO.Username,requestDTO.Email);
            if (userExist)
            {
                throw new InvalidOperationException("Username or email has been used");
            }
            var newUser = new User
            {
                Name = requestDTO.Name,
                Username = requestDTO.Username,
                Email = requestDTO.Email,
                Password = requestDTO.Password,
                Phone = requestDTO.Phone,
                AmountSpend = 0

            };
            await _userRepository.CreateUserAsync(newUser);
        }

        internal async Task<ResponseLoginDTO> login(LoginDTORequest loginDTO)
        {
            var user = await _userRepository.GetByUsernameAndPassWord(loginDTO.Username, loginDTO.Password);
            if (user == null)
            {
                throw new InvalidOperationException("Wrong username or password");
            }

            return new ResponseLoginDTO
            {
                UserId = user.UserId,
                UserName = user.Username
            };
            }
        }
    }

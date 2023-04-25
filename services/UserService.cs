using serviceApi.interfaces;
using serviceApi.interfaces.DTO;
using serviceApi.models;

namespace serviceApi.services
{
    public class UserService
    {
         private readonly IRepository<UserModel> repository;       

        public UserService(IRepository<UserModel> context)
        {
            this.repository = context;
        }

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            return await repository.GetAll();
        }

        public async Task<UserResponseDTO> GetUserId(string id)
        {
            var user = await repository.GetOneById(id);
            var servs = user.Services;
            return new UserResponse() {
                Id= user.Id,
                Nombre = user.Nombre,
                Email = user.Email,
                Services = user.Services
            };
        }

        public async Task<UserInserDTO> CreatetUser(UserInserDTO value)
        {
                var user = await repository.Insert( new UserModel()
                {
                    Nombre = value.Nombre,
                    Email = value.Email,
                    Password = value.Password,
                });
                value.Id = user.Id;
                return new InsertUserResponse(
                    id: user.Id,
                    nombre: user.Nombre,
                    email: user.Email
                );
        }

        
    }
}
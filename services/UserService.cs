using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        
    }
}
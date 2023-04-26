using System;
using serviceApi.context;
using serviceApi.interfaces;
using serviceApi.interfaces.DTO;
using serviceApi.models;
using serviceApi.repositories;

namespace serviceApi.services
{
    public class UserService
    {
         private readonly IRepository<UserModel> repository;
        private readonly IRepository<ServicesModel> repositoryService;

        public UserService(ServicesDb context)
        {
            this.repository = new Repository<UserModel>(context);            
            repositoryService = new Repository<ServicesModel>(context);
        }

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            var data = await repository.GetAll();
            // return data;
            foreach (var item in data)
            {
              item.Password = null;   
            }
            return data;
        }

        public async Task<UserResponseDTO> GetUserId(string id)
        {
            var user = await repository.GetOneById(id);
            var servicesQuery = repositoryService.Query(serv => serv.UserCreateId == user.Id);
            var services  = new List<ServiceResponse>();

            foreach (var serv in servicesQuery)
            {
                services.Add(new ServiceResponse {
                    Id = serv.Id,
                    Titulo = serv.Titulo,
                    Descripcion = serv.Descripcion,
                    UserAuthId = serv.UserAuthId,
                    UserAuthName = "",
                    imagen = serv.imagen,
                    Estatus = serv.Estatus,
                    Crete = serv.Crete,
                    Update = serv.Update,
                });
            }
            var servs = user.Services;
            return new UserResponse() {
                Id= user.Id,
                Nombre = user.Nombre,
                Email = user.Email,
                Services = services,
            };
        }
        public async Task<UserModel> GetUserModelId(string id)
        {
            return  await repository.GetOneById(id);
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
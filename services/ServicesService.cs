using serviceApi.context;
using serviceApi.interfaces;
using serviceApi.interfaces.DTO;
using serviceApi.models;
using serviceApi.repositories;

namespace serviceApi.services
{
    public class ServicesService
    {
        private readonly IRepository<ServicesModel> repository;
        
        private readonly IRepository<UserModel> repositoryUser;

        public ServicesService(ServicesDb context)
        {
            this.repository = new Repository<ServicesModel>(context);
            repositoryUser = new Repository<UserModel>(context);
        }

        public async Task<IEnumerable<ServicesModel>> FindServices()
        {
            return await repository.GetAll();
        }

        public async Task<ServicesModel> CreateServices(InsertServiceDTO values)
        {
            var user = await repositoryUser.GetOneById(values.userId);
            ServicesModel service = new ServicesModel
            {
                Titulo = values.titulo,
                Descripcion = values.descripcion,
                imagen = values.imagen,
                Estatus = Enums.EstatusEnum.Pendiente.ToString(),
                UserCreateId = values.userId,
                UserCreate = user,
                Crete = DateTime.Now,
                Update = DateTime.Now,

            };

            return await repository.Insert(service);
        }

        public async Task<ServicesModel> AuthService(string id, Enums.EstatusEnum estatus, string userId)
        {
            
            var userAuth = await repositoryUser.GetOneById(userId);
            ServicesModel service = await repository.GetOneById(id);
            service.Estatus = estatus.ToString();
            service.UserAuthId = userId;
            service.UserAuth = userAuth;
             return await repository.Update(service);
        }

        public IQueryable<ServicesModel> FindServicesId(string id)
        {
            return repository.Query(user => user.UserCreateId == id);
        }
    }
}
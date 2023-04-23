using serviceApi.interfaces;
using serviceApi.interfaces.DTO;
using serviceApi.models;

namespace serviceApi.services
{
    public class ServicesService
    {
        private readonly IRepository<ServicesModel> repository;       

        public ServicesService(IRepository<ServicesModel> context)
        {
            this.repository = context;
        }

        public async Task<IEnumerable<ServicesModel>> FindServices()
        {
            return await repository.GetAll();
        }

        public async Task<ServicesModel> CreateServices(InsertServiceDTO values)
        {
            ServicesModel service = new ServicesModel
            {
                Titulo = values.titulo,
                Descripcion = values.descripcion,
                imagen = values.imagen,
                Estatus = Enums.EstatusEnum.Pendiente.ToString(),
                UserCreate = values.user,
                Crete = DateTime.Now,
                Update = DateTime.Now,

            };

            return await repository.Insert(service);
        }

        public async Task<ServicesModel> AuthService(string id, Enums.EstatusEnum estatus)
        {
            ServicesModel service = await repository.GetOneById(id);
            service.Estatus = estatus.ToString();
             return await repository.Update(service);
        }
    }
}
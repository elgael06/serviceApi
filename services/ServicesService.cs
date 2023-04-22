using serviceApi.interfaces;
using serviceApi.models;

namespace serviceApi.services
{
    public class ServicesService
    {
        private IRepository<ServicesModel> repository;        

        public ServicesService(IRepository<ServicesModel> context)
        {
            this.repository = context;
        }

        public async Task<IEnumerable<ServicesModel>> FindServices()
        {
            return await repository.GetAll();
        }

        public async Task<ServicesModel> CreateServices(            
            string titulo,
            string descripcion,
            string imagen,
            int user
        )
        {
            ServicesModel service = new ServicesModel
            {
                Titulo = titulo,
                Descripcion = descripcion,
                imagen = imagen,
                Estatus = Enums.EstatusEnum.Pendiente.ToString(),
                UserCreate = user,
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
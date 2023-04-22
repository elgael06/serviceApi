using serviceApi.Enums;

namespace serviceApi.models
{
    public class ServicesModel
    {
        public string Id {get; set;} = Guid.NewGuid().ToString();
        public string Titulo {get; set;}
        public string Descripcion {get; set;}
        public string Estatus {get; set;}
        public string imagen  {get; set;}
        public int UserCreate {get;set;}
        public int UserAuth {get;set;}
        public DateTime Crete {get;set;}
        public DateTime Update {get;set;}
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using serviceApi.Enums;

namespace serviceApi.models
{
    public class ServicesModel
    {
        public string Id {get; set;} = Guid.NewGuid().ToString();
        public string? UserCreateId {get; set;} = string.Empty;
        public string? UserAuthId {get; set;} = string.Empty;
        public string? Titulo {get; set;} = string.Empty;
        public string? Descripcion {get; set;} = string.Empty;
        public string? Estatus {get; set;} = string.Empty;
        public string? imagen  {get; set;} = string.Empty;
        public UserModel? UserCreate {get;set;}
        
        [NotMapped]
        public UserModel? UserAuth {get;set;}
        public DateTime Crete {get;set;}
        public DateTime Update {get;set;}
    }
}
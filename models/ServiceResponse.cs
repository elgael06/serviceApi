using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace serviceApi.models
{
    public class ServiceResponse
    {
        public string Id {get; set;} = string.Empty;
        public string? Titulo {get; set;} = string.Empty;
        public string? Descripcion {get; set;} = string.Empty;
        public string? Estatus {get; set;} = string.Empty;
        public string? imagen  {get; set;} = string.Empty;
        public string? UserAuthId {get; set;} = string.Empty;
        public string? UserAuthName {get; set;} = string.Empty;
        public DateTime Crete {get;set;}
        public DateTime Update {get;set;}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace serviceApi.interfaces.DTO
{
    public interface InsertServiceDTO
    {
        public string titulo {get; set;}
        public string descripcion {get; set;}
        public string imagen {get; set;}
        public int user {get; set;}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using serviceApi.Enums;

namespace serviceApi.interfaces.DTO
{
    public class UpdateServiceDTO
    {
        public string UserId {get; set;}
        public EstatusEnum Estatus {get; set;}
    }
}
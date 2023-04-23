using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using serviceApi.interfaces.DTO;

namespace serviceApi.models
{
    public class UserResponse: UserResponseDTO
    {
        public string Id {get; set;}
        public string Nombre {get; set;}
        public string Email {get; set;}
        public ICollection<ServicesModel> Services {get; set;}      
    }
}
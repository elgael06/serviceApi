using serviceApi.interfaces.DTO;

namespace serviceApi.models
{
    public class UserResponse: UserResponseDTO
    {
        public string Id {get; set;}
        public string Nombre {get; set;}
        public string Email {get; set;}
        public ICollection<ServiceResponse> Services {get; set;}    
    }
}
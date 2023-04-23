using serviceApi.models;

namespace serviceApi.interfaces.DTO
{
    public interface UserResponseDTO
    {
        public string Id {get; set;}
        public string Nombre {get; set;}
        public string Email {get; set;}
        public ICollection<ServicesModel> Services {get; set;}

    }
}
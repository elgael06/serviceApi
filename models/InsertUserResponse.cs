using serviceApi.interfaces.DTO;

namespace serviceApi.models
{
    public class InsertUserResponse: UserInserDTO
    {
        public string? Id {get;set;}
        public string Nombre {get; set;}
        public string Email {get; set;}
        public string Password {get; set;} = string.Empty;

        public InsertUserResponse(string id, string nombre, string email)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
        }
    }
}
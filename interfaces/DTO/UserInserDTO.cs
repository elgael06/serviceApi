namespace serviceApi.interfaces.DTO
{
    public interface UserInserDTO
    {
        public string? Id {get;set;}
        public string Nombre {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace serviceApi.models
{
    public class UserModel
    {
        public UserModel()
        {
            Services = new HashSet<ServicesModel>();
        }
        [Key]
        public string Id {get; set;} = Guid.NewGuid().ToString();
        public string Nombre {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public virtual ICollection<ServicesModel>? Services {get;set;} = null;
        public DateTime Crete {get;set;}
        public DateTime Update {get;set;}
    }
}
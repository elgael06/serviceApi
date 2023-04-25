using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using serviceApi.context;
using serviceApi.models;

namespace serviceApi.Data
{
    public class DbInitializer
    {
         public static void Initialize(ServicesDb context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;
            }

            var user = new UserModel();
            user.Nombre = "Admin";
            user.Email = "admin@mi-app.cpm";
            user.Password = "1234";
            context.Add(user);
            context.SaveChanges();
        }
    }
}
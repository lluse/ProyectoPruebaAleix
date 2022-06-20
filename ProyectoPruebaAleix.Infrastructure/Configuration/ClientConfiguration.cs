using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProyectoPruebaAleix.Domain;

namespace ProyectoPruebaAleix.Infrastructure.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");

            builder.HasData(
                new Client { 
                    ClientId = 1,
                    Nombre = "Paco",
                    Apellidos = "Jimenez Pato",
                    Nif = "453453254P",
                    Email = "paco.jimenez@hotmail.com"
                },
                new Client
                {
                    ClientId = 2,
                    Nombre = "Carla",
                    Apellidos = "Garcia De Mato",
                    Nif = "456345654O",
                    Email = "carladm@gmail.com"
                },
                new Client
                {
                    ClientId = 3,
                    Nombre = "Ramon",
                    Apellidos = "Sanchez Martin",
                    Nif = "342342412Y",
                    Email = "ramon55@gmail.com"
                },
                new Client
                {
                    ClientId = 4,
                    Nombre = "Irene",
                    Apellidos = "Loro Ayuso",
                    Nif = "821378223Y",
                    Email = "lorito@gmail.com"
                },
                new Client
                {
                    ClientId = 5,
                    Nombre = "Alex",
                    Apellidos = "Lorenzo Marquez",
                    Nif = "456542342I",
                    Email = "lorenzo@gmail.com"
                }
            );
        }
    }
}

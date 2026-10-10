using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using TorneosEsports.Web.Data;

namespace TorneosEsports.Web.Security
{
    public static class IdentitySeeder
    {
        public static async Task InitializeAsync(
            IServiceProvider serviceProvider,
            IConfiguration configuration)
        {
            using var scope = serviceProvider.CreateScope();

            var services = scope.ServiceProvider;

            var roleManager = services
                .GetRequiredService<RoleManager<IdentityRole>>();

            var userManager = services
                .GetRequiredService<UserManager<ApplicationUser>>();

            string[] roles =
            {
                "Administrador",
                "Comprador"
            };

            // Crear los roles si todavía no existen.
            foreach (string role in roles)
            {
                bool roleExists = await roleManager.RoleExistsAsync(role);

                if (!roleExists)
                {
                    var result = await roleManager.CreateAsync(
                        new IdentityRole(role));

                    if (!result.Succeeded)
                    {
                        throw new InvalidOperationException(
                            $"No se pudo crear el rol {role}.");
                    }
                }
            }

            // Obtener el correo configurado para el administrador.
            string? adminEmail = configuration["InitialAdminEmail"];

            if (string.IsNullOrWhiteSpace(adminEmail))
            {
                return;
            }

            // Buscar la cuenta por correo electrónico.
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                Console.WriteLine(
                    $"No se encontró una cuenta registrada con el correo {adminEmail}.");

                return;
            }

            // Asignar el rol Administrador si todavía no lo tiene.
            bool isAdmin = await userManager.IsInRoleAsync(
                adminUser, "Administrador");

            if (!isAdmin)
            {
                var result = await userManager.AddToRoleAsync(
                    adminUser, "Administrador");

                if (!result.Succeeded)
                {
                    throw new InvalidOperationException(
                        "No se pudo asignar el rol Administrador.");
                }

                Console.WriteLine(
                    $"Se asignó el rol Administrador a {adminEmail}.");
            }
        }
    }
}
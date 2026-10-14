// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TorneosEsports.Web.Data;

namespace TorneosEsports.Web.Areas.Identity.Pages.Account;

public class LogoutModel : PageModel
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ILogger<LogoutModel> _logger;
    private readonly ApplicationDbContext _context;

    public LogoutModel(
     SignInManager<ApplicationUser> signInManager,
     ILogger<LogoutModel> logger,
     ApplicationDbContext context)
    {
        _signInManager = signInManager;
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> OnPost(string? returnUrl = null)
    {
        // Obtener los datos del usuario antes de cerrar la sesión.
        var usuarioId = User.FindFirst(
            System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        var correoUsuario = User.FindFirst(
            System.Security.Claims.ClaimTypes.Email)?.Value;

        // Cerrar la sesión.
        await _signInManager.SignOutAsync();

        // Registrar el cierre de sesión en la bitácora.
        if (!string.IsNullOrEmpty(usuarioId))
        {
            var registro = new BitacoraAccion
            {
                UsuarioId = usuarioId,
                CorreoUsuario = correoUsuario ?? "Correo no disponible",
                Accion = "Cierre de sesión",
                Detalle = "El usuario cerró sesión correctamente.",
                FechaHora = DateTime.UtcNow
            };

            _context.BitacoraAcciones.Add(registro);
            await _context.SaveChangesAsync();
        }

        _logger.LogInformation("User logged out.");

        if (returnUrl != null)
        {
            return LocalRedirect(returnUrl);
        }

        return RedirectToPage();
    }
}

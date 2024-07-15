using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P3_Proyecto.Context;
using P3_Proyecto.Models;
using P3_Proyecto.ViewModels;
using System.Diagnostics;

namespace P3_Proyecto.Controllers
{
    public class HomeController(ChatRoomContext context) : Controller
    {

        public async Task<IActionResult> Index()
        {
            var message = await context.ChatMessages.OrderBy(c => c.FechaHora).ToListAsync();
            var messageListView = message.Select(m =>
            {
                return new MessageViewModel
                {
                    Usuario = m.Usuario,
                    Mensaje = m.Mensaje,
                    FechaHora = m.FechaHora
                };
            });
            return View(messageListView);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

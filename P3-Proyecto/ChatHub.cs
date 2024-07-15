using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using P3_Proyecto.Context;
using P3_Proyecto.Models;
using P3_Proyecto.ViewModels;

namespace P3_Proyecto
{
    public class ChatHub(ChatRoomContext context) : Hub
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public async Task AddMessage(string userName, string message)
        {
            var chatMessage = new ChatMessage
            {
                Usuario = userName,
                Mensaje = message,
                FechaHora = DateTime.Now
            };
            context.ChatMessages.Add(chatMessage);
            await context.SaveChangesAsync();
            await Clients.All.SendAsync("ReceiveMessage", new MessageViewModel
            {
                Usuario = userName,
                Mensaje = message,
                FechaHora = chatMessage.FechaHora
            });

            var messagesCount = await context.ChatMessages.CountAsync();
            if (messagesCount == 1)
            {
                await Task.Delay(3000);
                chatMessage.FechaHora = DateTime.Now;
                chatMessage.Mensaje = "Bienvenido, uno de nuestro representantes lo atendera en breve";
                chatMessage.Usuario = "BOT";
                context.ChatMessages.Add(chatMessage);
                await context.SaveChangesAsync();

                await Clients.All.SendAsync("ReceiveMessage", new MessageViewModel
                {
                    Usuario = chatMessage.Usuario,
                    Mensaje = chatMessage.Mensaje,
                    FechaHora = chatMessage.FechaHora
                });
            }
        }
    }
}

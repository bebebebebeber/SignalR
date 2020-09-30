using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MVCCoreSignalR.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SignalRTest.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ApplicationDbContext _context;

        public ChatHub(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task SendMessage(string userId, string message)
        {
            var userName= Context.User.Identity.Name;
            var user = _context.Users.SingleOrDefault(x => x.UserName == userName);
            string[] users = { userId, user.Id.ToString() }; 

            await Clients.Users(users).SendAsync("ReceiveMessage", Context.User.Identity.Name, message);
            
            //await Clients.All.SendAsync("ReceiveMessage", Context.User.Identity.Name, message);
        }
    }
}

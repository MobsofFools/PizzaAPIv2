using Microsoft.AspNetCore.SignalR;
using PizzaAPIv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaAPIv2.Hubs
{
    public interface IStatusClient
    {
        Task Status(string status);
    }
    public interface IStatusRepository
    {
        List<Connection> Connections { get; }
    }

    public class StatusHub : Hub<IStatusClient>
    {
        private IStatusRepository _repository;

        public StatusHub(IStatusRepository repository)
        {
            _repository = repository;
        }
        public async Task OnConnectedAsync()
        {
            var connection = _repository.Connections.FirstOrDefault(e => !e.InProgress);
            if(connection is null)
            {
                connection = new Connection();
                connection.Id = Guid.NewGuid().ToString();

            }


        }
    }
}

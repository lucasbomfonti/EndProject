using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using EndProject.Domain.Arguments.Base;
using EndProject.Domain.Arguments.Player;
using EndProject.Domain.Entities;
using EndProject.Domain.ValueObjects;
using EndProject.Service.Interfaces;
using EndProject.Service.Interfaces.Base;
using EndProject.Service.Repositories;

namespace EndProject.Service.Service
{
    public class ServicePlayer : Notifiable, IServiceBase, IServicePlayer
    {
        private readonly IRepositoryPlayer _repository;

        public ServicePlayer()
        {
        }

        public ServicePlayer(IRepositoryPlayer repository)
        {
            _repository = repository;
        }
     
        public AddPlayerResponse AddPlayer(AddPlayerRequest request)
        {
            var nome = new Name("Teste", "Testado");
            Email email = new Email("Teste@teste.com");

            Player player = new Player(nome, email, "1324567");
            

             player =  _repository.Add(player);

            return (AddPlayerResponse) player;
        }

        public ChangePlayerResponse ChangePlayer(ChangePlayerRequest request)
        {
            if (request == null)
            {
                AddNotification("ChangePlayerResponse", "is required");
            }

            Player player = _repository.GetById(request.Id);

            if (player == null)
            {
                AddNotification("id", "not found");
            }

            var name = new Name(request.FirstName, request.LastName);
            var email = new Email(request.Email);
           

            player.ChangePlayer(name, email, player.Status);

            AddNotifications(player);
            if (IsInvalid())
            {
                return null;
            }

            _repository.Edit(player);
            return (ChangePlayerResponse)player;
        }

        public IEnumerable<PlayerResponse> PlayerList()
        {
            return _repository.list().Select(player => (PlayerResponse) player).ToList();
        }


        public  AuthenticatePlayerResponse AuthenticatePlayer(AuthenticatePlayerRequest request)
        {
            if (request == null)
            {
                AddNotification("AuthenticatePlayerResponse", "is required");
            }

            
                var email = new Email(request.Email);
                var player = new Player(email,request.Password);  
            
                AddNotifications(player, email);
                if (player.IsInvalid())
                {
                    return null;
                }

            player = _repository.GetBy(x => x.Email.Address == player.Email.Address,
                x => x.Password == player.Password); 
            return (AuthenticatePlayerResponse) player;
        }

        public ResponseBase DeletePlayer(Guid id)
        {
            Player player = _repository.GetById(id);
            if (player == null)
            {
                AddNotification("Id", "NotFound");
                return null;
            }
            _repository.Remove(player);

            return new ResponseBase();
        }
    }
}
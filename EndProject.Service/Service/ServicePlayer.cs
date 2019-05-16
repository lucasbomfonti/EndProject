using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using EndProject.Domain.Arguments.Base;
using EndProject.Domain.Arguments.Player;
using EndProject.Domain.Entities;
using EndProject.Domain.ValueObjects;
using EndProject.Service.Interfaces;
using EndProject.Service.Repositories;

namespace EndProject.Service.Service
{
    public class ServicePlayer : Notifiable, IServicePlayer
    {
        private readonly IRepositoryPlayer _repository;

        public ServicePlayer(IRepositoryPlayer repository)
        {
            _repository = repository;
        }
     
        public AddPlayerResponse AddPlayer(AddPlayerRequest request)
        {
            var nome = new Name(request.Name.FirstName, request.Password);
            Email email = new Email(request.Email.Address);

            Player player = new Player(nome, email, request.Password);

            AddNotifications(nome, email);

            if (_repository.Existe(x => x.Email == request.Email))
            {
                AddNotification("E-mail","fail");
            }

            if (IsInvalid())
            {
                return null;
            }

            player = _repository.Add(player);


            return (AddPlayerResponse)player;
        }

        public ChangePlayerResponse ChangePlayer(ChangePlayerRequest request)
        {
            if (request == null)
            {
                AddNotification("ChangePlayerResponse", "is required");
            }

            Debug.Assert(request != null, nameof(request) + " != null");
            Player player = _repository.GetById(request.Id);

            if (player == null)
            {
                AddNotification("id", "not found");
            }

            var name = new Name(request.FirstName, request.LastName);
            var email = new Email(request.Email);
           

            player?.ChangePlayer(name, email, player.Status);

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

            
                var email = new Email(request?.Email);
                var player = new Player(email,request?.Password);  
            
                AddNotifications(player, email);
                if (player.IsInvalid())
                {
                    return null;
                }

            var player1 = player;
            var player2 = player;
            player = _repository.GetBy(x => x.Email.Address == player1.Email.Address,
                x => x.Password == player2.Password); 
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
using System;
namespace EndProject.Domain.Arguments.Player
{
    public class AddPlayerResponse 
    {
        public Guid Id { get; set; }
        public string Message { get; set; }

        public static explicit operator AddPlayerResponse(Entities.Player entidade)
        {
            return new AddPlayerResponse()
            {
                Id = entidade.Id,
                Message = "Success"

            };
        }
    }
    
}

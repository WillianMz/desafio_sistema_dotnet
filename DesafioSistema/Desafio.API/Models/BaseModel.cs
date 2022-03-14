using Flunt.Notifications;

namespace Desafio.API.Models
{
    public abstract class BaseModel : Notifiable<Notification>
    {
        public DateTime CadastradoEm { get; set; }
    }
}

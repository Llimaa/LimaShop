namespace LimaShop.Notification.ViewModel
{
    public class BodyEmail
    {
        public BodyEmail()
        {

        }
        public BodyEmail(string content, string @event, string nome)
        {
            Content = content;
            Event = @event;
            Nome = nome;
        }

        public string Content { get; set; }
        public string Event { get; set; }
        public string Nome { get; set; }

        public override string ToString()
        {
            string body = @$"
                            <div style='width: 560px; margin: 0 auto; background-color: #f48221; padding: 30px 0; text-align: center;'>
                             <H1 style='text-align: center; color: white;'>Notificação</H1>
                            </div>

                            <div style='width: 500px; margin: 0 auto; padding: 30px; background-color: #f9f9f9; border: 1px solid #ccc; text-align: center;'>
                               <b>Content</b>: {Content}
                              <br>

                               <b>Nome</b>: {Content}
                               <br>
                           
                             <b>Evento:</b>: <br> {Event}
                              <br />
                              <hr>
                              <br />
                            <p style='margin: auto;'>{DateTime.Now}</p>
                              </div >
                            ";
            return body;
        }
    }
}

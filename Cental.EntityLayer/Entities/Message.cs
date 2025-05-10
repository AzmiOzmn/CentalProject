namespace Cental.EntityLayer.Entities
{
   public class Message : BaseEntity
    {
        public int MessageId { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Comment { get; set; }


    }
}

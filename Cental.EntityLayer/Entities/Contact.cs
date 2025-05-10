namespace Cental.EntityLayer.Entities
{
   public class Contact : BaseEntity
    {
        public int ContactId { get; set; }
        public string Adress { get; set; }
        public string Mail { get; set; }
        public int PhoneNumber { get; set; }
        public int WebsiteNumber { get; set; }
        public string BranchAdress { get; set; }
        public int BranchPhone { get; set; }
        public string MapUrl { get; set; }




    }
}

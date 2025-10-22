namespace TheMindSpire.Models.ContactData
{
    public class ContactUs
    {
        public int Id { get; set; }      
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime SubmittedOn { get; set; } = DateTime.Now;
    }
}

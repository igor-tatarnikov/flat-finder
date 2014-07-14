namespace FlatFinder.Core.Domain.User
{
    public class ContactInfo: BaseEntity
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string ContactName { get; set; }
        public string PrimaryPhoneNumber { get; set; }
        public string SecondaryPhoneNumber { get; set; }
    }
}

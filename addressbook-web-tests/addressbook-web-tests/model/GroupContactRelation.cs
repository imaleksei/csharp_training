using LinqToDB.Mapping;

namespace WebAddressBookTests
{
    [Table(Name = "address_in_groups")]
    public class GroupContactRelation
    {
        [Column(Name = "group_id")]
        public string groupId { get; set; }
        [Column(Name = "id")]
        public string contactId { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace HomeWork_Week2.Models
{
    public class BootcampMembers // Katılımcı entity
    {
        [Key]
        public int BootcampMembersID { get; set; }

        public string MembersName { get; set; }
        public string MembersSurname { get; set; }
        public string GSMnumber { get; set; }

        public bool Status { get; set; }
    }
}

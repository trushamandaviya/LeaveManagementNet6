using System.ComponentModel;

namespace LeaveManagement.Web.Models
{
    public class EmployeeListVM
    {
        public string Id { get; set; }

        [DisplayName("First Name")]
        public string? FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Email Address")]
        public string Email { get;set; }

        [DisplayName("Date Joinned")]
        public DateTime DateJoinned { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserPropertiesAD
{
    public class UserProperties
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get => $"{FirstName} {LastName}"; }
        public string? WorkTitle { get; set; }
        public string? SubTitle { get; set; }
        public string? Department { get; set; }
        public string? BirthdayDate { get; set; }
        public string? DisplayName { get; set; }
        public string? StartDate { get; set; }
        public string? OfficeName { get; set; }
        public string? Level { get; set; }
        public string? EmployeeID { get; set; }
        public string? Mobile { get; set; }
        public string? Manager { get; set; }
        public string? Location { get; set; }
        public string? Partition { get; set; }
        public byte[]? PhotoByte { get; set; }
        public string? PhotoBase64 { get; set; }
    }
}

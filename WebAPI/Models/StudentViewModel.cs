using System;

namespace WebAPI.Models
{
    public class StudentViewModel
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public Nullable<int> StandardId { get; set; }
        public StandardViewModel Standard { get; set; }
        public AddressViewModel Address { get; set; }
    }
}
using System;

namespace api.DTO.Intacct
{
    public class IntacctEmailDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
    }
}
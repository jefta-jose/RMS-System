using System;
using System.Collections.Generic;

namespace api.DTO.Reports.Sdl
{
    public class HoursDto
    {
        public string DateString { get; set; }
        public DateTime Date { get; set; }
        public Decimal Hours { get; set; }
    }
}
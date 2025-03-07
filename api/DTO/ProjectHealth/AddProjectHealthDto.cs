using System;
using System.Globalization;

namespace api.DTO.ProjectHealth
{
    public class AddProjectHealthDto
    {
        public Guid ProjectID { get; set; }
        public long? ProjectLeaderID { get; set; }
        public long? SolutionDeliveryLeaderID { get; set; }

        private string _status;
        public string Status
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_status))
                    return _status;

                // Create a TextInfo object to get the current culture's casing rules
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

                // Convert the input string to title case
                return textInfo.ToTitleCase(_status.ToLower());
            }
            set { _status = value; }
        }
        public string OnTime { get; set; }
        public string MeetsExpectations { get; set; }
        public string TeamPerformance { get; set; }
        public string Comments { get; set; }
    }
}

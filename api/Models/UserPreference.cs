using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace api.Models
{
    public class UserPreference
    {
        public long ID { get; set; }
        public Guid UserPreferenceID { get; set; }
        public long UserID { get; set; }
        public string Preference { get; set; }
        public DateTime CreatedDTM { get; set; }
        public DateTime UpdatedDTM { get; set; }
        [Timestamp]
        public virtual byte[] RowVersion { get; set; }
        public User User { get; set; }
        [NotMapped]
        public Dictionary<string, string> Preferences
        {
            get { return JsonConvert.DeserializeObject<Dictionary<string, string>>(Preference); }
            set { Preference = JsonConvert.SerializeObject(value); }
        }
        public UserPreference() { }
    }
}
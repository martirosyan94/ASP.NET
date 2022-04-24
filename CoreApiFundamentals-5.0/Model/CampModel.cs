using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreCodeCamp.Model
{
    public class CampModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public string Moniker { get; set; }
        public DateTime EventDate { get; set; } = DateTime.MinValue;
        [Range(1, 10)]
        public int Length { get; set; } = 1;
        public LocationModel Location { get; set; }
        public ICollection<TalkModel> Talks { get; set; }
    }
}

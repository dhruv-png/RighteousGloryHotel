using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RighteousGloryHotel.Models
{
    public class Room
    {

        [Required]
        [Display(Name = "Room No")]       

        public int roomId { get; set; }

        [Required]
        public int floor { get; set; }

        [Required]
        public int roomNo { get; set; }

        public string image { get; set; }
        
        public Boolean balconyView { get; set; }

        public Boolean bed { get; set; }

        public string  roomDescription { get; set; }

    }
}

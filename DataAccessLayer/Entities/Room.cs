using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Room
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string Id { get; set; }

        [Range(1, 5)]
        public int RoomStatus { get; set; }
        public decimal RoomRate { get; set; }
        public string HotelId { get; set; }
        public Hotel Hotel { get; set; }

    }
}

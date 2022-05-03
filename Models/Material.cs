using System;
using System.ComponentModel.DataAnnotations;

namespace storage.Models
{
    public class Material
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Piece { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
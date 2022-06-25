using System.ComponentModel.DataAnnotations;

namespace HomeWork_Week2.Models
{

    public class Bootcamp  //Bootcamp entity
    {
        [Key]
        public int BootcampID { get; set; }
        public string BootcampName { get; set; }
        public bool BootcampStatus { get; set; }

    }
}

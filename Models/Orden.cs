using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*No se utiliza*/
namespace HuertoDelValle.Models
{
    [Table("T_Orden")]
    public class Orden
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        public String UserID { get; set;}

        public String Direccion { get; set; }

        public String Estado { get; set; }

        public DateTime PaymentDate { get; set; }

        public Orden() {  
            PaymentDate = DateTime.Now;
        }
        

        public Decimal MontoTotal { get; set; }
    }
}
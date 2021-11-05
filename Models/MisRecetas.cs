using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HuertoDelValle.Models
{
    public class MisRecetas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id {get; set;}

        public String UserID {get; set;}

        public Receta Receta {get; set;}

    }

}
using System;

namespace HuertoDelValle.Models
{
    public class Envio
    {
        public int Id { get; set; }

        public TipoEnvio tipoEnvio {get; set;}

        public string Direccion {get; set;}

   }
}
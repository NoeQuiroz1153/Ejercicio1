using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Ejercicio1.Models
{
    public class Contactos
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
        [MaxLength(50)]
        public string Apellido { get; set; }

        [MaxLength(2)]
        public int Edad { get; set; }

        public string Pais { get; set; }
        [MaxLength(50)]
        public string Nota { get; set; }



    }
}

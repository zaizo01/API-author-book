using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API01.Entities
{
    public class Libro
    {
        public int id { get; set; }
        public string title { get; set; }
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
    }
}

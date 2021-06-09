using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API01.Entities
{
    public class Autor
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Libro> Libros { get; set; }
    }
}

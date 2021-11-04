using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlesGUI
{
    class Pais
    {
        int id;
        string nombre;
        string continente;
        long habitantes;
        string idioma;

        public Pais(int id, string nombre, string continente, long habitantes, string idioma)
        {
            this.id = id;
            this.nombre = nombre;
            this.continente = continente;
            this.habitantes = habitantes;
            this.idioma = idioma;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Continente { get => continente; set => continente = value; }
        public long Habitantes { get => habitantes; set => habitantes = value; }
        public string Idioma { get => idioma; set => idioma = value; }
        public int Id { get => id; }

        public override string ToString()
        {
            string show = String.Format("{0}- {1}", id, nombre.ToUpper());
            return show;
        }
    }
}

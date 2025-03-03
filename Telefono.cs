using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_de_Telefonos
{
    internal class Telefono
    {
        //Constructor
        public Telefono(string pNumero) { Numero = pNumero; }
        public Telefono(Telefono pTelefono) : this(pTelefono.Numero) { }//Estoy clonando del objeto anterior

        //Propiedades
        public string Numero { get; set; }

    } 
}

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_de_Telefonos
{
    internal class Persona
    {
        //Declaro
        List<Telefono> lt;//Solo declaro la vriable lt

        //Instancio
        public Persona() {  lt = new List<Telefono>(); }//Aca cree la lista
        public Persona(string pDNI) :this() { DNI = pDNI; }
        public Persona(string pDNI, string pNombre, string pApellido): this(pDNI) { Name = pNombre; LastName = pApellido; }
        public Persona(Persona pPersona):this(pPersona.DNI, pPersona.Name, pPersona.LastName) 
        {
            foreach(var t in pPersona.RetornaTelefono())
            {
                lt.Add(new Telefono(t.Numero));
            }
        }//Clonamos

        //Propiedades

        public string DNI { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        //Metodos

        public void AgregarTelefono(Telefono pTelefono)
        {
            lt.Add(new Telefono(pTelefono));
        }

        public List<Telefono> RetornaTelefono()
        {
            List<Telefono> auxLt = new List<Telefono>();
            
            foreach(var t in lt)
            {
                auxLt.Add(new Telefono(t)); 
            }
            return auxLt;
        }
    }
}

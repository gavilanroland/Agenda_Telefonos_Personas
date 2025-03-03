using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda_de_Telefonos
{
    internal class Agenda
    {
        List<Persona> lp;

        //Constructor
        public Agenda() { lp = new List<Persona>(); }

        //Metodos
        public void Agregarpersona(Persona pPersona)

        {
            try
            {
                if (ExisteDNI(pPersona) == true) throw new Exception("El DNI ya Existe");
                
                lp.Add(new Persona(pPersona)); 
                
                
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
 
        }
        public List<Persona> RetornaPersona()
        {
            List<Persona> auxLp = new List<Persona>();
            foreach(var p in lp)
            {
                var auxPersona = new Persona(p);
                auxLp.Add(auxPersona);
            }
            return auxLp;
        }

        public void BorrarPersona(Persona pPersona)
        {
            try
            {
                if (!ExisteDNI(pPersona)) throw new Exception("El DNI No Existe");
                var p = lp.Find(x=> x.DNI== pPersona.DNI);
                lp.Remove(p);
            }
            catch(Exception ex){  MessageBox.Show(ex.Message); }
        
        }
        public void ModificarPersona(Persona pPersona)
        {
            try
            {
                if (!ExisteDNI(pPersona)) throw new Exception("El DNI No Existe");
                var p = lp.Find(x => x.DNI == pPersona.DNI);
                p.Name = pPersona.Name;
                p.LastName = pPersona.LastName;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public bool ExisteDNI(Persona pPersona)
        {
            return lp.Exists(x=> x.DNI == pPersona.DNI);//Utilizo funcion anonima o landa
        }
    }
}

using Microsoft.VisualBasic;

namespace Agenda_de_Telefonos
{
    public partial class Form1 : Form


    {
        Agenda agenda;

        public Form1()
        {
            InitializeComponent();
            agenda = new Agenda();
        }

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }


        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.MultiSelect = false;
            dataGridView2.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void Mostrar(DataGridView pDGV, Object Po)
        {
            pDGV.DataSource = null; pDGV.DataSource = Po;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var dni = Interaction.InputBox("DNI : ");
                var p = new Persona(dni);
                if (agenda.ExisteDNI(p)) throw new Exception(" El DNI ya Existe");
                p.Name = Interaction.InputBox("Nombre : ");
                p.LastName = Interaction.InputBox("Apellido : ");
                if (MessageBox.Show("Desea agregar telefono", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    do
                    {
                        p.AgregarTelefono(new Telefono(Interaction.InputBox("Ingrese el Telefono")));
                        if (MessageBox.Show("Desea agregar otro telefono", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) break;

                    } while (true);
                }
                agenda.Agregarpersona(p);
                Mostrar(dataGridView1, agenda.RetornaPersona());
                dataGridView1_RowEnter(null, null);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    var p = dataGridView1.SelectedRows[0].DataBoundItem as Persona;
                    Mostrar(dataGridView2, p.RetornaTelefono());
                }
                else { dataGridView2.DataSource = null; dataGridView2.Rows.Clear(); }
            }

            catch (Exception) { };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0) throw new Exception(" No Existe Persona para Borrar");
                var p = dataGridView1.SelectedRows[0].DataBoundItem as Persona;
                agenda.BorrarPersona(p);
                Mostrar(dataGridView1, agenda.RetornaPersona());
                dataGridView1_RowEnter(null, null);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0) throw new Exception(" No Existe Persona para Modificar");
                var p = dataGridView1.SelectedRows[0].DataBoundItem as Persona;
                p.Name = Interaction.InputBox("Agregar Nombre", "", p.Name);
                p.LastName = Interaction.InputBox("Agregar Apellido", "", p.LastName);
                agenda.ModificarPersona(p);
                Mostrar(dataGridView1, agenda.RetornaPersona());
                dataGridView1_RowEnter(null, null);
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}

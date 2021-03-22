using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agenda
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            UpdateListBox();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this.monthCalendar1.SelectionStart, this);
            form2.ShowDialog();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox.SelectedItem.ToString() != "" || listBox.SelectedItem != null)
                {
                    Evento evento = NotebookInterface.eventos.Find(x =>
                    {
                        if (x.Data == monthCalendar1.SelectionStart && x.Descricao == listBox.SelectedItem.ToString()) return true;
                        else return false;
                    });
                    Console.WriteLine(evento.Descricao);
                    if (evento != null)
                    {
                        NotebookInterface.eventos.Remove(evento);
                        Database.DatabaseDelete(evento);
                    }
                    UpdateListBox();
                }
            }
            catch (NullReferenceException)
            {

            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            List<string> eventosDia = new List<string>();
            eventosDia.Clear();
            NotebookInterface.eventos.ForEach(x =>
            {
                if (monthCalendar1.SelectionStart == x.Data) eventosDia.Add(x.Descricao);
            });
            listBox.DataSource = eventosDia;
            listBox.Update();
        }

        public void UpdateListBox()
        {
            List<string> eventosDia = new List<string>();
            eventosDia.Clear();
            NotebookInterface.eventos.ForEach(x =>
            {
                if (monthCalendar1.SelectionStart == x.Data) eventosDia.Add(x.Descricao);
            });
            listBox.DataSource = eventosDia;
            listBox.Update();
        }
    }
}

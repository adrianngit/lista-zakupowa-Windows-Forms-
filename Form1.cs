using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lista
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if(progressBar1.Value < 100)
            {
                if(textBox1.Text.Length > 0)
                {
                    if (listBox1.Items.Contains(textBox1.Text))
                    {
                        DialogResult result =  MessageBox.Show("Element już istnieje czy chcesz go dodać?", "Uwaga!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if(result == DialogResult.No)
                        {
                            return;
                        }
                    }
                    listBox1.Items.Add(textBox1.Text);
                    AktualizujProgres();
                    textBox1.Text = "";
                }
                else
                {
                    MessageBox.Show("Wartość jest pusta!", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lista jest już pełna!", "Błąd!", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void AktualizujProgres()
        {
            int i = listBox1.Items.Count;
            progressBar1.Value = i * 10;
        }

        private void btnUsun_Click(object sender, EventArgs e)
        {
            int i = listBox1.SelectedIndex;
            if(i != -1)
            {
                listBox1.Items.RemoveAt(i);
                AktualizujProgres();
            }
            else
            {
                MessageBox.Show("Żaden element nie został zaznaczony!", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnczysc_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy chcesz wyczyścić wszystkie elementy?", "Uwaga!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return;
            }
            else
            {
                listBox1.Items.Clear();
                AktualizujProgres();
            }
            
        }
    }
}

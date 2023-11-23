using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Notes : Form
    {
        DataTable notes =new DataTable();
        bool edit=false;
        public Notes()
        {
            InitializeComponent();
        }

        private void Notes_Load(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");
            notes.Columns.Add("Note");
            previousNotes.DataSource = notes;
            
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            title.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            note.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            edit = true;

        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            title.Text = "";
            note.Text = "";

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (edit)
            {
                notes.Rows[previousNotes.CurrentCell.RowIndex]["Title"] = title.Text;
                notes.Rows[previousNotes.CurrentCell.RowIndex]["Note"] = note.Text;
            }
            else {
                notes.Rows.Add(title.Text, note.Text);


            }

            title.Text = "";
            note.Text = "";
            edit=false;
            


        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            try {
                notes.Rows[previousNotes.CurrentCell.RowIndex].Delete();     
            }
            catch (Exception ex) { 
            Console.WriteLine("Error deleting");
            }
        }

        private void previousNotes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            title.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            note.Text = notes.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            edit = true;

        }
    }
}

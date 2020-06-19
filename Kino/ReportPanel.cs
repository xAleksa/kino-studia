using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Dapper;


namespace ReportsGenerator
{
    public partial class ReportPanel : Form
    {

        GetFromDB db = new GetFromDB();
        public ReportPanel()
        {
            InitializeComponent();
            
        }
        private void GenerateButton_Click (object sender, EventArgs e)
        {
            try
            {
                Generator generator = new Generator();
                generator.windowState = this.WindowState;
                generator.dateFrom = DateFrom;
                generator.dateTo = DateTo;
                generator.checkBox1 = checkBox1;
                generator.comboBox1 = comboBox1;
                generator.comboBox2 = comboBox2;
                generator.Generate();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Something went wrong");
            }    
            
        }

        

        
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = -1;
            comboBox2.Items.Clear();

            if (comboBox1.SelectedIndex == 2)
            {
                
                db.doQuery("SELECT EmployeeId FROM WorkTime");
                

                
                if (db.reader.HasRows)
                {
                    while (db.reader.Read())
                    {
                        if (!comboBox2.Items.Contains(db.reader[0]))
                            comboBox2.Items.Add(db.reader[0]);
                    }
                }
                else
                {
                    MessageBox.Show("There is no data for this report.", "No user ID");
                }
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                
                db.doQuery("SELECT IdPracownika FROM CzasPracy");
                if (db.reader.HasRows)
                {
                    while (db.reader.Read())
                    {
                        if (!comboBox2.Items.Contains(db.reader[0]))
                            comboBox2.Items.Add(db.reader[0]);
                    }
                }
                else
                {
                    MessageBox.Show("There is no data for this report.", "No user ID");
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       

    }
}

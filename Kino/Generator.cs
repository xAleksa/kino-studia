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
using System;

namespace ReportsGenerator
{
    class Generator
    {

        private CheckBox checkBox_1;
        private FormWindowState windowState_pv;
        private ComboBox comboBox_1;
        private ComboBox comboBox_2;

        GetFromDB db = new GetFromDB();

        public DateTimePicker dateFrom

        {

            get { return db.dateFrom; }

            set { db.dateFrom = value; }

        }
        public DateTimePicker dateTo

        {

            get { return db.dateTo; }

            set { db.dateTo = value; }

        }


        public CheckBox checkBox1

        {

            get { return checkBox_1; }

            set { checkBox_1 = value; }

        }
        public FormWindowState windowState

        {

            get { return windowState_pv; }

            set { windowState_pv = value; }

        }

        public ComboBox comboBox1

        {

            get { return comboBox_1; }

            set { comboBox_1 = value; }

        }

        public ComboBox comboBox2

        {

            get { return comboBox_2; }

            set { comboBox_2 = value; }

        }

        public void Generate()
        {
            db.dataTable.Clear();
            db.dataTable.Rows.Clear();
            db.dataTable.Columns.Clear();
            db.dataTable.Dispose();
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a report type!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (comboBox_1.SelectedIndex == 0)
                db.GenerateAllMoviesReport();
            else if (comboBox_1.SelectedIndex == 1)
                db.GenerateWorkTimeReport();
            else if (comboBox_1.SelectedIndex == 2)
            {
                if (comboBox_2.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a User ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                    db.GenerateIndividualWorkTimeReport();
            }
            else if (comboBox_1.SelectedIndex == 3)
                db.GenerateSalariesReport();
            else if (comboBox_1.SelectedIndex == 4)
            {
                if (comboBox_2.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a User ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                    db.GenerateIndividualSalaryReport();
            }
            else if (comboBox_1.SelectedIndex == 5)
                db.GenerateIncomesReport();
            else if (comboBox_1.SelectedIndex == 6)
                db.GenerateFoodSaleReport();

            string destination;
            if ((comboBox_1.SelectedIndex == 2 || comboBox_1.SelectedIndex == 4) && comboBox_2.SelectedIndex != -1)
                destination = "C:/Users/Public/Documents/" + comboBox1.Text + " for Employee " + comboBox2.Text;
            else
                destination = "C:/Users/Public/Documents/" + comboBox1.Text;

            try
            {
                if (db.dataTable.Rows.Count > 0 && db.dataTable.Rows[0][0] != DBNull.Value)
                {
                    ToPdf toPDF = new ToPdf();
                    toPDF.comboBox1 = comboBox_1;
                    toPDF.ExportDataTableToPdf(db.dataTable, destination);

                    MessageBox.Show("Generated report: " + destination + ".",
                    "Report generated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (checkBox_1.Checked)
                    {
                        System.Diagnostics.Process.Start(@destination + ".pdf");
                        windowState_pv = System.Windows.Forms.FormWindowState.Minimized;
                    }
                }
                else
                {
                    if (comboBox1.SelectedIndex == 2 || comboBox1.SelectedIndex == 4)
                        MessageBox.Show("No data for selected timeframe for current Employee ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("No data for this report!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch
            {
                MessageBox.Show(destination + ".pdf is already opened or the file in in Read Only mode!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


    }
}

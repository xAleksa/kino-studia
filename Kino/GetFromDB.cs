using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportsGenerator
{
    class GetFromDB
    {
        private SqlDataReader Reader;
        private ComboBox comboBox;
        private ComboBox comboBox_2;


        private DateTimePicker DateFrom;
        private DateTimePicker DateTo;

        private DataTable dataTable_pv = new DataTable();

        public DateTimePicker dateFrom

        {

            get { return DateFrom; }

            set { DateFrom = value; }

        }
        public DateTimePicker dateTo

        {

            get { return DateTo; }

            set { DateTo = value; }

        }

        public DataTable dataTable

        {

            get { return dataTable_pv; }

            set { dataTable_pv = value; }

        }

        

        public SqlDataReader reader

        {

            get { return Reader; }

            set { Reader = value; }

        }
        public ComboBox comboBox1

        {

            get { return comboBox; }

            set { comboBox = value; }

        }

        public ComboBox comboBox2

        {

            get { return comboBox_2; }

            set { comboBox_2 = value; }

        }

        public GetFromDB()
        {

        }

        public void doQuery(string Query)
        {
            SqlConnection conn = new SqlConnection(Helper.CnnString("test"));
            conn.Open();
            SqlCommand cmd = new SqlCommand(Query, conn);
            Reader = cmd.ExecuteReader();
        }

        public void GenerateAllMoviesReport()
        {
            SqlConnection conn = new SqlConnection(Helper.CnnString("test"));
            conn.Open();
            string procedure = "AllMoviesReport";
            SqlCommand cmd = new SqlCommand(procedure, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DateFrom", DateFrom.Value);
            cmd.Parameters.AddWithValue("@DateTo", DateTo.Value);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable_pv);
            da.Dispose();

        }
        public void GenerateWorkTimeReport()
        {
            SqlConnection conn = new SqlConnection(Helper.CnnString("test"));
            conn.Open();
            SqlCommand cmd = new SqlCommand("WorkTimeReport", conn);
            cmd.Parameters.AddWithValue("@DateFrom", DateFrom.Value);
            cmd.Parameters.AddWithValue("@DateTo", DateTo.Value);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable_pv);
            da.Dispose();

        }
        public void GenerateIndividualWorkTimeReport()
        {

            SqlConnection conn = new SqlConnection(Helper.CnnString("test"));
            conn.Open();

            string procedure = "IndyvidualWorkTimeReport";
            SqlCommand cmd = new SqlCommand(procedure, conn);
            cmd.Parameters.AddWithValue("@EmployeeId", comboBox_2.Text);
            cmd.Parameters.AddWithValue("@DateFrom", DateFrom.Value);
            cmd.Parameters.AddWithValue("@DateTo", DateTo.Value);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable_pv);
            da.Dispose();


        }
        public void GenerateSalariesReport()
        {
            SqlConnection conn = new SqlConnection(Helper.CnnString("test"));
            conn.Open();
            string procedure = "SalaryReport";
            SqlCommand cmd = new SqlCommand(procedure, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable_pv);
            da.Dispose();
        }
        public void GenerateIndividualSalaryReport()
        {
            SqlConnection conn = new SqlConnection(Helper.CnnString("test"));
            conn.Open();
            string procedure = "IndyvidualSalaryReport";
            SqlCommand cmd = new SqlCommand(procedure, conn);
            cmd.Parameters.AddWithValue("@EmployeeId", comboBox_2.Text);
            cmd.Parameters.AddWithValue("@DateFrom", DateFrom.Value);
            cmd.Parameters.AddWithValue("@DateTo", DateTo.Value);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable_pv);
            da.Dispose();

        }
        public void GenerateIncomesReport()
        {
            SqlConnection conn = new SqlConnection(Helper.CnnString("test"));
            conn.Open();
            string procedure = "IncomesReport";
            SqlCommand cmd = new SqlCommand(procedure, conn);
            cmd.Parameters.AddWithValue("@DateFrom", DateFrom.Value);
            cmd.Parameters.AddWithValue("@DateTo", DateTo.Value);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable_pv);
            da.Dispose();

        }
        public void GenerateFoodSaleReport()
        {
            SqlConnection conn = new SqlConnection(Helper.CnnString("test"));
            conn.Open();
            string procedure = "FoodSaleReport";
            SqlCommand cmd = new SqlCommand(procedure, conn);
            cmd.Parameters.AddWithValue("@DateFrom", DateFrom.Value);
            cmd.Parameters.AddWithValue("@DateTo", DateTo.Value);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dataTable_pv);
            da.Dispose();

        }



    }
}

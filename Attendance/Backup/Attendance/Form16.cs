using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Attendance
{
    //Form16: Display "Delete Subject Name" form.
    public partial class Form16 : Form
    {
        OleDbConnection DBCon1;
        bool BDept;
        bool BClass;
    
        public Form16()
        {
            InitializeComponent();

            //Intialise New DataBase Connection 1
            DBCon1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MonthlyReport.mdb");

            //Open DataBase Connection 1
            DBCon1.Open();

            //Set Department Flag to false
            BDept = false;
            //Set Class Flag to false
            BClass = false;
        }

        ~Form16()
        {
            //Close DataBase Connection 1
            DBCon1.Close();
        }

        //This method will load Department, Class, Semester & Subject List in combobox1, combobox2, combobox3 & combobox4 respectively 
        private void Form16_Load(object sender, EventArgs e)
        {
            //Load List of Department in Combobox1
            //Get DataBase Adapter
            OleDbDataAdapter DBAdapter1 = new OleDbDataAdapter("select * from department", DBCon1);
            //Declare Data Set1
            DataSet DS1 = new DataSet();
            //Intialise IRecordCount to 0; IRecordCount is use to store no. of record afected
            int IRecordCount = 0;
            //Fill DataBase Adapter1 and set IRecordCount
            IRecordCount = DBAdapter1.Fill(DS1, "Department");
            //Set Data Table1
            DataTable DT1 = DS1.Tables["Department"];
            //Set Data View1
            DataView DV1 = DT1.DefaultView;
            //set Combobox Data source to Data View 1
            comboBox1.DataSource = DV1;
            //Set DisplayMember and ValueMember of Combobox1
            comboBox1.DisplayMember = "DEPT_NAME";
            comboBox1.ValueMember = "DEPT_ID";
            //Dispose DataTable1, DataSet1, DataBase Adapter 1 
            DT1.Dispose();
            DS1.Dispose();
            DBAdapter1.Dispose();

            //Set Department Flag to true
            BDept = true;

            //Load List of Class in Combobox2
            if (comboBox1.SelectedValue != null)
            {
                //Get DataBase Adapter2
                OleDbDataAdapter DBAdapter2 = new OleDbDataAdapter("select * from Class where dept_id =" + comboBox1.SelectedValue.ToString(), DBCon1);
                //Declare Data Set2
                DataSet DS2 = new DataSet();
                //Intialise IRecordCount to 0; IRecordCount is use to store no. of record afected
                int IRecordCount2 = 0;
                //Fill DataBase Adapter1 and set IRecordCount
                IRecordCount2 = DBAdapter2.Fill(DS2, "Class");
                //Set Data Table1
                DataTable DT2 = DS2.Tables["Class"];
                //Set Data View1
                DataView DV2 = DT2.DefaultView;
                //set Combobox Data source to Data View 1
                comboBox2.DataSource = DV2;
                //Set DisplayMember and ValueMember of Combobox1
                comboBox2.DisplayMember = "CLASS_NAME";
                comboBox2.ValueMember = "CLASS_ID";
                //Dispose DataTable1, DataSet1, DataBase Adapter 1 
                DT2.Dispose();
                DS2.Dispose();
                DBAdapter2.Dispose();
            }

            //Set Class Flag to true
            BClass = true;

            //Load Semester List in Combobox3
            //Get DataBase Adapter
            OleDbDataAdapter DBAdapter3 = new OleDbDataAdapter("select * from Semester", DBCon1);
            //Declare Data Set3
            DataSet DS3 = new DataSet();
            //Intialise IRecordCount3 to 0; IRecordCount3 is use to store no. of record afected
            int IRecordCount3 = 0;
            //Fill DataBase Adapter3 and set IRecordCount3
            IRecordCount3 = DBAdapter3.Fill(DS3, "Semester");
            //Set Data Table3
            DataTable DT3 = DS3.Tables["Semester"];
            //Set Data View3
            DataView DV3 = DT3.DefaultView;
            //set Combobox Data source to Data View 3
            comboBox3.DataSource = DV3;
            //Set DisplayMember and ValueMember of Combobox3
            comboBox3.DisplayMember = "SEM_NAME";
            comboBox3.ValueMember = "SEM_ID";
            //Dispose DataTable3, DataSet3, DataBase Adapter3 
            DT3.Dispose();
            DS3.Dispose();
            DBAdapter3.Dispose();

            if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null && comboBox3.SelectedValue != null)
            {
                //Get DataBase Adapter4
                OleDbDataAdapter DBAdapter4 = new OleDbDataAdapter("select * from Subject where dept_id =" + comboBox1.SelectedValue.ToString() + " and class_id =" + comboBox2.SelectedValue.ToString() + " and sem_id =" + comboBox3.SelectedValue.ToString(), DBCon1);
                //Declare Data Set4
                DataSet DS4 = new DataSet();
                //Intialise IRecordCount4 to 0; IRecordCount is use to store no. of record afected
                int IRecordCount4 = 0;
                //Fill DataBase Adapter4 and set IRecordCount4
                IRecordCount4 = DBAdapter4.Fill(DS4, "Subject");
                //Set Data Table4
                DataTable DT4 = DS4.Tables["Subject"];
                //Set Data View4
                DataView DV4 = DT4.DefaultView;
                //set Combobox Data source to Data View 4
                comboBox4.DataSource = DV4;
                //Set DisplayMember and ValueMember of Combobox1
                comboBox4.DisplayMember = "SUB_NAME";
                comboBox4.ValueMember = "SUB_IND";
                //Dispose DataTable1, DataSet1, DataBase Adapter 1 
                DT4.Dispose();
                DS4.Dispose();
                DBAdapter4.Dispose();
            }
        }

        //This method will load Class & Subject List in combobox2 & combobox4 if another department name is selected
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null && BDept == true)
            {
                //Set Class Flag to false
                BClass = false;
                //Get DataBase Adapter2
                OleDbDataAdapter DBAdapter2 = new OleDbDataAdapter("select * from Class where dept_id =" + comboBox1.SelectedValue.ToString(), DBCon1);
                //Declare Data Set2
                DataSet DS2 = new DataSet();
                //Intialise IRecordCount to 0; IRecordCount is use to store no. of record afected
                int IRecordCount2 = 0;
                //Fill DataBase Adapter1 and set IRecordCount
                IRecordCount2 = DBAdapter2.Fill(DS2, "Class");
                //Set Data Table1
                DataTable DT2 = DS2.Tables["Class"];
                //Set Data View1
                DataView DV2 = DT2.DefaultView;
                //set Combobox Data source to Data View 1
                comboBox2.DataSource = DV2;
                //Set DisplayMember and ValueMember of Combobox1
                comboBox2.DisplayMember = "CLASS_NAME";
                comboBox2.ValueMember = "CLASS_ID";
                //Dispose DataTable1, DataSet1, DataBase Adapter 1 
                DT2.Dispose();
                DS2.Dispose();
                DBAdapter2.Dispose();
                //Set Class Flag to true
                BClass = true;
            }
            else if (comboBox1.SelectedValue == null && BDept == true)
            {
                MessageBox.Show("No Department Exist");
            }

            if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null && comboBox3.SelectedValue != null && BDept == true)
            {
                //Get DataBase Adapter4
                OleDbDataAdapter DBAdapter4 = new OleDbDataAdapter("select * from Subject where dept_id =" + comboBox1.SelectedValue.ToString() + " and class_id =" + comboBox2.SelectedValue.ToString() + " and sem_id =" + comboBox3.SelectedValue.ToString(), DBCon1);
                //Declare Data Set4
                DataSet DS4 = new DataSet();
                //Intialise IRecordCount4 to 0; IRecordCount is use to store no. of record afected
                int IRecordCount4 = 0;
                //Fill DataBase Adapter4 and set IRecordCount4
                IRecordCount4 = DBAdapter4.Fill(DS4, "Subject");
                //Set Data Table4
                DataTable DT4 = DS4.Tables["Subject"];
                //Set Data View4
                DataView DV4 = DT4.DefaultView;
                //set Combobox Data source to Data View 4
                comboBox4.DataSource = DV4;
                //Set DisplayMember and ValueMember of Combobox1
                comboBox4.DisplayMember = "SUB_NAME";
                comboBox4.ValueMember = "SUB_IND";
                //Dispose DataTable1, DataSet1, DataBase Adapter 1 
                DT4.Dispose();
                DS4.Dispose();
                DBAdapter4.Dispose();
            }
        }

        //This method will load Subject List in combobox4 if class name is changed 
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null && comboBox3.SelectedValue != null && BClass == true)
            {
                //Get DataBase Adapter4
                OleDbDataAdapter DBAdapter4 = new OleDbDataAdapter("select * from Subject where dept_id =" + comboBox1.SelectedValue.ToString() + " and class_id =" + comboBox2.SelectedValue.ToString() + " and sem_id =" + comboBox3.SelectedValue.ToString(), DBCon1);
                //Declare Data Set4
                DataSet DS4 = new DataSet();
                //Intialise IRecordCount4 to 0; IRecordCount is use to store no. of record afected
                int IRecordCount4 = 0;
                //Fill DataBase Adapter4 and set IRecordCount4
                IRecordCount4 = DBAdapter4.Fill(DS4, "Subject");
                //Set Data Table4
                DataTable DT4 = DS4.Tables["Subject"];
                //Set Data View4
                DataView DV4 = DT4.DefaultView;
                //set Combobox Data source to Data View 4
                comboBox4.DataSource = DV4;
                //Set DisplayMember and ValueMember of Combobox1
                comboBox4.DisplayMember = "SUB_NAME";
                comboBox4.ValueMember = "SUB_IND";
                //Dispose DataTable1, DataSet1, DataBase Adapter 1 
                DT4.Dispose();
                DS4.Dispose();
                DBAdapter4.Dispose();
            }
        }

        //This method will load Subject List in combobox4 if semester name is changed
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null && comboBox3.SelectedValue != null)
            {
                //Get DataBase Adapter4
                OleDbDataAdapter DBAdapter4 = new OleDbDataAdapter("select * from Subject where dept_id =" + comboBox1.SelectedValue.ToString() + " and class_id =" + comboBox2.SelectedValue.ToString() + " and sem_id =" + comboBox3.SelectedValue.ToString(), DBCon1);
                //Declare Data Set4
                DataSet DS4 = new DataSet();
                //Intialise IRecordCount4 to 0; IRecordCount is use to store no. of record afected
                int IRecordCount4 = 0;
                //Fill DataBase Adapter4 and set IRecordCount4
                IRecordCount4 = DBAdapter4.Fill(DS4, "Subject");
                //Set Data Table4
                DataTable DT4 = DS4.Tables["Subject"];
                //Set Data View4
                DataView DV4 = DT4.DefaultView;
                //set Combobox Data source to Data View 4
                comboBox4.DataSource = DV4;
                //Set DisplayMember and ValueMember of Combobox1
                comboBox4.DisplayMember = "SUB_NAME";
                comboBox4.ValueMember = "SUB_IND";
                //Dispose DataTable1, DataSet1, DataBase Adapter 1 
                DT4.Dispose();
                DS4.Dispose();
                DBAdapter4.Dispose();
            }
 
        }

        //This Method will delete Subject name from database & reload subject list in combobox4
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox4.SelectedValue != null)
            {
                OleDbCommand DBCom1 = new OleDbCommand("Delete from Subject where Dept_id =" + comboBox1.SelectedValue.ToString() + " and Class_id =" + comboBox2.SelectedValue.ToString() + " and sem_id =" + comboBox3.SelectedValue.ToString() + " and sub_ind=" + comboBox4.SelectedValue.ToString(), DBCon1);
                DBCom1.ExecuteNonQuery();
                MessageBox.Show("Subject is Delated");
            }
            else
            {
                MessageBox.Show("No Subject Exist");
            }
 
            if (comboBox1.SelectedValue != null && comboBox2.SelectedValue != null && comboBox3.SelectedValue != null)
            {
                //Get DataBase Adapter4
                OleDbDataAdapter DBAdapter4 = new OleDbDataAdapter("select * from Subject where dept_id =" + comboBox1.SelectedValue.ToString() + " and class_id =" + comboBox2.SelectedValue.ToString() + " and sem_id =" + comboBox3.SelectedValue.ToString(), DBCon1);
                //Declare Data Set4
                DataSet DS4 = new DataSet();
                //Intialise IRecordCount4 to 0; IRecordCount is use to store no. of record afected
                int IRecordCount4 = 0;
                //Fill DataBase Adapter4 and set IRecordCount4
                IRecordCount4 = DBAdapter4.Fill(DS4, "Subject");
                //Set Data Table4
                DataTable DT4 = DS4.Tables["Subject"];
                //Set Data View4
                DataView DV4 = DT4.DefaultView;
                //set Combobox Data source to Data View 4
                comboBox4.DataSource = DV4;
                //Set DisplayMember and ValueMember of Combobox1
                comboBox4.DisplayMember = "SUB_NAME";
                comboBox4.ValueMember = "SUB_IND";
                //Dispose DataTable1, DataSet1, DataBase Adapter 1 
                DT4.Dispose();
                DS4.Dispose();
                DBAdapter4.Dispose();
            }
            
        }
    }
}
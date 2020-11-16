using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperUltraExcellentXMLDataTool
{
    public partial class FormAdd : Form
    {
        DataSet ds;
        DataSet dsadd=new DataSet();
        public void setDS(DataSet ds)
        {
            this.ds = ds;
        }
        public FormAdd()
        {
            InitializeComponent();
        }

        private void FormAdd_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = ds.Tables[0].Clone();
            dsadd.Tables.Add(dt);
            dataGridView1.DataSource = dsadd.Tables[0];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(dsadd.Tables.Count == 0)
            {
                Close();
            }
            foreach(DataRow dr in dsadd.Tables[0].Rows)
            {
                DataRow drnew = ds.Tables[0].NewRow();
                drnew.ItemArray = dr.ItemArray;
                ds.Tables[0].Rows.Add(drnew);
            }
            Close();
        }
    }
}

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
    public partial class FormSearch : Form
    {
        DataRow[] drs;
        DataSet ds;
        DataTable dtn;
        public void setDS(DataSet ds)
        {
            this.ds = ds;
        }
        public FormSearch()
        {
            InitializeComponent();
        }

        private void FormSearch_Load(object sender, EventArgs e)
        {
            foreach (DataColumn dc in ds.Tables[0].Columns)
            {
                comboBox1.Items.Add(dc.ColumnName);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("请选择或输入要查询的信息");
                return;
            }
            try
            {
                drs = ds.Tables[0].Select(comboBox1.Text + "=" + textBox1.Text);
            }
            catch (EvaluateException)
            {
                drs = ds.Tables[0].Select(comboBox1.Text + "='" + textBox1.Text + "'");
            }
            if (drs.Length == 0)
                return;
            dtn = ds.Tables[0].Clone();
            if (drs.Length > 0)
                foreach (DataRow dr in drs)
                {
                    dtn.ImportRow(dr);
                }
            DataSet dsn = new DataSet();
            dsn.Tables.Add(dtn);
            dataGridView1.DataSource = dsn.Tables[0];
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            IEqualityComparer<DataRow> cmp = DataRowComparer.Default;
            if (drs.Length > 0)
            {
                foreach (DataRow drdel in drs)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if (cmp.Equals(dr, drdel))
                        {
                            ds.Tables[0].Rows.Remove(dr);
                            break;
                        }
                    }
                }
                dtn.Clear();
            }
        }
    }
}

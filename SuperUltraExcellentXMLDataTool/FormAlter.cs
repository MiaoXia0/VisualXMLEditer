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
    public partial class FormAlter : Form
    {
        DataSet ds;

        public void setDS(DataSet ds)
        {
            this.ds = ds;
        }
        public FormAlter()
        {
            InitializeComponent();
        }

        private void FormAlter_Load(object sender, EventArgs e)
        {
            foreach (DataColumn dc in ds.Tables[0].Columns)
            {
                comboBox1.Items.Add(dc.ColumnName);
                comboBox2.Items.Add(dc.ColumnName);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow[] drs;
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
            foreach (DataRow dr in drs)
            {
                for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                {
                    if (ds.Tables[0].Columns[i].ColumnName == comboBox2.Text)
                    {
                        dr[i] = textBox2.Text;
                    }
                }
            }

        }
    }
}

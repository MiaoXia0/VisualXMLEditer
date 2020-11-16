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
    public partial class FormAna : Form
    {
        DataSet ds;
        public void setDS(DataSet ds)
        {
            this.ds = ds;
        }
        public FormAna()
        {
            InitializeComponent();
        }

        private void FormAna_Load(object sender, EventArgs e)
        {
            foreach (DataColumn dc in ds.Tables[0].Columns)
            {
                comboBox1.Items.Add(dc.ColumnName);
            }
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            bool fail = false;
            double sum = 0;
            if (comboBox1.Text == "")
            {
                MessageBox.Show("请选择或输入要统计的标签");
                return;
            }

            for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
            {
                if (ds.Tables[0].Columns[i].ColumnName == comboBox1.Text)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        try
                        {
                            sum += Convert.ToDouble(dr[i]);
                        }
                        catch(Exception)
                        {
                            fail = true;
                            break;
                        }
                    }
                }
            }
            if (fail)
                lblSum.Text = "请选择数值型数据！";
            else
                lblSum.Text = sum.ToString();
        }

        private void btnMean_Click(object sender, EventArgs e)
        {
            bool fail = false;
            double sum = 0;
            if (comboBox1.Text == "")
            {
                MessageBox.Show("请选择或输入要统计的标签");
                return;
            }

            for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
            {
                if (ds.Tables[0].Columns[i].ColumnName == comboBox1.Text)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        try
                        {
                            sum += Convert.ToDouble(dr[i]);
                        }
                        catch
                        {
                            fail = true;
                            break;
                        }
                    }
                }
            }
            if (fail)
                lblSum.Text = "请选择数值型数据！";
            else
                lblSum.Text = (sum / ds.Tables[0].Rows.Count).ToString();
        }
    }
}

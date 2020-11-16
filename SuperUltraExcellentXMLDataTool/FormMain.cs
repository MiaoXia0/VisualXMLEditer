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
    public partial class FormMain : Form
    {
        DataSet ds = new DataSet();
        string currentfile = "";
        public FormMain()
        {
            InitializeComponent();
        }
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ds.Tables.Count == 0)
            {
                MessageBox.Show("请先读取或创建XML！");
                return;
            }
            if (currentfile == "")
            {
                另存为ToolStripMenuItem_Click(sender, e);
                return;
            }
            ds.WriteXml(currentfile);
            toolStripStatusLabel1.Text = "成功保存！";
            Text = currentfile;
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog
            {
                Filter = "XML Files(*.xml)|*.xml"
            };
            op.ShowDialog();
            currentfile = op.FileName;
            if (op.FileName == "")
                return;
            ds.Clear();
            ds.ReadXml(op.FileName);
            if (ds.Tables.Count == 0)
            {
                MessageBox.Show("XML文件为空！");
                return;
            }
            dataGridView1.DataSource = ds.Tables[0];
            toolStripStatusLabel1.Text = "读取完毕！" + "根元素: <" + ds.DataSetName + ">, " + "共" + ds.Tables[0].Rows.Count.ToString() + "行，" + ds.Tables[0].Columns.Count.ToString() + "列数据，表中数据可直接修改。";
            Text = currentfile;
        }

        private void 另存为ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ds.Tables.Count == 0)
            {
                MessageBox.Show("请先读取或创建XML！");
                return;
            }
            SaveFileDialog sv = new SaveFileDialog()
            {
                Filter = "XML Files(*.xml)|*.xml"
            };
            sv.ShowDialog();
            if (sv.FileName == "")
                return;
            currentfile = sv.FileName;
            ds.WriteXml(sv.FileName);
            toolStripStatusLabel1.Text = "成功保存！";
            Text = currentfile;
        }
        private void 状态栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (状态栏ToolStripMenuItem.Checked == true)
            {
                statusStrip1.Visible = false;
                状态栏ToolStripMenuItem.Checked = false;
            }
            else
            {
                statusStrip1.Visible = true;
                状态栏ToolStripMenuItem.Checked = true;
            }

        }
        private void statusRefresh()
        {
            toolStripStatusLabel1.Text = "根元素: <" + ds.DataSetName + ">, " + ds.Tables[0].Rows.Count.ToString() + "行，" + ds.Tables[0].Columns.Count.ToString() + "列";
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            statusRefresh();
        }
        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ds.Tables.Count == 0)
            {
                MessageBox.Show("请先读取或创建XML！");
                return;
            }
            FormSearch fs = new FormSearch();
            fs.setDS(ds);
            fs.ShowDialog();
        }

        private void 统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ds.Tables.Count == 0)
            {
                MessageBox.Show("请先读取或创建XML！");
                return;
            }
            FormAna fan = new FormAna();
            fan.setDS(ds);
            fan.ShowDialog();
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ds.Tables.Count == 0)
            {
                MessageBox.Show("请先读取或创建XML！");
                return;
            }
            FormAdd add = new FormAdd();
            add.setDS(ds);
            add.ShowDialog();
            statusRefresh();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ds.Tables.Count == 0)
            {
                MessageBox.Show("请先读取或创建XML！");
                return;
            }
            FormAlter fa = new FormAlter();
            fa.setDS(ds);
            fa.ShowDialog();
            statusRefresh();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ds = new DataSet();
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            InputForm ip = new InputForm();
            ip.text = "请输入根元素名名";
            ip.ShowDialog();
            ds.DataSetName = ip.getText();
            ip = new InputForm();
            ip.text = "请输入列名";
            ip.ShowDialog();
            dc.ColumnName = ip.getText();
            dt.Columns.Add(dc);
            ds.Tables.Add(dt);
            dataGridView1.DataSource = ds.Tables[0];
            toolStripStatusLabel1.Text = "创建完毕！" + "根元素: <" + ds.DataSetName + ">, ";
            Text = "未命名";
        }

        private void 添加新列CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ds.Tables.Count == 0)
            {
                MessageBox.Show("请先读取或创建XML！");
                return;
            }
            DataColumn dc = new DataColumn();
            InputForm ip = new InputForm();
            ip.text = "请输入列名";
            ip.ShowDialog();
            if (ip.getText() == "")
                return;
            dc.ColumnName = ip.getText();
            ds.Tables[0].Columns.Add(dc);
            statusRefresh();
        }

        private void 删除列RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Cname;
            InputForm ip = new InputForm();
            ip.ShowDialog();
            if (ip.getText() == "")
                return;
            Cname = ip.getText();
            foreach (DataColumn dc in ds.Tables[0].Columns)
            {
                if (dc.ColumnName == Cname)
                {
                    ds.Tables[0].Columns.Remove(dc);
                    return;
                }
            }
            dataGridView1.Refresh();
            statusRefresh();
        }

        private void 修改根元素EToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ds.Tables.Count == 0)
            {
                MessageBox.Show("请先读取或创建XML！");
                return;
            }
            InputForm ip = new InputForm();
            ip.text = "请输入根元素名名";
            ip.ShowDialog();
            ds.DataSetName = ip.getText();
            statusRefresh();
        }
    }
}

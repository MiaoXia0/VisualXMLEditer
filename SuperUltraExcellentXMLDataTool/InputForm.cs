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
    public partial class InputForm : Form
    {
        public string text = "";
        public InputForm()
        {
            InitializeComponent();
        }
        public string getText()
        {
            return textBox1.Text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InputForm_Load(object sender, EventArgs e)
        {
            label1.Text = text;
        }
    }
}

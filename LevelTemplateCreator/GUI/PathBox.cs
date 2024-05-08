using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelTemplateCreator
{
    public partial class PathBox : UserControl
    {
        public PathBox()
        {
            InitializeComponent();
        }

        [Browsable(true)]
        public override string Text { get => TextBox.Text; set => TextBox.Text = value; }

        private void Button_Click(object sender, EventArgs e)
        {
            if (FolderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                Text = FolderBrowserDialog.SelectedPath;
            }
        }
    }
}

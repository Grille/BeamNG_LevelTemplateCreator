using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelTemplateCreator.GUI
{
    public partial class LabledTextbox : UserControl
    {
        [Browsable(true)]
        public string LabelText { get => Label.Text; set => Label.Text = value; }


        [Browsable(true)]
        public override string Text { get => TextBox.Text; set => TextBox.Text = value; }


        public LabledTextbox()
        {
            InitializeComponent();
        }
    }
}

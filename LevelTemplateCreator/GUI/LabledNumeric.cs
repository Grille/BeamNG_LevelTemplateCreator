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
    public partial class LabledNumeric : UserControl
    {
        [Browsable(true)]
        public string LabelText { get => Label.Text; set => Label.Text = value; }

        [Browsable(true)]
        public decimal Value { get => Numeric.Value; set => Numeric.Value = value; }

        [Browsable(true)]
        public override string Text { get => Numeric.Text; set => Numeric.Text = value; }

        public LabledNumeric()
        {
            InitializeComponent();

            Numeric.Minimum = 0m;
            Numeric.Maximum = decimal.MaxValue;
        }
    }
}

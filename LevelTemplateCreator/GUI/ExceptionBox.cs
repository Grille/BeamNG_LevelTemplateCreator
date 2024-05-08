using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.GUI;

internal static class ExceptionBox
{
    public static DialogResult Show(IWin32Window owner, Exception e)
    {
        return MessageBox.Show(owner, e.Message, e.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

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
        [Browsable(true)]
        public enum TargetType
        {
            [Browsable(true)]
            Folder,
            [Browsable(true)]
            OpenFile,
            [Browsable(true)]
            SaveFile,
        }

        public string FileFilter { get; set; } = "All files (*.*)|*.*";


        FolderBrowserDialog _folderDialog;
        OpenFileDialog _openFileDialog;
        SaveFileDialog _saveFileDialog;

        [Browsable(true)]
        public TargetType Target { get; set; }

        public PathBox()
        {
            InitializeComponent();

            _folderDialog = new FolderBrowserDialog();
            _openFileDialog = new OpenFileDialog();
            _saveFileDialog = new SaveFileDialog();
        }

        [Browsable(true)]
        public override string Text
        {
            get => TextBox.Text;
            set
            {
                TextBox.Text = value;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            switch (Target)
            {
                case TargetType.Folder:
                {
                    FolderDialog(_folderDialog);
                    break;
                }
                case TargetType.OpenFile:
                {
                    FileDialog(_openFileDialog);
                    break;
                }
                case TargetType.SaveFile:
                {
                    FileDialog(_saveFileDialog);
                    break;
                }
            }
        }

        void FolderDialog(FolderBrowserDialog dialog)
        {
            dialog.SelectedPath = Text;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Text = dialog.SelectedPath;
            }
        }

        void FileDialog(FileDialog dialog)
        {
            dialog.FileName = Text;
            dialog.Filter = FileFilter;
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                Text = dialog.FileName;
            }
        }
    }
}

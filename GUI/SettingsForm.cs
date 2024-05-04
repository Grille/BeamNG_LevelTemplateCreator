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
    public partial class SettingsForm : Form
    {
        string backupgame, backupuser, backuppack;
        public SettingsForm()
        {
            InitializeComponent();

            backupgame = pathBoxGame.Text = SystemInfo.GameDirPath;
            backupuser = pathBoxUser.Text = SystemInfo.UserDirPath;
            backuppack = pathBoxPack.Text = SystemInfo.PackagesDirPath;

            Update();

            pathBoxGame.TextBox.TextChanged += (sender, e) =>
            {
                SystemInfo.GameDirPath = pathBoxGame.Text;
                Update();

            };
            pathBoxUser.TextBox.TextChanged += (sender, e) =>
            {
                SystemInfo.UserDirPath = pathBoxUser.Text;
                Update();
            };
            pathBoxPack.TextBox.TextChanged += (sender, e) =>
            {
                SystemInfo.PackagesDirPath = pathBoxPack.Text;
            };
        }

        private void Update()
        {
            SystemInfo.Validate();

            pathBoxGame.TextBox.ForeColor = SystemInfo.IsGameDirValid ? Color.Black : Color.Red;
            pathBoxUser.TextBox.ForeColor = SystemInfo.IsUserDirValid ? Color.Black : Color.Red;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            SystemInfo.GameDirPath = backupgame;
            SystemInfo.UserDirPath = backupuser;
            SystemInfo.PackagesDirPath = backuppack;

            SystemInfo.Validate();

            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            SystemInfo.Save();
            //SystemInfo.GamedataPath = pathBoxOut.Text;
            Close();
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            SystemInfo.TryFindInvalid();

            pathBoxGame.Text = SystemInfo.GameDirPath;
            pathBoxUser.Text = SystemInfo.UserDirPath;
        }
    }
}

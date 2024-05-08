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

            backupgame = pathBoxGame.Text = EnvironmentInfo.GameData.Path;
            backupuser = pathBoxUser.Text = EnvironmentInfo.UserData.Path;
            backuppack = pathBoxPack.Text = EnvironmentInfo.Packages.Path;

            UpdateColor();

            pathBoxGame.TextBox.TextChanged += (sender, e) =>
            {
                EnvironmentInfo.GameData.Path = pathBoxGame.Text;
                UpdateColor();

            };
            pathBoxUser.TextBox.TextChanged += (sender, e) =>
            {
                EnvironmentInfo.UserData.Path = pathBoxUser.Text;
                UpdateColor();
            };
            pathBoxPack.TextBox.TextChanged += (sender, e) =>
            {
                EnvironmentInfo.Packages.Path = pathBoxPack.Text;
                UpdateColor();
            };
        }

        private void UpdateColor()
        {
            pathBoxGame.TextBox.ForeColor = EnvironmentInfo.GameData.IsValid ? Color.Black : Color.Red;
            pathBoxUser.TextBox.ForeColor = EnvironmentInfo.UserData.IsValid ? Color.Black : Color.Red;

            pathBoxPack.TextBox.ForeColor = EnvironmentInfo.Packages.IsValid ? Color.Black : Color.Red;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            EnvironmentInfo.GameData.Path = backupgame;
            EnvironmentInfo.UserData.Path = backupuser;
            EnvironmentInfo.Packages.Path = backuppack;

            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            EnvironmentInfo.Save();
            //SystemInfo.GamedataPath = pathBoxOut.Text;
            Close();
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            EnvironmentInfo.TryFindInvalid();

            pathBoxGame.Text = EnvironmentInfo.GameData.Path;
            pathBoxUser.Text = EnvironmentInfo.UserData.Path;
        }
    }
}

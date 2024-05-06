using System.Diagnostics;
using System.Text;
using LevelTemplateCreator.Assets;

namespace LevelTemplateCreator
{
    public partial class MainForm : Form
    {
        AssetLibary AssetLibary { get; set; }
        Level Level { get; set; }

        public MainForm()
        {
            InitializeComponent();

            AssetLibary = new AssetLibary();
            Level = new Level();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void createTexturePackFromLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var fd = new FolderBrowserDialog();
            fd.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Export();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.SelectedPath;
                Export(path);
            }
        }

        bool AssertEnvironmentInfo()
        {
            if (EnvironmentInfo.IsValid)
                return true;

            new SettingsForm().ShowDialog(this);

            if (EnvironmentInfo.IsValid)
                return true;

            var sb = new StringBuilder();
            sb.AppendLine("Some of the paths are not correctly set, the program will not work correctly until this is fixed.");
            sb.AppendLine();
            sb.AppendLine($"BeamNG-gamdata path valid: {EnvironmentInfo.GameData.IsValid}");
            sb.AppendLine($"BeamNG-userdata path valid: {EnvironmentInfo.UserData.IsValid}");
            sb.AppendLine($"Content path valid: {EnvironmentInfo.Packages.IsValid}");

            MessageBox.Show(this, sb.ToString(), "Invalid Paths.", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return false;
        }

        void Export()
        {
            if (!AssertEnvironmentInfo())
                return;

            Export(EnvironmentInfo.UserData.LevelsPath);
        }

        void Export(string path)
        {
            if (!AssertEnvironmentInfo())
                return;

            var fullPath = Path.Combine(path, Level.Namespace);

            if (Directory.Exists(fullPath))
            {
                if (MessageBox.Show(this, $"Level '{Level.Namespace}' already exists at '{path}'.\nDo you want to overwrite?", "Level alredy exists", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    Directory.Delete(fullPath, true);
                }
                else
                {
                    return;
                }
            }

            Directory.CreateDirectory(fullPath);

            Level.Content.Clear();
            Level.Content.Add(ContentManager.GetSelectedAssets());
            Level.Content.Preview = AssetLibary.Preview;
            Level.Content.PrintSumary();

            Level.Export(fullPath);

            if (MessageBox.Show(this, $"Level '{Level.Namespace}' at '{path}' successfully created, do you want to open it now?", "Template successfully created", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                Process.Start("explorer.exe", fullPath);
        }

        private void systemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog(this);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            EnvironmentInfo.Load();
            AssertEnvironmentInfo();

            if (!EnvironmentInfo.Packages.IsValid)
            {
                Close();
                return;
            }

            EnvironmentInfo.PrintSumary();

            var loader = new AssetLibaryLoader(AssetLibary);
            loader.LoadDirectory(EnvironmentInfo.Packages.Path);
            loader.PrintErrors();

            AssetLibary.SeperateGroundCoverInstances();
            AssetLibary.PrintSumary();

            LevelSettings.SetLevel(Level);

            ContentManager.SetLibary(AssetLibary);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ContentManager.SetItemHeight(64);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ContentManager.SetItemHeight(128);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ContentManager.SetItemHeight(256);
        }
    }
}

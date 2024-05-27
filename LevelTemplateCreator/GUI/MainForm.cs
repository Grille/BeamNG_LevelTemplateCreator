using System.Diagnostics;
using System.Text;
using Grille.BeamNG;
using Grille.BeamNG.IO;
using Grille.BeamNG.Logging;
using LevelTemplateCreator.Assets;
using LevelTemplateCreator.GUI;

namespace LevelTemplateCreator
{
    public partial class MainForm : Form
    {
        AssetLibary AssetLibary { get; set; }
        LevelExporter Level { get; set; }

        public MainForm()
        {
            InitializeComponent();

            AssetLibary = new AssetLibary();
            Level = new LevelExporter(AssetLibary);

            LevelSettings.ButtonSave.Click += (object? sender, EventArgs e) =>
            {
                Export();
            };
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
            var size = Level.Terrain.CalcApproxSize();
            if (size.Megabyte > 200)
            {
                var message = $"The terrain file you’re trying to export will be larger then {size}, continue anyway?";
                if (MessageBox.Show(this, message, $"Large file size {size}", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) == DialogResult.Cancel)
                {
                    return;
                }
            }

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

            try
            {
                Directory.CreateDirectory(fullPath);

                Level.SetContent(ContentManager.GetSelectedAssets());
                Level.Export(fullPath);
            }
            catch (Exception e)
            {
                ExceptionBox.Show(this, e);
                if (Program.Debug)
                    throw;
            }

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
            LevelSettings.SetLevel(Level);
            EnvironmentInfo.Load();
            LoadContent();

            //ToolTip.SetToolTip(LevelSettings.ComboBoxCopyMode, "");
        }

        void LoadContent()
        {
            if (!AssertEnvironmentInfo())
                return;

            AssetLibary.Clear();

            var loader = new AssetLibaryLoader(AssetLibary) { Debug = true };
            loader.LoadDirectory(EnvironmentInfo.Packages.Path);

            loader.Print();

            AssetLibary.SeperateGroundCoverInstances();
            AssetLibary.PrintSumary();

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

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadContent();
        }

        private void terrainMergerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TerrainMerger().Show();
        }
    }
}

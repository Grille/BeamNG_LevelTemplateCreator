using System.Diagnostics;
using LevelTemplateCreator.Packages;

namespace LevelTemplateCreator
{
    public partial class MainForm : Form
    {
        PackageLibary Ressources { get; set; }
        Level Level { get; set; }

        public MainForm()
        {
            InitializeComponent();

            Level = new Level();
            Ressources = new PackageLibary();
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
            if (!SystemInfo.IsValid) {
                new SettingsForm().ShowDialog(this);
            }

            Export(SystemInfo.UserDirLevelsPath);
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

        void Export(string path)
        {
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

            Level.Materials.Clear();
            foreach (var material in Ressources.TerrainMaterials)
            {
                Level.Materials.Add(material.Material);
            }

            Level.LevelPreset = (LevelPreset)comboBoxPreset.SelectedItem;
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

            SystemInfo.Load();

            if (!SystemInfo.IsValid)
            {
                new SettingsForm().ShowDialog(this);
            }

            Ressources.LoadDirectory(SystemInfo.PackagesDirPath);

            foreach (var item in Ressources.LevelPresets)
            {
                comboBoxPreset.Items.Add(item);
            }
            comboBoxPreset.SelectedIndex = 0;

            terainSettings1.Terrain = Level.Terrain;

            textBoxNamespace.Text = Level.Namespace;
            textBoxTitle.Text = Level.Info.Title;
            textBoxAuthors.Text = Level.Info.Authors;
        }
    }
}

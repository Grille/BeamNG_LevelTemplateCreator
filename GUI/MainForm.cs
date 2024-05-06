using System.Diagnostics;
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
            Level = new Level(AssetLibary);
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
            if (!EnvironmentInfo.IsValid) {
                new SettingsForm().ShowDialog(this);
            }

            Export(EnvironmentInfo.UserData.LevelsPath);
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

            Level.TerrainMaterials.Clear();
            foreach (var material in AssetLibary.TerrainMaterials)
            {
                Level.TerrainMaterials.Add(material);
            }

            Level.LevelPreset = LevelSettings.SelectedLevelPreset;
            Level.Preview = AssetLibary.Preview;
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

            if (!EnvironmentInfo.IsValid)
            {
                new SettingsForm().ShowDialog(this);
            }

            var sw = Stopwatch.StartNew();

            var loader = new AssetLibaryLoader(AssetLibary);
            loader.LoadDirectory(EnvironmentInfo.Packages.Path);

            if (loader.Errors.Count > 0)
            {
                var error = loader.Errors[0];
                var exception = error.Exception;
                MessageBox.Show($"Error at '{error.File}'\n\n{exception.Message}\n\n{exception.StackTrace}", exception.GetType().FullName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            /*
            try
            {
                //AssetLibary.LoadDirectory(EnvironmentInfo.Packages.Path);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}\n\n{ex.StackTrace}", ex.GetType().FullName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */

            Console.WriteLine(sw.ElapsedMilliseconds);

            LevelSettings.Level = Level;

            foreach (var item in AssetLibary.TerrainMaterials)
            {
                contentManager1.AssetListBoxAvailable.Items.Add(item);
            }


        }
    }
}

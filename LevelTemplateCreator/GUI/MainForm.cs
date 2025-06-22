using System.Diagnostics;
using System.Text;
using System.Numerics;

using Grille.BeamNG;
using Grille.BeamNG.Collections;
using Grille.BeamNG.IO;
using Grille.BeamNG.IO.Binary.Torque3D;
using Grille.BeamNG.Logging;
using LevelTemplateCreator.Assets;
using LevelTemplateCreator.GUI;
using LevelTemplateCreator.Scripting;
using Grille.BeamNG.SceneTree.Forest;
using Grille.BeamNG.SceneTree.Art;

namespace LevelTemplateCreator
{
    public partial class MainForm : Form
    {
        AssetLibary AssetLibary { get; set; }
        LevelExporter Level { get; set; }

        public MainForm()
        {
            InitializeComponent();

            Icon = Properties.Resources.GrilleBeamNgIcon;

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

        void SaveAsScript(string path)
        {
            using var stream = File.Create(path);
            using var writer = new StreamWriter(stream, leaveOpen: true);

            writer.WriteLine($"Assets.Clear()");

            foreach (var asset in ContentManager.GetSelectedAssets())
            {
                writer.WriteLine($"Assets.Add({asset.Key})");
            }
        }

        void LoadScript(string path)
        {
            var cfg = new CfgScript();
            using (var stream = File.OpenRead(path))
            {
                cfg.Parse(stream);
            }

            var evaluator = new CfgScriptEvaluator(cfg);
            evaluator.Actions.Add("Assets.Clear", (args) => ContentManager.ClearSelected());
            evaluator.Actions.Add("Assets.Add", (args) => ContentManager.Select(args[0]));
            evaluator.Run();
        }

        void LoadContent()
        {
            if (!AssertEnvironmentInfo())
                return;

            AssetLibary.Clear();

            var loader = new AssetLibaryLoader(AssetLibary) { Debug = Program.Debug };
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

        public const string CfgFilter = "Cfg Files(*.CFG)|*.cfg;|All files (*.*)|*.*";

        private void savePresetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog()
            {
                Filter = CfgFilter,
                DefaultExt = "cfg",
            };
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SaveAsScript(dialog.FileName);
            }
        }

        private void loadPresetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog()
            {
                Filter = CfgFilter,
            };
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    LoadScript(dialog.FileName);
                }
                catch (Exception ex)
                {
                    ExceptionBox.Show(this, ex);
                }
            }
        }

        public const string MisDecalFilter = "Decals Files(*.CFG)|*.mis.decals;|All files (*.*)|*.*";


        private void misDecalV5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var opendialog = new OpenFileDialog()
            {
                Filter = MisDecalFilter,
            };
            if (opendialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            using var openstream = File.OpenRead(opendialog.FileName);
            var decals = MisDecalsV5Serializer.Deserialize(openstream);
            var dict = MisDecalsV5Serializer.ConvertToV2Dict(decals);

            using var savedialog = new SaveFileDialog();
            if (savedialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            using var savestream = File.Create(savedialog.FileName);
            JsonDictSerializer.Serialize(savestream, dict, true);
        }

        public const string Forest4JsonFilter = "Decals Files(*.CFG)|*.forest4.json;|All files (*.*)|*.*";

        private void batchEditForest4jsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var opendialog = new OpenFileDialog()
            {
                Multiselect = true,
                Filter = Forest4JsonFilter,
            };
            if (opendialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            var rnd = new Random(1);

            foreach (var fileName in opendialog.FileNames)
            {
                var forest = new ForestItemCollection();
                forest.Load(fileName);

                foreach (var item in forest)
                {

                    float angle = rnd.NextSingle() * 2f * MathF.PI;
                    float cos = MathF.Cos(angle);
                    float sin = MathF.Sin(angle);
                    var matrix = item.RotationMatrix.Value;
                    //matrix[0] = cos; matrix[1] = -sin; matrix[2] = 0;
                    //matrix[3] = sin; matrix[4] = cos; matrix[5] = 0;
                    //matrix[6] = 0; matrix[7] = 0; matrix[8] = 1;

                    item.Scale.Value = rnd.NextSingle() * 0.5f + 0.75f;
                }

                forest.Save(fileName);
            }
        }

        private void treeMapBuilderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TreeMapBuilder().Show();
        }

        private void enableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var opendialog = new OpenFileDialog()
            {
                Multiselect = true,
            };
            if (opendialog.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            foreach (var fileName in opendialog.FileNames)
            {
                var items = new MaterialItems(null);
                items.Load(fileName);

                foreach (var item in items.Enumerate<ObjectMaterial>())
                {
                    item.Stage0.UseAnisotropic.Value = true;
                    item.AlphaTest.Value = true;
                    item.AlphaRef.Value = 127;
                }

                items.Save(fileName);
            }
        }
    }
}

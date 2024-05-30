using LevelTemplateCreator.Assets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelTemplateCreator.GUI;

internal partial class ContentManager : UserControl
{
    public ContentManager()
    {
        InitializeComponent();

        AssetListBoxAvailable.OnItemClick = Select;
        AssetListBoxSelected.OnItemClick = Deselcet;
    }

    void Select(Asset a)
    {
        AssetListBoxAvailable.Items.Remove(a);
        AssetListBoxSelected.Items.Add(a);

        ItemsChanged();
    }

    void Deselcet(Asset a)
    {
        AssetListBoxSelected.Items.Remove(a);
        AssetListBoxAvailable.Items.Add(a);

        ItemsChanged();
    }

    public void SetItemHeight(int value)
    {
        AssetListBoxAvailable.ItemHeight = value;
        AssetListBoxSelected.ItemHeight = value;

        ItemsChanged();
    }

    public void SetLibary(AssetLibary libary)
    {
        AssetListBoxAvailable.Items.Clear();
        AssetListBoxSelected.Items.Clear();

        foreach (var item in libary.TerrainMaterials)
        {
            AssetListBoxAvailable.Items.Add(item);
        }

        foreach (var item in libary.LevelPresets)
        {
            AssetListBoxAvailable.Items.Add(item);
        }

        ItemsChanged();

        TrySelcet(libary.TerrainMaterials, "Core_10m_grid");
        TrySelcet(libary.LevelPresets, "Core_Default");
    }

    public void Select(string key)
    {
        foreach (var asset in AssetListBoxAvailable.Items)
        {
            if (asset.Key == key)
            {
                Select(asset);
                return;
            }
        }
        throw new KeyNotFoundException();
    }

    void TrySelcet<T>(AssetCollection<T> values, string key) where T : Asset
    {
        if (values.TryGetValue(key, out var value))
        {
            Select(value);
        }
    }

    public void ClearSelected()
    {
        foreach (var asset in AssetListBoxAvailable.Items)
        {
            Deselcet(asset);
        }
    }

    public Asset[] GetSelectedAssets()
    {
        return AssetListBoxSelected.Items.ToArray();
    }

    void ItemsChanged()
    {
        AssetListBoxAvailable.ItemsChanged();
        AssetListBoxSelected.ItemsChanged();
    }

    private void textBoxSelectedFilter_TextChanged(object sender, EventArgs e)
    {
        AssetListBoxSelected.Filter = textBoxSelectedFilter.Text;
    }

    private void textBoxAvailableFilter_TextChanged(object sender, EventArgs e)
    {
        AssetListBoxAvailable.Filter = textBoxAvailableFilter.Text;
    }
}

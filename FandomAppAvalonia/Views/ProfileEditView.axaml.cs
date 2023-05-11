using System.Collections.ObjectModel;
using System.Drawing;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using UserInfo;

namespace FandomAppSpace.Views;

public partial class ProfileEditView : UserControl
{
    // ObservableCollection<FontFamily> fonts = new ObservableCollection<FontFamily>();
    
    public ProfileEditView()
    {
        InitializeComponent();
        // fonts.Add(new FontFamily("Arial"));
        // fonts.Add(new FontFamily("Courier New"));
        // fonts.Add(new FontFamily("Times New Roman"));
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
        List<Category> AllCategories = new List<Category>{new Category("Gaming"), new Category("Sports")};
        ComboBox comboBox = this.Find<ComboBox>("Select");
        comboBox.Items = AllCategories;
        comboBox.SelectedIndex = 0;
    }
}
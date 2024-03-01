using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace player_rave
{
    /// <summary>
    /// Логика взаимодействия для HistoryWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window
    {
        public event Action<int> PlayTrack;//delegate use
        private List<string> music;
        public HistoryWindow(List<string> sounds)
        {
            
            
            InitializeComponent();
            music = sounds;
        }

        private void HistoryList_Select(object sender, SelectionChangedEventArgs e)
        {
            List<string> Files = music.Where(x => string.Equals(System.IO.Path.GetExtension(x), ".mp3", StringComparison.OrdinalIgnoreCase))
            .Select(x => System.IO.Path.GetFileNameWithoutExtension(x))
            .ToList();

            HistoryList.ItemsSource = Files;

            if (HistoryList.SelectedItem != null)
            {
                if (HistoryList.SelectedItem is string selectedTrack)
                {
                    int selectedTrackIndex = HistoryList.Items.IndexOf(selectedTrack);
                    if (selectedTrackIndex >= 0)
                    {
                        PlayTrack(selectedTrackIndex);
                        DialogResult = true;
                    }
                }
            }
        }
            
    }
}

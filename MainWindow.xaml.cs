using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using Chess_Chernyshkov.Classes;

namespace Chess_Chernyshkov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Pawn> Pawns = new List<Pawn>();
        public static MainWindow init;
        public MainWindow()
        {
            InitializeComponent();
            init = this;
        }

        public void SelectTitle(object sender, MouseButtonEventArgs e)
        {

        }
    }
}

using System;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Chess_Chernyshkov.Classes
{
    public class Pawn
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Select = false;
        public bool Black = false;
        public Grid Figure { get; set; }
        public bool Ferz = false;
        public Pawn(int X, int Y, bool Black)
        {
            this.X = X;
            this.Y = Y;
            this.Black = Black;

            if (this.X == 3 && this.Y == 0 && !Black)
            {

                this.Ferz = true;
            }
        }

        public void SelectFigure(object sender, MouseButtonEventArgs e)
        {
            bool stack = false;
            Pawn SelectРамп = MainWindow.mainWindow.Pawns.Find(x => x.Select == true);
            if (SelectРамп != null)
            {
                if (this.Black && this.Y - 1 == SelectРамп.Y && (this.X - 1 == SelectРамп.X || this.X == SelectРамп.X || this.X + 1 == SelectРамп.X))
                {
                    MainWindow.mainWindow.gameBoard.Children.Remove(this.Figure);
                    Grid.SetColumn(SelectРамп.Figure, this.X);
                    Grid.SetRow(SelectРамп.Figure, this.Y);
                    SelectРамп.X = this.X;
                    SelectРамп.Y = this.Y;
                    SelectРамп.SelectFigure(null, null);
                    stack = true;
                }
            }
            if (!stack)
            {
                MainWindow.mainWindow.OnSelect(this);
                if (this.Select)
                {
                    if (this.Black)
                        this.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Pawn (black).png")));
                    else
                        this.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Pawn.png")));
                    this.Select = false;
                }
                else
                {
                    this.Figure.Background = new ImageBrush(new BitmapImage(new Uri(@"pack://application:,,,/Images/Pawn (select).png")));
                    this.Select = true;
                }
            }
        }

        public void Transform(int X, int Y)
        {
            if (this.Ferz)
            {
                if (this.Y == Y && this.X != X)
                {
                    Grid.SetColumn(this.Figure, X);
                    Grid.SetRow(this.Figure, Y);
                    this.X = X;
                    this.Y = Y;
                }
                else if (this.X == X && this.Y != Y)
                {
                    Grid.SetColumn(this.Figure, X);
                    Grid.SetRow(this.Figure, Y);
                    this.X = X;
                    this.Y = Y;
                }
                else if (Math.Abs(this.X - X) == Math.Abs(this.Y - Y))
                {
                    Grid.SetColumn(this.Figure, X);
                    Grid.SetRow(this.Figure, Y);
                    this.X = X;
                    this.Y = Y;
                }
            }
            else 
            { 

                if (X != this.X)
                {
                    SelectFigure(null, null);
                    return;
                }

                if (!Black && ((this.Y == 1 && this.Y + 2 == Y) || this.Y + 1 == Y) ||
                Black && ((this.Y == 6 && this.Y - 2 == Y) || this.Y - 1 == Y))
                {
                    Grid.SetColumn(this.Figure, X);
                    Grid.SetRow(this.Figure, Y);
                    this.X = X;
                    this.Y = Y;
                }

                
            }

            SelectFigure(null, null);


        }

    }
}

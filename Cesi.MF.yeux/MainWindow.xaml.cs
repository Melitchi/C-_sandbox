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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cesi.MF.yeux
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double Xo = 0;
        public double Yo = 0;
        private const double cercleDistance = 75;

        public MainWindow()
        {
            InitializeComponent();
            //this.monCanvas.AddHandler(MouseMoveEvent, new MouseEventHandler(monCanvas_MouseMove));
            Xo = monCanvas.Width / 2;
            Yo = monCanvas.Height / 2;
        }

        private void monCanvas_MouseMove(object sender, MouseEventArgs e){
            // créer une nouvelle ligne
            Line line = new Line();
            // définir le style de la ligne 
            line.Stroke = SystemColors.WindowFrameBrush;
            // positionner le début de la ligne sur le dernier point courant enregistré
            // (attribué dans la méthode du gestionnaire de MouseDown)
            line.X1 = Xo;
            line.Y1 = Yo;
            // positionner la fin de la ligne sur le point courant
            line.X2 = e.GetPosition(this).X;
            line.Y2 = e.GetPosition(this).Y;

            double dx = line.X2 - line.X1;
            double dy = line.Y2 - line.Y1;

            double angle= Math.Atan2(dy, dx);
            double x = Xo + cercleDistance * Math.Cos(angle);
            double y = Yo + cercleDistance * Math.Sin(angle);

            monCanvas.Children.Add(line);

            Canvas.SetLeft(monElipse, x - (monElipse.Width/2) );
            Canvas.SetTop(monElipse,  y - (monElipse.Height / 2));
            
        }
    }
}

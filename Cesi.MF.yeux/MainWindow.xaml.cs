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
        public MainWindow()
        {
            InitializeComponent();
            this.monCanvas.AddHandler(MouseMoveEvent, new MouseEventHandler(monCanvas_MouseMove));
            
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

            // affiche sur l'élément paintSurface (canvas) la ligne
            monCanvas.Children.Add(line);

        }
    }
}

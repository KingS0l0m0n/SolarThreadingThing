using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SolarThreadingThing
{
    public partial class MainWindow : Window
    {
        private double angle = 0;   
        private Timer timer;        

        public MainWindow()
        {
            InitializeComponent();

          //Timer
            timer = new Timer(UpdatePlanet, null, 0, 30);
        }
        private void UpdatePlanet(object state)
        {
            double radius = 50; //orbit radius
            angle += 0.05; // orbit speed        

            //dispatcher to update ui
            Dispatcher.Invoke(() =>
            {
                double sunCenterX = Canvas.GetLeft(Sun) + Sun.Width / 2;
                double sunCenterY = Canvas.GetTop(Sun) + Sun.Height / 2;

                double x = sunCenterX + radius * Math.Cos(angle);
                double y = sunCenterY + radius * Math.Sin(angle);

                Canvas.SetLeft(Planet, x - Planet.Width / 2);
                Canvas.SetTop(Planet, y - Planet.Height / 2);
            });

        }
    }
}
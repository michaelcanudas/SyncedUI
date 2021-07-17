using SyncedUI.Window;
using System.Drawing;
using static SyncedUI.Synced;

namespace SyncedUIDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using var window = new MainWindow();

            using var graphics = window.CreateGraphics();

            var brush = new SolidBrush(Color.Red);

            window.Layout();

            while (window.IsOpen())
            {
                window.HandleEvents();

                graphics.Clear(Color.Black);

                window.Render(graphics);
            }
        }

        class MainWindow : SyncedWindow
        {
            public override void Layout()
            {
                TextSection()
                    .Children(Text("hey!").Color(Color.White));
            }
        }
    }
}

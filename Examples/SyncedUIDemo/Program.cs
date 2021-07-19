using SyncedUI;
using SyncedUI.Window;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using static SyncedUI.Synced;

namespace SyncedUIDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using var window = new MainWindow();
            using var graphics = window.CreateGraphics();
            window.Layout();
            graphics.Clear(ColorTranslator.FromHtml("#fff"));
            graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            window.Render(graphics);

            while (window.IsOpen())
            {
                window.HandleEvents();
            }
        }

        class MainWindow : SyncedWindow
        {
            public override void Layout()
            {
                View().Children(

                    Stack()
                        .Direction(Direction.Vertical)
                        .Children(
                            Image(Directory.GetCurrentDirectory() + "\\image2.png")
                            .Width(322)
                            .Height(259),

                            Text("The Comprehensive Guide to the State Management in iOS")
                            .Font(Directory.GetCurrentDirectory() + "\\SFUIText-Heavy.otf")
                            .CustomFont(true)
                            .FontSize(16)
                            .Color(ColorTranslator.FromHtml("#111"))
                            .Width(322)
                ));
            }
        }
    }
}

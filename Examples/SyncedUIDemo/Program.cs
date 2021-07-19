using SyncedUI;
using System.Drawing;
using System.Drawing.Text;
using static SyncedUI.Synced;

namespace SyncedUIDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            SyncedUI.Platforms.SyncedPlatform.Start(new MainWindow());
        }

        class MainWindow : SyncedWindow
        {
            public override void Layout()
            {
                View().Children(

                    Stack()
                        .Direction(Direction.Vertical)
                        .Children(
                            Image("./Images/image2.png")
                            .Width(322)
                            .Height(259),

                            Text("The Comprehensive Guide to the State Management in iOS")
                            .Font("./Fonts/SFUIText-Heavy.otf")
                            .CustomFont(true)
                            .FontSize(16)
                            .Color(ColorTranslator.FromHtml("#111"))
                            .Width(322)
                ));
            }
        }
    }
}

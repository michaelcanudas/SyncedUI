using System.Drawing;

namespace SyncedUI.Components
{
    public class Text : SyncedComponent
    {
        string content;
        public Text(string content)
        {
            this.content = content;
        }

        public override void Render(Graphics graphics)
        {
            SolidBrush brush = new SolidBrush(color.GetValueOrDefault());
            Font font = new Font("Verdana", 20);

            graphics.DrawString(content, font, brush, 0, 0);
        }
    }
}

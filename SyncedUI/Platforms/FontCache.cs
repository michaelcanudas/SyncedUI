using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncedUI.Platforms
{
    /// <summary>
    /// Provides font caching.
    /// </summary>
    // quick and dirty. Could and should be optimized.
    public class FontCache : IDisposable
    {
        internal FontCache()
        {

        }

        private static PrivateFontCollection customFonts = new();
        private static Dictionary<(string fileName, int size, FontStyle styles), Font> fonts = new();

        private void AddFont(string fileName, int size, FontStyle styles)
        {
            customFonts.AddFontFile(fileName);
            
            fonts.Add((fileName, size, styles), new Font(customFonts.Families.Last() ?? throw new Exception(), size, styles));
        }

        private bool ContainsFont(string fileName, int size, FontStyle styles)
        {
            return fonts.ContainsKey((fileName, size, styles));
        }

        private Font GetFont(string fileName, int size, FontStyle styles)
        {
            return fonts[(fileName, size, styles)];
        }

        public Font Load(string fileName, int size, FontStyle styles)
        {
            if (!ContainsFont(fileName, size, styles))
                AddFont(fileName, size, styles);
                
            return GetFont(fileName, size, styles);
        }

        public void Unload(string fileName, int size, FontStyle styles)
        {
            if (fonts.Remove((fileName, size, styles), out Font font))
            {
                font.Dispose();
            }
        }

        public void Dispose()
        {
            customFonts.Dispose();
            foreach (var desc in fonts.Keys)
            {
                Unload(desc.fileName, desc.size, desc.styles);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GraphicsImage = System.Drawing.Image;
using System.Drawing.Text;

namespace SyncedUI.Platforms
{
    /// <summary>
    /// Provides resource managment for simple resources like images.
    /// </summary>
    internal static class ResourceCache
    {
        static ResourceCache()
        {
            Dispose += (sender, e) => Fonts.Dispose();
        }

        private static event EventHandler Dispose;

        public static FontCache Fonts { get; } = new();

        public static Cache<GraphicsImage, string> Images { get; } = new(GraphicsImage.FromFile);
        
        internal static void DisposeResources()
        {
            Dispose?.Invoke(null, null);
        }
        
        public class Cache<TItem, TKey> where TItem : IDisposable
        {
            private Dictionary<TKey, TItem> items = new();
            private Func<TKey, TItem> loadFunc;

            public Cache(Func<TKey, TItem> load)
            {
                Dispose += (sender, args) => this.OnDispose();
                this.loadFunc = load;
            }

            public TItem Load(TKey key)
            {
                if (!items.ContainsKey(key))
                    items.Add(key, this.loadFunc(key) ?? throw new Exception("Unable to load item!"));

                return items[key];
            }

            public void Unload(TKey key)
            {
                if (items.ContainsKey(key))
                    items.Remove(key);
                else
                    throw new Exception("Item that is not loaded cannot be unloaded!");
            }

            private void OnDispose()
            {
                foreach (var item in items.Values)
                {
                    item.Dispose();
                }
            }
        }
    }
}

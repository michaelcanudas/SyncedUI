using SyncedUI.Components;
using SyncedUI.Window;

namespace SyncedUI
{
    public static class Synced
    {
        public static SyncedComponent Text(string content)
        {
            var component = new Text(content);

            SyncedWindow.Get().AddChild(component);

            return component;
        }
        public static SyncedComponent TextSection()
        {
            var component = new TextSection();

            SyncedWindow.Get().AddChild(component);

            return component;
        }
    }
}

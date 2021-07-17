using SyncedUI.Components;
using SyncedUI.Window;

namespace SyncedUI
{
    public static class Synced
    {
        public static SyncedComponent Image(string content)
        {
            return new Image(content);
        }
        public static SyncedComponent Stack()
        {
            return new Stack();
        }
        public static SyncedComponent Text(string content)
        {
            return new Text(content);
        }
        public static SyncedComponent View()
        {
            View view = new View();
            SyncedWindow.Get().AddChild(view);
            return view;
        }
    }
}

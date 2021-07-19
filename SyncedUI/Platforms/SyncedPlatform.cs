using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncedUI.Platforms
{
    /// <summary>
    /// Handles Operating-System related functions, including running the app's event loop, managing input, and taking input.
    /// </summary>
    public sealed partial class SyncedPlatform
    {
        /// <summary>
        /// Starts the app with the specified primary window.
        /// </summary>
        /// <param name="window">The primary window for the app.</param>
        public static void Start(SyncedWindow window)
        {
            SyncedWindowHost host = new SyncedWindowHost(window ?? throw new ArgumentNullException(nameof(window)));

            host.RunAppLoop();
        }

        /// <summary>
        /// Creates and displays a configurable message box to the user.
        /// </summary>
        /// <param name="title">The title of the message box.</param>
        /// <param name="description">The description shown as the content of the message box.</param>
        /// <param name="type">The Configuration of buttons on the message box.</param>
        /// <param name="icon">The type of icon to show in the message box.</param>
        /// <returns><see langword="true"/> if 'ok', 'retry', or 'yes' was selected, <see langword="false"/> if 'cancel' or 'no' was selected or the message box's window was closed.</returns>
        // TODO: If we implement Style Objects, take in a style object to style a custom MessageBox.
        public partial bool MessageBox(string title, string description, MessageBoxType type, MessageBoxIcon icon);
    }
}

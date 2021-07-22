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
        /// Gets the host of the application's window.
        /// </summary>
        internal SyncedWindowHost WindowHost { get; private set; }

        // The app's platform instance.
        private static SyncedPlatform instance;

        // An instance of SyncedPlatform can be created using Start(), and using Get();
        private SyncedPlatform(SyncedWindow window)
        {
            this.WindowHost = new SyncedWindowHost(window ?? throw new ArgumentNullException(nameof(window)));
        }

        #region Partial Method Declarations

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

        #endregion

        /// <summary>
        /// Starts the app with the specified primary window.
        /// </summary>
        /// <param name="window">The primary window for the app.</param>
        public static void Start(SyncedWindow window)
        {
            if (instance is not null)
                throw new Exception("There is already a platform instance. Only one call to SyncedPlatform.Start() is allowed!");

            instance = new SyncedPlatform(window);

            instance.WindowHost.RunAppLoop();

            ResourceCache.DisposeResources();
        }

        /// <summary>
        /// Gets the active platform instance;
        /// </summary>
        /// <returns></returns>
        public static SyncedPlatform Get()
        {
            return instance ?? throw new Exception("There is no platform instance! Did you call SyncedPlatform.Start()?");
        }

    }
}

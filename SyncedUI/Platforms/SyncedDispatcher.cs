using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncedUI.Platforms
{
    public sealed partial class SyncedDispatcher
    {
        private SyncedPlatform platform;

        internal SyncedDispatcher(SyncedPlatform platform)
        {
            this.platform = platform ?? throw new ArgumentNullException(nameof(platform));
        }
    }
}

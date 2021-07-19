using System;
using static SyncedUI.Platforms.WindowsInterop;

#if WIN32

namespace SyncedUI.Platforms
{
    public sealed partial class SyncedPlatform
    {
        public partial bool MessageBox(string title, string description, MessageBoxType type, MessageBoxIcon icon)
        {
            MessageBoxFlags flags = 0;

            flags |= type switch
            {
                MessageBoxType.Ok => MessageBoxFlags.OK,
                MessageBoxType.OkCancel => MessageBoxFlags.OKCANCEL,
                MessageBoxType.RetryCancel => MessageBoxFlags.RETRYCANCEL,
                MessageBoxType.YesNo => MessageBoxFlags.YESNO,
                _ => 0,
            };

            flags |= icon switch
            {
                MessageBoxIcon.None => 0,
                MessageBoxIcon.Info => MessageBoxFlags.ICONINFORMATION,
                MessageBoxIcon.Question => MessageBoxFlags.ICONQUESTION,
                MessageBoxIcon.Warning => MessageBoxFlags.ICONWARNING,
                MessageBoxIcon.Error => MessageBoxFlags.ICONERROR,
                _ => 0,
            };

            var result = WindowsInterop.MessageBox(null, description, title, flags);

            return result == 6 || result == 4 || result == 1; // return value is either IDYES, IDRETRY, or IDOK if we should return true;
        }
    }
}

#endif
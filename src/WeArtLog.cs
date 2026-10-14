/*

* Copyright (c) 2026 Nokia Corporation and/or its subsidiary(-ies). All rights reserved.

*

*

* This software, including documentation, is protected by copyright controlled by Nokia Corporation and/ or its

* subsidiaries. All rights are reserved. Copying, including reproducing, storing, adapting or translating, any or all

* of this material requires the prior written consent of Nokia.

*/

/*
* Based on the WEART Low-Level C# SDK v2.0.1 -- WEART - Log utility
* Copyright (c) 2026 Weart S.r.l. Licensed under the MIT License; see LICENSE-WEART.md.
* https://www.weart.it/
*/

using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace WeArt.Utils
{
    /// <summary>
    /// Utility class used to log events and messages in the <see cref="WeArt"/> framework
    /// </summary>
    public static class WeArtLog
    {
        /// <summary>Logs a message in the debug console</summary>
        /// <param name="message">The string message</param>
        /// <param name="callerPath">The path of the caller (optional)</param>
        public static void Log(object message)
        {
            Debug.WriteLine(message);
        }
    }
}
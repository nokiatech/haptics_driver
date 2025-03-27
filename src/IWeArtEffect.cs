/*

* Copyright (c) 2025 Nokia Corporation and/or its subsidiary(-ies). All rights reserved.

*

*

* This software, including documentation, is protected by copyright controlled by Nokia Corporation and/ or its

* subsidiaries. All rights are reserved. Copying, including reproducing, storing, adapting or translating, any or all

* of this material requires the prior written consent of Nokia.

*/

using System;

namespace WeArt.Core
{
    /// <summary>
    /// An interface for objects that combines temperature, force and texture haptic feelings.
    /// </summary>
    public interface IWeArtEffect
    {
        /// <summary>
        /// The temperature applied by this haptic effect
        /// </summary>
        Temperature Temperature { get; }

        /// <summary>
        /// The force applied by this haptic effect
        /// </summary>
        Force Force { get; }

        /// <summary>
        /// The texture applied by this haptic effect
        /// </summary>
        Texture Texture { get; }

        /// <summary>
        /// This event should be called whenever any of the haptic values changes over time
        /// </summary>
        event Action OnUpdate;
    }
}
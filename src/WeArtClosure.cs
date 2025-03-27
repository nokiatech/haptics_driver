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
    /// The actuation point closure amount.
    /// It is minimum when the actuation point is open, maximum when closed.
    /// </summary>
    [Serializable]
    public struct Closure
    {
        /// <summary>
        /// The default closure is zero (max openness)
        /// </summary>
        public static Closure Default = new Closure
        {
            Value = WeArtConstants.defaultClosure
        };


        internal float _value;

        /// <summary>
        /// The closure amount, normalized between 0 (max openness) and 1 (max closure)
        /// </summary>
        public float Value
        {
            get => _value;
            set => _value = value;
        }
    }
}
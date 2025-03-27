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
    /// The actuation point abduction amount.
    /// It is minimum when the actuation point is far from the hand, maximum when close.
    /// </summary>
    [Serializable]
    public struct Abduction
    {
        /// <summary>
        /// The default abduction is zero
        /// </summary>
        public static Abduction Default = new Abduction
        {
            Value = WeArtConstants.defaultAbduction
        };


        internal float _value;

        /// <summary>
        /// The abduction amount, normalized between 0 (max) and 1 (max)
        /// </summary>
        public float Value
        {
            get => _value;
            set => _value = Math.Max(WeArtConstants.minAbduction, Math.Min(value, WeArtConstants.maxAbduction));
        }
    }
}
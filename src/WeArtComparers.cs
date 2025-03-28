/*

* Copyright (c) 2025 Nokia Corporation and/or its subsidiary(-ies). All rights reserved.

*

*

* This software, including documentation, is protected by copyright controlled by Nokia Corporation and/ or its

* subsidiaries. All rights are reserved. Copying, including reproducing, storing, adapting or translating, any or all

* of this material requires the prior written consent of Nokia.

*/
using System;
using System.Collections.Generic;

namespace WeArt.Core
{
    /// <summary>
    /// Utility class for approximate comparison of single precision numbers
    /// </summary>
    public class ApproximateFloatComparer : IEqualityComparer<float>
    {
        public static readonly ApproximateFloatComparer Instance = new ApproximateFloatComparer();

        /// <summary>
        /// Two numbers are equal if their difference is less than <see cref="float.Epsilon"/>
        /// </summary>
        /// <param name="x">The first number</param>
        /// <param name="y">The second number</param>
        /// <returns>Equality check result</returns>
        public bool Equals(float x, float y) => Math.Abs(x - y) < float.Epsilon;

        public int GetHashCode(float x) => x.GetHashCode();
    }
}
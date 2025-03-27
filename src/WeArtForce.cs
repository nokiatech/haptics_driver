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
using System.Linq;

namespace WeArt.Core
{
    /// <summary>
    /// The force applied as haptic pressure on the actuation point.
    /// The minimum value indicates no pressure, the maximum indicates maximum pressure.
    /// </summary>
    [Serializable]
    public struct Force : ICloneable
    {
        /// <summary>
        /// The default force is zero
        /// </summary>
        public static Force Default = new Force
        {
            Value = WeArtConstants.defaultForce,
            Active = false
        };

        internal float _value;

        internal bool _active;


        /// <summary>
        /// The horizontal component of the 3D force values, normalized between 0 (min force) and 1 (max force)
        /// </summary>
        public float Value
        {
            get => _value;
            set => _value = Math.Max(WeArtConstants.minForce, Math.Min(WeArtConstants.maxForce, value));
        }

        /// <summary>
        /// Indicates whether the force feeling is applied or not
        /// </summary>
        public bool Active
        {
            get => _active;
            set => _active = value;
        }


        /// <summary>
        /// True if the object is a <see cref="Force"/> instance with the same activation status and values
        /// </summary>
        /// <param name="obj">The object to check equality with</param>
        /// <returns>The equality check result</returns>
        public override bool Equals(object obj)
        {
            return obj is Force force &&
                ApproximateFloatComparer.Instance.Equals(Value, force.Value) &&
                Active == force.Active;
        }

        /// <summary>Basic <see cref="GetHashCode"/> implementation</summary>
        /// <returns>The hashcode of this object</returns>
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>Clones this object</summary>
        /// <returns>A clone of this object</returns>
        public object Clone()
        {
            return this;
        }


        /// <summary>
        /// Calculates the mean of multiple forces
        /// </summary>
        /// <param name="forces">A collection or set of forces</param>
        /// <returns>The mean force</returns>
        public static Force Mean(IEnumerable<Force> forces)
        {
            var actives = forces.Where(f => f.Active);

            if (actives.Count() > 0)
                return new Force
                {
                    Active = true,
                    Value = actives.Sum(f => f.Value) / actives.Count()
                };
            else
                return Default;
        }
    }
}
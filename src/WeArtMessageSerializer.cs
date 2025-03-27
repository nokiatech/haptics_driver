/*

* Copyright (c) 2025 Nokia Corporation and/or its subsidiary(-ies). All rights reserved.

*

*

* This software, including documentation, is protected by copyright controlled by Nokia Corporation and/ or its

* subsidiaries. All rights are reserved. Copying, including reproducing, storing, adapting or translating, any or all

* of this material requires the prior written consent of Nokia.

*/
using System;
using System.Text;

namespace WeArt.Messages
{
    /// <summary>
    /// Abstract class that implements the base for serialization and deserialization of
    /// messages to/from the middleware
    /// </summary>
    public abstract class WeArtMessageSerializer
    {
        /// <summary>
        /// Common method to serialize text to bytes
        /// </summary>
        /// <param name="text">The input text</param>
        /// <param name="byteData">The output byte array</param>
        /// <returns>True if the serialization is successful</returns>
        public bool Serialize(string text, out byte[] byteData)
        {
            try
            {
                byteData = Encoding.ASCII.GetBytes(text);
                return true;
            }
            catch (Exception)
            {
                byteData = null;
                return false;
            }
        }

        /// <summary>
        /// Converts a <see cref="IWeArtMessage"/> to text
        /// </summary>
        /// <param name="message">The WeArt message</param>
        /// <param name="text">The output text</param>
        /// <returns>True if the serialization is successful</returns>
        public abstract bool Serialize(IWeArtMessage message, out string text);

        /// <summary>
        /// Common method to deserialize bytes to text
        /// </summary>
        /// <param name="byteData">The array of bytes</param>
        /// <param name="byteCount">The number of bytes containing the text</param>
        /// <param name="text">The output text</param>
        /// <returns>True if the deserialization is successful</returns>
        public bool Deserialize(byte[] byteData, int byteCount, out string text)
        {
            try
            {
                text = Encoding.ASCII.GetString(byteData, 0, byteCount);
                return true;
            }
            catch (Exception)
            {
                text = null;
                return false;
            }
        }

        /// <summary>
        /// Tries to parse a text to a <see cref="IWeArtMessage"/>
        /// </summary>
        /// <param name="text">The input text</param>
        /// <param name="message">The output message</param>
        /// <returns>True if the parsing was successful</returns>
        public abstract bool Deserialize(string text, out IWeArtMessage message);
    }
}
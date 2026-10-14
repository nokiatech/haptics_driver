/*

* Copyright (c) 2026 Nokia Corporation and/or its subsidiary(-ies). All rights reserved.

*

*

* This software, including documentation, is protected by copyright controlled by Nokia Corporation and/ or its

* subsidiaries. All rights are reserved. Copying, including reproducing, storing, adapting or translating, any or all

* of this material requires the prior written consent of Nokia.

*/

/*
* Based on the WEART Low-Level C# SDK v2.0.1 -- WeArtCustomJsonConverters
* Copyright (c) 2026 Weart S.r.l. Licensed under the MIT License; see LICENSE-WEART.md.
* https://www.weart.it/
*/

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;


namespace WeArt.Messages
{
    public class ListConverter<T> : JsonConverter<List<T>>
    {
        public override List<T> ReadJson(JsonReader reader, Type objectType, List<T> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return new List<T>();

            // Read the elements one by one rather than deserializing the list as a whole:
            // asking the serializer for a List<T> here would re-enter this converter.
            JArray array = JArray.Load(reader);
            List<T> items = new List<T>(array.Count);
            foreach (JToken element in array)
                items.Add(element.ToObject<T>(serializer));

            return items;
        }

        public override void WriteJson(JsonWriter writer, List<T> value, JsonSerializer serializer)
        {
            writer.WriteStartArray();
            if (value != null)
                foreach (T item in value)
                    serializer.Serialize(writer, item, typeof(T));
            writer.WriteEndArray();
        }
    }

    public class EnumConverter<T> : JsonConverter<T> where T : Enum
    {
        public override T ReadJson(JsonReader reader, Type objectType, T existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.String)
            {
                return default;  // Default is the first element of Enum
            }

            string enumValue = (reader.Value as string)?.Trim();

            if (string.IsNullOrEmpty(enumValue))
            {
                return default;
            }

            foreach (var enumName in Enum.GetNames(typeof(T)))
            {
                if (string.Equals(enumValue, enumName, StringComparison.OrdinalIgnoreCase))
                {
                    return (T)Enum.Parse(typeof(T), enumName);
                }
            }

            return default;
        }

        public override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }
    }
}

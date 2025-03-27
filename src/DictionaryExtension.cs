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

public static class DictionaryExtensions
{
    public static TValue GetValueOrDefault<TKey, TValue>(
        this Dictionary<TKey, TValue> dictionary,
        TKey key,
        TValue defaultValue = default)
    {
        if (dictionary == null)
            throw new ArgumentNullException(nameof(dictionary));

        return dictionary.TryGetValue(key, out var value) ? value : defaultValue;
    }
}

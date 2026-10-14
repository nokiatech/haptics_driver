# ========================================================================================
# Copyright (c) 2026 Nokia Corporation and/or its subsidiary(-ies). All rights reserved.
#
# This software, including documentation, is protected by copyright controlled by
# Nokia Corporation and/or its subsidiaries. All rights are reserved. Copying, including
# reproducing, storing, adapting or translating, any or all of this material requires the
# prior written consent of Nokia.
# ========================================================================================

# 3.27 is required for DOTNET_SDK, which makes CMake emit an SDK-style project.
# The legacy project style CMake produces otherwise cannot resolve references
# without editing them by hand in Visual Studio.
cmake_minimum_required(VERSION 3.27)

# Set the project name and specify it's for C#
project(Haptics_Device_Driver LANGUAGES CSharp)

# netstandard2.1 is what Unity 6 can load. Do not raise this to a net* target:
# the driver is consumed as a managed plugin from Unity, whose scripting runtime
# cannot load .NET Core/5+ assemblies. 2.1 rather than 2.0 because the SDK uses
# Math.Clamp, which 2.0 does not define.
set(CMAKE_DOTNET_SDK "Microsoft.NET.Sdk")
set(CMAKE_DOTNET_TARGET_FRAMEWORK "netstandard2.1")
set(CMAKE_CSharp_FLAGS "/langversion:latest")

# Add the source files to the project
file(GLOB_RECURSE SOURCE_FILES src/*.cs)

# Specify the output as a DLL
add_library(Haptics_Device_Driver SHARED ${SOURCE_FILES})

# Set the output directory for the DLL
set_target_properties(Haptics_Device_Driver PROPERTIES
            OUTPUT_NAME "Haptics_Device_Driver"
            OUTPUT_DIRECTORY "${CMAKE_BINARY_DIR}/bin"
)

# Newtonsoft.Json is restored automatically by the SDK-style project, so there is
# nothing to install by hand. At runtime Unity supplies its own copy through the
# com.unity.nuget.newtonsoft-json package, so this DLL must NOT be shipped next to
# the driver in Assets/Plugins: that would load the assembly twice.
set_property(TARGET Haptics_Device_Driver PROPERTY
    VS_PACKAGE_REFERENCES "Newtonsoft.Json_13.0.3"
)

# ========================================================================================
# Copyright (c) 2025 Nokia Corporation and/or its subsidiary(-ies). All rights reserved.
#
# This software, including documentation, is protected by copyright controlled by
# Nokia Corporation and/or its subsidiaries. All rights are reserved. Copying, including
# reproducing, storing, adapting or translating, any or all of this material requires the
# prior written consent of Nokia.
# ========================================================================================

cmake_minimum_required(VERSION 3.13)

# Set the project name and specify it's for C#
project(Haptics_Device_Driver LANGUAGES CSharp)



# Specify the target framework (adjust according to your needs)
set(CMAKE_CSharp_FLAGS "/langversion:latest /target:library /p:TargetFramework=net9.0")



# Add the source files to the project
file(GLOB_RECURSE SOURCE_FILES src/*.cs)



# Specify the output as a DLL
add_library(Haptics_Device_Driver SHARED ${SOURCE_FILES})



# Set the output directory for the DLL

set_target_properties(Haptics_Device_Driver PROPERTIES
			OUTPUT_NAME "Haptics_Device_Driver"
			OUTPUT_DIRECTORY "${CMAKE_BINARY_DIR}/bin"

)



# Add references to external dependencies if needed (e.g., Newtonsoft.Json)

target_link_libraries(Haptics_Device_Driver
    PRIVATE
    "System.Private.CoreLib" # .NET Core base library
    "System.Runtime"
    "System"
    "System.Net.Http"
    "Newtonsoft.Json"
)




# Haptics Device Driver

This repository provides the source code for the Haptics Device Driver.

It is based on the [WEART Low-Level C# SDK](https://github.com/WEARTHaptics/WEART-SDK-CSharp)
version 2.0.1, which adds support for the TouchDIVER Pro alongside the
TouchDIVER: six actuation points (thumb, index, middle, annular, pinky, palm),
the WeartApp status messages, and per-thimble raw data from the Pro devices.

The driver is built as a **netstandard2.1** class library so that it can be loaded
by Unity as a managed plugin. 

## Prerequisites

Ensure the following tools and frameworks are installed on your system:

- Visual Studio 2022
- CMake 3.27 or later
- .NET 9.0 SDK or compatible version
- The WeArt host application for your device (see below), installed and launched

### WeArt host application per device

The driver connects over TCP to a WeArt host application, not to the glove directly.
Which application you need depends on the device, and only one can run at a time
(both listen on the same port):

| Device | Host application |
|---|---|
| TouchDIVER (G1) | [WeArt Middleware](https://apps.microsoft.com/detail/9p4t2jgfqn5z?hl=en-US&gl=FI) |
| TouchDIVER Pro | [WeArt App](https://apps.microsoft.com/detail/9NF7NVV1LZ6F?hl=en-us&gl=FI) |

The TouchDIVER Pro is **not** supported by the Middleware, and the original
TouchDIVER (G1) is **not** supported by the WeArt App. Install and launch the one
that matches the glove you are using before running the driver. The driver detects
which host is running automatically — no configuration is needed.

## Cloning the Repository

To clone the repository, run the following command:

```bash
git clone https://github.com/nokiatech/haptics_driver.git
cd haptics_driver
```

## Build Instructions

### 1. Configure the Project with CMake

Run the following command to configure the project using CMake:

```bash
mkdir build
cd build
cmake .. -G "Visual Studio 17 2022"
```

This generates a Visual Studio solution in the `build` directory.

### 2. Build the Project

To build the project, navigate to the `build` directory and open the solution in Visual Studio:

```bash
start Haptics_Device_Driver.sln
```

#### Shortcut to Build the Project

In Visual Studio, you can build the project quickly using the shortcut `Ctrl + Shift + B`.

### 3. Additional Dependencies

`Newtonsoft.Json` 13.0.3 is the only dependency, and CMake now declares it as a
package reference that MSBuild restores automatically. There is nothing to
install through the NuGet GUI and no references to add by hand.


### 4. Build the Solution (´Ctrl + Shift + B´)

Set the build configuration to `Release` or `Debug` and build the solution in Visual Studio.

Alternatively, you can build the project directly from the command line:

```bash
cmake --build build --config Release
```

### 5. Cleaning the Build (Optional)

To clean the build directory, run the following command:

```bash
cmake --build build --target clean
```

Alternatively, you can delete the `build` folder manually.

### 6. Generated DLL

After building the project, the DLL file will be located in:

```
build/<Configuration>/Haptics_Device_Driver.dll
```

Replace `<Configuration>` with `Debug` or `Release`, depending on the build configuration you selected.

### 7. Using the Driver from Unity

Copy **only** `Haptics_Device_Driver.dll` into the Unity project's
`Assets/Plugins/` folder.

Do not copy `Newtonsoft.Json.dll` alongside it. Unity provides its own copy via the
`com.unity.nuget.newtonsoft-json` package, and a second copy in `Assets/Plugins`
loads the assembly twice and breaks the build. Make sure that package is listed in
the project's `Packages/manifest.json`.

The project's API Compatibility Level must be `.NET Framework` or `.NET Standard 2.1`
(Project Settings → Player → Other Settings).

## Notes

- Ensure all dependencies are correctly installed before building the project.
- If you encounter issues, refer to the CMake and Visual Studio documentation for troubleshooting tips.

## License:
Please see <a href="./LICENSE.TXT"><strong>LICENSE.TXT</strong></a> file for the terms of use of the contents of this repository.

Portions of this software are derived from the WEART Low-Level C# SDK, which is
distributed under the MIT License. See <a href="./LICENSE-WEART.md"><strong>LICENSE-WEART.md</strong></a>.

All the example media files (*.heic, *.png, *.jpg, *.gif) in this repository are under copyright © Nokia Technologies 2015-2026.

For more information/questions/source code/commercial licensing related issues, please contact: <heif@nokia.com>

### **Copyright (c) 2015-2026, Nokia Technologies Ltd.**
### **All rights reserved.**


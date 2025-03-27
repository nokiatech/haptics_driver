

# Haptics Device Driver

This repository provides the source code for the Haptics Device Driver. 

## Prerequisites

Ensure the following tools and frameworks are installed on your system:

- Visual Studio 2022
- CMake 3.13 or later
- .NET 9.0 SDK or compatible version
- Download and Install [Weart Middleware](https://apps.microsoft.com/detail/9p4t2jgfqn5z?hl=en-US&gl=FI)
- Launch the Middleware

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

#### Adding Newtonsoft.Json

1. Open the solution in Visual Studio.
2. Right-click on the project (`Haptics_Device_Driver`) and select `Manage NuGet Packages...`.
3. Search for `Newtonsoft.Json` in the NuGet package manager.
4. Install the latest version of `Newtonsoft.Json`.

#### Adding "System" Reference

1. In Visual Studio, expand the `References` section under the `Haptics_Device_Driver` project.
2. Right-click on `References` and select `Add Reference`.
3. In the `.NET Assemblies` tab, search for `System`.
4. Select `System` and click `OK`.

These steps ensure that required dependencies are properly included.

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
../build/<Configuration>/Haptics_Device_Driver.dll
```

Replace `<Configuration>` with `Debug` or `Release`, depending on the build configuration you selected.

## Notes

- Ensure all dependencies are correctly installed before building the project.
- If you encounter issues, refer to the CMake and Visual Studio documentation for troubleshooting tips.

## License:
Please see <a href="https://github.com/nokiatech/haptics_driver/blob/master/LICENSE.TXT"><strong>LICENSE.TXT</strong></a> file for the terms of use of the contents of this repository.

All the example media files (*.heic, *.png, *.jpg, *.gif) in this repository are under copyright © Nokia Technologies 2015-2025.

For more information/questions/source code/commercial licensing related issues, please contact: <heif@nokia.com>

### **Copyright (c) 2015-2025, Nokia Technologies Ltd.**
### **All rights reserved.**


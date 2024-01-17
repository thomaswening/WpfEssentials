# WpfEssentials

WpfEssentials is a comprehensive collection of utilities and helpers designed to streamline and enhance the development of WPF applications. It provides a range of tools and services that address common needs and challenges faced by WPF developers. More features will be added along the way.

## Features

#### Base
- **DelegateCommand**: A versatile implementation of `ICommand` for creating commands in MVVM applications.
- **ObservableObject**: A base class implementing `INotifyPropertyChanged`, facilitating property change notifications.

#### ValueConverters
- **BoolToVisibilityConverter**: An `IValueConverter` that converts a boolean to a `Visibility` value and vice versa.
- **IsNotNullToBoolConverter**: Converts a non-null object to `true` and a null object to `false`.
- **IsNullToBoolConverter**: Converts a null object to `true` and a non-null object to `false`.

## Dependencies

### WpfEssentials Project
- **.NET Framework**: net8.0-windows
- **UseWPF**: True (Indicating that this is a WPF application)

### WpfEssentials Test Suite
- **.NET Framework**: net8.0-windows
- **NuGet Packages**:
  - `Microsoft.NET.Test.Sdk` (Version 17.8.0)
  - `NUnit` (Version 4.0.1)
  - `NUnit3TestAdapter` (Version 4.5.0)

## Getting Started

To get started with WpfEssentials, clone the repository and open `WpfEssentials.sln` in Visual Studio.

```bash
git clone [repository-url]
cd WpfEssentials
```

Open the solution in Visual Studio to build and run the project.

## Usage

There are two ways to use the WpfEssentials library in your WPF project:

### Using the DLL Directly

1. Build the WpfEssentials project in Visual Studio to generate the `WpfEssentials.dll`.
2. In your WPF project, add a reference to the `WpfEssentials.dll`.
3. Use the functionalities provided by the library as needed in your project.

### Embedding the Project in Your Solution (Visual Studio 2022 and CLI)

#### Visual Studio 2022:
1. Open your WPF project in Visual Studio 2022.
2. Right-click on the solution and choose 'Add' -> 'Existing Project...'. Select the `WpfEssentials.csproj` file.
3. Add a reference to WpfEssentials in your WPF project by right-clicking 'References' and choosing 'Add Reference...'.

#### CLI:
1. Navigate to your WPF project's directory.
2. Use the CLI to add the `WpfEssentials.csproj` to your solution: `dotnet sln add path/to/WpfEssentials.csproj`.
3. Add a reference to WpfEssentials: `dotnet add reference path/to/WpfEssentials.csproj`.

## Running Tests

To run the tests in the WpfEssentials Test Suite, follow these steps:

1. Open the `WpfEssentials.sln` in Visual Studio.
2. Build the solution to ensure all projects are up to date.
3. Navigate to the Test Explorer in Visual Studio.
4. Run all tests or select specific tests to run.

Alternatively, tests can be run from the CLI using the following command:

```bash
dotnet test path/to/WpfEssentialsTests.csproj
```

## License

This project is licensed under the GPL-3.0 License - see the [LICENSE](LICENSE.txt) file for details.

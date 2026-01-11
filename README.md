# Missing Files Console

A simple .NET console application to identify files from a CSV list that are missing in a specified directory.

## Description

This tool reads a list of filenames from a CSV file and checks for their existence within a given folder. It outputs the list of any missing files to both the console and a text file named `missing_files.txt`.

This is useful for verifying that a set of expected files is present in a directory.

## How to Use

You can run this application in two ways: via command-line arguments or in an interactive mode.

### Command-Line Arguments

Provide the path to the CSV file and the directory to search in as command-line arguments.

```bash
MissingFilesConsole.exe "C:\path\to\your\file.csv" "C:\path\to\your\folder"
```

- **Argument 1:** The full path to the CSV file containing the filenames to check.
- **Argument 2:** The full path to the directory where the files are expected to be.

### Interactive Mode

If you run the application without any arguments, you will be prompted to enter the paths.

```bash
MissingFilesConsole.exe
```

The application will then ask for the CSV file path and the folder path interactively.

### CSV Format

The CSV file should contain filenames. If a single line has multiple filenames, they should be separated by commas.

**Example `files.csv`:**

```csv
file1.txt,document.pdf,image.jpg
archive.zip
photo.png,data.csv
```

## Output

The application will print a list of all missing files to the console. Additionally, a file named `missing_files.txt` will be created in the same directory as the executable, containing the names of the missing files.

If all files are found, a success message will be displayed.

## Building from Source

This is a .NET project. You can build it using the .NET SDK.

1. Clone the repository.
2. Navigate to the project directory (`MissingFilesConsole`).
3. Run the build command:

    ```bash
    dotnet build --configuration Release
    ```

The executable will be located in `bin/Release/net10.0/`.

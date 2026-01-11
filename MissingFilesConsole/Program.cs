using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace MissingFilesConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string csvPath;
            string folderPath;

            // Check if arguments are provided via command line
            if (args.Length >= 2)
            {
                csvPath = args[0];
                folderPath = args[1];
            }
            else
            {
                // Interactive input if no arguments provided
                Console.WriteLine("Enter the full path to the CSV file:");
                csvPath = Console.ReadLine()?.Trim('"');

                Console.WriteLine("Enter the folder path to search in:");
                folderPath = Console.ReadLine()?.Trim('"');
            }

            // Validate input paths
            if (string.IsNullOrWhiteSpace(csvPath) || !File.Exists(csvPath))
            {
                Console.WriteLine($"Error: CSV file not found at '{csvPath}'.");
                return;
            }

            if (string.IsNullOrWhiteSpace(folderPath) || !Directory.Exists(folderPath))
            {
                Console.WriteLine($"Error: Folder not found at '{folderPath}'.");
                return;
            }

            Console.WriteLine("--- Missing Files ---");
            
            // Output file
            string outputFilePath = "missing_files.txt";

            try
            {
                var missingFiles = new List<string>();

                foreach (var line in File.ReadLines(csvPath))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    var fileNames = line.Split(',');

                    foreach (var fileName in fileNames)
                    {
                        string trimmedFileName = fileName.Trim();
                        if (string.IsNullOrWhiteSpace(trimmedFileName)) continue;

                        string fullPath = Path.Combine(folderPath, trimmedFileName);

                        // Check if the file exists
                        if (!File.Exists(fullPath))
                        {
                            // File is missing and write to console and list
                            Console.WriteLine(trimmedFileName);
                            missingFiles.Add(trimmedFileName);
                        }
                    }
                }

                // Write missing files to output file
                if (missingFiles.Any())
                {
                    File.WriteAllLines(outputFilePath, missingFiles);
                    Console.WriteLine($"\nA list of missing files has been saved to: {Path.GetFullPath(outputFilePath)}");
                }
                else
                {
                    Console.WriteLine("All Files in the cvs exist in the file path!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
using System.Xml;
using Newtonsoft.Json;

class Program
{
	static void Main()
	{
		try
		{
			// Read the configuration file
			string configData = File.ReadAllText("config.txt");
			ProcessConfig(configData);
		}
		catch (Exception ex) when (ex is XmlException || ex is JsonReaderException)
		{
			// Handle XML and JSON format errors specifically
			Console.WriteLine("Error: Invalid format in configuration file.");

			if (ex is XmlException xmlEx)
			{
				Console.WriteLine($"XML Error: {xmlEx.Message}");
			}
			else if (ex is JsonReaderException jsonEx)
			{
				Console.WriteLine($"JSON Error: {jsonEx.Message}");
			}
		}
		catch (FileNotFoundException)
		{
			// Handle missing file errors
			Console.WriteLine("Error: Configuration file not found.");
		}
		catch (Exception ex)
		{
			// Handle any other unexpected errors
			Console.WriteLine($"An unexpected error occurred: {ex.Message}");
		}
	}

	static void ProcessConfig(string configData)
	{
		// Simulating the parsing of JSON and XML
		if (configData.Trim().StartsWith("<")) // Simple check for XML
		{
			// Simulating XML parsing
			throw new XmlException("Malformed XML at line 1.");
		}
		else if (configData.Trim().StartsWith("{")) // Simple check for JSON
		{
			// Simulating JSON parsing
			throw new JsonReaderException("Unexpected token at line 1.");
		}
		else
		{
			throw new FormatException("Unsupported format.");
		}
	}
}
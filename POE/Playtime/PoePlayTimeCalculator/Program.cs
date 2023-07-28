using System;
using System.IO;
using System.Text.Json;

public class CharacterData
{
    public string name { get; set; }
    public string league { get; set; }
    public int classId { get; set; }
    public int ascendancyClass { get; set; }
    public string @class { get; set; }
    public int level { get; set; }
    public long experience { get; set; }
    public bool pinnable { get; set; }
}

public class Program
{
    static void Main()
    {
        string jsonFilePath = "data.json";

        try
        {
            CharacterData data = ReadAndParseJson(jsonFilePath);

            // Now you can work with the 'data' object that holds the parsed JSON data.
            Console.WriteLine($"Name: {data.name}");
            Console.WriteLine($"League: {data.league}");
            Console.WriteLine($"Class: {data.@class}");
            Console.WriteLine($"Level: {data.level}");
            // ... and so on.
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading or parsing the JSON file:");
            Console.WriteLine(ex.Message);
        }
    }

    static CharacterData ReadAndParseJson(string jsonFilePath)
    {
        if (!File.Exists(jsonFilePath))
        {
            throw new FileNotFoundException("The JSON file does not exist.", jsonFilePath);
        }

        try
        {
            string jsonString = File.ReadAllText(jsonFilePath);

            // Deserialize the JSON string to CharacterData object.
            CharacterData data = JsonSerializer.Deserialize<CharacterData>(jsonString);

            return data;
        }
        catch (Exception ex)
        {
            throw new Exception("Error reading or parsing the JSON file.", ex);
        }
    }
}

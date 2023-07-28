using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;





public class CharacterData
{
    // public string name { get; set; }
    // public string league { get; set; }
    // public int classId { get; set; }
    // public int ascendancyClass { get; set; }
    // public string @class { get; set; }
    // public int level { get; set; }
    public long experience { get; set; }
    //public bool pinnable { get; set; }

    // Additional property to store the calculated playtime
    public double overallPlaytime { get; set; }
    public double overallXP { get; set; }
}

public class Program
{
    static void Main()
    {
        string jsonFilePath = "JSON\\AllChars.json";

        try
        {
            List<CharacterData> characterList = ReadAndParseJson(jsonFilePath);

            double overallPlaytime = 0.0; // Declare the variable outside of the loop
            double overallXP = 0.0;
            int charCount=0;
            double XP=0;

            // Calculate playtime for each character and add it to the overallPlaytime property
            foreach (CharacterData character in characterList)
            {
                charCount++;
                XP += character.experience; 

                if (character.experience >= 839850)
                {
                    overallXP += character.experience - 839850;
                    overallPlaytime += 6.0; // Increment overallPlaytime by 6 hours
                }
            }

            // Print the overall playtime 
            double xpPerHour = 3000000;
            double overallPlaytimeHours = overallXP / xpPerHour; // 2 million XP per hour assumed
            overallPlaytime += overallPlaytimeHours;

            //Console.WriteLine("Overall Playtime: " + overallPlaytime + " hours");
            //Console.WriteLine("RestXP: " + overallXP + " XP");
            Console.WriteLine("XP: " + XP);
            Console.WriteLine("charCount: " + charCount);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading or parsing the JSON file:");
            Console.WriteLine(ex.Message);
        }
    }

    static List<CharacterData> ReadAndParseJson(string jsonFilePath)
    {
        if (!File.Exists(jsonFilePath))
        {
            throw new FileNotFoundException("The JSON file does not exist.", jsonFilePath);
        }

        try
        {
            string jsonString = File.ReadAllText(jsonFilePath);

            // Deserialize the JSON string to a list of CharacterData objects.
            List<CharacterData> characterList = JsonSerializer.Deserialize<List<CharacterData>>(jsonString);

            return characterList;
        }
        catch (Exception ex)
        {
            throw new Exception("Error reading or parsing the JSON file.", ex);
        }
    }
}

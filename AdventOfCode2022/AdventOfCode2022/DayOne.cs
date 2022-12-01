using System.Runtime.CompilerServices;

namespace AdventOfCode2022;

public class DayOne
{
    public long TaskOne()
    {
        var lists = ReadData();
        
        long highest = 0;
        foreach(var list in lists)
        {
            var current = list.Sum();
            if (current > highest)
                highest = current;
        }

        return highest;
    }
    
    public long TaskTwo()
    {
        var values = ReadData()
            .Select(array => array.Sum())
            .OrderByDescending(x => x)
            .Take(3)
            .Sum();
        
        return values;
    }
    
    private List<List<long>> ReadData()
    {
        var lines = ReadFile(@"files\day1_task1.txt");
        var list = new List<List<long>>();
        
        var subList = new List<long>();
        foreach(var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                list.Add(subList);
                subList = new();
            }
            else
            {
                subList.Add(Int64.Parse(line.Trim()));
            }
        }
        
        return list;
    }
    
    private List<string> ReadFile(string filePath) => File.ReadLines(filePath).ToList();
}
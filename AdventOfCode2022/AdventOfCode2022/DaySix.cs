namespace AdventOfCode2022;

public class DaySix
{
    public int TaskOne()
    {
        var data = ReadData();
        var chars = new char[4];
        for(int i = 3; i < data.Length; i++)
        {
            chars = data.Substring(i - 3, 4).ToCharArray();
            if (chars.Distinct().Count() == 4)
                return i + 1;
        }
        
        return -1;
    }
    
    public int TaskTwo()
    {
        var data = ReadData();
        var chars = new char[14];
        for(int i = 13; i < data.Length; i++)
        {
            chars = data.Substring(i - 13, 14).ToCharArray();
            if (chars.Distinct().Count() == 14)
                return i + 1;
        }
        
        return -1;
    }
    
    private string ReadData() => File.ReadAllText(@"files/day6.txt");
}
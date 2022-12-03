namespace AdventOfCode2022;

public class DayThree
{
    private static string codeArray = "0abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    
    public long TaskOne()
    {
        var data = ReadData();
        long res = 0;
        
        foreach(var i in data)
        {
            res += Find(i.left, i.right);
        }
        
        return res;
    }
    
    public long TaskTwo()
    {
        var data = ReadDataButBetter();
        long res = 0;
        foreach (var i in data)
        {
            res += FindButBetter(i.left, i.middle, i.right);
        }
        
        return res;
    }
    
    private List<(long[] left, long[] middle, long[] right)> ReadDataButBetter()
    {
        var file = @"files/day3.txt";
        return File
            .ReadAllLines(file)
            .Chunk(3)
            .Select(s =>
            {
                var left = s[0];
                var middle = s[1];
                var right = s[2];
                long[] newLeft = new long[left.Length], newRight = new long[right.Length], newMiddle = new long[middle.Length];
                
                for(int i = 0; i < left.Length; i++)
                {
                    var idx = codeArray.IndexOf(left[i]);
                    newLeft[i] = idx != -1 ? idx : throw new Exception($"{left[i]}");
                }
                for(int i = 0; i < right.Length; i++)
                {
                    var idx = codeArray.IndexOf(right[i]);
                    newRight[i] = idx != -1 ? idx : throw new Exception($"{right[i]}");
                }

                for (int i = 0; i < middle.Length; i++)
                {
                    var idx = codeArray.IndexOf(middle[i]);
                    newMiddle[i] = idx != -1 ? idx : throw new Exception($"{middle[i]}");
                }
                
                return (newLeft, newMiddle, newRight);
            })
            .ToList();
    }
    
    private long Find(long[] left, long[] right)
    {
        for (int j = 0; j < left.Length; j++)
        {
            for (int k = 0; k < right.Length; k++)
            {
                if (left[j] == right[k])
                {
                    var l = left[j];
                    var r = right[k];
                    char letter = codeArray[(int)l];
                    return l;
                }
            }
        }
        
        return 0;
    }
    
    private long FindButBetter(long[] left, long[] middle, long[] right)
    {
        for (int i = 0; i < left.Length; i++)
        {
            for (int j = 0; j < middle.Length; j++)
            {
                for (int k = 0; k < right.Length; k++)
                {
                    var l = left[i];
                    var m = middle[j];
                    var r = right[k];
                    char letter = codeArray[(int)l];
                    if (l == m && m == r && l == r)
                        return l;
                }
            }
        }
        
        return 0;
    }
    
    private List<(long[] left, long[] right)> ReadData()
    {
        var file = @"files/day3.txt";
        return File
            .ReadAllLines(file)
            .Select(s =>
            {
                var length = s.Length;
                var left = s[..(length/2)];
                var right = s[(length/2)..];
                long[] newLeft = new long[left.Length], newRight = new long[right.Length];
                
                for(int i = 0; i < left.Length; i++)
                {
                    var idx = codeArray.IndexOf(left[i]);
                    newLeft[i] = idx != -1 ? idx : throw new Exception($"{left[i]}");
                }
                for(int i = 0; i < right.Length; i++)
                {
                    var idx = codeArray.IndexOf(right[i]);
                    newRight[i] = idx != -1 ? idx : throw new Exception($"{right[i]}");
                }
                
                return (newLeft, newRight);
            })
            .ToList();
    }
}
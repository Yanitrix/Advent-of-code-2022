namespace AdventOfCode2022;

public class DayFour
{
    public long TaskOne()
    {
        long res = 0;
        var paris = ReadData();
        
        foreach(var i in paris)
        {
            if (OneContainsTheOther(i.left, i.right))
                res += 1;
        }
        
        return res;
    }
    
    public long TaskTwo()
    {
        long res = 0;
        var paris = ReadData();
        
        foreach(var i in paris)
        {
            if (DoTheyOverlapOrNot(i.left, i.right))
                res += 1;
        }
        
        return res;
    }
    
    private bool OneContainsTheOther(Range one, Range other)
    {
        //check if other contains one
        if (one.Start.Value >= other.Start.Value && one.End.Value <= other.End.Value)
        {
            return true;
        }
        
        if (other.Start.Value >= one.Start.Value && other.End.Value <= one.End.Value)
        {
            return true;
        }
        
        return false;
    }
    
    private bool DoTheyOverlapOrNot(Range left, Range right)
    {
        if (left.End.Value >= right.Start.Value && left.Start.Value <= right.Start.Value)
            return true;
        if (right.End.Value >= left.Start.Value && right.Start.Value <= left.Start.Value)
            return true;
        return false;
    }
    
    private List<(Range left, Range right)> ReadData()
    {
        var lines = File.ReadAllLines(@"files/day4.txt");
        var list = new List<(Range left, Range right)>(lines.Length);
        foreach(var line in lines)
        {
            var arr = line.Split(',');
            var arrLeft = arr[0].Split('-');
            var arrRight = arr[1].Split('-');
            var lowerLeft = int.Parse(arrLeft[0]);
            var greaterLeft = int.Parse(arrLeft[1]);
            var lowerRight = int.Parse(arrRight[0]);
            var greaterRight = int.Parse(arrRight[1]);
            
            var left = new Range(new(lowerLeft), new(greaterLeft));
            var right = new Range(new(lowerRight), new(greaterRight));
            
            list.Add((left, right));
        }
        
        return list;
    }
}
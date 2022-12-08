using System.Text;

namespace AdventOfCode2022;

public class DayFive
{
    public string TaskOne()
    {
        // var setup = GetCratesSetupTest();
        var setup = GetCratesSetup();
        var data = REadData();
        foreach (var i in data)
        {
            setup.Move(i.count, i.from, i.to);
        }
        
        return setup.Select(s => s.Peek()).Aggregate("", (left, right) => left + right);
    }
    
    public string TaskTwo()
    {
        // var setup = GetCratesSetupTest();
        var setup = GetCratesSetup();
        var data = REadData();
        foreach (var i in data)
        {
            setup.MoveKeepingOrder(i.count, i.from, i.to);
        }
        
        return setup.Select(s => s.Peek()).Aggregate("", (left, right) => left + right);
    }
    
    private IList<Stack<char>> GetCratesSetup()
    {
        var list = new Stack<char>[9];
        list[0] = new Stack<char>(new char[]{'S' , 'Z', 'P', 'D', 'L', 'B', 'F', 'C'});
        list[1] = new Stack<char>(new char[]{'N', 'V', 'G', 'P', 'H', 'W', 'B'});
        list[2] = new Stack<char>(new char[]{'F', 'W', 'B', 'J', 'G'});
        list[3] = new Stack<char>(new char[]{'G', 'J', 'N', 'F', 'L', 'W', 'C', 'S'});
        list[4] = new Stack<char>(new char[]{'W', 'J', 'L', 'T', 'P', 'M', 'S', 'H'});
        list[5] = new Stack<char>(new char[]{'B', 'C', 'W', 'G', 'F', 'S'});
        list[6] = new Stack<char>(new char[]{'H', 'T', 'P', 'M', 'Q', 'B', 'W'});
        list[7] = new Stack<char>(new char[]{'F', 'S', 'W', 'T'});
        list[8] = new Stack<char>(new char[]{'N', 'C', 'R'});
        
        return list;
    }
    
    private List<(int count, int from, int to)> REadData()
    {
        var lines = File.ReadAllLines(@"files/day5.txt");
        var list = new List<(int count, int from, int to)>(lines.Length);
        
        foreach(var i in lines)
        {
            var s = new StringBuilder(i);
            s
                .Remove(i.IndexOf("to", StringComparison.Ordinal), 2)
                .Remove(i.IndexOf("from", StringComparison.Ordinal), 4)
                .Remove(i.IndexOf("move", StringComparison.Ordinal), 4)
                ;
            
            var arr = s.ToString().Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            
            list.Add((Int32.Parse(arr[0]), Int32.Parse(arr[1]), Int32.Parse(arr[2])));
        }
        
        return list;
    }

    private IList<Stack<char>> GetCratesSetupTest()
    {
        var list = new Stack<char>[3];
        list[0] = new Stack<char>(new char[]{'Z' , 'N'});
        list[1] = new Stack<char>(new char[]{'M', 'C', 'D'});
        list[2] = new Stack<char>(new char[]{'P'});
        
        return list;
    }
}

public static class StackExtensions
{
    public static void Move(this IList<Stack<char>> target, int count, int from, int to)
    {
        //from-to is one based
        from -= 1;
        to -= 1;
        
        for(int i = 0; i < count; i++)
        {
            var item = target[from].Pop();
            target[to].Push(item);
        }
    }
    
    public static void MoveKeepingOrder(this IList<Stack<char>> target, int count, int from, int to)
    {
        //from-to is one based
        from -= 1;
        to -= 1;
        
        var moving = new char[count];
        for(int i = 0; i < count; i++)
        {
            var item = target[from].Pop();
            moving[i] = item;
        }
        
        for(int i = count - 1; i >= 0; i--)
        {
            var item = moving[i];
            target[to].Push(item);
        }
    }
}
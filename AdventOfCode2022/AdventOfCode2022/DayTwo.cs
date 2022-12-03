namespace AdventOfCode2022;

public class DayTwo
{
    
    public long TaskOne()
    {
        var games = ReadData();
        long result = 0;

        foreach (var game in games)
        {
            if (game.me == Game.ROCK)
                result += 1;
            if (game.me == Game.PAPER)
                result += 2;
            if (game.me == Game.SCISSORS)
                result += 3;
            
            var res = game.me.AreYouWinningSon(game.opponent);
            if (res ==  true)
                result += 6;
            if (res == null)
                result += 3;
        }
        
        return result;
    }
    
    public long TaskTwo()
    {
        var newGames = TransformGameToBetterGame(ReadData());
        
        long result = 0;

        foreach (var game in newGames)
        {
            if (game.me == Game.ROCK)
                result += 1;
            if (game.me == Game.PAPER)
                result += 2;
            if (game.me == Game.SCISSORS)
                result += 3;
            
            var res = game.me.AreYouWinningSon(game.opponent);
            if (res ==  true)
                result += 6;
            if (res == null)
                result += 3;
        }
        
        return result;
    }
    
    private List<(Game me, Game opponent)> TransformGameToBetterGame(List<(Game me, Game opponent)> originalGames)
    {
        //now interpreting my turn as:
        //Game.Rock = false
        //Game.Paper = null
        //Game.Scissors = true
        
        return originalGames
            .Select(tuple =>
            {
                var me = tuple.me;
                var opponent = tuple.opponent;

                bool? figureItOut = me switch
                {
                    Game.ROCK => false,
                    Game.PAPER => null,
                    Game.SCISSORS => true,
                    _ => throw new Exception("hstus pan")
                };

                var newMe = opponent.FigureOutWhatToDoToAchieveTheRightResult(figureItOut);
                
                return (newMe, opponent);
            })
            .ToList();
    }
    
    private List<(Game me, Game opponent)> ReadData()
    {
        var lines = File.ReadAllLines("files/day2.txt");
        var list = new List<(Game me, Game other)>(lines.Length); //optimizing the shit out of this code
        foreach (var line in lines)
        {
            var arr = line.Split(' ');
            var (me, other) = (arr[0], arr[1]);
            Game gMe = Game.ROCK, gOther = Game.ROCK;
            if (me == "A")
                gOther = Game.ROCK;
            if (me == "B")
                gOther = Game.PAPER;
            if (me == "C")
                gOther = Game.SCISSORS;
            if (other == "X")
                gMe = Game.ROCK;
            if (other == "Y")
                gMe = Game.PAPER;
            if (other == "Z")
                gMe = Game.SCISSORS;
            
            list.Add((gMe, gOther));
        }
        
        return list;
    }
}

public enum Game
{
    ROCK,
    PAPER,
    SCISSORS
}

public static class GameExtensions
{
    public static bool? AreYouWinningSon(this Game you, Game theOther)
    {
        if (you == Game.ROCK && theOther == Game.PAPER)
            return false;
        if (you == Game.ROCK && theOther == Game.SCISSORS)
            return true;
        if (you == Game.SCISSORS && theOther == Game.ROCK)
            return false;
        if (you == Game.SCISSORS && theOther == Game.PAPER)
            return true;
        if (you == Game.PAPER && theOther == Game.ROCK)
            return true;
        if (you == Game.PAPER && theOther == Game.SCISSORS)
            return false;

        return null;
    }
    
    public static Game FigureOutWhatToDoToAchieveTheRightResult(this Game opponent, bool? result)
    {
        Game res = Game.ROCK;
        if (result == null)
        {
            res =  opponent;
        }
        else if (result == true)
        {
            if (opponent == Game.ROCK)
                res =  Game.PAPER;
            if (opponent == Game.PAPER)
                res = Game.SCISSORS;
            if (opponent == Game.SCISSORS)
                res = Game.ROCK;
        }
        else if (result == false)
        {
            if (opponent == Game.ROCK)
                res = Game.SCISSORS;
            if (opponent == Game.PAPER)
                res = Game.ROCK;
            if (opponent == Game.SCISSORS)
                res = Game.PAPER;
        }
        else
        {
            throw new Exception("hstus pan");
        }
        
        return res;
    }
}
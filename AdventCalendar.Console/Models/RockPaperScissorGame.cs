using AdventCalendar.Console.Enums;

namespace AdventCalendar.Console.Models
{
    /// <summary>
    /// Mapping:
    /// A, X: Rock
    /// B, Y: Paper
    /// C, Z: Scissor
    /// </summary>
    public class RockPaperScissorGame
    {
        private readonly Dictionary<string, int> _pointMapping = new Dictionary<string, int>()
        {
            {"X", 1 },
            {"Y", 2 },
            {"Z", 3 },
        };

        private static Dictionary<(string, string), GameStates> _outcomes =
            new Dictionary<(string, string), GameStates>()
            {
                {("A", "X"),  GameStates.Draw},
                {("A", "Y"),  GameStates.Win},
                {("A", "Z"),  GameStates.Lose},
                {("B", "X"),  GameStates.Lose},
                {("B", "Y"),  GameStates.Draw},
                {("B", "Z"),  GameStates.Win},
                {("C", "X"),  GameStates.Win},
                {("C", "Y"),  GameStates.Lose},
                {("C", "Z"),  GameStates.Draw},
            };

        public RockPaperScissorGame(string handOne, string handTwo)
        {
            HandOne = handOne;
            HandTwo = handTwo;
        }

        public RockPaperScissorGame(string handOne, GameStates state)
        {
            HandOne = handOne;
            HandTwo = FindSecondHandBasedOnGameState(state, handOne);
        }

        public string HandOne { get; set; }
        public string HandTwo { get; set; }

        public int CalculatePoints()
        {
            var gameState = _outcomes[(HandOne, HandTwo)];
            return (int)gameState + _pointMapping[HandTwo];
        }

        public static string FindSecondHandBasedOnGameState(GameStates state, string handOne)
        {
            return _outcomes
                .Where(g => g.Value == state)
                .FirstOrDefault(g => g.Key.Item1 == handOne)
                .Key
                .Item2;
        }
    }
}

namespace FantasyFootbal.Models.Tournoment
{
    /// <summary>
    /// For autocomplete we must have below two properties, each tiem when we want to make our virtual footbal 
    /// club, the program genareted only name and position from db
    /// </summary>
    public class FillModel
    {
        // Name of player
        public string Name { get; set; }

        // Position of player
        public string Position { get; set; }
    }
}

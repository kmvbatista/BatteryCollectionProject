namespace DataTypeObject
{
    public class RankingData
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public RankingData(string name, int totalPoints)
        {
        Name = name;
        Points = totalPoints;
        }
    }
}
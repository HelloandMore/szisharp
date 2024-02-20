    public static class DataService
    {
    public static Dictionary<string, int> GetSumOfRatings(List<Book> students)
    {
        Dictionary<string, int> result = new Dictionary<string, int> {
        {"elégtelen", 0},
        {"elégséges", 0},
        {"jó", 0},
        {"jeles", 0},
        {"kitűnő", 0}
    };


        foreach (Book item in students)
        {
            switch (item.Average)
            {
                case < 2:
                    result["elégtelen"]++;
                    break;
                case < 3:
                    result["elégséges"]++;
                    break;
                case < 4:
                    result["jó"]++;
                    break;
                case < 5:
                    result["jeles"]++;
                    break;
                case >= 5:
                    result["kitűnő"]++;
                    break;

            }
        }

        return result;
    }
}


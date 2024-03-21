
    public class DanceTypeAndCoupleNames
    {
    public string DanceName { get; set; }

    public string GirlName { get; set; }

    public string BoyName { get; set; }

    public DanceTypeAndCoupleNames() {    }

    public DanceTypeAndCoupleNames(string danceName, string girlName, string boyName)
    {
        DanceName = danceName;
        GirlName = girlName;
        BoyName = boyName;
    }

    public override string ToString()
    {
        return $"{DanceName}: {GirlName} és {BoyName}";
    }
}


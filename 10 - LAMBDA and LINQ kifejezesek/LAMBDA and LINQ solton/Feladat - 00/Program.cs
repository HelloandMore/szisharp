List<Student> students = new List<Student>
{
	new Student("Hétfő Henrik", 10, 154),
	new Student("Kedd Kinga", 14, 250),
	new Student("Szerda Szilárd", 9, 98),
	new Student("Csütörtök Csongor", 11, 198),
	new Student("Péntek Petra", 13, 245),
	new Student("Szombat Szimonetta", 10, 152),
	new Student("Vasárnap Virág", 13, 221),
};


// Mennyi a legnagyobb pontszám?? 
int maxPoints = students.Max(x => x.Points);

// Ki érte ezt el??
Student bestStudent = students.MaxBy(x => x.Points);

// Mennyi a legkisebb pontszám??
int minPoints = students.Min(x => x.Points);

// Ki érte ezt el??
Student worstStudent = students.MinBy(x => x.Points);

// Mik a diákok nevei?
List<string> studentNames = students.Select(students => students.Name).ToList();

// Kik szereztek többet 200 pontnál??
List<string> studentAboveTwohundred = students.Where(x => x.Points > 200).Select(x => x.Name).ToList();

// Diákok neve ABC sorrendben..
List<string> studentsInAlphabeticOrder = students.OrderBy(x => x.Name).Select(x => x.Name).ToList();

// ..majd pontok alapján csökkenő sorrendbe
List<string> orderStudentsbyNameandPoints = students.OrderBy(x => x.Name).ThenByDescending(x => x.Points).Select(x => x.Name).ToList();

// Diákok csökkenő sorrendbe rendezése osztályok alapján ..
// ..majd diákok csökkenő sorrendbe rendezése pontok alapján
List<string> orderStudentsByGradeandPoints = students.OrderByDescending(x => x.Grade).ThenByDescending(x => x.Points).Select(x => x.Name).ToList();

// Évfolyamonként elért pontszámok évfolyam szerint csökkenő sorrendben

List<GradeWithPoints> gradeWithPoints = students.GroupBy(x => x.Grade).Select(x => new GradeWithPoints
{
	Grade = x.Key,
	Points = x.Sum(x => x.Points)
}).OrderByDescending(x => x.Grade).ToList();

// milyen pontszámokat kaptak egyes évfolyamok
// minden pontszám csak 1x-szer fordulhat elő az eredményben

// módszer 1
List<int> distinctedPoints = students.Select(x => x.Points).Distinct().ToList();

// módszer 2
List<int> distinctedPoints2 = students.DistinctBy(x => x.Points).Select(x => x.Points).ToList();
using Diary.Database.Entites;

namespace Diary.ConsoleApp;

public class DbFunctions
{

	public static async Task DisplayMainMenuAsync(ApplicationDbContext context)
	{
		Console.WriteLine("=== Napló alkalmazás ===");
		Console.WriteLine("0. Diák adatainak kiíratása");
		Console.WriteLine("1. Új diák felvétele");
		Console.WriteLine("2. Diák adatainak módosítása");
		Console.WriteLine("3. Diák törlése");
		Console.WriteLine("4. Új tantárgy felvétele");
		Console.WriteLine("5. Tantárgy hozzáadása diákhoz");
		Console.WriteLine("6. Osztályzat rögzítése");
		Console.WriteLine("7. Osztályzat törlése diákról");
		Console.WriteLine("8. Tantárgy törlése diákról");
		Console.WriteLine("9. Kilépés");
		int choice = ReadValidNumFromRange("Válasszon egy menüpontot: ", 0, 9);
		switch (choice)
		{
			case 0:
				await DisplayStudentInformations(context);
				break;
			case 1:
				await AddStudentAsync(context);
				break;
			case 2:
				await ModifyStudentAsync(context);
				break;
			case 3:
				await DeleteStudentAsync(context);
				break;
			case 4:
				await AddSubjectAsync(context);
				break;
			case 5:
				await AddSubjectToStudent(context);
				break;
			case 6:
				await AddGradeAsync(context);
				break;
			case 7:
				await RemoveGradeFromStudentAsync(context);
				break;
			case 8:
				await RemoveSubjectFromStudentAsync(context);
				break;
			case 9:
				Console.WriteLine("Kilépés...");
				Thread.Sleep(3000);
				Environment.Exit(0);
				break;
		}
	}

	public static async Task DisplayStudentInformations(ApplicationDbContext context)
	{
		Console.Clear();
		Console.WriteLine("=== Diák adatainak megjelenítése ===");
		var students = await context.Students.OrderBy(x => x.Name).ToListAsync();
		DisplayStudents(students);
		var studentId = ReadValidNumFromRange("Add meg a diák oktatási azonosítóját: ", students.Min(s => s.EduId), students.Max(s => s.EduId));
		var selectedStudent = await context.Students.FindAsync(studentId);
		if (selectedStudent is null)
		{
			Console.WriteLine("Nem található diák ezzel az azonosítóval.");
			return;
		}
		DisplayStudentDetails(selectedStudent);
	}

	public static async Task AddStudentAsync(ApplicationDbContext context)
	{
		Console.Clear();
		Console.WriteLine("=== Új diák felvétele ===");

		var student = new StudentEntity
		{
			Name = ReadNonEmptyString("Teljes név: "),
			MotherName = ReadNonEmptyString("Anyja neve: "),
			DateOfBirth = ReadValidDateTime("Születési dátum"),
		};

		var newAddress = new AddressEntity
		{
			Country = ReadNonEmptyString("Lakcím ország: "),
			City = ReadNonEmptyString("Lakcím város: "),
			Street = ReadNonEmptyString("Lakcím utca: "),
			HouseNumber = ReadNonEmptyString("Lakcím házszám: ")
		};
		student.AddressId = await CheckForExistingAddressAsync(context, newAddress);

		await context.Students.AddAsync(student);
		await context.SaveChangesAsync();
	}

	public static async Task ModifyStudentAsync(ApplicationDbContext context)
	{
		Console.Clear();
		Console.WriteLine("=== Diák adatainak módosítása ===");

		var students = await context.Students.OrderBy(x => x.Name).ToListAsync();
		DisplayStudents(students);

		Console.Write("Add meg a módosítandó diák oktatási azonosítóját: ");
		var selectedStudent = await context.Students.FindAsync(int.Parse(Console.ReadLine()));
		if (selectedStudent is null)
		{
			Console.WriteLine("Nem található diák ezzel az azonosítóval.");
			return;
		}

		DisplayStudentDetails(selectedStudent);

		Console.WriteLine("Mely adatokat szeretné módosítani?");
		Console.WriteLine("1. Név");
		Console.WriteLine("2. Anyja neve");
		Console.WriteLine("3. Születési dátum");
		Console.WriteLine("4. Lakcím");
		Console.Write("Válasszon egy menüpontot: ");
		int choice = ReadValidNumFromRange("", 1, 4);

		switch (choice)
		{
			case 1:
				selectedStudent.Name = ReadNonEmptyString("Új név: ");
				break;
			case 2:
				selectedStudent.MotherName = ReadNonEmptyString("Anyja új neve: ");
				break;
			case 3:
				selectedStudent.DateOfBirth = ReadValidDateTime("Új születési dátum");
				break;
			case 4:
				await ChangeStudentAddressAsync(context, selectedStudent);
				break;
		}

		await context.SaveChangesAsync();
	}

	public static async Task DeleteStudentAsync(ApplicationDbContext context)
	{
		Console.Clear();
		Console.WriteLine("=== Diák törlése ===");
		var students = await context.Students.OrderBy(x => x.Name).ToListAsync();
		DisplayStudents(students);
		var studentId = ReadValidNumFromRange("Add meg a törlendő diák oktatási azonosítóját: ", students.Min(s => s.EduId), students.Max(s => s.EduId));
		var selectedStudent = await context.Students.FindAsync(studentId);
		context.Students.Remove(selectedStudent);
		await context.SaveChangesAsync();
	}

	public static async Task AddSubjectAsync(ApplicationDbContext context)
	{
		Console.Clear();
		Console.WriteLine("=== Új tantárgy felvétele ===");
		string subjectName = ReadNonEmptyString("Tantárgy neve: ");
		var subject = new SubjectEntity
		{
			SubjectName = subjectName
		};
		context.Subjects.Add(subject);
		await context.SaveChangesAsync();
	}

	public static async Task AddSubjectToStudent(DbContext context)
	{
		Console.Clear();
		Console.WriteLine("=== Tantárgy hozzáadása diákhoz ===");
		var students = await context.Set<StudentEntity>().OrderBy(x => x.Name).ToListAsync();
		DisplayStudents(students);
		var studentId = ReadValidNumFromRange("Add meg a diák oktatási azonosítóját: ", students.Min(s => s.EduId), students.Max(s => s.EduId));
		var selectedStudent = await context.Set<StudentEntity>().FindAsync(studentId);
		if (selectedStudent is null)
		{
			Console.WriteLine("Nem található diák ezzel az azonosítóval.");
			return;
		}
		var subjects = await context.Set<SubjectEntity>().OrderBy(x => x.SubjectName).ToListAsync();
		DisplaySubjects(subjects);
		var subjectId = ReadValidNumFromRange("Add meg a tantárgy azonosítóját: ", subjects.Min(s => s.Id), subjects.Max(s => s.Id));
		var selectedSubject = await context.Set<SubjectEntity>().FindAsync(subjectId);
		if (selectedSubject is null)
		{
			Console.WriteLine("Nem található tantárgy ezzel az azonosítóval.");
			return;
		}
		if (selectedStudent.Subjects == null)
		{
			selectedStudent.Subjects = new List<SubjectEntity>();
		}
		selectedStudent.Subjects.Add(selectedSubject);
		await context.SaveChangesAsync();
	}

	public static async Task AddGradeAsync(ApplicationDbContext context)
	{
		Console.Clear();
		Console.WriteLine("=== Új osztályzat rögzítése ===");
		var students = await context.Students.OrderBy(x => x.Name).ToListAsync();
		DisplayStudents(students);
		var studentId = ReadValidNumFromRange("Add meg a diák oktatási azonosítóját: ", students.Min(s => s.EduId), students.Max(s => s.EduId));
		var selectedStudent = await context.Students.FindAsync(studentId);
		if (selectedStudent is null)
		{
			Console.WriteLine("Nem található diák ezzel az azonosítóval.");
			return;
		}
		DisplaySubjects(selectedStudent.Subjects);
		var subjectId = ReadValidNumFromRange("Add meg a tantárgy azonosítóját: ", selectedStudent.Subjects.Min(s => s.Id), selectedStudent.Subjects.Max(s => s.Id));
		var selectedSubject = await context.Subjects.FindAsync(subjectId);
		if (selectedSubject is null)
		{
			Console.WriteLine("Nem található tantárgy ezzel az azonosítóval.");
			return;
		}
		var grade = ReadValidNumFromRange("Osztályzat: ", 1, 5);
		var gradeEntity = new GradeEntity
		{
			GradeValue = grade,
			Student = selectedStudent,
			Subject = selectedSubject
		};
		context.Grades.Add(gradeEntity);
		await context.SaveChangesAsync();
	}

	public static async Task RemoveGradeFromStudentAsync(ApplicationDbContext context)
	{
		Console.Clear();
		Console.WriteLine("=== Osztályzat törlése diákról ===");
		var students = await context.Students.OrderBy(x => x.Name).ToListAsync();
		DisplayStudents(students);
		var studentId = ReadValidNumFromRange("Add meg a diák oktatási azonosítóját: ", students.Min(s => s.EduId), students.Max(s => s.EduId));
		var selectedStudent = await context.Students.FindAsync(studentId);
		if (selectedStudent is null)
		{
			Console.WriteLine("Nem található diák ezzel az azonosítóval.");
			return;
		}
		var grades = await context.Grades.Where(x => x.Student.EduId == studentId).ToListAsync();
		DisplayGrades(selectedStudent);
		var gradeId = ReadValidNumFromRange("\nAdd meg az osztályzat azonosítóját: ", grades.Min(g => g.Id), grades.Max(g => g.Id));
		var selectedGrade = await context.Grades.FindAsync(gradeId);
		if (selectedGrade is null)
		{
			Console.WriteLine("Nem található osztályzat ezzel az azonosítóval.");
			return;
		}
		context.Grades.Remove(selectedGrade);
		await context.SaveChangesAsync();
	}

	public static async Task RemoveSubjectFromStudentAsync(ApplicationDbContext context)
	{
		Console.Clear();
		Console.WriteLine("=== Tantárgy törlése diákról ===");
		var students = await context.Students.OrderBy(x => x.Name).ToListAsync();
		DisplayStudents(students);
		var studentId = ReadValidNumFromRange("Add meg a diák oktatási azonosítóját: ", students.Min(s => s.EduId), students.Max(s => s.EduId));
		var selectedStudent = await context.Students.FindAsync(studentId);
		if (selectedStudent is null)
		{
			Console.WriteLine("Nem található diák ezzel az azonosítóval.");
			Thread.Sleep(2000);
			return;
		}
		if (selectedStudent.Subjects == null || !selectedStudent.Subjects.Any())
		{
			Console.WriteLine("A diáknak nincsenek tantárgyai.");
			Thread.Sleep(2000);
			return;
		}
		var subjects = await context.Subjects.OrderBy(x => x.SubjectName).ToListAsync();
		DisplaySubjects(subjects);
		var subjectId = ReadValidNumFromRange("Add meg a tantárgy azonosítóját: ", subjects.Min(s => s.Id), subjects.Max(s => s.Id));
		var selectedSubject = await context.Subjects.FindAsync(subjectId);
		if (selectedSubject is null)
		{
			Console.WriteLine("Nem található tantárgy ezzel az azonosítóval.");
			Thread.Sleep(2000);
			return;
		}
		selectedStudent.Subjects.Remove(selectedSubject);
		await context.SaveChangesAsync();
	}

	public static async Task InitAsync(ApplicationDbContext context)
	{
		Console.Clear();
		Console.WriteLine("=== Adatok inicializálása ===");

		var students = await context.Students.ToListAsync();
		var grades = await context.Grades.ToListAsync();
		var subjects = await context.Subjects.Include(s => s.Students).ToListAsync();
		var addresses = await context.Addresses.ToListAsync();

		foreach (var student in students)
		{
			student.Subjects = subjects
				.Where(s => s.Students != null && s.Students.Any(st => st.EduId == student.EduId))
				.ToList();
			student.Grades = grades.Where(g => g.Student.EduId == student.EduId).ToList();
			//student.Subjects = subjects.Where(s => s.Students.Any(st => st.EduId == student.EduId)).ToList();
			var address = addresses.FirstOrDefault(a => a.Id == student.Address.Id);
			if (address != null)
			{
				student.Address = address;
			}
		}

		await context.SaveChangesAsync();
		Console.WriteLine("Adatok sikeresen inicializálva.");
		Thread.Sleep(500);
	}

	private static string ReadNonEmptyString(string prompt)
	{
		string input;
		do
		{
			Console.Write(prompt);
			input = Console.ReadLine();
			if (string.IsNullOrWhiteSpace(input))
			{
				Console.WriteLine("A név nem lehet üres. Kérem, adja meg újra.");
			}
		} while (string.IsNullOrWhiteSpace(input));
		return input;
	}

	private static int ReadValidNumFromRange(string prompt, int min, int max)
	{
		int num;
		Console.Write(prompt);
		while (!int.TryParse(Console.ReadLine(), out num) || num < min || num > max)
		{
			Console.WriteLine($"Érvénytelen választás. Kérem, adjon meg egy számot {min} és {max} között.");
			Console.Write(prompt);
		}
		return num;
	}

	private static DateTime ReadValidDateTime(string prompt)
	{
		DateTime date;
		Console.Write($"{prompt} (éééé-hh-nn): ");
		while (!DateTime.TryParse(Console.ReadLine(), out date))
		{
			Console.WriteLine("Érvénytelen dátumformátum. Kérem, adja meg újra (éééé-hh-nn): ");
			Console.Write(prompt);
		}
		return date;
	}

	private static async Task ChangeStudentAddressAsync(ApplicationDbContext context, StudentEntity student)
	{
		var newAddress = new AddressEntity
		{
			Country = ReadNonEmptyString("Új lakcím ország: "),
			City = ReadNonEmptyString("Új lakcím város: "),
			Street = ReadNonEmptyString("Új lakcím utca: "),
			HouseNumber = ReadNonEmptyString("Új lakcím házszám: ")
		};
		var addressId = await CheckForExistingAddressAsync(context, newAddress);
		await context.SaveChangesAsync();
		Console.WriteLine("Lakcím sikeresen módosítva.");
		Thread.Sleep(2000);
	}

	private static async Task<int> CheckForExistingAddressAsync(ApplicationDbContext context, AddressEntity newAddress)
	{
		var existingAddress = await context.Addresses
			.FirstOrDefaultAsync(a =>
				a.Country == newAddress.Country &&
				a.City == newAddress.City &&
				a.Street == newAddress.Street &&
				a.HouseNumber == newAddress.HouseNumber);

		if (existingAddress != null)
		{
			return existingAddress.Id;
		}
		else
		{
			await context.AddAsync(newAddress);
			await context.SaveChangesAsync();
			return newAddress.Id;
		}
	}

	private static void DisplayStudents(List<StudentEntity> students)
	{
		if (students.Any())
		{
			Console.WriteLine("Diákok:");
			foreach (var student in students)
			{
				Console.WriteLine($"{student.EduId}. {student.Name}");
			}
		}
		else
		{
			Console.WriteLine("Nincsenek diákok az adatbázisban.");
			Thread.Sleep(2000);
			Console.Clear();
			DisplayMainMenuAsync(new ApplicationDbContext()).Wait();
		}
	}

	private static void DisplayStudentDetails(StudentEntity student)
	{
		Console.WriteLine("Kiválasztott diák adatai:");
		Console.WriteLine($"Név: {student.Name}");
		Console.WriteLine($"Anyja neve: {student.MotherName}");
		Console.WriteLine($"Születési dátum: {student.DateOfBirth}");
		Console.WriteLine($"Lakcím: {student.Address.Country}, {student.Address.City}, {student.Address.Street} {student.Address.HouseNumber}");
		if (student.Subjects != null && student.Subjects.Any())
		{
			Console.Write("Tantárgyak:");
			foreach (var subject in student.Subjects)
			{
				Console.WriteLine();
				Console.Write($"{subject.SubjectName}: ");
				if (student.Grades != null && student.Grades.Any())
				{
					foreach (var grade in student.Grades)
					{
						if (grade.Subject.Id == subject.Id)
						{
							Console.Write($"{grade.GradeValue} ");
						}
					}
				}
			}
		}
		else
		{
			Console.WriteLine("Nincs tantárgy hozzárendelve");
		}
		Console.WriteLine();
		Console.Write("Nyomja meg az Enter-t a visszalépéshez...");
		Console.ReadLine();
	}

	private static void DisplaySubjects(ICollection<SubjectEntity> subjects)
	{
		Console.WriteLine("Tantárgyak:");
		if (subjects is null || !subjects.Any())
		{
			Console.WriteLine("Nincsenek tantárgyak az adatbázisban.");
			Thread.Sleep(2000);
			Console.Clear();
			DisplayMainMenuAsync(new ApplicationDbContext()).Wait();
		}
		foreach (var subject in subjects)
		{
			Console.WriteLine($"{subject.Id}. {subject.SubjectName}");
		}
	}

	private static void DisplayGrades(StudentEntity student)
	{
		if (student.Subjects != null && student.Subjects.Any())
		{
			Console.WriteLine("Tantárgyak (azonosító) (jegy):");
			foreach (var subject in student.Subjects)
			{
				Console.WriteLine($"{subject.SubjectName}: ");
				if (student.Grades != null && student.Grades.Any())
				{
					foreach (var grade in student.Grades)
					{
						if (grade.Subject.Id == subject.Id)
						{
							Console.WriteLine($"\t({grade.Id}) {grade.GradeValue}");
						}
					}
				}
			}
		}
		else
		{
			Console.WriteLine("Nincs tantárgy hozzárendelve a diákhoz");
			DisplayMainMenuAsync(new ApplicationDbContext()).Wait();
		}
	}
	public static async Task AssignAddressToStudentsAsync(ApplicationDbContext context)
	{
		Console.Clear();
		Console.WriteLine("=== Diákok lakcímének hozzárendelése ===");
		var students = await context.Students.OrderBy(x => x.Name).ToListAsync();
		DisplayStudents(students);
		var studentId = ReadValidNumFromRange("Add meg a diák oktatási azonosítóját: ", students.Min(s => s.EduId), students.Max(s => s.EduId));
		var selectedStudent = await context.Students.FindAsync(studentId);
		if (selectedStudent is null)
		{
			Console.WriteLine("Nem található diák ezzel az azonosítóval.");
			return;
		}

		var addresses = await context.Addresses.OrderBy(x => x.City).ToListAsync();
		DisplayAddresses(addresses);
		var addressId = ReadValidNumFromRange("Add meg a lakcím azonosítóját: ", addresses.Min(a => a.Id), addresses.Max(a => a.Id));
		var selectedAddress = await context.Addresses.FindAsync(addressId);
		if (selectedAddress is null)
		{
			Console.WriteLine("Nem található lakcím ezzel az azonosítóval.");
			return;
		}

		selectedStudent.Address = selectedAddress;
		await context.SaveChangesAsync();
		Console.WriteLine("Lakcím sikeresen hozzárendelve a diákhoz.");
	}

	private static void DisplayAddresses(List<AddressEntity> addresses)
	{
		if (addresses.Count > 1)
		{
			Console.WriteLine("Lakcímek:");
		}
		else
		{
			Console.WriteLine("Lakcím:");
		}
		foreach (var address in addresses)
		{
			Console.WriteLine($"{address.Id}. {address.Country}, {address.City}, {address.Street} {address.HouseNumber}");
		}
	}
}

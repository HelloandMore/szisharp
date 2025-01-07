/* FELADAT: Készítsünk egy, a Kréta-hoz hasonló console appot.

 

Egy diáknak lehet több tantárgya is, a tantárgy az egy diákhoz tartozik. A diagram csak tájékoztató jellegű, az osztályok tartalmazhatnak más mezőket is!

A diákok adatai a diakok.txt, a tantárgyak adatai pedig a tantargyak.txt fileokben legyenek eltárolva.
Az adattárolást elvégezheti txt vagy json állományban is.

Az adatok kezelését menüpontokon keresztül kell elvégezni. Ezeket a menüpontokat a saját megoldása alapján hozza létre.

A programnak lehetővé kell tennie új diák felvételét. A dikának új tantárgy felvételét és a tantárgyhoz új osztályzat beírását.
A programnak lehetővé kell tennie már meglévő diák adatainak módosítását is. Ez alatt a diák nevének, tanárgya jegyeinek módosítását értjük.
*/
// A programot .net 8.0-ás keretrendszer késztse el, és használjon linq-t ahol csak lehet.

	Console.Write("1. Új diák felvétele\n2. Új tantárgy felvétele\n3. Diák adatainak módosítása\n4. Kilépés\nVálassza ki mivel szeretné kezdeni > ");
	char menu = Console.ReadLine().KeyChar();

		switch (menu)
		{
			case '1':
				Console.WriteLine("Adja meg a diák nevét");
				string name = Console.ReadLine();
				Console.WriteLine("Adja meg a diák tantárgyait vesszővel elválasztva");
				string classes = Console.ReadLine();
				await DataManager.AddStudent(name, classes);
				await Start();
				break;
			case '2':
				Console.WriteLine("Adja meg a tantárgy nevét");
				string className = Console.ReadLine();
				Console.WriteLine("Adja meg a tantárgy jegyeit vesszővel elválasztva");
				string grades = Console.ReadLine();
				await DataManager.AddClass(className, grades);
				await Start();
				break;
			case '3':
				Console.WriteLine("Adja meg a diák nevét");
				string studentName = Console.ReadLine();
				Console.WriteLine("Adja meg a diák tantárgyait vesszővel elválasztva");
				string studentClasses = Console.ReadLine();
				await DataManager.ModifyStudent(studentName, studentClasses);
				await Start();
				break;
			case '4':
				Environment.Exit(0);
				break;
			default:
				Console.WriteLine("Nem megfelelő menüpont");
				await Start();
				break;
		}

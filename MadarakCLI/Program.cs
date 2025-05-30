namespace MadarakCLI
{
    public class Program
    {
        static List<Madar> madarak;

        static void Main(string[] args)
        {
            string allomany = "madarak.txt";
            madarak = Beolvas(allomany);
            LinqFeladatok();

            Console.ReadKey();
        }

        public static List<Madar> Beolvas(string allomany)
        {
            List<Madar> madarak = new();
            try
            {
                using (StreamReader olvas = new(allomany))
                {
                    olvas.ReadLine(); // Fejléc

                    while (!olvas.EndOfStream)
                    {
                        string sor = olvas.ReadLine();
                        madarak.Add(new(sor));
                    }
                    Console.WriteLine("Sikeres beolvasás!");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba történt a fájl beolvasásakor: " + ex.Message);
            }
            return madarak;
        }

        static void LinqFeladatok()
        {
            Console.WriteLine("1. feladat");
            Console.WriteLine(madarak.Count);

            Console.WriteLine("2. feladat");
            Console.WriteLine(madarak.First(x => x.MagyarNev == "gyurgyalag").Ev);

            Console.WriteLine("3. feladat");
            Console.Write("Kérem, adja meg a keresett madár magyar nevét: ");
            string felhasznaloMadara = Console.ReadLine();

            var keresettMadar = madarak.FirstOrDefault(x => x.MagyarNev == felhasznaloMadara);

            Console.WriteLine($"Magyar név: {keresettMadar.MagyarNev}, latin neve: {keresettMadar.LatinNev}");

            Console.WriteLine("4. feladat");

            List<Madar> legalabb = madarak.Where(x => x.Ertek >= 50000).ToList();
            Console.WriteLine($"{legalabb.Count} madár van amelynek az értéke legalább 50.000Ft");

            Console.WriteLine("5. feladat");

            int legkisebbEv = madarak.Min(x => x.Ev);

            foreach(var item in madarak.Where(x => x.Ev == legkisebbEv))
            {
                Console.WriteLine(item.MagyarNev);
            }







        }
    }
}

using projekt_2;
using System.Runtime.Intrinsics.Arm;
using System.Xml.Linq;
using System;

var welcome = new welcomescreen();
bool loop = true;

List<client> lstclients = new List<client>();
lstclients.Add(new client("1", "Jan Nowak" ,2021,03,04));
lstclients.Add(new client("2", "Agnieszka Kowalska", 1999,01,15));
lstclients.Add(new client("3", "Robert Lewandowski",2010,12,18));
lstclients.Add(new client("4", "Zofia Plucińska",2020,04,29));
lstclients.Add(new client("5", "Grzegorz Braun",2015,07,12));

List<cars> lstcars = new List<cars>();
lstcars.Add(new cars("1", "Skoda Citigo", "mini", "benzyna", 70, "dostępny"));
lstcars.Add(new cars("2", "Toyota Aygo", "mini", "benzyna", 90m, "dostępny"));
lstcars.Add(new cars("3", "Fiat 500", "mini", "elektryczny", 110m, "dostępny"));
lstcars.Add(new cars("4", "Ford Focus", "kompakt", "diesel", 160m, "dostępny"));
lstcars.Add(new cars("5", "Kia Ceed", "kompakt", "benzyna", 150m, "dostępny"));
lstcars.Add(new cars("6", "Volkswagen Golf", "kompakt", "benzyna", 160m, "dostępny"));
lstcars.Add(new cars("7", "Hyundai Kona Electric", "kompakt", "elektryczny", 180m, "dostępny"));
lstcars.Add(new cars("8", "Audi A6 Allroad", "premium", "diesel", 290m, "dostępny"));
lstcars.Add(new cars("9", "Mercedes E270 AMG", "premium", "benzyna", 320m, "dostępny"));
lstcars.Add(new cars("10", "Tesla Model S", "premium", "elektryczny", 350m, "dostępny"));


while (loop)
{
    
    string answer = welcome.welcome();
    if (answer == "1")
    {
        Console.Clear();
        Console.WriteLine("LISTA KLIENTÓW:");
        Console.WriteLine("---------------------------");
        Console.WriteLine("---------------------------");
        Console.WriteLine("Id | Imię i nazwisko | Data wydania prawa jazdy");
        foreach (var client in lstclients) 
        {
            var helpDate = new DateTime(client.Year, client.Month, client.Day);
            var finnaldate = helpDate.ToShortDateString();
            Console.WriteLine($"{client.Id} {client.Name} {finnaldate}");
        }
        Console.WriteLine("                ");
        Console.WriteLine("LISTA SAMOCHODÓW:");
        Console.WriteLine("---------------------------");
        Console.WriteLine("---------------------------");
        Console.WriteLine("Id | Model | Segment | Rodzaj paliwa | Cena za dobę");
        foreach (var cars in lstcars)
        {
            Console.WriteLine($"{cars.Id} | {cars.Marka} | {cars.segment} | {cars.fueltype} | {cars.priceforaday} | {cars.status}");
        }



    }
    if (answer == "2")
    {
        Console.Clear();
        Console.Write("PROSZĘ PODAĆ ID KLIENTA, KTÓRY WYPOŻYCZA SAMOCHÓD: ");
        String readid = Console.ReadLine();
        Console.Clear();
        Console.WriteLine("1. mini");
        Console.WriteLine("2. kompakt");
        Console.Write("PODAJ SEGMENT SAMOCHODU: ");
        String readsegment = Console.ReadLine();
        Console.Clear();
        Console.WriteLine("1. benzyna");
        Console.WriteLine("2. elekryczny");
        Console.WriteLine("3. diesel");
        Console.Write("PODAJ PREFEROWANY RODZAJ PALIWA:");
        String readfueal = Console.ReadLine();
        Console.Clear();
        Console.WriteLine("PODAJ ILOŚĆ DNI WYNAJMU POJAZDU:");
        String readtime = Console.ReadLine();
        if (lstclients.Exists(x => x.Id == readid))
        {
            string Segment = "";
            switch (readsegment)
            {
                case "1":
                    Segment = "mini";
                    break;
                case "2":
                    Segment = "kompakt";
                    break;
            }
            string Fuel = "";

            switch (readfueal)
            {
                case "1":
                    Fuel = "benzyna";
                    break;
                case "2":
                    Fuel = "elektryczny";
                    break;
                case "3":
                    Fuel = "diesel";
                    break;
            }
            var firstStep = lstcars.Where(q => q.segment == Segment).ToList();
            var secoundStep = firstStep.Where(q => q.fueltype == Fuel).ToList();
            var torent = secoundStep.Where(q => q.status == "dostępny").ToList();
            var clientwyn = lstclients.Where(q => q.Id == readid).ToList();
            int ile = 0;
            ile = torent.Count();
            if ((ile > 0) && (int.TryParse(readtime, out int timerent)))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("UMOWA WYNAJMU POJAZDU");
                var now = DateTime.Now;
                var todayAsString = now.ToShortDateString();
                Console.WriteLine($"DATA ZAWARCIA: {todayAsString}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("-----------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"WYNAJMUJĄCY: {clientwyn[0].Name}");
                Console.WriteLine($"RODZAJ POJAZDU: {torent[0].Marka}");
                Console.WriteLine($"RODZAJ PALIWA: {torent[0].fueltype}");
                Console.WriteLine($"SEGMENT: {torent[0].segment}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("-----------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                var dooddania = now.AddDays(timerent);
                Console.WriteLine($"DATA ZWROTU POJAZDU: {dooddania}");
                decimal opłata = timerent * torent[0].priceforaday;
                Console.WriteLine($"OPŁATA: {opłata} PLN");
                var indexcar = lstcars.FindIndex(c => c.Marka == torent[0].Marka);
                lstcars[indexcar].status = "zajęty";
                Console.ForegroundColor = ConsoleColor.White;
            }

        }
        else
        {
            Console.WriteLine("client nie istnieje");
        }

    }
    if (answer == "3")
    {
        break;
    }
}
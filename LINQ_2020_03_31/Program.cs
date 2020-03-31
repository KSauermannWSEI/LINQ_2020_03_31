using LINQ_2020_03_31.Data;
using LINQ_2020_03_31.Models;
using LINQ_2020_03_31.Models.WW;
using LINQ_2020_03_31.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LINQ_2020_03_31
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello LINQ World!");
            Console.WriteLine();

            //display(new List<int> { 1, 2, 46, 7, 8 });
            //int name = 2;
            //name.ToString();

            InMemory db = new InMemory();

            //display(query.ToList());
            //query.First();
            //query.Last();

            //string x = "abcdefgh";
            //var left = x.Left(2);
            //Console.WriteLine(left);

            //Action<string> line = (l) => Console.WriteLine(l);
            //line(x);

            //Func<int, int> square = a => a * a;
            //Console.WriteLine(square(4));      
            //Console.WriteLine(square(5));  

            //var query = from person in db.People
            //            where person.Id < 5
            //            select new PersonAge
            //            { 
            //               Name = $"{person.Name} {person.LastName}",
            //               Age = DateTime.Now.Year - person.BirthDate.Year
            //            };

            //var query2 = db.People
            //            .Where(person => person.Id < 6 || person.BirthDate.Year > 1999);
            //.Where(Person => Person.BirthDate.Year > 1999);

            //display(query2.ToList());
            //db.People.Clear();

            //var areThereAny = db.People.Any(p => p.BirthDate.Year > 2000);
            //var areThereAnyWhere = db.People.Where(p => p.BirthDate.Year > 2000).Count() > 0;
            //Console.WriteLine(areThereAny);

            //var areThereAll = db.People.All(p => p.Name.Length >= 6);
            //Console.WriteLine(areThereAll);

            //List<string> nameList = db.People.Select(p => p.Name).ToList();
            ////display(nameList);
            ////var isNameLukas = nameList.Contains("Łukasz");
            //var isNameLukas = nameList.Any(x => x == "Łukasz");
            //Console.WriteLine(isNameLukas);

            //var query = from p in db.People
            //            where p.BirthDate.Year > 2000
            //            group p by new { p.BirthDate.Year } into g
            //            where g.Count() > 1
            //            select new { g.Key.Year, Count = g.Count() };
            //display(query.ToList());

            //var queryM = db.People.GroupBy(p => p.BirthDate.Year)
            //                            .Select(g => new { Year = g.Key, Count = g.Count() });
            //display(queryM.ToList());

            //Context context = new Context();
            //db.Cities.ForEach(c => context.Cities.Add(new City { CityName = c.CityName }));
            //context.SaveChanges();

            //db.People.ForEach(p => 
            //{
            //    p.Id = 0;
            //    p.City = context.Cities.First();
            //});
            //context.People.AddRange(db.People);
            //context.SaveChanges();

            //var query = context.People.ToList();
            //display(query);
            //Console.WriteLine("OK");

            ////var joinQuery = from p in context.People
            ////                join c in context.Cities
            ////                on p.City.Id equals c.Id into pc
            ////                from c in pc.DefaultIfEmpty()
            ////                select new { p.LastName, c.CityName };
            //display(joinQuery.ToList());
            WWContext context = new WWContext();
            var x = context.Orders.ToList();

            Stopwatch stopwatch = new Stopwatch();
            IQueryable<OrderLines> iq = context.OrderLines;
            stopwatch.Start();
            var result = iq.Where(a => a.PickingCompletedWhen > new DateTime(2013, 1, 1)).Take(10).ToList();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);

            Stopwatch stopwatch1 = new Stopwatch();
            IEnumerable<OrderLines> ie = context.OrderLines;
            stopwatch1.Start();
            var result1 = ie.AsQueryable().Where(a => a.PickingCompletedWhen > new DateTime(2013, 1, 1)).Take(10).ToList();
            stopwatch1.Stop();
            Console.WriteLine(stopwatch1.ElapsedMilliseconds);
        }

        #region helpers
        static void display<T>(List<T> list)
        {
            list.ForEach(obj =>
            {
                if (obj is String || obj is ValueType)
                    Console.Write($"{obj} ");
                else
                    obj.GetType().GetProperties().ToList().
                        ForEach(prop => Console.Write($"[{prop.Name}]: {prop.GetValue(obj)} "));
                Console.WriteLine();
            });
        }
        #endregion
    }
}

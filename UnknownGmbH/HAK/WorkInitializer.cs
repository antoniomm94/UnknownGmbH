using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using UnknownGmbH.Models;

namespace UnknownGmbH.HAK
{
	public class WorkInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<WorkContext>
	{

		protected override void Seed(WorkContext context)
		{
			var neuerechnungs = new List<NeueRechnung>
			{
			new NeueRechnung{Klient="Antonio Matan", FirmenName="Finanzamt", Adresse="Merkel Str. 17", Email="antoniom@gmail.com", PLZ=70382, Stadt="Stuttgart", Land="Germany", Datum=DateTime.Parse("1991-12-01"), Artikel="Car", Menge=1, ZahlenBis=DateTime.Parse("2021-04-08")},
			new NeueRechnung{Klient="Jack Nicholson", FirmenName="Damler AG", Adresse="Markhirch Str. 20", Email="jack@gmail.com", PLZ=80385, Stadt="Sydney", Land="Australien", Datum=DateTime.Parse("1978-07-03"), Artikel="House", Menge=1, ZahlenBis=DateTime.Parse("2021-05-08")},
			new NeueRechnung{Klient="John Sekec", FirmenName="HandwerkGmbH", Adresse="Gasteiner Str. 128a", Email="sekec@handwer.de", PLZ=70324, Stadt="Heidelberg", Land="Germany", Datum=DateTime.Parse("1990-05-05"), Artikel="Chips", Menge=4, ZahlenBis=DateTime.Parse("2021-02-04")},
			new NeueRechnung{Klient="Sarah Sprecher", FirmenName="Blaue GmbH", Adresse="Markhansen Str. 228", Email="BlaueGmbH@gmail.com", PLZ=60382, Stadt="Ottawa", Land="Japan", Datum=DateTime.Parse("1995-12-12"), Artikel="IceCream", Menge=5, ZahlenBis=DateTime.Parse("2021-08-03")},
			new NeueRechnung{Klient="Sebastian Hahn", FirmenName="ArbeitGmbH", Adresse="Goethe Str. 128", Email="hahnsebastian@gmail.com", PLZ=20352, Stadt="Zagreb", Land="Croatia", Datum=DateTime.Parse("1969-03-01"), Artikel="Chocolade", Menge=6, ZahlenBis=DateTime.Parse("2021-11-06")},
			new NeueRechnung{Klient="Hulk Hogan", FirmenName="StarkG", Adresse="Hehrenstein Str. 99b", Email="iyijoj@gmail.com", PLZ=10782, Stadt="New York", Land="USA", Datum=DateTime.Parse("1983-03-08"), Artikel="Kopfhörer", Menge=2, ZahlenBis=DateTime.Parse("2021-12-12")},
			new NeueRechnung{Klient="Leonardo Di Caprio", FirmenName="HolidaysGmbH", Adresse="Moningeh Str. 1", Email="titanic@gmail.com", PLZ=60202, Stadt="Freiburg", Land="Germany", Datum=DateTime.Parse("1995-12-04"), Artikel="Boat", Menge=1, ZahlenBis=DateTime.Parse("2021-09-08")}
			};

			neuerechnungs.ForEach(s => context.NeueRechnungs.Add(s));
			context.SaveChanges();

		}
	}
}
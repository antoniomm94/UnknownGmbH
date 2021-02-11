using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace UnknownGmbH.Models
{
	public enum Währung
	{
		EURO,
		KRO
	}
	public enum Steuer
	{
		DE,
		KRO
	}
	public enum ZahlungsMethode
	{
		PayPal,
		KreditKarte,
		SofortÜberweisung
	}

	public class NeueRechnung
	{
		public int ID { get; set; }
		[Required]
		[StringLength(50, MinimumLength = 3,
		ErrorMessage = "Der Klient muss mindestens 3 und maximal 30 Buchstaben enthalten")]
		public string Klient { get; set; }
		[Required]
		[StringLength(50, MinimumLength = 3,
		ErrorMessage = "FirmenName muss mindestens 3 und maximal 30 Buchstaben enthalten")]
		public string FirmenName { get; set; }
		[Required]
		public string Adresse { get; set; }
		[EmailAddress]
		public string Email { get; set; }
		public int PLZ { get; set; }
		[Required]
		public string Stadt { get; set; }
		[Required]
		public string Land { get; set; }
		public DateTime Datum { get; set; }

		public Währung? Währung { get; set; }
		public Steuer? Steuer { get; set; }
		public ZahlungsMethode? ZahlungsMethode { get; set; }

		[Required]
		public string Artikel { get; set; }
		public int Menge { get; set; }
		public DateTime ZahlenBis { get; set; }

		public decimal NettoPreis { get; set; }
		public decimal BruttoPreis { get; set; }
		public decimal Gesamt { get; set; }

		
		public virtual AusgestellteRechnung AusgestellteRechnung { get; set; }
	}
}
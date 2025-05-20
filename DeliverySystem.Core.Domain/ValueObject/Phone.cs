using DeliverySystem.Core.Domain.Utils;
using System.Text.RegularExpressions;

namespace DeliverySystem.Core.Domain.ValueObject
{
	public class Phone
	{
		public DisplayValue Number { get; private set; }
		public Phone(string value)
		{
			Number = Validate(value);
		}

		private DisplayValue Validate(string value)
		{
			if (!string.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentException("Numero não pode ser vazio.");
			}

			var clearnumber = Regex.Replace(value, @"[^\d]", "");

			if (clearnumber.Length < 10 || clearnumber.Length > 11)
			{
				throw new ArgumentException("Número inválido. Deve conter 10 ou 11 dígitos (com DDD).");
			}

			var ddd = clearnumber.Substring(0, 2);

			if (!ValidarDDD(ddd))
			{
				throw new ArgumentException("DDD inválido.");
			}
			return new DisplayValue(clearnumber,
			clearnumber.Length == 11 ?
			($"({clearnumber.Substring(0, 2)}) {clearnumber.Substring(2, 1)}" + $"{clearnumber.Substring(3, 4)}-{clearnumber.Substring(7)}") :
			($"({clearnumber.Substring(0, 2)}) {clearnumber.Substring(2, 4)}-{clearnumber.Substring(6)}")
			);
		}
		private static bool ValidarDDD(string ddd)
		{
			string[] dddsValidos = {
				"11", "12", "13", "14", "15", "16", "17", "18", "19",
			"21", "22", "24", "27", "28", "31", "32", "33", "34",
			"35", "37", "38", "41", "42", "43", "44", "45", "46",
			"47", "48", "49", "51", "53", "54", "55", "61", "62",
			"63", "64", "65", "66", "67", "68", "69", "71", "73",
			"74", "75", "77", "79", "81", "82", "83", "84", "85",
			"86", "87", "88", "89", "91", "92", "93", "94", "95",
			"96", "97", "98", "99"
		};

			return dddsValidos.Contains(ddd);
		}


		public override string ToString()
		{
			return Number.Display;
		}
	}
}

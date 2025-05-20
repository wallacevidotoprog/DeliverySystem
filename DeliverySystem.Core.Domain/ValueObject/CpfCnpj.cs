using DeliverySystem.Core.Domain.Enum;
using DeliverySystem.Core.Domain.Interfaces;
using DeliverySystem.Core.Domain.Utils;
using System.Text.RegularExpressions;

namespace DeliverySystem.Core.Domain.ValueObject
{
	public class CpfCnpj 
	{
		public DisplayValue Number { get; private set; }
		public CpfOrCnpj Indentifier { get; private set; }


		public CpfCnpj(string value)
		{
			Number = Validate(value);
		}

		private DisplayValue Validate(string value)
		{
			if (!string.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentException("Indentificador não pode ser vazio.");
			}

			var clearnumber = Regex.Replace(value, @"[^\d]", "");


			if (clearnumber.Length == 11)
			{
				Indentifier = CpfOrCnpj.CPF;

				return new DisplayValue(clearnumber, Convert.ToUInt64(clearnumber).ToString(@"000\.000\.000\-00"));
			}

			if (clearnumber.Length == 14)
			{
				Indentifier = CpfOrCnpj.CNPJ;

				return new DisplayValue(clearnumber, Convert.ToUInt64(clearnumber).ToString(@"00\.000\.000\/0000\-00"));
			}


			throw new ArgumentException("Indentificador não válido.");
		}

		public override string ToString()
		{
			return Number.Value.ToString();
		}

	}
}

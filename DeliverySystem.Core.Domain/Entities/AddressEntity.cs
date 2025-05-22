using DeliverySystem.Core.Domain.Enum;
using DeliverySystem.Core.Domain.Utils;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DeliverySystem.Core.Domain.Entities
{
	public class AddressEntity
	{
		[Required(ErrorMessage = "Logradouro é obrigatório")]
		[StringLength(100, ErrorMessage = "Logradouro não pode exceder 100 caracteres")]
		public string Street { get; private set; }

		[Required(ErrorMessage = "Número é obrigatório")]
		[StringLength(20, ErrorMessage = "Número não pode exceder 20 caracteres")]
		public string Number { get; private set; }

		[StringLength(50, ErrorMessage = "Complemento não pode exceder 50 caracteres")]
		public string Complement { get; private set; }

		[Required(ErrorMessage = "Bairro é obrigatório")]
		[StringLength(50, ErrorMessage = "Bairro não pode exceder 50 caracteres")]
		public string Neighborhood { get; private set; }

		[Required(ErrorMessage = "Cidade é obrigatório")]
		[StringLength(50, ErrorMessage = "Cidade não pode exceder 50 caracteres")]
		public string City { get; private set; }

		[Required(ErrorMessage = "Estado é obrigatório")]
		[StringLength(2, MinimumLength = 2, ErrorMessage = "UF deve ter 2 caracteres")]
		public BrazilianState State { get; private set; }

		[Required(ErrorMessage = "CEP é obrigatório")]
		public DisplayValue PostalCode { get; private set; }

		[Required(ErrorMessage = "País é obrigatório")]
		public string Country { get; private set; } = "Brasil";


		public AddressEntity(string street, string number, string city, BrazilianState state, string postalCode)
		{
			Street = street;
			Number = number;
			City = city;
			State = state;
			PostalCode = NormalizePostalCode(postalCode);
			Validate();
		}
		private DisplayValue NormalizePostalCode(string code)
		{
			if (string.IsNullOrWhiteSpace(code))
			{
				throw new ArgumentException("CEP não pode ser vazio");
			}
			string temp = Regex.Replace(code, "[^0-9]", "");

			if (temp.Length != 8)
			{
				throw new ArgumentException("CEP deve conter 8 dígitos");
			}
			return new DisplayValue(temp, temp.Insert(5, "-"));
		}
		private void Validate()
		{
			List<ValidationResult> validationResults = new List<ValidationResult>();
			ValidationContext validationContext = new ValidationContext(this);

			if (!Validator.TryValidateObject(this, validationContext, validationResults, true))
			{
				throw new ValidationException(validationResults.First().ErrorMessage);
			}

			if (PostalCode.Value is not string rawCep || !Regex.IsMatch(rawCep, "^[0-9]{8}$"))
			{
				throw new ValidationException("CEP inválido");
			}

		}
		public override string ToString()
		{
			return $"{Street}, {Number} {Complement} - {Neighborhood}, {City}/{State}, {PostalCode}, {Country}";
		}
	}
}

using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DeliverySystem.Core.Domain.ValueObject
{
	public class Email
	{
		[Required(ErrorMessage = " Email é obrigatório")]
		public string email { get; private set; }

		public Email(string email)
		{
			this.email = ValidateEmail(email);
		}

		private string ValidateEmail(string value)
		{
			if (!string.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentException("Email não pode ser vazio.");
			}
			string pattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
						@"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

			bool check = Regex.IsMatch(value, pattern, RegexOptions.IgnoreCase);

			if (!check)
			{
				throw new ArgumentException("Email não é valido.");
			}

			return value;
		}

		public override string ToString()
		{
			return email;
		}
	}
}

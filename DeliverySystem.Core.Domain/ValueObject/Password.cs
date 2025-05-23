using System.Text;

namespace DeliverySystem.Core.Domain.ValueObject
{
	public class Password
	{
		public string Pass { get; private set; }

		public Password(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				throw new ArgumentException("A senha não pode ser vazia.");
			}

			Pass = HashPassword(value);
		}


		private string HashPassword(string password)
		{
			using (var sha256 = System.Security.Cryptography.SHA256.Create())
			{
				var bytes = Encoding.UTF8.GetBytes(password);
				var hash = sha256.ComputeHash(bytes);
				return Convert.ToBase64String(hash);
			}
		}


		public override string ToString()
		{
			return Pass;
		}

	}
}

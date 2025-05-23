using DeliverySystem.Core.Domain.ValueObject;

namespace DeliverySystem.Core.Domain.Entities
{
	public class UserEntity : BaseEntity
	{
		public CpfCnpj Indentifier { get; private set; }
		public string Name { get; private set; }
		public Password Password { get; private set; }
		public AddressEntity Address { get; private set; }


		public UserEntity(CpfCnpj indentifier, string name, string password, AddressEntity address)
		{
			Indentifier = indentifier;
			Name = name ?? throw new ArgumentException("Nome é obrigatório");
			Password = new Password(password);
			Address = address;
		}
	}
}

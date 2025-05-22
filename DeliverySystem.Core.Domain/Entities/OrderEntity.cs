using DeliverySystem.Core.Domain.Enum;

namespace DeliverySystem.Core.Domain.Entities
{
	public class OrderEntity : BaseEntity
	{
		public ClientEntity Client { get; private set; }
		public StoreEntity Store { get; private set; }
		public decimal TotalValue { get; private set; }
		public OrderStatusEnum Status { get; private set; }
		public DateTime? DeliveredAt { get; private set; }


		public OrderEntity(ClientEntity client, StoreEntity store, decimal totalValue, OrderStatusEnum status = OrderStatusEnum.Created)
		{
			if (totalValue <= 0) throw new ArgumentException("Valor da entrega deve ser maior que zero");

			Client = client ?? throw new ArgumentNullException(nameof(client));
			Store = store ?? throw new ArgumentNullException(nameof(store));
			TotalValue = totalValue;
			Status = status;
		}

	}
}

using System;

namespace DeliverySystem.Core.Domain.Entities
{
	public abstract class BaseEntity
	{
		public Guid Id { get; private set; } = Guid.NewGuid();
		public DateTime CreateAt { get; private set; } = DateTime.UtcNow;
		public DateTime UpdateAt { get; private set; } = DateTime.UtcNow;


	}
}

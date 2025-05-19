﻿using DeliverySystem.Core.Domain.Entities;
using System.Linq.Expressions;

namespace DeliverySystem.Core.Domain.Interfaces
{
	public interface IRepository<T> where T : BaseEntity
	{
		Task<T> GetByIdAsync(Guid id);
		Task<IEnumerable<T>> GetAllAsync();
		Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
		Task<T> AddAsync(T entity);
		Task<T> UpdateAsync(T entity);
		Task<T> DeleteAsync(Guid id);
	}
}

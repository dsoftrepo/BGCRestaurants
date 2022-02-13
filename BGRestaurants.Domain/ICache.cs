using System;

namespace BGRestaurants.Domain
{
	public interface ICache<T>
	{
		public T GetOrCreate(object key, Func<T> createFunc);
		public void Update(object key, Func<T> updateFunc);
		public void Set(object key, T item);
		public T Get(object key);
	}
}

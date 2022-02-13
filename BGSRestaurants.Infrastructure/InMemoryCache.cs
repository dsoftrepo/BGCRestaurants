using System;
using System.Collections.Generic;
using BGRestaurants.Domain;

namespace BGSRestaurants.Infrastructure
{
	public class InMemoryCache<T> : ICache<T>
	{
		readonly Dictionary<object, T> _cache = new();

		public T GetOrCreate(object key, Func<T> createFunc)
		{
			if (!_cache.ContainsKey(key))
			{
				_cache.Add(key, createFunc());
			}
			return _cache[key];
		}

		public void Update(object key, Func<T> updateFunc)
		{
			if (!_cache.ContainsKey(key))
				_cache.Add(key, updateFunc());
			else
				_cache[key] = updateFunc();	
		}

		public void Set(object key, T item)
		{
			if (!_cache.ContainsKey(key))
				_cache.Add(key, item);
			else
				_cache[key] = item;	
		}

		public T Get(object key)
		{
			return _cache.TryGetValue(key, out T value) ? value : default;
		}
	}
}

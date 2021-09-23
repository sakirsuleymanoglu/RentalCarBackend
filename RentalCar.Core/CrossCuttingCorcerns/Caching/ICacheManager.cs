﻿namespace RentalCar.Core.CrossCuttingCorcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object data, int duration);
        bool isAdd(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);
    }
}

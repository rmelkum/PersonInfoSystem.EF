using System;

namespace PersonInfoSystem.Repositories;

public interface ICRUDRepository<T> where T : class
{
    T Add(T entity);
    List<T> GetAll();
    T? GetById(int id);
    void Update(T entity);
    bool DeleteById(int id);
}
 
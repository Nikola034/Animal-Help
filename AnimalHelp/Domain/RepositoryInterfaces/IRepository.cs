using System.Collections.Generic;

namespace AnimalHelp.Domain.RepositoryInterfaces;

public interface IRepository<T> where T : class
{
    public List<T> GetAll();
    public T? Get(string id);
    public List<T> Get(List<string> ids);
    public T Add(T item);
    public T? Update(string id, T item);    
    public void Delete(string id);
}
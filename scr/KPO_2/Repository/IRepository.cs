namespace KPO_2.Repository;

public interface IRepository<T>
{
    void Add(T entity);
    void Update(T entity);
    void Delete(Guid id);
    T? Get(Guid id);
    List<T> GetAll();
}
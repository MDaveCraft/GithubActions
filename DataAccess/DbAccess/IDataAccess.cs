namespace DataAccess;
public interface IDataAccess{
  Task<IEnumerable<T>> FetchAsync<T, U>(string procedure, U parameters, string connectionId = "Default");
  Task<int> ExecuteAysnc<T>(string procedure, T parameters, string connectionId = "Default");
}
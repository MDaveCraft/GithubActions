namespace DataAccess;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using Dapper;

public class SqlDataAccess: IDataAccess {
  private readonly IConfiguration _config;
  public SqlDataAccess(IConfiguration config) {
    _config = config;
  }
  public async Task<IEnumerable<T>> FetchAsync<T, U>(string procedure, U parameters, string connectionId = "Default") {
    try{
      using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
      return await connection.QueryAsync<T>(procedure, parameters, commandType: CommandType.StoredProcedure);
    } catch (Exception e) {
      throw new Exception("Error : " + e.Message);
    }
  }
  
  public async Task<int> ExecuteAysnc<T>(string procedure, T parameters, string connectionId = "Default") {
    try{
      using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
      return await connection.ExecuteAsync(procedure, parameters, commandType: CommandType.StoredProcedure);
    } catch(Exception e) {
      throw new Exception("Error : " + e.Message);
    }
  }

  public async Task<T?> FetchScalarAsync<T, U>(string procedure, U parameters, string connectionId = "Default") {
    try{
      using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
      return await connection.ExecuteScalarAsync<T>(procedure, parameters, commandType: CommandType.StoredProcedure);
    } catch (Exception e) {
      throw new Exception("Error : " + e.Message);
    }
  }
}

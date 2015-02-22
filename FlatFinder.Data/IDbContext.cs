using System.Collections.Generic;

namespace FlatFinder.Data
{
    public interface IDbContext : IBaseDbContext
    {
        /*IList<TResultSetType> ExecuteStoredProcedureListResultSetType<TResultSetType>(string commandText, params object[] parameters)
            where TResultSetType : class , new();

        IList<T> ExecuteStoredProcedure<T>(string commandText, int? timeout = null, params object[] parameters);

        int ExecuteStoredProcedure(string commandName, int? timeout = null, params object[] parameters);

        IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters);

        int ExecuteSqlCommand(string sql, int? timeout = null, params object[] parameters);*/
    }
}

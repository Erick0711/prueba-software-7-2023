using  Dapper;
using System.Data.SqlClient;

namespace backend.connection{
    public sealed class BDManager{

        private static readonly object lockObj = new();
        private static BDManager? instance;

        private BDManager(){

        }
        public static BDManager GetInstance{
            get
            {
                lock(lockObj)
                {
                    if(instance == null){
                        instance = new BDManager();
                    }
                }
                return instance;
            }
        }

        public string ConnectionString{ get; set;}

        public IEnumerable<T> GetData<T>(string sql){
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            DefaultTypeMap.MatchNamesWithUnderscores = true;
            return connection.Query<T>(sql);
        }

    }
}
//using Microsoft.Data.SqlClient;

//namespace CRUD.Services
//{
//    public class DatabaseServices
//    {
//        private readonly IConfiguration _iconfiguration;

//        public DatabaseServices(IConfiguration iconfiguration)
//        {
//            _iconfiguration = iconfiguration;
//        }

//        public SqlConnection GetConnection()
//        {
//            return new SqlConnection(_iconfiguration.GetConnectionString("DefaultConnection"));
//        }
//    }
//}

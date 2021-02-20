using API.Models;
using API.Repositories.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace API.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        DynamicParameters parameters = new DynamicParameters();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
        public int Create(Supplier supplier)
        {
            var SP_Name = "SP_InsertSupplier";

            parameters.Add("@name", supplier.NameSupplier);
            var Create = connection.Execute(SP_Name, parameters, commandType: CommandType.StoredProcedure);
            return Create;
        }

        public int Delete(int Id)
        {
            var SP_Name = "SP_DeleteSupplier";
            parameters.Add("@id", Id);
            var Delete = connection.Execute(SP_Name, parameters, commandType: CommandType.StoredProcedure);
            return Delete;
        }

        public IEnumerable<Supplier> Get()
        {

            var SP_Name = "SP_ReteriveSupplier";

            var GetAll = connection.Query<Supplier>(SP_Name, commandType: CommandType.StoredProcedure);

            return GetAll;

        }

        public async Task<IEnumerable<Supplier>> Get(int Id)
        {

            var SP_Name = "SP_ReteriveSupplierById";
            parameters.Add("@id", Id);
            var GetId = await connection.QueryAsync<Supplier>(SP_Name, parameters, commandType: CommandType.StoredProcedure);
            return GetId;
        }

        public int Update(Supplier supplier, int Id)
        {
            var SP_Name = "SP_UpdateSupplier";
            parameters.Add("@id", Id);
            parameters.Add("@name", supplier.NameSupplier);
            var Update = connection.Execute(SP_Name, parameters, commandType: CommandType.StoredProcedure);
            return Update;
        }
    }
}
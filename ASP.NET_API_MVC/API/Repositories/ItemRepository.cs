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
    public class ItemRepository : IItemRepository
    {
        DynamicParameters parameters = new DynamicParameters();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);
        public int Create(Item item)
        {
            var SP_Name = "SP_InsertItem";

            parameters.Add("@name", item.NameItem);
            parameters.Add("@quantity", item.Quantity);
            parameters.Add("@price", item.price);
            parameters.Add("@SupplierID", item.SupplierID);
            var Create = connection.Execute(SP_Name, parameters, commandType: CommandType.StoredProcedure);

            return Create;
        }

        public int Delete(int Id)
        {
            var SP_Name = "SP_DeleteItem";
            parameters.Add("@id", Id);
            var Delete = connection.Execute(SP_Name, parameters, commandType: CommandType.StoredProcedure);
            return Delete;
        }

        public IEnumerable<ViewModel> Get()
        {
            var SP_Name = "SP_ReteriveItem";
            var GetAll = connection.Query<ViewModel>(SP_Name, commandType: CommandType.StoredProcedure);
            return GetAll;
        }

        public async Task<IEnumerable<ViewModel>> Get(int Id)
        {
            var SP_Name = "SP_ReteriveItemById";
            parameters.Add("@id", Id);
            var GetId = await connection.QueryAsync<ViewModel>(SP_Name, parameters, commandType: CommandType.StoredProcedure);
            return GetId;
        }

        public int Update(Item item, int Id)
        {
            var SP_Name = "SP_UpdateItem";
            parameters.Add("@id", Id);
            parameters.Add("@name", item.NameItem);
            parameters.Add("@quantity", item.Quantity);
            parameters.Add("@price", item.price);
            parameters.Add("@SupplierID", item.SupplierID);
            var Update = connection.Execute(SP_Name, parameters, commandType: CommandType.StoredProcedure);
            return Update;
        }
    }
}
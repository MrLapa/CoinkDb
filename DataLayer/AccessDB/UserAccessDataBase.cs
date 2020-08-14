using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace DataLayer.AccessDB
{
    public class UserAccessDataBase
    {
        public static async Task<List<User>> GetUsersAsync(User user)
        {
            var userList = new List<User>();
            DataTable dtResult = await AccessDataBase.ExecuteProcedureQueryAsync("GetUsers", user, "User");
            foreach (DataRow row in dtResult.Rows)
            {
                User userForList = new User();
                userForList.Id = Convert.ToInt32(row["Id"]);
                userForList.Name = row["Name"].ToString();
                userForList.Phone = row["Phone"].ToString();
                userForList.Address = row["Address"].ToString();
                userForList.CityId = Convert.ToInt32(row["CityId"]);
                userForList.City = new City();
                userForList.City.Id = userForList.CityId;
                userForList.City.Name = row["CityName"].ToString();
                userForList.City.Department = new Department();
                userForList.City.Department.Id = Convert.ToInt32(row["DepartmentId"]);
                userForList.City.Department.Name = row["DepartmentName"].ToString();
                userForList.City.Department.Country = new Country();
                userForList.City.Department.Country.Id = Convert.ToInt32(row["CountryId"]);
                userForList.City.Department.Country.Name = row["CountryName"].ToString();
                userList.Add(userForList);
            }

            return userList;
        }

        public static async Task<int> AddUser(User user)
        {
            int lastId = await AccessDataBase.ExecuteProcedureInsertAsync("AddUser", user);
            return lastId;
        }
    }
}

using System.Collections.Generic;
using System.Data;
using Flight_Agency.model;
using log4net;

namespace Flight_Agency.repository
{
    public class EmployeeDBRepository: IEmployeeRepositoryInterface
    {
        private static readonly ILog log = LogManager.GetLogger("SortingTaskDbRepository");

        public EmployeeDBRepository()
        {
           log.Info("Creating EmployeeDBRepository");
        }

        public IEnumerable<Employee> FindAll()
        {
            
            IDbConnection con = DBUtils.getConnection();
            IList<Employee> employees = new List<Employee>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Employees";
                using (var dataR=comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        string username = dataR.GetString(0);
                        string password = dataR.GetString(1);
                        string name = dataR.GetString(2);
                        Employee employee = new Employee(password, name);
                        employee.ID = username;
                        employees.Add(employee);
                    }
                }
            }
            return employees;
        }

        public Employee Save(Employee entity)
        {
            log.Info("Entering save function...");
            var con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Employees values (@username, @password, @name)";

                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@username";
                paramId.Value = entity.ID;
                comm.Parameters.Add(paramId);
                
                var paramPass = comm.CreateParameter();
                paramPass.ParameterName = "@password";
                paramPass.Value = entity.ID;
                comm.Parameters.Add(paramPass);
                
                var paramName = comm.CreateParameter();
                paramName.ParameterName = "@name";
                paramName.Value = entity.ID;
                comm.Parameters.Add(paramName);
                
                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    System.Console.Write("No employee added!");
            }

            log.Info("Exiting save function");
            return entity;
        }
        
        public Employee Update(Employee entity)
        {
            throw new System.NotImplementedException();
        }

        public Employee findOne(string stringUser)
        {
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Employees where username=@username";
                var paramUser = comm.CreateParameter();
                paramUser.ParameterName = "@username";
                paramUser.Value = stringUser;
                comm.Parameters.Add(paramUser);
                
                using (var dataR=comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        string username = dataR.GetString(0);
                        string password = dataR.GetString(1);
                        string name = dataR.GetString(2);
                        Employee employee = new Employee(password, name);
                        employee.ID = username;
                        return employee;
                    }
                }
            }
            return null;
        }
    }
}
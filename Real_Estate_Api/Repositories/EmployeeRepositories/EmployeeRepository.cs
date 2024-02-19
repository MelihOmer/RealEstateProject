using Dapper;
using Real_Estate_Api.Dtos.EmployeeDtos;
using Real_Estate_Api.Models.DapperContext;

namespace Real_Estate_Api.Repositories.EmployeeRepositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateEmployeeAsync(CreateEmployeeDto createEmployeeDto)
        {
            string query = "insert into Employee (Name,Title,Mail,PhoneNumber,ImageUrl,Status) values " +
                "(@empName,@empTitle,@empMail,@empPhoneNumber,@empImageUrl,@empStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@empName", createEmployeeDto.Name);
            parameters.Add("@empTitle", createEmployeeDto.Title);
            parameters.Add("@empMail", createEmployeeDto.Mail);
            parameters.Add("@empPhoneNumber", createEmployeeDto.PhoneNumber);
            parameters.Add("@empImageUrl", createEmployeeDto.ImageUrl);
            parameters.Add("@empStatus", true);
            using (var connection = _context.CreateConnection())
            {
                var execute = await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            string query = "delete from Employee where Id=@empId";
            var parameters = new DynamicParameters();
            parameters.Add("@empId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultEmployeeDto>> GetAllEmployeeAsync()
        {
            string query = "select * from Employee";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEmployeeDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdEmployeeDto> GetEmployeeByIdAsync(int id)
        {
            string query = "select * from Employee where Id=@empId";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@empId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdEmployeeDto>(query, parameters);
                return values;
            }
        }

        public async Task UpdateEmployeeAsync(UpdateEmployeeDto updateEmployeeDto)
        {
            string query = "update Employee set Name=@empName,Title = @empTitle,Mail = @empMail,PhoneNumber =@empPhoneNumber,ImageUrl = @empImageUrl,Status = @empStatus where Id = @empId";
            var parameters = new DynamicParameters();
            parameters.Add("@empName", updateEmployeeDto.Name);
            parameters.Add("@empTitle", updateEmployeeDto.Title);
            parameters.Add("@empMail", updateEmployeeDto.Mail);
            parameters.Add("@empPhoneNumber", updateEmployeeDto.PhoneNumber);
            parameters.Add("@empImageUrl", updateEmployeeDto.ImageUrl);
            parameters.Add("@empId", updateEmployeeDto.Id);
            parameters.Add("@empStatus", true);
            using (var connection = _context.CreateConnection())
            {
                var execute = await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}

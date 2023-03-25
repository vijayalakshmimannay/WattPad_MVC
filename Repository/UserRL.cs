using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WattPad.Models;

namespace WattPad.Repository
{
    public class UserRL : IUserRL
    {
        string dbpath = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WattPad;Integrated Security=True";

        SqlConnection sqlConnection;

        public UserRL(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        

        public UserModel AddUser(UserModel user)
        {
            try
            {
                sqlConnection = new SqlConnection(dbpath);
                SqlCommand command = new SqlCommand("Watt_AddUser", sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;


                sqlConnection.Open();

                // command.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@RoleId", user.Role);
                command.ExecuteNonQuery();
                return user;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public string UserLogin(LoginModel loginModel)
        {
            sqlConnection = new SqlConnection(dbpath);
            using (sqlConnection)
            {
                try
                {
                    SqlCommand command = new SqlCommand("Watt_Login", sqlConnection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    sqlConnection.Open();
                    command.Parameters.AddWithValue("@Email", loginModel.Email);
                    command.Parameters.AddWithValue("@Password", loginModel.Password);

                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        string query = "SELECT UserId FROM tbl_Reg WHERE Email = '" + result + "'";
                        SqlCommand cmd = new SqlCommand(query, sqlConnection);
                        var UserId = cmd.ExecuteScalar();
                        var token = GenerateSecurityToken(loginModel.Email, UserId.ToString());
                        return token;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }

            }
        }



        private string GenerateSecurityToken(string Email, string UserId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim(ClaimTypes.Role,"User"),
                new Claim(ClaimTypes.Email,Email),
              //  new Claim("EmployeeId",EmployeeId.ToString())
                new Claim(ClaimTypes.NameIdentifier, UserId.ToString())
            };

            var token = new JwtSecurityToken(Configuration["JWT:key"],
              Configuration["JWT:key"],
              claims,
              expires: DateTime.Now.AddMinutes(60),
              signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}

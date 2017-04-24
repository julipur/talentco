using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TalentConnect.UI.Infrastructure.Context;

namespace TalentConnect.UI.Domain.Queries
{
    public class GetJobsDto
    {
        public IEnumerable<GetJobDto> Jobs { get; set; }
    }
    public class GetJobs
    {
            private string _sqlCommand = @"SELECT * FROM Jobs";


        public string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["TalentConnect"].ToString();
            }
        }

        public IEnumerable<GetJobDto> ExecuteQuery()
        {
            var list = new List<GetJobDto>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(_sqlCommand))
                {
                    connection.Open();
                    command.Connection = connection;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                list.Add(new GetJobDto()
                                {
                                    Id = reader.GetInt32(0),
                                    Title = reader.GetString(1),
                                    Description = reader.GetString(2),
                                    City = reader.GetString(4),
                                    Province = reader.GetString(5),
                                    JobType = reader.GetInt32(6).ToString(),
                                    YearsOfExperience = reader.GetInt32(7),
                                    ClosingDate = reader.GetDateTime(8),
                                    Hours = reader.GetInt32(9),
                                    Rate = reader.GetString(10),
                                    Filled = reader.GetBoolean(11),
                                    Active = reader.GetBoolean(12),
                                    CreatedDate = reader.GetDateTime(13)
                                });
                            }
                        }
                    }
                }
            }

            return list;
        }
    }
}
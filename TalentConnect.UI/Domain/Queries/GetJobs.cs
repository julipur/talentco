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
        private string _sqlCommand = @"SELECT 
                                    Id
                                    ,Title
                                    ,Description
                                    ,City
                                    ,Province
                                    ,JobType
                                    ,YearsOfExperience
                                    ,ClosingDate
                                    ,Hours
                                    ,Rate
                                    ,Filled
                                    ,Active
                                    ,CreatedDate FROM Jobs";


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
                        if (reader != null && reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                list.Add(new GetJobDto()
                                {
                                    Id = reader.GetInt32(0),
                                    Title = reader.GetString(1),
                                    Description = reader.GetString(2),
                                    City = reader.GetString(3),
                                    Province = reader.GetString(4),
                                    JobType = reader.GetString(5),
                                    YearsOfExperience = reader.GetInt32(6),
                                    ClosingDate = reader.GetDateTime(7),
                                    Hours = reader.GetInt32(8),
                                    Rate = reader.GetString(9),
                                    Filled = reader.GetBoolean(10),
                                    Active = reader.GetBoolean(11),
                                    CreatedDate = reader.GetDateTime(12)
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
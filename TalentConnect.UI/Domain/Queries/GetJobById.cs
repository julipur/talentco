using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TalentConnect.UI.Infrastructure.Context;

namespace TalentConnect.UI.Domain.Queries
{
    public class GetJobDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string JobType { get; set; }
        public int? YearsOfExperience { get; set; }
        public DateTime? ClosingDate { get; set; }
        public int? Hours { get; set; }
        public string Rate { get; set; }
        public bool Filled { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class GetJobById
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
                                    ,CreatedDate FROM Jobs
                                    WHERE Id = @Id";


        public string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["TalentConnect"].ToString();
            }
        }

        public GetJobDto ExecuteQuery(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(_sqlCommand))
                {
                    cmd.Parameters.Add(new SqlParameter("@Id", System.Data.SqlDbType.Int) { Value = id });
                    connection.Open();
                    cmd.Connection = connection;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null && reader.HasRows)
                        {
                            reader.Read();

                            return new GetJobDto()
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
                            };

                        }
                    }
                } 
            }
            return null;
        }
    }
}
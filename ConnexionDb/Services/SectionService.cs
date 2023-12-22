using ConnexionDb.Entities;
using ConnexionDb.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ConnexionDb.Services
{
    public class SectionService : ISectionRepository
    {
        private readonly string _connectionString;

        public SectionService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Delete(int sectionId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM section WHERE section_id = @SectionId";
                    command.Parameters.AddWithValue("SectionId", sectionId);

                    int rows = command.ExecuteNonQuery();
                    
                    return rows == 1;
                }
            }
        }

        public IEnumerable<Section> Get()
        {
            List<Section> sections = new List<Section>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT section_id, section_name, delegate_id FROM section;";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sections.Add(new Section()
                            {
                                SectionId = (int)reader["section_id"],
                                SectionName = (string)reader["section_name"],
                                DelegateId = reader["delegate_id"] as int? //Si le champs est nullable on utilise AS plutot que la conversion
                            });
                        }
                    }
                }
            }
            return sections;
        }

        public Section? Get(int sectionId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT section_id, section_name, delegate_id FROM section WHERE section_id = @SectionId;";
                    command.Parameters.AddWithValue("SectionId", sectionId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Section()
                            {
                                SectionId = (int)reader["section_id"],
                                SectionName = (string)reader["section_name"],
                                DelegateId = reader["delegate_id"] as int? //Si le champs est nullable on utilise AS plutot que la conversion
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public bool Insert(Section entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO section (section_id, section_name, delegate_id) VALUES (@Id, @Name, @DelegateId);";
                    command.Parameters.AddWithValue("Id", entity.SectionId);
                    command.Parameters.AddWithValue("Name", entity.SectionName);
                    command.Parameters.AddWithValue("DelegateId", (object?)entity.DelegateId ?? DBNull.Value);

                    int rows = command.ExecuteNonQuery();

                    return rows == 1;
                }
            }
        }

        public bool Update(Section entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE section SET section_name = @SectionName, delegate_id = @DelegateId WHERE section_id = @SectionId;";
                    command.Parameters.AddWithValue("SectionName", entity.SectionName);
                    command.Parameters.AddWithValue("DelegateId", (object?)entity.DelegateId ?? DBNull.Value);
                    command.Parameters.AddWithValue("SectionId", entity.SectionId);

                    int rows = command.ExecuteNonQuery();

                    return rows == 1;
                }
            }
        }
    }
}

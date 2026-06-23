using CRUD.Model;
using Microsoft.Data.SqlClient;

namespace CRUD.Services
{
    public class StudentServices
    {
        private readonly DatabaseServices _databaseServices;
        public StudentServices(DatabaseServices databaseServices)
        {
            _databaseServices = databaseServices;
        }

        public List<StudentOutputDTO> GetAllStudents()
        {
            List<StudentOutputDTO> students = new List<StudentOutputDTO>();
            using SqlConnection conn = _databaseServices.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                "Select * from student", conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                students.Add(new StudentOutputDTO
                {
                    Id = Convert.ToInt32(reader["id"]),
                    Name = reader["name"].ToString(),
                    Age = Convert.ToInt32(reader["age"]),
                    Grade = reader["grade"].ToString()
                });

            }
            return students;
        }

        public void AddStudent(StudentInputDTO input)
        {

            using SqlConnection conn = _databaseServices.GetConnection();
            conn.Open();
            string query = @"INSERT INTO Student(Name, Age, Grade)
                             VALUES(@Name, @Age, @Grade)";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", input.Name);
            cmd.Parameters.AddWithValue("@Age", input.Age);
            cmd.Parameters.AddWithValue("@Grade", input.Grade);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void UpdateStudent(StudentInputDTO input, int id)
        {
            using SqlConnection conn = _databaseServices.GetConnection();
            conn.Open();

            SqlCommand checkCmd = new SqlCommand(
                "SELECT COUNT(*) FROM student WHERE Id = @Id", conn);

            checkCmd.Parameters.AddWithValue("@Id", id);

            int count = (int)checkCmd.ExecuteScalar();

            if (count == 0)
            {
                conn.Close();
                throw new Exception("Student not found");
            }

            SqlCommand updateCmd = new SqlCommand(
                @"UPDATE Student
                SET Name = @Name,
                Age = @Age,
                Grade = @Grade
                WHERE Id = @Id", conn);

            updateCmd.Parameters.AddWithValue("@Id", id);
            updateCmd.Parameters.AddWithValue("@Name", input.Name);
            updateCmd.Parameters.AddWithValue("@Age", input.Age);
            updateCmd.Parameters.AddWithValue("@Grade", input.Grade);

            updateCmd.ExecuteNonQuery();

            conn.Close();

        }

        public void DeleteStudent(int id) {
            using SqlConnection conn = _databaseServices.GetConnection();
            conn.Open();
            SqlCommand isExist = new SqlCommand("SELECT COUNT(*) FROM student WHERE id = @id", conn);
            isExist.Parameters.AddWithValue("@id", id);
            int count = (int)isExist.ExecuteScalar();
            if (count == 0)
            {
                conn.Close();
                throw new Exception("Student not found");
            }
            string query = "DELETE FROM student WHERE id=@id";
        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}

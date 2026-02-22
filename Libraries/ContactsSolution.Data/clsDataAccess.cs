

using System;
using System.Data.SqlClient;

namespace ContactsSolution.Data
{
    public static class clsDataAccess
    {
        public static bool GetContactInfoByID(int contactId, ref string firstName, ref string lastName, ref string email, ref string phoneNumber, ref string address, ref DateTime dateOfBirth, ref int countryId, ref string imagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string queryText = "SELECT * FROM Contacts WHERE ContactID = @ContactID";

            SqlCommand command = new SqlCommand(queryText, connection);

            command.Parameters.AddWithValue("@ContactID", contactId);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    firstName = reader["FirstName"].ToString();
                    lastName = reader["LastName"].ToString();
                    email = reader["Email"].ToString();
                    phoneNumber = reader["Phone"].ToString();
                    address = reader["Address"].ToString();
                    dateOfBirth = (DateTime)reader["DateOfBirth"];
                    countryId = (int)reader["CountryID"];
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        imagePath = reader["ImagePath"].ToString();
                    }
                    else
                    {
                        imagePath = string.Empty;
                    }
                    isFound = true;
                }
                reader.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine("An error occurred: " + ex.ToString());
            }
            finally
            {
                connection.Close();

            }
            return isFound;
        }


        public static int Create(string firstName, string lastName, string email, string phoneNumber, string address, DateTime dateOfBirth, int countryId, string imagePath)
        {
            int contactId = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string queryText = "INSERT INTO Contacts (FirstName, LastName, Email, Phone, Address, DateOfBirth, CountryID, ImagePath) " +
                                "VALUES (@FirstName, @LastName, @Email, @Phone, @Address, @DateOfBirth, @CountryID, @ImagePath); " +
                                "SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(queryText, connection);
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Phone", phoneNumber);
            command.Parameters.AddWithValue("@Address", address);
            command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
            command.Parameters.AddWithValue("@CountryID", countryId);
            command.Parameters.AddWithValue("@ImagePath", imagePath);
            try
            {
                connection.Open();
                contactId = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return contactId;
        }

        public static bool Update(int contactID,string firstName, string lastName, string email, string phoneNumber, string address, DateTime dateOfBirth, int countryId, string imagePath)
        {
            bool isUpdated = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);



            string queryText = "UPDATE Contacts SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone, Address = @Address, DateOfBirth = @DateOfBirth, CountryID = @CountryID, ImagePath = @ImagePath WHERE ContactID = @ContactID";
            SqlCommand command = new SqlCommand(queryText, connection);
            command.Parameters.AddWithValue("@ContactID", contactID);
            command.Parameters.AddWithValue("@FirstName", firstName);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Phone", phoneNumber);
            command.Parameters.AddWithValue("@Address", address);
            command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
            command.Parameters.AddWithValue("@CountryID", countryId);
            command.Parameters.AddWithValue("@ImagePath", imagePath);


            try
            {
                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    isUpdated = true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                connection.Close();
            }

            return isUpdated;
        }



        public static bool Delete(int id)
        {
            bool isDeleted = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string queryText = "DELETE FROM Contacts WHERE ContactID = @ContactID";

            SqlCommand command = new SqlCommand(queryText, connection);
            command.Parameters.AddWithValue("@ContactID", id);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    isDeleted = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                connection.Close();
            }

            return isDeleted;
        }
    }
}

using Microsoft.IdentityModel.Protocols;
using SportsProyect.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsProyect
{
    public class SportsClass
    {


        string CnnSrtingSP = ConfigurationManager.AppSettings["ConnectionSport"];  // config para la conexion// config para la conexion
        public List<ModelSport> GetCategories()
        {

            List<ModelSport> categoriesList = new List<ModelSport>(); // objetivo p/ llenar y retornar
            try
            {
                using (SqlConnection newConnection = new SqlConnection(CnnSrtingSP))
                {
                    newConnection.Open(); // abrir conexion con el Obj creado
                    if (newConnection.State == ConnectionState.Open)
                    {
                        SqlCommand commandWithSqL = new SqlCommand("SP_GetCategories", newConnection);
                        commandWithSqL.Parameters.Add("@IdCategory", SqlDbType.Int).Value = null;

                        commandWithSqL.CommandType = CommandType.StoredProcedure;  // tipo de transac a ejecutar
                        SqlDataReader CommSqlResult = commandWithSqL.ExecuteReader();
                        while (CommSqlResult.Read())
                        {
                            ModelSport objCategory = new ModelSport();
                            objCategory.Id = (int)CommSqlResult[0];
                            objCategory.Name = CommSqlResult[1].ToString();

                            categoriesList.Add(objCategory);
                        }
                    }
                }

            }
            catch (Exception e)
            {

                Console.WriteLine("no se pudo realizar la conexion" + e.Message);
            }

            return categoriesList;
        }


        public List<TeamModel> GetTeams()
        {
            List<TeamModel> teamsList = new List<TeamModel>(); // objetivo p/ llenar y retornar
            try
            {
                using (SqlConnection newConnection = new SqlConnection(CnnSrtingSP))
                {
                    newConnection.Open();
                    if (newConnection.State == ConnectionState.Open)
                    {
                        SqlCommand commandWithSqL = new SqlCommand("SP_TeamDetail", newConnection);
                        commandWithSqL.CommandType = CommandType.StoredProcedure;  // tipo de transac a ejecutar
                        SqlDataReader CommSqlResult = commandWithSqL.ExecuteReader();
                        while (CommSqlResult.Read())
                        {
                            TeamModel objTeam = new TeamModel();
                            objTeam.NameTime = CommSqlResult[0].ToString();
                            objTeam.PlayerNumber = (int)CommSqlResult[1];
                            objTeam.AwardsWon = int.Parse(CommSqlResult[2].ToString());
                            objTeam.FoundationDate = (DateTime)CommSqlResult[3];
                            objTeam.CountryName = CommSqlResult[4].ToString();
                            objTeam.SportName = CommSqlResult[5].ToString();
                            objTeam.CategoryName = CommSqlResult[6].ToString();

                            teamsList.Add(objTeam);
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("no se pudo realizar la conexion" + e.Message);
            }

            return teamsList;
        }


        public List<ModelSport> GetCountry()
        {
            List<ModelSport> countriesList = new List<ModelSport>();
            try
            {
                using (SqlConnection newConnection = new SqlConnection(CnnSrtingSP))
                {
                    newConnection.Open();
                    if (newConnection.State == ConnectionState.Open)
                    {
                        SqlCommand commandWithSqL = new SqlCommand("SP_GetCountry", newConnection);
                        commandWithSqL.Parameters.Add("@IdCountry", SqlDbType.Int).Value = null;
                        commandWithSqL.CommandType = CommandType.StoredProcedure;  // tipo de transac a ejecutar
                        SqlDataReader CommSqlResult = commandWithSqL.ExecuteReader();
                        while (CommSqlResult.Read())
                        {
                            ModelSport objCountry = new ModelSport();
                            objCountry.Id = (int)CommSqlResult[0];
                            objCountry.Name = CommSqlResult[1].ToString();

                            countriesList.Add(objCountry);
                        }

                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("no se pudo realizar la conexion" + e.Message);
            }

            return countriesList;
        }

        public List<ModelSport> GetSport()
        {
            List<ModelSport> SportList = new List<ModelSport>();
            try
            {
                using (SqlConnection newConnection = new SqlConnection(CnnSrtingSP))
                {
                    newConnection.Open();
                    if (newConnection.State == ConnectionState.Open)
                    {
                        SqlCommand commandWithSqL = new SqlCommand("SP_GetSports", newConnection);
                        commandWithSqL.Parameters.Add("@IdSport", SqlDbType.Int).Value = null;
                        commandWithSqL.CommandType = CommandType.StoredProcedure;  // tipo de transac a ejecutar
                        SqlDataReader CommSqlResult = commandWithSqL.ExecuteReader();
                        while (CommSqlResult.Read())
                        {
                            ModelSport objSport = new ModelSport();
                            objSport.Id = (int)CommSqlResult[0];
                            objSport.Name = CommSqlResult[1].ToString();

                            SportList.Add(objSport);
                        }

                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("no se pudo realizar la conexion" + e.Message);
            }

            return SportList;
        }


        public bool InsertTeams(string nameTeam , int playersNumber , int awardsWon , int idCategory , int idSport , int idCountry)
        {
            bool response = false;
            try
            {
                using (SqlConnection newConnection = new SqlConnection(CnnSrtingSP))
                {
                    newConnection.Open();
                    if (newConnection.State == ConnectionState.Open)
                    {
                        SqlCommand commandWithSqL = new SqlCommand("SP_InsertTeam", newConnection);
                        commandWithSqL.Parameters.Add("@NameTeam", SqlDbType.VarChar).Value = nameTeam;
                        commandWithSqL.Parameters.Add("@PlayersNumber", SqlDbType.Int).Value = playersNumber;
                        commandWithSqL.Parameters.Add("@AwardsWon", SqlDbType.Int).Value = awardsWon;
                        commandWithSqL.Parameters.Add("@IdCategory", SqlDbType.Int).Value = idCategory;
                        commandWithSqL.Parameters.Add("@IdSport", SqlDbType.Int).Value = idSport;
                        commandWithSqL.Parameters.Add("@IdCountry", SqlDbType.Int).Value = idCountry;
                        commandWithSqL.CommandType = CommandType.StoredProcedure;  // tipo de transac a ejecutar
                        int CommSqlResult = commandWithSqL.ExecuteNonQuery();
                        response = CommSqlResult == 1;
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine("no se pudo realizar la conexion" + e.Message);
            }
            return response;
        }

        public List<ModelBestTeam> GetBestTeam(int IdCountry)
        {
            List<ModelBestTeam> teamList = new List<ModelBestTeam>();
            try
            {
                using (SqlConnection newConnection = new SqlConnection(CnnSrtingSP))
                {
                    newConnection.Open();
                    if (newConnection.State == ConnectionState.Open)
                    {
                        SqlCommand commandWithSqL = new SqlCommand("SP_BestTeam", newConnection);
                        commandWithSqL.Parameters.Add("@IdCountry", SqlDbType.Int).Value = IdCountry;
                        commandWithSqL.CommandType = CommandType.StoredProcedure;  // tipo de transac a ejecutar
                        SqlDataReader CommSqlResult = commandWithSqL.ExecuteReader();
                        while (CommSqlResult.Read())
                        {
                            ModelBestTeam objBestTeam = new ModelBestTeam();
                            objBestTeam.NameTeam  = CommSqlResult[0].ToString();
                            objBestTeam.AwardsWon = (int)CommSqlResult[1];
                            objBestTeam.Name = CommSqlResult[2].ToString();

                            teamList.Add(objBestTeam);
                        }
                    }

                }

            }
            catch (Exception e)
            {

                Console.WriteLine("no se pudo realizar la conexion" + e.Message);
            }




            return teamList;
        }

    }
}

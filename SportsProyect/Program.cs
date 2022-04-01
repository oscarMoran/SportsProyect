using SportsProyect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsProyect
{
    class Program
    {
        static void Main(string[] args)
        {
            SportsClass objSportClas = new SportsClass();
            int answerUser;
            bool answerBool = false;
            bool respuesta = true;
            do
            {
                while (answerBool == false)
                {
                    Console.WriteLine("Elije la opcion que con la que desees interactuar:");
                    Console.WriteLine("1.-Consultar");
                    Console.WriteLine("2.-Registrar ");
                    string optionUser = (Console.ReadLine());
                    int.TryParse(optionUser, out answerUser);

                    switch (answerUser)
                    {
                        case 1:

                            List<ModelBestTeam> theBestTeam = objSportClas.GetBestTeam(1);
                            foreach (var team in theBestTeam)
                            {
                                Console.WriteLine($"{team.NameTeam},{team.AwardsWon},{team.Name}");
                            }

                            answerBool = true;
                            break;
                        case 2:

                            Console.WriteLine("\n****THESE ARE THE PARTICIPATING TEAMS*****\n");
                            Console.WriteLine("NameTeam||PlayerNumber||AwardsWon||CountryName||SportName||CountryName||FoundationName\n\n");


                            List<TeamModel> Teams = objSportClas.GetTeams();
                            foreach (var cat in Teams)
                            {
                                Console.WriteLine($"{cat.NameTime} | {cat.PlayerNumber} | {cat.AwardsWon} | {cat.CategoryName} | {cat.SportName} | {cat.CountryName}  | founded at {cat.FoundationDate:yyyy/MMMM} \n");

                            }

                            Console.WriteLine("*******REGISTER YOUR TEAM ********\n");
                            List<ModelSport> categories = objSportClas.GetCategories();
                            foreach (var cat in categories)
                            {
                                Console.WriteLine($"category:{cat.Id}, {cat.Name}");
                            }

                            int answerCategory = CategoryQuestion(categories);
                            List<ModelSport> countries = objSportClas.GetCountry();
                            foreach (var cou in countries)
                            {
                                Console.WriteLine($"{cou.Id}.- {cou.Name}");
                            }

                            int answerCountry = CountryQuestion(countries);



                            List<ModelSport> sports = objSportClas.GetSport();
                            foreach (var sprt in sports)
                            {
                                Console.WriteLine($"{sprt.Id}, {sprt.Name}");
                            }

                            int answerSport = SportQuestion(sports);

                            string nombreEquipo = NameTeamQuestion();

                            int answerPlayerNumber = NamePlayerNumber();

                            int answerAwardWon = AwardsWonQuestion();



                            bool insertResponse = objSportClas.InsertTeams(nombreEquipo, answerPlayerNumber, answerAwardWon, answerCategory, answerSport, answerCountry);
                            if (insertResponse)
                            {
                                List<TeamModel> objListUpdated = objSportClas.GetTeams();
                                foreach (var cat in objListUpdated)
                                {
                                    Console.WriteLine($"{cat.NameTime} | {cat.PlayerNumber} | {cat.AwardsWon} | {cat.CategoryName} | {cat.SportName} | {cat.CountryName}  | founded at {cat.FoundationDate:yyyy/MMMM} \n");

                                }
                                Console.WriteLine("Felicidades, tu equipo ha sido Agregado\n");
                            }
                            else
                            {
                                Console.WriteLine("Servicio no disponible, inténtelo mas tarde.");
                            }

                            answerBool = true;


                            break;

                        default:
                            Console.WriteLine("Caracter invalido");
                            break;


                    }


                }
                Console.WriteLine("Deseas intentarlo de nuevo? , ingresa la letra S para continuar, de lo contrario elige cualquier tecla:");
                string s = Console.ReadLine();
                if (s.ToLower() == "s")
                {
                    answerBool = false;
                }
                else
                {
                    Console.WriteLine("gRACIAS, A LA VERG");
                    respuesta = false;
                }


            } while (respuesta);







            Console.ReadKey();
        }

        public static int CategoryQuestion(List<ModelSport> categories)
        {
            int answerCategory = 0;
            bool answerBool = false;
            while (!answerBool)
            {

                Console.WriteLine("Elige un numero segun el genero de tu preferencia:");
                String elige = (Console.ReadLine());
                int.TryParse(elige, out answerCategory);
                answerBool = answerCategory > 0 && answerCategory <= categories.Count; // improve it
                if (!answerBool)
                {
                    Console.WriteLine("Caracter invalido");
                }

            }
            Console.Clear();


            return answerCategory;
        }

        public static int CountryQuestion(List<ModelSport> countries)
        {
            int answerCountry = 0;
            bool countryBool = false;
            while (!countryBool)
            {
                Console.WriteLine("\nAhora elige el numero segun el pais al que pertenece tu equipo:");
                string eligePais = (Console.ReadLine());

                int.TryParse(eligePais, out answerCountry);
                countryBool = answerCountry > 0 && answerCountry <= countries.Count;
                if (!countryBool)
                {
                    Console.WriteLine("Caracter invalido");
                }
            }

            Console.Clear();


            return answerCountry;
        }

        public static int SportQuestion(List<ModelSport> sports)
        {
            int answerSport = 0;
            bool SportBool = false;
            while (!SportBool)
            {
                Console.WriteLine("\nA continuacion elige el deporte de tu preferencia\n\n");
                string eligeDeporte = (Console.ReadLine());

                int.TryParse(eligeDeporte, out answerSport);
                SportBool = answerSport > 0 && answerSport <= sports.Count;
                if (!SportBool)
                {
                    Console.WriteLine("Caracter invalido");
                }

            }
            Console.Clear();


            return answerSport;
        }

        public static string NameTeamQuestion()
        {
            String nombreEquipo = null;
            bool NameSprtBool = false;
            while (!NameSprtBool)
            {
                Console.WriteLine("Ingresa El Nombre de tu Equipo:");
                nombreEquipo = (Console.ReadLine());
                NameSprtBool = !string.IsNullOrEmpty(nombreEquipo);// (nombreEquipo != null);
                if (!NameSprtBool)
                {
                    Console.WriteLine("Caracter invalido");
                }

            }
            Console.Clear();


            return nombreEquipo;
        }

        public static int NamePlayerNumber()
        {

            int answerPlayerNumber = 0;
            bool playerNumberBool = false;
            while (!playerNumberBool)
            {
                Console.WriteLine("Ingresa el numero total de jugadores que tiene tu Equipo:");
                String numJugadores = (Console.ReadLine());
                playerNumberBool = int.TryParse(numJugadores, out answerPlayerNumber);
                //playerNumberBool = answerPlayerNumber >= 0;
                if (!playerNumberBool)
                {
                    Console.WriteLine("Caracter invalido");
                }

            }
            Console.Clear();

            return answerPlayerNumber;

        }

        public static int AwardsWonQuestion()
        {
            int answerAwardWon = 0;
            bool awardsWonBool = false;
            while (!awardsWonBool)
            {
                Console.WriteLine("Ingresa el numero de trofeos que ha ganado tu equipo tu Equipo:");
                String numAwardsWon = (Console.ReadLine());
                awardsWonBool = int.TryParse(numAwardsWon, out answerAwardWon);
                if (!awardsWonBool)
                {
                    Console.WriteLine("Caracter invalido");
                }

            }
            Console.Clear();




            return answerAwardWon;
        }
    }
}

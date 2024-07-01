using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fitness_King
{
    internal class Utils
    {
        public static MySqlConnection cnx = new MySqlConnection("server=localhost;database=fitness;uid=root;password=");
        public static DataTable dataTable = new DataTable();



        public static void OpenConnection()
        {
            try
            {
                if (cnx.State == System.Data.ConnectionState.Closed)
                {
                    cnx.Open();
                    // Console.WriteLine("Connexion à la base de données ouverte avec succès.");
                     MessageBox.Show("Connexion à la base de données ouverte avec succès.", "Zakaria Location");
                }
            }
            catch (Exception ex)
            {
                // Console.WriteLine("Erreur lors de l'ouverture de la connexion : " + ex.Message);
                MessageBox.Show("Erreur lors de l'ouverture de la connexion : " + ex.Message, "Zakaria Location");
            }
        }

        // Méthode pour fermer la connexion
        public static void CloseConnection()
        {
            try
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                {
                    cnx.Close();
                    //Console.WriteLine("Connexion à la base de données fermée avec succès.");
                    MessageBox.Show("Connexion à la base de données fermer avec succès.", "Zakaria Location");
                }
            }
            catch (Exception ex)
            {
                // Console.WriteLine("Erreur lors de la fermeture de la connexion : " + ex.Message);
                MessageBox.Show("Connexion à la base de données fermer avec succès.", "Zakaria Location");
            }
        }


        public static void SuprimerDonner(string table, string id)
        {
            try
            {
                {
                    cnx.Open();

                    string query = $"delete from {table} where id=  {id}";

                    //using (SqlCommand command = new SqlCommand(query,cnx))
                    MySqlCommand command = new MySqlCommand(query, cnx);
                    {
                        command.ExecuteNonQuery();
                        //Console.WriteLine($"La colonne {id} a été supprimée de la table {table} avec succès.");
                        //MessageBox.Show($"La colonne {id} a été supprimée de la table {table} avec succès.", "Zakaria Location");
                    }
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Erreur lors de la suppression de la colonne : {ex.Message}");
                MessageBox.Show($"Erreur lors de la suppression de la colonne : {ex.Message}");
            }
        }

        public static void obtenirNomApp(Label label)
        {
            try
            {
                OpenConnection(); // Ouvrir la connexion à la base de données

                string query = $"SELECT nom_app FROM admin where id =1 "; // Requête SQL pour compter les employés

                MySqlCommand command = new MySqlCommand(query, cnx);
                string appName = command.ExecuteScalar()?.ToString(); // Exécutez la requête et récupérez le nom de l'application
                label.Text = appName;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'exécution de la requête : " + ex.Message);
                MessageBox.Show("Erreur lors de l'exécution de la requête : " + ex.Message, "Gestion Restaurant");
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                    cnx.Close(); // Fermer la connexion à la base de données après utilisation
            }


        }

        public static void NomApplication(Label label)
        {
            try
            {
                OpenConnection(); // Ouvrir la connexion à la base de données

                string query = "SELECT nom_app FROM admin WHERE id = @Id"; // Requête SQL pour récupérer le chemin de l'image de la table admin
                MySqlCommand command = new MySqlCommand(query, cnx);
                command.Parameters.AddWithValue("@Id", 1); // Remplacer 1 par l'ID de l'admin dont vous voulez afficher l'image

                // Récupérer le chemin de l'image à partir de la base de données
                string nom_app = (string)command.ExecuteScalar();

                label.Text = nom_app;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'exécution de la requête : " + ex.Message);
                MessageBox.Show("Erreur lors de l'exécution de la requête : " + ex.Message, "Zakaria Location");
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                    cnx.Close(); // Fermer la connexion à la base de données après utilisation
            }


        }


        public static DataTable ObtenirDonnees(string query)
        {
            DataTable dataTable = new DataTable();

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, cnx);

                {
                    cnx.Open();
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération des données : {ex.Message}");
                MessageBox.Show($"Erreur lors de la récupération des données .{ex.Message}", "Zakaria Location");
            }

            return dataTable;
        }




        public static void NombreStatictique(string table, Label label)
        {
            try
            {
                OpenConnection(); // Ouvrir la connexion à la base de données

                string query = $"SELECT COUNT(*) FROM {table}"; // Requête SQL pour compter les employés

                MySqlCommand command = new MySqlCommand(query, cnx);
                int nombreEmployes = Convert.ToInt32(command.ExecuteScalar());

                // Remplissage de la Label avec le résultat de la requête
                label.Text = nombreEmployes.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de l'exécution de la requête : " + ex.Message);
                MessageBox.Show("Erreur lors de l'exécution de la requête : " + ex.Message, "Zakaria Location");
            }
            finally
            {
                if (cnx.State == System.Data.ConnectionState.Open)
                    cnx.Close(); // Fermer la connexion à la base de données après utilisation
            }
        }

            public static void AfficherImageAdmin(PictureBox pictureBox)
            {
                try
                {
                    OpenConnection(); // Ouvrir la connexion à la base de données

                    string query = "SELECT logo FROM admin WHERE id = @Id"; // Requête SQL pour récupérer le chemin de l'image de la table admin
                    MySqlCommand command = new MySqlCommand(query, cnx);
                    command.Parameters.AddWithValue("@Id", 1); // Remplacer 1 par l'ID de l'admin dont vous voulez afficher l'image

                    // Récupérer le chemin de l'image à partir de la base de données
                    string imagePath = (string)command.ExecuteScalar();

                    pictureBox.Load(@"C:\Users\Zakaria\source\repos\Xamarin\Fitness King\bin\Debug\img\" + imagePath);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur lors de l'exécution de la requête : " + ex.Message);
                    MessageBox.Show("Erreur lors de l'exécution de la requête : " + ex.Message, "Zakaria Location");
                }
                finally
                {
                    if (cnx.State == System.Data.ConnectionState.Open)
                        cnx.Close(); // Fermer la connexion à la base de données après utilisation
                }
            }
        }
    
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fitness_King
{
    internal class Client
    {
        public string nom;
        public string prenom;
        public string cin;
        public string tel;
        public string email;
        public string abonnement;


        public Client(string nom, string prenom, string cin,  string tel, string email, string abonnement)
        {
            //this.ClientId = ClientId;
            this.nom = nom;
            this.prenom = prenom;
            this.cin = cin;
            //this.permis = permis;
            this.tel = tel;
            this.email = email;
            this.abonnement = abonnement;
            // this.mot_de_passe = mot_de_passe;
            //this.ph_cin = ph_cin;
        }

        public static void ajouterclient(Client Client)
        {
            try
            {

                Utils.OpenConnection();

                string query = "INSERT INTO client (nom, prenom,cin,tel,email,abonnement) VALUES (@Nom, @Prenom,@cin, @tel, @email,@abonnement)";

                MySqlCommand command = new MySqlCommand(query, Utils.cnx);
                {
                    command.Parameters.AddWithValue("@Nom", Client.nom);
                    command.Parameters.AddWithValue("@Prenom", Client.prenom);
                    command.Parameters.AddWithValue("@cin", Client.cin);
                   // command.Parameters.AddWithValue("@permis", Client.permis);
                    command.Parameters.AddWithValue("@tel", Client.tel);
                    command.Parameters.AddWithValue("@email", Client.email);
                   command.Parameters.AddWithValue("@abonnement", Client.abonnement);
                   // command.Parameters.AddWithValue("@ph_cin", Client.ph_cin);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Votre Client Bien Ajouter", "Zakaria Location");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur ajoute avec success: {ex.Message} ");
            }
        }

        public static void ModifierClient(Client Client, int id)
        {
            try
            {

                {
                    Utils.OpenConnection();

                    string query = "UPDATE client SET nom = @Nom, prenom = @Prenom , cin = @cin ,  tel = @tel, email = @email,abonnement=@abonnement WHERE id = @id";


                    MySqlCommand command = new MySqlCommand(query, Utils.cnx);
                    {
                        command.Parameters.AddWithValue("@Nom", Client.nom);
                        command.Parameters.AddWithValue("@Prenom", Client.prenom);
                        command.Parameters.AddWithValue("@cin", Client.cin);
                      //  command.Parameters.AddWithValue("@permis", Client.permis);
                        command.Parameters.AddWithValue("@tel", Client.tel);
                        command.Parameters.AddWithValue("@email", Client.email);
                        command.Parameters.AddWithValue("@abonnement", Client.abonnement);
                       // command.Parameters.AddWithValue("@ph_cin", Client.ph_cin);
                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Modification effectuée avec succès", "Zakaria Location");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la modification des données : {ex.Message}");
            }
        }
    }
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fitness_King
{
    internal class Coach
    {
        public string nom;
        public string prenom;
        public string cin;
        public string tel;
        public string email;
        public string type;


        public Coach(string nom, string prenom, string cin,  string tel, string email, string type)
        {
            //this.CoachId = CoachId;
            this.nom = nom;
            this.prenom = prenom;
            this.cin = cin;
            //this.permis = permis;
            this.tel = tel;
            this.email = email;
            this.type = type;
            // this.mot_de_passe = mot_de_passe;
            //this.ph_cin = ph_cin;
        }

        public static void ajouterCoach(Coach Coach)
        {
            try
            {

                Utils.OpenConnection();

                string query = "INSERT INTO coach (nom, prenom,cin,tel,email,type) VALUES (@Nom, @Prenom,@cin, @tel, @email,@type)";

                MySqlCommand command = new MySqlCommand(query, Utils.cnx);
                {
                    command.Parameters.AddWithValue("@Nom", Coach.nom);
                    command.Parameters.AddWithValue("@Prenom", Coach.prenom);
                    command.Parameters.AddWithValue("@cin", Coach.cin);
                   // command.Parameters.AddWithValue("@permis", Coach.permis);
                    command.Parameters.AddWithValue("@tel", Coach.tel);
                    command.Parameters.AddWithValue("@email", Coach.email);
                   command.Parameters.AddWithValue("@type", Coach.type);
                   // command.Parameters.AddWithValue("@ph_cin", Coach.ph_cin);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Votre Coach Bien Ajouter", "Zakaria Location");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur ajoute avec success: {ex.Message} ");
            }
        }

        public static void ModifierCoach(Coach Coach, int id)
        {
            try
            {

                {
                    Utils.OpenConnection();

                    string query = "UPDATE coach SET nom = @Nom, prenom = @Prenom , cin = @cin ,  tel = @tel, email = @email,type=@type WHERE id = @id";


                    MySqlCommand command = new MySqlCommand(query, Utils.cnx);
                    {
                        command.Parameters.AddWithValue("@Nom", Coach.nom);
                        command.Parameters.AddWithValue("@Prenom", Coach.prenom);
                        command.Parameters.AddWithValue("@cin", Coach.cin);
                      //  command.Parameters.AddWithValue("@permis", Coach.permis);
                        command.Parameters.AddWithValue("@tel", Coach.tel);
                        command.Parameters.AddWithValue("@email", Coach.email);
                        command.Parameters.AddWithValue("@type", Coach.type);
                       // command.Parameters.AddWithValue("@ph_cin", Coach.ph_cin);
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

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fitness_King
{
    public partial class Login : Form
    {
        
        
        public Login()
        {
            InitializeComponent();
        }


        private void connecter_Click(object sender, EventArgs e)
        {
            if (txtlg.Text != "" && txtmp.Text != "")
            {
                string connectionString = "server=localhost;user=root;database=fitness;password=";
                string queryAdmin = "SELECT * FROM admin WHERE email = @Username AND mot_de_passe = @Password";
                string queryAssistant = "SELECT * FROM assistant WHERE email = @Username AND mot_de_passe = @Password";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmdAdmin = new MySqlCommand(queryAdmin, connection);
                    MySqlCommand cmdAssistant = new MySqlCommand(queryAssistant, connection);
                    cmdAdmin.Parameters.AddWithValue("@Username", txtlg.Text);
                    cmdAdmin.Parameters.AddWithValue("@Password", txtmp.Text);
                    cmdAssistant.Parameters.AddWithValue("@Username", txtlg.Text);
                    cmdAssistant.Parameters.AddWithValue("@Password", txtmp.Text);

                    try
                    {
                        connection.Open();
                        using (MySqlDataReader rdAdmin = cmdAdmin.ExecuteReader())
                        {
                            if (rdAdmin.Read()) // Vérifie si une ligne correspondante a été trouvée dans la table "admin"
                            {
                                // Les informations de connexion sont correctes
                                this.Hide();
                                Dashboard dashbord = new Dashboard();
                                dashbord.Show();
                                return;
                            }
                        }

                        // Si aucune correspondance n'a été trouvée dans la table "admin", on essaie dans la table "assistant"
                        using (MySqlDataReader rdAssistant = cmdAssistant.ExecuteReader())
                        {
                            if (rdAssistant.Read()) // Vérifie si une ligne correspondante a été trouvée dans la table "assistant"
                            {
                                // Les informations de connexion sont correctes
                                this.Hide();
                                Dashboard dashbord = new Dashboard();
                                dashbord.Show();
                                return;
                            }
                        }

                        // Aucune correspondance trouvée dans les tables "admin" et "assistant"
                        MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtmp.Text = "";
                        txtmp.Focus();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur lors de la connexion à la base de données : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez saisir le nom d'utilisateur et le mot de passe.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Utils.AfficherImageAdmin(logo);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

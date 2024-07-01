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
    public partial class FormClient : Form
    {
        OpenFileDialog ofd = new OpenFileDialog();
        string chemin = "";
        public FormClient()
        {
            InitializeComponent();
        }

        void remplir()
        {
            Utils.CloseConnection();
            DataTable dataTable = Utils.ObtenirDonnees("SELECT c.id as N°Client, c.nom,c.prenom,c.cin,c.tel,c.email, c.abonnement from client c "); // Inclure l'abonnement
            tableau.DataSource = dataTable;
           // tableau.Columns["ph_cin"].Visible = false;
        }

        void nouveau()
        {
            Utils.CloseConnection();
            txtn.Text = "";
            txtp.Text = "";
            txtnc.Text = "";
           // txtnp.Text = ""; // Effacer le permis
            txtt.Text = "";
            txte.Text = "";
            txta.Text = "";
            //txtmp.Text = ""; // Effacer le mot de passe
           
            txtn.Focus();
        }
        private void FormClient_Load(object sender, EventArgs e)
        {
            remplir();
        }

        private void ajouter_Click(object sender, EventArgs e)
        {
            Utils.CloseConnection();
            //abonnement = "votre_abonnement"; // Ajout de l'abonnement
            Client client = new Client(txtn.Text, txtp.Text, txtnc.Text, txtt.Text, txte.Text, txta.Text);
            Client.ajouterclient(client);
            nouveau();
            remplir();
            ajouter.Enabled = true;
            modifier.Enabled = false;
            supprimer.Enabled = false;
        }

        private void modifier_Click(object sender, EventArgs e)
        {
            if (txtn.Text != "" && txtp.Text != "" && txtnc.Text != "" && txtt.Text != "" && txte.Text != "" &&  txta.Text != "")
            {
                //abonnement = "votre_abonnement"; // Ajout de l'abonnement
                Client client = new Client(txtn.Text, txtp.Text, txtnc.Text,  txtt.Text, txte.Text,  txta.Text);
                int id = int.Parse(txtid.Text);
                Client.ModifierClient(client, id);
                nouveau();
                remplir();
                ajouter.Enabled = true;
                modifier.Enabled = false;
                supprimer.Enabled = false;
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            this.Hide();
            dashboard.Show();
        }

        private void supprimer_Click(object sender, EventArgs e)
        {
            Utils.CloseConnection();
            if (MessageBox.Show("Voulez-vous suprimer Ce Client?", "Zakaria Location", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Utils.SuprimerDonner("client", txtid.Text);
                MessageBox.Show("Supression Avec Success", "Zakaria Location");
                remplir();
                nouveau();
                ajouter.Enabled = true;
                modifier.Enabled = false;
                supprimer.Enabled = false;
            }
        }

        private void tableau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = tableau.Rows.Count - 1;
            if (e.RowIndex >= 0 && e.RowIndex < n)
            {
                DataGridViewRow row = tableau.Rows[e.RowIndex];
                txtid.Text = row.Cells["N°Client"].Value.ToString();
                txtn.Text = row.Cells["nom"].Value.ToString();
                txtp.Text = row.Cells["prenom"].Value.ToString();
                txtnc.Text = row.Cells["cin"].Value.ToString();
                //txtnp.Text = row.Cells["permis"].Value.ToString();
                txtt.Text = row.Cells["tel"].Value.ToString();
                txte.Text = row.Cells["email"].Value.ToString();
                //txtmp.Text = row.Cells["mot_de_passe"].Value.ToString();
                txta.Text = row.Cells["abonnement"].Value.ToString();
              // abonnement = row.Cells["abonnement"].Value.ToString(); // Afficher l'abonnement
                //ph_cin.Image = Image.FromFile(@"C:\laragon\www\zakaria location\assets\img\clients\" + lb_cin.Text);
                ajouter.Enabled = false;
                modifier.Enabled = true;
                supprimer.Enabled = true;
            }
            else
            {
                MessageBox.Show("Aucun Element Selectionner", "Zakaria Location");
                txtid.Text = "";
                nouveau();
                ajouter.Enabled = true;
                modifier.Enabled = false;
                supprimer.Enabled = false;
            }
        }
    }
}

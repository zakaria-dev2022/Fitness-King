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
    public partial class FormProfil : Form
    {
        public FormProfil()
        {
            InitializeComponent();
        }
        void remplir()
        {
            Utils.CloseConnection();
            //Connection dbOperations = new Connection();
            DataTable dataTable = Utils.ObtenirDonnees("SELECT a.id as N°Employe,a.nom,a.prenom,a.email,a.mot_de_passe from assistant a ");
            //DataTable dataTable = Utils.ObtenirDonnees("select * from produit");
            // Lier le DataTable au DataGridView
            tableau.DataSource = dataTable;
            // tableau.Columns["ph_cin"].Visible = false;

        }

        void nouveau()
        {
            Utils.CloseConnection();
            txtn.Text = "";
            txtp.Text = "";
            txte.Text = "";
            txtmp.Text = "";
            txtcmp.Text = "";
            lb_msg.Visible = false;
            txtn.Focus();

        }

        private void FormProfil_Load(object sender, EventArgs e)
        {
            remplir();
        }

        private void ajouter_Click(object sender, EventArgs e)
        {
            if (txtmp.Text == txtcmp.Text)
            {
                Utils.CloseConnection();
                Assistant assistant = new Assistant(txtn.Text, txtp.Text, txte.Text, txtmp.Text);
                Assistant.ajouterAssistant(assistant);
                nouveau();
                remplir();
                ajouter.Enabled = true;
                modifier.Enabled = false;
                supprimer.Enabled = false;
            }
            else
            {
                //MessageBox.Show("Mot De Passe Incorect", "Zakaria Location");
                lb_msg.Visible = true;
                lb_msg.Text = "Mot De Passe Incorect";
                txtcmp.Text = "";
                txtcmp.Focus();
            }
        }
    }
}

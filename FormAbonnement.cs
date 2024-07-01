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
    public partial class FormAbonnement : Form
    {
        public FormAbonnement()
        {
            InitializeComponent();
        }

        void remplir()
        {
            Utils.CloseConnection();
            //Connection dbOperations = new Connection();
            DataTable dataTable = Utils.ObtenirDonnees("SELECT r.id as N°Location,v.matricule ,c.cin,c.id as id_client,v.id as id_voiture,r.date_debut ,r.date_fin ,r.montant  from reservation r\r\njoin client c on r.client_id =c.id \r\nJOIN voiture v on r.voiture_id=v.id ");
            
            //DataTable dataTable = Utils.ObtenirDonnees("SELECT v.id as N°Voiture,m.type as Type_voiture,m.id as N°Marque,v.nom_voiture,v.matricule,v.type_boite_vitesse,v.type_carburant,v.model,v.prix,v.assurance,v.carte_grise,v.visite,v.ph_voiture\r\nFROM voiture v \r\nJOIN type_marque m on v.id_marque=m.id ");
            //DataTable dataTable = Utils.ObtenirDonnees("select * from produit");
            // Lier le DataTable au DataGridView
            tableau.DataSource = dataTable;
            tableau.Columns["id_client"].Visible = false;
            tableau.Columns["id_voiture"].Visible = false;
        }
        private void FormAbonnement_Load(object sender, EventArgs e)
        {

        }
    }
}

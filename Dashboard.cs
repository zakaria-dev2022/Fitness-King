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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            FormCoach coach = new FormCoach();
            this.Hide();
            coach.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormSetting emp = new FormSetting();
            this.Hide();
            emp.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            FormClient emp = new FormClient();
            this.Hide();
            emp.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            FormAbonnement abn = new FormAbonnement();
            this.Hide();
            abn.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-Vous Se Déconnecter??", "Gestion Location De Voiture", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Login emp = new Login();
                this.Hide();
                emp.Show();
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            Utils.NombreStatictique("client", lb_nc);
            Utils.NombreStatictique("coach", lb_np);
            Utils.AfficherImageAdmin(logo);
            Utils.NomApplication(lb_na);
           // Utils.nombreReclamation(lb_nr);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            FormProfil emp = new FormProfil();
            this.Hide();
            emp.Show();
        }
    }
}

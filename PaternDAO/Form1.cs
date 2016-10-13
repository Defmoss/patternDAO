using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Classes;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace PaternDAO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ClientDAO connexion = new ClientDAO("server=.;database=hotel;integrated security=true");
        string btnChoix;


        private void Form1_Load(object sender, EventArgs e)
        {
            listClient.DisplayMember = "Affichage";
            listClient.ValueMember = "Id";
            listClient.DataSource = connexion.List();
            Width = 313;
        }

        private void listClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNom.Clear();
            txtPrenom.Clear();
            txtVille.Clear();
            btnValider.Enabled = false;
            btnAnnuler.Enabled = false;

        }

        private void btnSuppr_Click(object sender, EventArgs e)
        {
            btnChoix = "supprimer";
            Client cli = new Client();
            cli = connexion.Find((int)listClient.SelectedValue);
            txtNom.Text = cli.Nom;
            txtPrenom.Text = cli.Prenom;
            txtVille.Text = cli.Ville;
            btnValider.Enabled = true;
            btnAnnuler.Enabled = true;
            groupBox1.Enabled = true;
            Width = 561;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            txtNom.Clear();
            txtPrenom.Clear();
            txtVille.Clear();
            btnChoix = "ajouter";
            btnValider.Enabled = true;
            btnAnnuler.Enabled = true;
            groupBox1.Enabled = true;
            Width = 561;
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            btnChoix = "modifier";
            Client cli = new Client();
            cli = connexion.Find((int)listClient.SelectedValue);
            txtNom.Text = cli.Nom;
            txtPrenom.Text = cli.Prenom;
            txtVille.Text = cli.Ville;
            btnValider.Enabled = true;
            btnAnnuler.Enabled = true;
            groupBox1.Enabled = true;
            Width = 561;
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            Client cli = new Client();
            //Si Ajouter
            if (btnChoix == "ajouter")
            {
                cli.Nom = txtNom.Text;
                cli.Prenom = txtPrenom.Text;
                cli.Ville = txtVille.Text;
                connexion.Insert(cli);
                MessageBox.Show("Client Ajouté", "Ajout", MessageBoxButtons.OK);
            }
            //SI Modifier
            if (btnChoix == "modifier")
            {
                cli.Nom = txtNom.Text;
                cli.Prenom = txtPrenom.Text;
                cli.Ville = txtVille.Text;
                cli.Id = (int)listClient.SelectedValue;

                connexion.Update(cli);
                MessageBox.Show("Client Modifié", "Modification", MessageBoxButtons.OK);
            }            
            //Si Supprimer
            if (btnChoix == "supprimer")
            {
                cli = connexion.Find((int)listClient.SelectedValue);
                connexion.Delete(cli);
                MessageBox.Show("Client Supprimé", "Suppression", MessageBoxButtons.OK);
            }
            
            listClient.DataSource = connexion.List();
            txtNom.Clear();
            txtPrenom.Clear();
            txtVille.Clear();
            btnValider.Enabled = false;

            groupBox1.Enabled = false;
            Width = 313;

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            txtNom.Clear();
            txtPrenom.Clear();
            txtVille.Clear();
            btnValider.Enabled = false;
            btnAnnuler.Enabled = false;
            groupBox1.Enabled = false;
            Width = 313;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Classes
{
    public class ClientDAO
    {
        SqlConnection connect;
        public ClientDAO(string phrase)
        {
            connect = new SqlConnection(phrase);
        }
        
        public Client Find(int id)
        {
            connect.Open();
            SqlCommand requete = new SqlCommand("select * from client where cli_id="+id, connect);
            SqlDataReader lecture = requete.ExecuteReader();
            Client cli = new Client();
            if (lecture.Read())
            {
                //cli.Id = id;
                cli.Id = Convert.ToInt32(lecture["cli_id"]);
                cli.Nom = lecture["cli_nom"].ToString();
                cli.Prenom = lecture["cli_prenom"].ToString();
                cli.Ville = lecture["cli_ville"].ToString();
                cli.Affichage = lecture["cli_nom"].ToString() + " " + lecture["cli_prenom"].ToString();
                
            }
            
            
            connect.Close();

            return cli;

        }

        public List<Client> List()
        {
            connect.Open();
            SqlCommand requete = new SqlCommand("select * from client", connect);
            SqlDataReader lecture = requete.ExecuteReader();
            List<Client> liste = new List<Client>();
            while (lecture.Read())
            {
                Client cli = new Client();
                cli.Id = Convert.ToInt32(lecture["cli_id"]);
                cli.Nom = lecture["cli_nom"].ToString();
                cli.Prenom = lecture["cli_prenom"].ToString();
                cli.Ville = lecture["cli_ville"].ToString();
                cli.Affichage = lecture["cli_nom"].ToString() + " " + lecture["cli_prenom"].ToString();
               
                liste.Add(cli);
            }

            connect.Close();
            return liste;
        }

        public void Delete(Client cli)
        {
            connect.Open();
            SqlCommand requete = new SqlCommand("delete from client where cli_id =" + cli.Id, connect);
            requete.ExecuteNonQuery();            
            connect.Close();
        }

        public void Insert(Client cli)
        {
            connect.Open();
            SqlCommand requete = new SqlCommand("insert into client (cli_nom, cli_prenom, cli_ville) values (@nom, @prenom, @ville)", connect);
            requete.Parameters.AddWithValue("@nom", cli.Nom);
            requete.Parameters.AddWithValue("@prenom", cli.Prenom);
            requete.Parameters.AddWithValue("@ville", cli.Ville);
            requete.ExecuteNonQuery();
            connect.Close();
        }

        public void Update(Client cli)
        {
            connect.Open();
            SqlCommand requete = new SqlCommand("update client set cli_nom = @nom, cli_prenom = @prenom, cli_ville = @ville where cli_id =@id", connect);
            requete.Parameters.AddWithValue("@nom", cli.Nom);
            requete.Parameters.AddWithValue("@prenom", cli.Prenom);
            requete.Parameters.AddWithValue("@ville", cli.Ville);
            requete.Parameters.AddWithValue("@id", cli.Id);
            requete.ExecuteNonQuery();
            connect.Close();
        }

        
    }
}

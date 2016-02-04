using EntitiesLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class test
    {
        public List<Jedi> getJedis(String connectionString)
        {
            List<Jedi> allJedis = new List<Jedi>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                String request = "SELECT id, nom, isSith FROM Jedi;";
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    List<Caracteristiques> listcarac = new List<Caracteristiques>();

                    using (SqlConnection sqlConnection2 = new SqlConnection(connectionString))
                    {
                        int id = int.Parse(sqlDataReader["id"].ToString());

                        String request2 = "SELECT C.id, C.definition, C.nom, C.ETypeCaracteristique, C.valeur FROM Jedi J, Caracteristiques C, CaraJedi CJ WHERE J.id=" + id + " AND J.id=JC.idj AND C.id=CJ.idc;";
                        SqlCommand sqlCommand2 = new SqlCommand(request2, sqlConnection2);
                        sqlConnection2.Open();

                        SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
                        while (sqlDataReader2.Read())
                        {
                            Caracteristiques carac = new Caracteristiques();

                            if (sqlDataReader2["definition"].ToString() == EDefCaracteristique.Force.ToString())
                            { carac.Definition = EDefCaracteristique.Force; }
                            if (sqlDataReader2["definition"].ToString() == EDefCaracteristique.Defense.ToString())
                            { carac.Definition = EDefCaracteristique.Defense; }
                            if (sqlDataReader2["definition"].ToString() == EDefCaracteristique.Chance.ToString())
                            { carac.Definition = EDefCaracteristique.Chance; }
                            if (sqlDataReader2["definition"].ToString() == EDefCaracteristique.Sante.ToString())
                            { carac.Definition = EDefCaracteristique.Sante; }

                            carac.Nom = sqlDataReader2["nom"].ToString();
                            carac.Valeur = int.Parse(sqlDataReader2["valeur"].ToString());

                            if (sqlDataReader2["ETypeCaracteristique"].ToString() == ETypeCaracteristique.Jedi.ToString())
                            { carac.Type = ETypeCaracteristique.Jedi; }
                            if (sqlDataReader2["ETypeCaracteristique"].ToString() == ETypeCaracteristique.Stade.ToString())
                            { carac.Type = ETypeCaracteristique.Stade; }

                            listcarac.Add(carac);
                        }
                        sqlConnection2.Close();
                    }

                    Jedi jedi = new Jedi();
                    //khkhkkhkhk
                    jedi.Carac = listcarac.ToArray();

                    jedi.IsSith = bool.Parse(sqlDataReader["isSith"].ToString());
                    jedi.Nom = sqlDataReader["nom"].ToString();


                    allJedis.Add(jedi);
                }
                sqlDataReader.Close();
                /*SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                dataTables[(int)DTName.JEDIS].Clear();
                sqlDataAdapter.Fill(dataTables[(int)DTName.JEDIS]);
                sqlDataAdapter = new SqlDataAdapter(new SqlCommand("SELECT idjedi, idcarac FROM JediCarac;", sqlConnection));
                dataTables[(int)DTName.JEDICARAC].Clear();
                sqlDataAdapter.Fill(dataTables[(int)DTName.JEDICARAC]);*/
                sqlConnection.Close();
            }
           
       
        
            foreach (Jedi j in allJedis)
            {

                Console.WriteLine(j.Id+ "+++");
                Console.WriteLine(j.Nom+ "+++");
                Console.WriteLine(j.IsSith + "+++");
               
       

            }
            return allJedis;
        }
        static void Main(string[] args)
        {
            test t = new test();
            List<Jedi> ListJedi = new List<Jedi>();
            string server = "bktsql.database.windows.net";

            string dataBaseName = "SQL";

            string UserName = "Groupe10";

            string pwd = "Tour1234";


   String  ConnectionString = "Data Source=" + server + ";Initial Catalog=" + dataBaseName + ";User ID=" + UserName + ";Password=" + pwd;
    // Requête SQL

             ListJedi =t.getJedis(ConnectionString);

        }
    }

}

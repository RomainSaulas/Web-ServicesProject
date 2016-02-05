using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace DataAccessLayer
{
    public class MySql : IBridge
    {
        SqlConnection conn;
        SqlCommand cmd = new SqlCommand();
        private string connectionString = null;

        public MySql(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Caracteristiques> getCaracteristiques()
        {
            List<Caracteristiques> listcarac = new List<Caracteristiques>();

            using (SqlConnection sqlConnection2 = new SqlConnection(connectionString))
            {
                String request2 = "SELECT C.id, C.definition, C.nom, C.ETypeCaracteristique, C.valeur FROM Caracteristiques C;";
                SqlCommand sqlCommand2 = new SqlCommand(request2, sqlConnection2);
                try
                { 

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
                        carac.Id = int.Parse(sqlDataReader2["id"].ToString());

                        carac.Nom = sqlDataReader2["nom"].ToString();
                    carac.Valeur = int.Parse(sqlDataReader2["valeur"].ToString());

                    if (sqlDataReader2["ETypeCaracteristique"].ToString() == ETypeCaracteristique.Jedi.ToString())
                    { carac.Type = ETypeCaracteristique.Jedi; }
                    if (sqlDataReader2["ETypeCaracteristique"].ToString() == ETypeCaracteristique.Stade.ToString())
                    { carac.Type = ETypeCaracteristique.Stade; }

                    listcarac.Add(carac);
                
                }
                    sqlDataReader2.Close();
                }
                catch (Exception ex)
                {
                    // Affiche des erreurs
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    // Fermeture de la connexion à la base de données
                    //connexion.Close();
                }
                
                sqlConnection2.Close();
            }

            return listcarac;
        }

        public List<Jedi> getJedis()
        {
            List<Jedi> allJedis = new List<Jedi>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                String request = "SELECT id, nom, isSith FROM Jedi;";
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
            try
                { 
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
                     try
                     {

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
                        }
                        catch (Exception ex)
                        {
                            // Affiche des erreurs
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            // Fermeture de la connexion à la base de données
                            //connexion.Close();
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
                }
                catch (Exception ex)
                {
                    // Affiche des erreurs
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    // Fermeture de la connexion à la base de données
                    //connexion.Close();
                }
                sqlConnection.Close();
            }
            return allJedis;
        }


        public List<Stade> getStades()
        {
            List<Stade> allStades = new List<Stade>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                String request = "SELECT id, NBplace, Planet FROM Stade;";
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
            try
                { 
                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    List<Caracteristiques> listcarac = new List<Caracteristiques>();

                    using (SqlConnection sqlConnection2 = new SqlConnection(connectionString))
                    {
                        int id = int.Parse(sqlDataReader["id"].ToString());

                        String request2 = "SELECT C.id, C.definition, C.nom, C.ETypeCaracteristique, C.valeur FROM Stade S, Caracteristiques C, CaraStade CS WHERE S.id=" + id + " AND S.id=CS.ids AND S.id=CS.idc;";
                        SqlCommand sqlCommand2 = new SqlCommand(request2, sqlConnection2);
                     try
                      {
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
                            }
                            catch (Exception ex)
                            {
                                // Affiche des erreurs
                                Console.WriteLine(ex.Message);
                            }
                            finally
                            {
                                // Fermeture de la connexion à la base de données
                                //connexion.Close();
                            }
                            sqlConnection2.Close();
                    }
                    Stade stade = new Stade();
    
                    stade.Caracteristiques = listcarac.ToArray();
                    stade.NbPlaces = int.Parse(sqlDataReader["NbPlace"].ToString());
                    stade.Planete = sqlDataReader["Planet"].ToString();
                    allStades.Add(stade);
                }
                }
                catch (Exception ex)
                {
                    // Affiche des erreurs
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    // Fermeture de la connexion à la base de données
                    //connexion.Close();
                }
                sqlConnection.Close();
            }
            return allStades;
        }

        public List<Match> getMatches()
        {

            List<Match> allMatches = new List<Match>();
            List<Stade> allStade = this.getStades();
            List<Jedi> allJedis = this.getJedis();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                String request = "SELECT id, idJediVainqueur,idj1,idj2,ids, EPhaseTournoi FROM Match;";
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
              try { 
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                Match match = new Match();
                while (sqlDataReader.Read())
                {
                    ///////////////////////////////////7
                    int idjedi1 = int.Parse(sqlDataReader["idj1"].ToString());
                    int idjedi2 = int.Parse(sqlDataReader["idj2"].ToString());
                    int ids = int.Parse(sqlDataReader["ids"].ToString());
                    if (sqlDataReader["EPhaseTournoi"].ToString() == EPhaseTournoi.Finale.ToString())
                    { match.PhaseTournoi = EPhaseTournoi.Finale; }
                    if (sqlDataReader["EPhaseTournoi"].ToString() == EPhaseTournoi.DemiFinale.ToString())
                    { match.PhaseTournoi = EPhaseTournoi.DemiFinale; }
                    if (sqlDataReader["EPhaseTournoi"].ToString() == EPhaseTournoi.QuartFinale.ToString())
                    { match.PhaseTournoi = EPhaseTournoi.QuartFinale; }
                    if (sqlDataReader["EPhaseTournoi"].ToString() == EPhaseTournoi.HuitiemeFinale.ToString())
                    { match.PhaseTournoi = EPhaseTournoi.HuitiemeFinale; }
                    match.Id = int.Parse(sqlDataReader["id"].ToString());
                    match.IdJediVainqueur = int.Parse(sqlDataReader["idJediVainqueur"].ToString());
                    Jedi j1 = allJedis.Where(x => x.Id == idjedi1).FirstOrDefault();
                    Jedi j2 = allJedis.Where(x => x.Id == idjedi2).FirstOrDefault();
                    Stade stade = allStade.Where(x => x.Id == ids).FirstOrDefault();
                    match.Jedi1 = j1;
                    match.Jedi2 = j2;
                    match.Stade = stade;
                    allMatches.Add(match);
                }
                sqlDataReader.Close();
                }
                catch (Exception ex)
                {
                    // Affiche des erreurs
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    // Fermeture de la connexion à la base de données
                    //connexion.Close();
                }
                sqlConnection.Close();
            }
            return allMatches;

            throw new NotImplementedException();
        }

        public List<Tournoi> getTournois()
        {
            List<Tournoi> allTournois = new List<Tournoi>();
            List<Match> allMatches = this.getMatches();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                String request = "SELECT id, nom FROM Tournoi;";
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    List<Match> matches = new List<Match>();

                    using (SqlConnection sqlConnection2 = new SqlConnection(connectionString))
                    {
                        int id = int.Parse(sqlDataReader["id"].ToString());

                        String request2 = "SELECT idm FROM TourMat WHERE idm=" + id;
                        SqlCommand sqlCommand2 = new SqlCommand(request2, sqlConnection2);
                        sqlConnection2.Open();

                        SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
                        while (sqlDataReader2.Read())
                        {
                            int i = int.Parse(sqlDataReader2["id"].ToString());

                            matches.Add(allMatches.Where(x => x.Id == i).FirstOrDefault());
                        }
                        sqlConnection2.Close();
                    }
                    Tournoi tournoi = new Tournoi();
                    //wwwwwwwwwww
                    tournoi.Id = int.Parse(sqlDataReader["id"].ToString());
                    tournoi.Nom = sqlDataReader["nom"].ToString();
                    tournoi.Match = matches;

                    allTournois.Add(tournoi);
                }
                sqlDataReader.Close();
                sqlConnection.Close();
            }
            return allTournois;
            throw new NotImplementedException();
        }
        // updatttte
        public void updateCaracteristiques(Caracteristiques caracteristiques)
        {

            String request1 = "UPDATE Caracteristiques SET definition= @Definition ,nom =@Nom,valeur =@Valeur, ETypeCaracteristique = @ETypeCaracteristique Where id = @IdCaracteristiques";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                try {
                sqlConnection.Open();
                /* Update dans la table Jedi */
                SqlCommand updateCommand1 = new SqlCommand(request1, sqlConnection);
                updateCommand1.Parameters.AddWithValue("@Valeur", caracteristiques.Valeur);
                updateCommand1.Parameters.AddWithValue("@Nom", caracteristiques.Nom);
                updateCommand1.Parameters.AddWithValue("@Definition", caracteristiques.Definition.ToString());
                updateCommand1.Parameters.AddWithValue("@IdCaracteristiques", caracteristiques.Id);
                updateCommand1.Parameters.AddWithValue("@ETypeCaracteristique", caracteristiques.Type.ToString());

                    updateCommand1.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Affiche des erreurs
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    // Fermeture de la connexion à la base de données
                    //connexion.Close();
                }
                sqlConnection.Close();
                
            }
            throw new NotImplementedException();
        }
        public void updateJedis(Jedi jedi)
        {
            String request1 = "UPDATE Jedi SET nom = @Nom , isSith = @IsSith Where id = @IdJedi";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
               try { 
                sqlConnection.Open();
                /* Update dans la table Jedi */
                SqlCommand updateCommand1 = new SqlCommand(request1, sqlConnection);
                updateCommand1.Parameters.AddWithValue("@Nom", jedi.Nom);
                updateCommand1.Parameters.AddWithValue("@IsSith", jedi.IsSith);
                updateCommand1.Parameters.AddWithValue("@IdJedi", jedi.Id);
                updateCommand1.ExecuteNonQuery();
                /*Update dans la table JediCaracteristiques */
                foreach (Caracteristiques c in jedi.Carac)
                {

                    updateCaracteristiques(c);
                    //   SqlCommand updateCommand2 = new SqlCommand(request2, sqlConnection);
                    //  updateCommand2.Parameters.AddWithValue("@Value", c.Valeur);
                    // updateCommand2.Parameters.AddWithValue("@IdJedi", jedi.Id);
                    // updateCommand2.Parameters.AddWithValue("@IdCaracteristique", (int)c.Id);
                    //updateCommand2.ExecuteNonQuery();
                }
                }
                catch (Exception ex)
                {
                    // Affiche des erreurs
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    // Fermeture de la connexion à la base de données
                    //connexion.Close();
                }
                sqlConnection.Close();
            }
        }


        public void updateStades(Stade stade)
        {
            String request1 = "UPDATE Stade SET NbPlace=@NbPlace, Planet= @Planet Where id = @IdStade";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
               try { 
                sqlConnection.Open();
                /* Update dans la table Jedi */
                SqlCommand updateCommand1 = new SqlCommand(request1, sqlConnection);
                updateCommand1.Parameters.AddWithValue("@NbPlaces", stade.NbPlaces);
                updateCommand1.Parameters.AddWithValue("@Planet", stade.Planete);
                updateCommand1.Parameters.AddWithValue("@IdStade", stade.Id);
                updateCommand1.ExecuteNonQuery();
                /*Update dans la table JediCaracteristiques */
                foreach (Caracteristiques c in stade.Caracteristiques)
                {
                    updateCaracteristiques(c);
                }
                }
                catch (Exception ex)
                {
                    // Affiche des erreurs
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    // Fermeture de la connexion à la base de données
                    //connexion.Close();
                }
                sqlConnection.Close();
            }
            throw new NotImplementedException();
        }

        public void updateMatches(Match match)
        {
            String request1 = "UPDATE Match SET idJediVainqueur=@idJediVainqueur, idj1=@idjedi1,=idj2@idjedi2,ids=@idstade, Where id = @IdMatch";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
              try{
                sqlConnection.Open();
                /* Update dans la table Jedi */
                SqlCommand updateCommand1 = new SqlCommand(request1, sqlConnection);
                updateCommand1.Parameters.AddWithValue("@idJediVainqueur", match.IdJediVainqueur);
                updateCommand1.Parameters.AddWithValue("@idjedi1", match.Jedi1.Id);
                updateCommand1.Parameters.AddWithValue("@Idjedi2", match.Jedi2.Id);
                updateCommand1.Parameters.AddWithValue("@Idstade", match.Stade.Id);
                updateCommand1.Parameters.AddWithValue("@EPhaseTournoi", match.PhaseTournoi.ToString());
                updateCommand1.Parameters.AddWithValue("@IdMatch", match.Id);
                updateCommand1.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Affiche des erreurs
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    // Fermeture de la connexion à la base de données
                    //connexion.Close();
                }
                sqlConnection.Close();
                throw new NotImplementedException();
            }

        }
    
         public void updateTournois(Tournoi tournoi )
        {
            String request1 = "UPDATE Jedi SET  nom = @Nom Where id = @IdTournoi";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                // Update dans la table Jedi 
                SqlCommand updateCommand1 = new SqlCommand(request1, sqlConnection);
                updateCommand1.Parameters.AddWithValue("@Nom", tournoi.Nom);
                updateCommand1.Parameters.AddWithValue("@IdTournoi", tournoi.Id);
                updateCommand1.ExecuteNonQuery();
                //Update dans la table JediCaracteristiques 
                foreach (Match m in tournoi.Match)
                {

                    updateMatches(m);
                   
                }
                sqlConnection.Close();
            }

            throw new NotImplementedException();
        }
        public void addJedi(Jedi jedi)
        {
            String request1 = "INSERT INTO Jedi (nom,IsSith) VALUES (@Nom,@IsSith)";
            String request2 = "INSERT INTO CaraJedi VALUES (@IdJedi,@IdCaracteristiques)";
            Int32 Current_Id = 0;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
              try
                { 
                sqlConnection.Open();
                /* Récupérer dans un premier temps la valeur courante du séquence */
                SqlCommand sqlCommand = new SqlCommand("SELECT IDENT_CURRENT ('Jedi') AS Current_Identity", sqlConnection);
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    while (sqlDataReader.Read())
                    {
                        Current_Id = Int32.Parse(sqlDataReader["Current_Identity"].ToString());
                    }
                }
                /* Insertion dans la table Jedi */
                SqlCommand insertCommand1 = new SqlCommand(request1, sqlConnection);
                insertCommand1.Parameters.AddWithValue("@NOM", jedi.Nom);
                insertCommand1.Parameters.AddWithValue("@IsSith", jedi.IsSith);
                insertCommand1.ExecuteNonQuery();
                /* Insertion dans la table JediCaracteristiques */
                foreach (Caracteristiques c in jedi.Carac)
                {
                    SqlCommand insertCommand2 = new SqlCommand(request2, sqlConnection);
                    insertCommand2.Parameters.AddWithValue("@IdJedi", Current_Id + 1);
                    insertCommand2.Parameters.AddWithValue("@Value", c.Valeur);
                    insertCommand2.Parameters.AddWithValue("@IdCaracteristiques", (int)c.Definition);
                    insertCommand2.ExecuteNonQuery();
                }
                }
                catch (Exception ex)
                {
                    // Affiche des erreurs
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    // Fermeture de la connexion à la base de données
                    //connexion.Close();
                }
                sqlConnection.Close();
            }
        }
    }
}
        
         
using SlojPodataka.Interfejsi;
using SlojPodataka.Klase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlojPodataka.Repozitorijumi
{
    public class KorisnikRepo : IKorisnikRepo
    {
        private string _konekcioniString;

        public KorisnikRepo(string konekcioniString)
        {
            _konekcioniString = konekcioniString;
        }

        public DataSet DajKorisnikaPoPrezimenu(string Prezime)
        {
            throw new NotImplementedException();
        }

        public DataSet DajSveKorisnike()
        {
            DataSet dsPodaci = new DataSet();

            SqlConnection Veza = new SqlConnection(_konekcioniString);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("DajSveKorisnikeSP", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = Komanda;
            da.Fill(dsPodaci);
            Veza.Close();
            Veza.Dispose();

            return dsPodaci;
        }

        public bool IzmeniKorisnika(string StariJMBG, Korisnik objNoviKorisnik)
        {
            int proveraUnosa = 0;

            SqlConnection Veza = new SqlConnection(_konekcioniString);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("IzmeniKorisnika", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@StariJmbg", SqlDbType.NVarChar).Value = StariJMBG;
            Komanda.Parameters.Add("@Jmbg", SqlDbType.NVarChar).Value = objNoviKorisnik.Jmbg;
            Komanda.Parameters.Add("@Ime", SqlDbType.NVarChar).Value = objNoviKorisnik.Ime;
            Komanda.Parameters.Add("@Prezime", SqlDbType.NVarChar).Value = objNoviKorisnik.Prezime;
            Komanda.Parameters.Add("@Drzavljanstvo", SqlDbType.NVarChar).Value = objNoviKorisnik.Drzavljanstvo;
            Komanda.Parameters.Add("@Email", SqlDbType.NVarChar).Value = objNoviKorisnik.Email;
            Komanda.Parameters.Add("@Lozinka", SqlDbType.NVarChar).Value = objNoviKorisnik.Lozinka;

            proveraUnosa = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (proveraUnosa > 0);
        }

        public bool IzmeniKorisnika(Korisnik objKorisnik)
        {
            throw new NotImplementedException();
        }

        public bool NoviKorisnik(Korisnik objNoviKorisnik)
        {
            //promenljiva za proveru uspesnosti unosa 
            int proveraUnosa = 0;

            SqlConnection Veza = new SqlConnection(_konekcioniString);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("NoviKorisnik", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@JMBG", SqlDbType.NVarChar).Value = objNoviKorisnik.Jmbg;
            Komanda.Parameters.Add("@Ime", SqlDbType.NVarChar).Value = objNoviKorisnik.Ime;
            Komanda.Parameters.Add("@Prezime", SqlDbType.NVarChar).Value = objNoviKorisnik.Prezime;
            Komanda.Parameters.Add("@Drzavljanstvo", SqlDbType.NVarChar).Value = objNoviKorisnik.Drzavljanstvo;
            Komanda.Parameters.Add("@Email", SqlDbType.NVarChar).Value = objNoviKorisnik.Email;
            Komanda.Parameters.Add("@Lozinka", SqlDbType.NVarChar).Value = objNoviKorisnik.Lozinka;
            Komanda.Parameters.Add("@isAdmin", SqlDbType.NVarChar).Value = false;


            try 
            {
                proveraUnosa = Komanda.ExecuteNonQuery();
                Veza.Close();
                Veza.Dispose();
            }
            catch (Exception ex)
            {
                return false;
            }

            //vraca true ako je uspesno
            return (proveraUnosa > 0);
        }

        public bool DodajAdmina(Korisnik objNoviKorisnik)
        {
            //promenljiva za proveru uspesnosti unosa 
            int proveraUnosa = 0;

            SqlConnection Veza = new SqlConnection(_konekcioniString);
            Veza.Open();
            SqlCommand Komanda = new SqlCommand("NoviKorisnik", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@JMBG", SqlDbType.NVarChar).Value = objNoviKorisnik.Jmbg;
            Komanda.Parameters.Add("@Ime", SqlDbType.NVarChar).Value = objNoviKorisnik.Ime;
            Komanda.Parameters.Add("@Prezime", SqlDbType.NVarChar).Value = objNoviKorisnik.Prezime;
            Komanda.Parameters.Add("@Drzavljanstvo", SqlDbType.NVarChar).Value = objNoviKorisnik.Drzavljanstvo;
            Komanda.Parameters.Add("@Email", SqlDbType.NVarChar).Value = objNoviKorisnik.Email;
            Komanda.Parameters.Add("@Lozinka", SqlDbType.NVarChar).Value = objNoviKorisnik.Lozinka;
            Komanda.Parameters.Add("@isAdmin", SqlDbType.NVarChar).Value = true;


            proveraUnosa = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            //vraca true ako je uspesno
            return (proveraUnosa > 0);
        }

        public bool ObrisiKorisnika(string JMBG)
        {
            int proveraUnosa = 0;

            SqlConnection Veza = new SqlConnection(_konekcioniString);
            Veza.Open();

            SqlCommand Komanda = new SqlCommand("ObrisiKorisnika", Veza);
            Komanda.CommandType = CommandType.StoredProcedure;
            Komanda.Parameters.Add("@Jmbg", SqlDbType.NVarChar).Value = JMBG;

            proveraUnosa = Komanda.ExecuteNonQuery();
            Veza.Close();
            Veza.Dispose();

            return (proveraUnosa > 0);
        }

        public Korisnik PronadjiPoEmail(string email)
        {
            using (SqlConnection Veza = new SqlConnection(_konekcioniString))
            {

                Veza.Open();
                SqlCommand Komanda = new SqlCommand("PronadjiKorisnikaPoEmailu", Veza);
                Komanda.CommandType = CommandType.StoredProcedure;
                Komanda.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;

                using (SqlDataReader Reader = Komanda.ExecuteReader())
                {
                    if (Reader.Read())
                    {
                        return MapirajRedUObjekat(Reader);
                    }
                    else
                    {
                        return null; 
                    }
                }
                Veza.Close();
                Veza.Dispose();
            }
        }

        public List<Korisnik> VratiSveAdmine()
        {
            List<Korisnik> admini = new List<Korisnik>();

            using (SqlConnection veza = new SqlConnection(_konekcioniString))
            {
                SqlCommand komanda = new SqlCommand("VratiSveAdmine", veza);
                komanda.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    veza.Open();

                    SqlDataReader reader = komanda.ExecuteReader();

                    while (reader.Read())
                    {
                        // Mapiranje reda u objekat Korisnik
                        Korisnik admin = new Korisnik
                        {
                            Jmbg = reader["Jmbg"].ToString(),
                            Ime = reader["Ime"].ToString(),
                            Prezime = reader["Prezime"].ToString(),
                            Drzavljanstvo = reader["Drzavljanstvo"].ToString(),
                            Email = reader["Email"].ToString(),
                            Lozinka = reader["Lozinka"].ToString(),
                            IsAdmin = Convert.ToBoolean(reader["IsAdmin"])
                        };

                        admini.Add(admin);
                    }
                }
                catch (Exception ex)
                {
                    // Obrada izuzetaka
                    Console.WriteLine("Greška prilikom čitanja podataka iz baze: " + ex.Message);
                }
            }

            return admini;
        }


        private Korisnik MapirajRedUObjekat(SqlDataReader reader)
        {
            return new Korisnik
            {
                Jmbg = reader["JMBG"].ToString(),
                Ime = reader["Ime"].ToString(),
                Prezime = reader["Prezime"].ToString(),
                Drzavljanstvo = reader["Drzavljanstvo"].ToString(),
                Email = reader["Email"].ToString(),
                Lozinka = reader["Lozinka"].ToString(),
                 IsAdmin = (bool)reader["isAdmin"] 
            };
        }
    }
}

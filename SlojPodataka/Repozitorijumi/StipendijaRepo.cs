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
    public class StipendijaRepo : IStipendijaRepo
    {
        private string _konekcioniString;

        public StipendijaRepo(string konekcioniString)
        {
            _konekcioniString = konekcioniString;
        }

        public List<Stipendija> DajSveStipendije()
        {
            List<Stipendija> listaStipendija = new List<Stipendija>();

            using (SqlConnection Veza = new SqlConnection(_konekcioniString))
            {
                //Veza.Open();
                //SqlCommand Komanda = new SqlCommand("DajSveStipendije", Veza);
                //Komanda.CommandType = CommandType.StoredProcedure;

                Veza.Open();
                SqlCommand Komanda = new SqlCommand("SELECT * FROM DajSveStipendijeView", Veza); 
                Komanda.CommandType = CommandType.Text;

                using (SqlDataReader Reader = Komanda.ExecuteReader())
                {
                    while (Reader.Read())
                    {
                        Stipendija stipendija = new Stipendija();
                        stipendija.Id = Convert.ToInt32(Reader["Id"]);
                        stipendija.DatumPocetka = Convert.ToDateTime(Reader["DatumPocetka"]);
                        stipendija.DatumKraja = Convert.ToDateTime(Reader["DatumKraja"]);
                        stipendija.Kriterijum = DajKriterijum(Convert.ToInt32(Reader["KriterijumId"]));
                        stipendija.Iznos = Convert.ToDecimal(Reader["Iznos"]);
                        stipendija.Naziv = Reader["Naziv"].ToString();

                        listaStipendija.Add(stipendija);
                    }
                }
            }

            return listaStipendija;
        }

        public Stipendija DobaviStipendijuPoId(int stipendijaId)
        {
            Stipendija stipendija = null;

            using (SqlConnection veza = new SqlConnection(_konekcioniString))
            {
                try
                {
                    veza.Open();

                    using (SqlCommand komanda = new SqlCommand("DobaviStipendijuPoId", veza))
                    {
                        komanda.CommandType = CommandType.StoredProcedure;
                        komanda.Parameters.AddWithValue("@StipendijaId", stipendijaId);

                        using (SqlDataReader reader = komanda.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Mapiranje podataka o stipendiji
                                stipendija = new Stipendija
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Iznos = Convert.ToDecimal(reader["Iznos"]),
                                    DatumPocetka = Convert.ToDateTime(reader["DatumPocetka"]),
                                    DatumKraja = Convert.ToDateTime(reader["DatumKraja"]),
                                    Kriterijum = DobaviKriterijumPoId(Convert.ToInt32(reader["KriterijumId"])),
                                    Naziv = reader["Naziv"].ToString()
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Obrada grešaka
                    Console.WriteLine($"Greška prilikom dohvatanja stipendije: {ex.Message}");
                }
            }

            return stipendija;
        }


        private Kriterijum DajKriterijum(int kriterijumId)
        {
            Kriterijum kriterijum = null;

            // Izvršite upit da biste dobili kriterijum sa datim ID-jem
            using (SqlConnection Veza = new SqlConnection(_konekcioniString))
            {
                Veza.Open();
                SqlCommand Komanda = new SqlCommand("SELECT * FROM Kriterijum WHERE Id = @KriterijumId", Veza);
                Komanda.Parameters.AddWithValue("@KriterijumId", kriterijumId);

                using (SqlDataReader Reader = Komanda.ExecuteReader())
                {
                    if (Reader.Read())
                    {                   
                        kriterijum = new Kriterijum();
                        kriterijum.Id = Convert.ToInt32(Reader["Id"]);
                        kriterijum.AkademskiUspeh = Convert.ToDouble(Reader["AkademskiUspeh"]);
                        kriterijum.DrustvenoAngazovanje = Convert.ToBoolean(Reader["DrustvenoAngazovanje"]);
                        kriterijum.FinansijskaPotreba = Convert.ToBoolean(Reader["FinansijskaPotreba"]);
                    }
                }
            }

            return kriterijum;
        }

        public Kriterijum DobaviKriterijumPoId(int kriterijumId)
        {
            Kriterijum kriterijum = null;

            using (SqlConnection veza = new SqlConnection(_konekcioniString))
            {
                try
                {
                    veza.Open();

                    using (SqlCommand komanda = new SqlCommand("DobaviKriterijumPoId", veza))
                    {
                        komanda.CommandType = CommandType.StoredProcedure;
                        komanda.Parameters.AddWithValue("@KriterijumId", kriterijumId);

                        using (SqlDataReader reader = komanda.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Mapiranje podataka o kriterijumu
                                kriterijum = new Kriterijum
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    AkademskiUspeh = Convert.ToDouble(reader["AkademskiUspeh"]),
                                    DrustvenoAngazovanje = Convert.ToBoolean(reader["DrustvenoAngazovanje"]),
                                    FinansijskaPotreba = Convert.ToBoolean(reader["FinansijskaPotreba"])
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Obrada grešaka
                    Console.WriteLine($"Greška prilikom dohvatanja kriterijuma: {ex.Message}");
                }
            }

            return kriterijum;
        }






    }
}

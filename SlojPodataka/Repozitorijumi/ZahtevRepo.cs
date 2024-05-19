using SlojPodataka.Interfejsi;
using SlojPodataka.Klase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlojPodataka.Repozitorijumi
{
    public class ZahtevRepo : IZahtevRepo
    {
        private string _konekcioniString;

        public ZahtevRepo(string konekcioniString)
        {
            _konekcioniString = konekcioniString;
        }

        public List<Zahtev> DajSveZahtevePoJmbgKorisnika(string jmbg)
        {
            List<Zahtev> listaZahteva = new List<Zahtev>();

            using (SqlConnection veza = new SqlConnection(_konekcioniString))
            {
                veza.Open();

                SqlCommand komanda = new SqlCommand("DajSveZahtevePoJmbgKorisnika", veza);
                komanda.CommandType = CommandType.StoredProcedure;
                komanda.Parameters.Add("@JmbgKorisnika", SqlDbType.NVarChar).Value = jmbg;

                using (SqlDataReader citac = komanda.ExecuteReader())
                {
                    while (citac.Read())
                    {
                        Zahtev zahtev = MapirajRedUZahtevObjekat(citac);
                        listaZahteva.Add(zahtev);
                    }
                }
            }

            return listaZahteva;
        }

        public List<Zahtev> DajSveZahteve()
        {
            List<Zahtev> zahtevi = new List<Zahtev>();

            using (SqlConnection veza = new SqlConnection(_konekcioniString))
            {
                SqlCommand komanda = new SqlCommand("DajSveZahteve", veza);
                komanda.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    veza.Open();

                    SqlDataReader reader = komanda.ExecuteReader();

                    while (reader.Read())
                    {
                        // Mapiranje reda u objekat Zahtev
                        Zahtev zahtev = new Zahtev
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            JmbgKorisnika = reader["JmbgKorisnika"].ToString(),
                            FinansijskaPotreba = Convert.ToBoolean(reader["FinansijskaPotreba"]),
                            DrustvenoAngazovanje = Convert.ToBoolean(reader["DrustvenoAngazovanje"]),
                            AkademskiUspeh = Convert.ToDouble(reader["AkademskiUspeh"]),
                            Razlozi = reader["Razlozi"].ToString(),
                            Status = reader["Status"].ToString()
                        };

                        zahtevi.Add(zahtev);
                    }
                }
                catch (Exception ex)
                {
                    // Obrada izuzetaka
                    Console.WriteLine("Greška prilikom čitanja podataka iz baze: " + ex.Message);
                }
            }

            return zahtevi;
        }

        public List<Zahtev> DajSveZahteveBezStatusaNula()
        {
            List<Zahtev> zahtevi = new List<Zahtev>();

            using (SqlConnection veza = new SqlConnection(_konekcioniString))
            {
                SqlCommand komanda = new SqlCommand("DajSveZahteveBezStatusaNula", veza);
                komanda.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    veza.Open();

                    SqlDataReader reader = komanda.ExecuteReader();

                    while (reader.Read())
                    {
                        // Mapiranje reda u objekat Zahtev
                        Zahtev zahtev = new Zahtev
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            JmbgKorisnika = reader["JmbgKorisnika"].ToString(),
                            FinansijskaPotreba = Convert.ToBoolean(reader["FinansijskaPotreba"]),
                            DrustvenoAngazovanje = Convert.ToBoolean(reader["DrustvenoAngazovanje"]),
                            AkademskiUspeh = Convert.ToDouble(reader["AkademskiUspeh"]),
                            Razlozi = reader["Razlozi"].ToString(),
                            Status = reader["Status"].ToString()
                        };

                        zahtevi.Add(zahtev);
                    }
                }
                catch (Exception ex)
                {
                    // Obrada izuzetaka
                    Console.WriteLine("Greška prilikom čitanja podataka iz baze: " + ex.Message);
                }
            }

            return zahtevi;
        }     

        public List<Zahtev> DajSveZahteveSaStatusomNula()
        {
            List<Zahtev> zahtevi = new List<Zahtev>();

            using (SqlConnection veza = new SqlConnection(_konekcioniString))
            {
                SqlCommand komanda = new SqlCommand("DajSveZahteveSaStatusomNula", veza);
                komanda.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    veza.Open();

                    SqlDataReader reader = komanda.ExecuteReader();

                    while (reader.Read())
                    {
                        // Mapiranje reda u objekat Zahtev
                        Zahtev zahtev = new Zahtev
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            JmbgKorisnika = reader["JmbgKorisnika"].ToString(),
                            FinansijskaPotreba = Convert.ToBoolean(reader["FinansijskaPotreba"]),
                            DrustvenoAngazovanje = Convert.ToBoolean(reader["DrustvenoAngazovanje"]),
                            AkademskiUspeh = Convert.ToDouble(reader["AkademskiUspeh"]),
                            Razlozi = reader["Razlozi"].ToString(),
                            Status = reader["Status"].ToString()
                        };

                        zahtevi.Add(zahtev);
                    }
                }
                catch (Exception ex)
                {
                    // Obrada izuzetaka
                    Console.WriteLine("Greška prilikom čitanja podataka iz baze: " + ex.Message);
                }
            }

            return zahtevi;
        }

        public void PrihvatiZahtev(int zahtevId)
        {
            using (SqlConnection veza = new SqlConnection(_konekcioniString))
            {
                SqlCommand komanda = new SqlCommand("PrihvatiZahtev", veza);
                komanda.CommandType = CommandType.StoredProcedure;
                komanda.Parameters.AddWithValue("@ZahtevId", zahtevId);

                try
                {
                    veza.Open();
                    komanda.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Greška prilikom izvršavanja stored procedure: " + ex.Message);
                }
            }
        }

        public void OdbijZahtev(int zahtevId)
        {
            using (SqlConnection veza = new SqlConnection(_konekcioniString))
            {
                SqlCommand komanda = new SqlCommand("OdbijZahtev", veza);
                komanda.CommandType = CommandType.StoredProcedure;
                komanda.Parameters.AddWithValue("@ZahtevId", zahtevId);

                try
                {
                    veza.Open();
                    komanda.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Greška prilikom izvršavanja stored procedure: " + ex.Message);
                }
            }
        }


        public bool NoviZahtev(Zahtev objNoviZahtev)
        {
            // Promenljiva za proveru uspešnosti unosa 
            int proveraUnosa = 0;

            using (SqlConnection Veza = new SqlConnection(_konekcioniString))
            {
                Veza.Open();
                SqlCommand Komanda = new SqlCommand("NoviZahtev", Veza);
                Komanda.CommandType = CommandType.StoredProcedure;
                Komanda.Parameters.Add("@JmbgKorisnika", SqlDbType.NVarChar).Value = objNoviZahtev.JmbgKorisnika;
                Komanda.Parameters.Add("@StipendijaId", SqlDbType.Int).Value = objNoviZahtev.StipendijaId;
                Komanda.Parameters.Add("@FinansijskaPotreba", SqlDbType.Bit).Value = objNoviZahtev.FinansijskaPotreba;
                Komanda.Parameters.Add("@DrustvenoAngazovanje", SqlDbType.Bit).Value = objNoviZahtev.DrustvenoAngazovanje;
                Komanda.Parameters.Add("@AkademskiUspeh", SqlDbType.Decimal).Value = objNoviZahtev.AkademskiUspeh;
                Komanda.Parameters.Add("@Razlozi", SqlDbType.NVarChar).Value = objNoviZahtev.Razlozi;
                Komanda.Parameters.Add("@Status", SqlDbType.NVarChar).Value = objNoviZahtev.Status;

                proveraUnosa = Komanda.ExecuteNonQuery();
            }

            // Vraća true ako je uspešno
            return (proveraUnosa > 0);
        }

        private Zahtev MapirajRedUZahtevObjekat(SqlDataReader red)
        {
            Zahtev zahtev = new Zahtev
            {
                Id = Convert.ToInt32(red["Id"]),
                JmbgKorisnika = red["JmbgKorisnika"].ToString(),
                StipendijaId = Convert.ToInt32(red["StipendijaId"]),
                Razlozi = red["Razlozi"].ToString(),
                FinansijskaPotreba = Convert.ToBoolean(red["FinansijskaPotreba"]),
                DrustvenoAngazovanje = Convert.ToBoolean(red["DrustvenoAngazovanje"]),
                AkademskiUspeh = Convert.ToDouble(red["AkademskiUspeh"]),
                Status = red["Status"].ToString()
            };

            return zahtev;
        }

        public Zahtev DobaviZahtevPoId(int zahtevId)
        {
            Zahtev zahtev = null;

            using (SqlConnection veza = new SqlConnection(_konekcioniString))
            {
                try
                {
                    veza.Open();

                    using (SqlCommand komanda = new SqlCommand("DobaviZahtevPoId", veza))
                    {
                        komanda.CommandType = CommandType.StoredProcedure;
                        komanda.Parameters.AddWithValue("@ZahtevId", zahtevId);

                        using (SqlDataReader reader = komanda.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                zahtev = new Zahtev
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    JmbgKorisnika = reader["JmbgKorisnika"].ToString(),
                                    StipendijaId = Convert.ToInt32(reader["StipendijaId"]),
                                    Razlozi = reader["Razlozi"].ToString(),
                                    FinansijskaPotreba = Convert.ToBoolean(reader["FinansijskaPotreba"]),
                                    DrustvenoAngazovanje = Convert.ToBoolean(reader["DrustvenoAngazovanje"]),
                                    AkademskiUspeh = Convert.ToDouble(reader["AkademskiUspeh"]),
                                    Status = reader["Status"].ToString()
                                };
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Greška prilikom dohvatanja zahteva: {ex.Message}");
                }
            }

            return zahtev;
        }

        public Zahtev DobaviZahtevPoJmbgKorisnikaIStipendijaId(string jmbgKorisnika, int stipendijaId)
        {
            Zahtev zahtev = null;

            using (SqlConnection connection = new SqlConnection(_konekcioniString))
            {
                SqlCommand command = new SqlCommand("DobaviZahtevPoJmbgKorisnikaIStipendijaId", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@JmbgKorisnika", SqlDbType.NVarChar).Value = jmbgKorisnika;
                command.Parameters.Add("@StipendijaId", SqlDbType.Int).Value = stipendijaId;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        zahtev = new Zahtev
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            JmbgKorisnika = reader["JmbgKorisnika"].ToString(),
                            StipendijaId = Convert.ToInt32(reader["StipendijaId"]),
                            Razlozi = reader["Razlozi"].ToString(),
                            FinansijskaPotreba = Convert.ToBoolean(reader["FinansijskaPotreba"]),
                            DrustvenoAngazovanje = Convert.ToBoolean(reader["DrustvenoAngazovanje"]),
                            AkademskiUspeh = Convert.ToDouble(reader["AkademskiUspeh"]),
                            Status = reader["Status"].ToString()
                        };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Greška prilikom čitanja podataka iz baze: " + ex.Message);
                }
            }

            return zahtev;
        }

        public List<Zahtev> DajSveZahteveSaAkademskimUspehomVecimOd(double minimalniAkademskiUspeh)
        {
            List<Zahtev> zahtevi = new List<Zahtev>();

            using (SqlConnection veza = new SqlConnection(_konekcioniString))
            {
                SqlCommand komanda = new SqlCommand("DajSveZahteveSaAkademskimUspehomVecimOd", veza);
                komanda.CommandType = System.Data.CommandType.StoredProcedure;
                komanda.Parameters.AddWithValue("@MinimalniAkademskiUspeh", minimalniAkademskiUspeh);

                try
                {
                    veza.Open();

                    SqlDataReader reader = komanda.ExecuteReader();

                    while (reader.Read())
                    {
                        // Mapiranje reda u objekat Zahtev
                        Zahtev zahtev = new Zahtev
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            JmbgKorisnika = reader["JmbgKorisnika"].ToString(),
                            FinansijskaPotreba = Convert.ToBoolean(reader["FinansijskaPotreba"]),
                            DrustvenoAngazovanje = Convert.ToBoolean(reader["DrustvenoAngazovanje"]),
                            AkademskiUspeh = Convert.ToDouble(reader["AkademskiUspeh"]),
                            Razlozi = reader["Razlozi"].ToString(),
                            Status = reader["Status"].ToString()
                        };

                        zahtevi.Add(zahtev);
                    }
                }
                catch (Exception ex)
                {
                    // Obrada izuzetaka
                    Console.WriteLine("Greška prilikom čitanja podataka iz baze: " + ex.Message);
                }
            }

            return zahtevi;
        }

        public List<Zahtev> DajSveZahteveSaAkademskimUspehomVecimIliJednakim(double minimalniAkademskiUspeh)
        {
            List<Zahtev> zahtevi = new List<Zahtev>();

            using (SqlConnection veza = new SqlConnection(_konekcioniString))
            {
                SqlCommand komanda = new SqlCommand("DajSveZahteveSaAkademskimUspehomVecimIliJednakim", veza);
                komanda.CommandType = System.Data.CommandType.StoredProcedure;
                komanda.Parameters.AddWithValue("@MinimalniAkademskiUspeh", minimalniAkademskiUspeh);

                try
                {
                    veza.Open();

                    SqlDataReader reader = komanda.ExecuteReader();

                    while (reader.Read())
                    {
                        // Mapiranje reda u objekat Zahtev
                        Zahtev zahtev = new Zahtev
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            JmbgKorisnika = reader["JmbgKorisnika"].ToString(),
                            FinansijskaPotreba = Convert.ToBoolean(reader["FinansijskaPotreba"]),
                            DrustvenoAngazovanje = Convert.ToBoolean(reader["DrustvenoAngazovanje"]),
                            AkademskiUspeh = Convert.ToDouble(reader["AkademskiUspeh"]),
                            Razlozi = reader["Razlozi"].ToString(),
                            Status = reader["Status"].ToString()
                        };

                        zahtevi.Add(zahtev);
                    }
                }
                catch (Exception ex)
                {
                    // Obrada izuzetaka
                    Console.WriteLine("Greška prilikom čitanja podataka iz baze: " + ex.Message);
                }
            }

            return zahtevi;
        }

    }
}

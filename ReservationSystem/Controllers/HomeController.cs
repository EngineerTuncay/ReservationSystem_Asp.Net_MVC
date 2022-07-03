//Model içinde yer alan Masalar & Kisiler'in kullanılabilmesi için namespace'inin tanımlanması
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
//Sql baglantı kütüphanelerinin tanımlanması
using System.Data.SqlClient;
using System.Web.Mvc;

namespace ReservationSystem.Controllers
{
    public class HomeController : Controller
    {

        
        // GET: Home
        public ActionResult Index()
        {

            SqlConnection con;
            SqlCommand cmd;

            con = new SqlConnection("server=.;Initial Catalog=ReservationSystems; Integrated Security=SSPI");

            List<Kisiler> DKisiler = new List<Kisiler>();
            //Kişiler tablomuzda bulunan tüm elemanlar
            string sql = "SELECT * FROM Kisiler";
            con.Open();
            cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            //Tüm elemanlar ExecureReader ile dr'a okundu
            //dr içindeki tüm elemanlar Dkisiler adlı Listeye eklendi
            while (dr.Read())
            {
                Kisiler Kisi = new Kisiler();
                Kisi.id = Convert.ToInt16(dr[0]);
                Kisi.Ad = dr[1].ToString();
                Kisi.TelNo = dr[2].ToString();
                Kisi.KisiSayisi = Convert.ToInt16(dr[3]);
                Kisi.MasaNo = Convert.ToInt16(dr[4]);
                Kisi.SaatAraligi = Convert.ToString(dr[5]);
                //değiştirdiğim yer aşağıda
                DKisiler.Add(Kisi);
                //değiştirdiğim yer yukarıda
            }
            con.Close();


            //Masaların veri tabanından getirilmesi
            con = new SqlConnection("server=.;Initial Catalog=ReservationSystems; Integrated Security=SSPI");

            List<Masalar> DMasalar= new List<Masalar>();
            sql = "SELECT * FROM Masalar";
            con.Open();
            cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Masalar Masa = new Masalar();
                Masa.id = Convert.ToInt16(dr[0]);
                Masa.MasaNo = Convert.ToInt16(dr[1]);

                Masa.H8_9 = Convert.ToBoolean(dr[2]);
                Masa.H9_10 = Convert.ToBoolean(dr[3]);
                Masa.H10_11 = Convert.ToBoolean(dr[4]);
                Masa.H11_12 = Convert.ToBoolean(dr[5]);
                Masa.H12_13 = Convert.ToBoolean(dr[6]);
                Masa.H13_14 = Convert.ToBoolean(dr[7]);
                Masa.H14_15 = Convert.ToBoolean(dr[8]);
                Masa.H15_16 = Convert.ToBoolean(dr[9]);
                Masa.H16_17 = Convert.ToBoolean(dr[10]);
                Masa.H17_18 = Convert.ToBoolean(dr[11]);
                Masa.H18_19 = Convert.ToBoolean(dr[12]);
                Masa.H19_20 = Convert.ToBoolean(dr[13]);
                Masa.H20_21 = Convert.ToBoolean(dr[14]);
                Masa.H21_22 = Convert.ToBoolean(dr[15]);
                Masa.H22_23 = Convert.ToBoolean(dr[16]);
                Masa.H23_24 = Convert.ToBoolean(dr[17]);
                //değiştirdiğim yer aşağıda
                DMasalar.Add(Masa);
                //değiştirdiğim yer yukarıda
            }
            con.Close();

            ViewBag.masalar = DMasalar;

            return View(DKisiler);
        }

        [HttpGet]
        public ActionResult KisiEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KisiEkle(string Ad, string TelNo, int KisiSayisi, int MasaNo, string SaatAraligi)
        {
            //KisiEkle View'indeki Buton'un Submit edilmesi üzerine TextBox'taki veriler buraya getirildi.
            Kisiler YeniKisi = new Kisiler();

            YeniKisi.Ad = Ad;
            YeniKisi.TelNo = TelNo;
            YeniKisi.KisiSayisi=KisiSayisi;
            YeniKisi.MasaNo = MasaNo;
            YeniKisi.SaatAraligi = SaatAraligi;

            SqlConnection con;
            SqlCommand cmd;

            con = new SqlConnection("server=.;Initial Catalog=ReservationSystems; Integrated Security=SSPI");
            //sorgu ile yeni bir üye veri tabanına eklenir
            string Qery = "INSERT INTO Kisiler(Ad,TelNo,KisiSayisi,MasaNo,SaatAraligi) VALUES (@Ad,@TelNo,@KisiSayisi,@MasaNo,@SaatAraligi)";

            cmd = new SqlCommand(Qery, con);

            cmd.Parameters.AddWithValue("@Ad", YeniKisi.Ad);
            cmd.Parameters.AddWithValue("@TelNo", YeniKisi.TelNo);
            cmd.Parameters.AddWithValue("@KisiSayisi", YeniKisi.KisiSayisi);
            cmd.Parameters.AddWithValue("@MasaNo", YeniKisi.MasaNo);
            cmd.Parameters.AddWithValue("@SaatAraligi", YeniKisi.SaatAraligi);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            return View();
        }

        public ActionResult KisiGuncelle(int id)
        {
            //View'den gelen id ile kişi bilgileri veri tabanından çekilir ve KisiGuncelle View'ine gönderilir
            int Id = id;

            SqlConnection con;
            SqlCommand cmd;

            con = new SqlConnection("server=.;Initial Catalog=ReservationSystems; Integrated Security=SSPI");

            List<Kisiler> DKisiler = new List<Kisiler>();
            string sql = "SELECT * FROM Kisiler";
            con.Open();
            cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();

            Kisiler Kisi = new Kisiler();

            while (dr.Read())
            {
                if (Convert.ToInt16(dr[0]) == Id)
                {
                    Kisi.id = Convert.ToInt16(dr[0]);
                    Kisi.Ad = dr[1].ToString();
                    Kisi.TelNo = dr[2].ToString();
                    Kisi.KisiSayisi = Convert.ToInt16(dr[3]);
                    Kisi.MasaNo = Convert.ToInt16(dr[4]);
                    Kisi.SaatAraligi = Convert.ToString(dr[5]);
                }
            }
            con.Close();

            return View(Kisi);
        }

        public ActionResult KisiSil(int id)
        {
            //view'den gelen id değerini kullanarak veri tanından misafir silinir.

            int Id = id;

            SqlConnection con;
            SqlCommand cmd;
            con = new SqlConnection("server=.;Initial Catalog=ReservationSystems; Integrated Security=SSPI");
            string Qery = "DELETE FROM Kisiler WHERE  id=@id";
            cmd = new SqlCommand(Qery, con);
            cmd.Parameters.AddWithValue("@id",Id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            //Veri tabanından misafir bilgileri çekilir, Index view'e model yoluyla gönderilir ve Index View görüntülenir

            List<Kisiler> DKisiler = new List<Kisiler>();
            string sql = "SELECT * FROM Kisiler";
            con.Open();
            cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Kisiler Kisi = new Kisiler();
                Kisi.id = Convert.ToInt16(dr[0]);
                Kisi.Ad = dr[1].ToString();
                Kisi.TelNo = dr[2].ToString();
                Kisi.KisiSayisi = Convert.ToInt16(dr[3]);
                Kisi.MasaNo = Convert.ToInt16(dr[4]);
                Kisi.SaatAraligi = Convert.ToString(dr[5]);
                //değiştirdiğim yer aşağıda
                DKisiler.Add(Kisi);
                //değiştirdiğim yer yukarıda
            }
            con.Close();

            //Diğer View'lerden farklı olarak Index View'i çağılır ve çağırma esnasında DKisiler Model olarak View'e gönderilir.
            //KişiSil'e ait bir View bulunmamaktadır.
            return View("Index",DKisiler);
        }

        public ActionResult UpDate(int Id, string Ad, string TelNo, int KisiSayisi, int MasaNo, string SaatAraligi)
        {
            //Kişi bilgileri KisiGuncelleme sayfasından UpDate Controller'ına getirilir.
            Kisiler YeniKisi = new Kisiler();

            YeniKisi.id = Id;
            YeniKisi.Ad = Ad;
            YeniKisi.TelNo = TelNo;
            YeniKisi.KisiSayisi = KisiSayisi;
            YeniKisi.MasaNo = MasaNo;
            YeniKisi.SaatAraligi = SaatAraligi;

            SqlConnection con;
            SqlCommand cmd;

            con = new SqlConnection("server=.;Initial Catalog=ReservationSystems; Integrated Security=SSPI");

            string Qery = "UPDATE Kisiler SET Ad=@Ad, TelNo=@TelNo, KisiSayisi=@KisiSayisi, MasaNo=@MasaNo, SaatAraligi=@SaatAraligi WHERE id=@id";

            cmd = new SqlCommand(Qery, con);

            cmd.Parameters.AddWithValue("@id", YeniKisi.id);
            cmd.Parameters.AddWithValue("@Ad", YeniKisi.Ad);
            cmd.Parameters.AddWithValue("@TelNo", YeniKisi.TelNo);
            cmd.Parameters.AddWithValue("@KisiSayisi", YeniKisi.KisiSayisi);
            cmd.Parameters.AddWithValue("@MasaNo", YeniKisi.MasaNo);
            cmd.Parameters.AddWithValue("@SaatAraligi", YeniKisi.SaatAraligi);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            //Veri tabanından misafir bilgileri çekilir, Index view'e model yoluyla gönderilir ve Index View görüntülenir

            List<Kisiler> DKisiler = new List<Kisiler>();
            string sql = "SELECT * FROM Kisiler";
            con.Open();
            cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Kisiler Kisi = new Kisiler();
                Kisi.id = Convert.ToInt16(dr[0]);
                Kisi.Ad = dr[1].ToString();
                Kisi.TelNo = dr[2].ToString();
                Kisi.KisiSayisi = Convert.ToInt16(dr[3]);
                Kisi.MasaNo = Convert.ToInt16(dr[4]);
                Kisi.SaatAraligi = Convert.ToString(dr[5]);
                //değiştirdiğim yer aşağıda
                DKisiler.Add(Kisi);
                //değiştirdiğim yer yukarıda
            }
            con.Close();

            //Diğer View'lerden farklı olarak Index View'i çağılır ve çağırma esnasında DKisiler Model olarak View'e gönderilir.
            //UpDate Controller'ının diğer Controller'lardan farklı olarak View'i bulunmamaktadır. Doğrudan Index View'i çağırır.
            return View("Index", DKisiler);
        }

    }
}
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ReservationSystem.Views.Home.Default" %>

<%@ Import Namespace="ReservationSystem.Controllers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Rezervasyon Sistemi</title>
    <link href="StyleSheet.css" rel="stylesheet" />
    </head>
<body>
    <form id="form1" runat="server">
        
        <h1 class="Baslik"> Rezervasyon Sistemine Hoşgeldiniz... </h1>

        <table class="DisTabloOzellikleri" >
            <tr>
                <td>
                    <table class="IcTabloBir">
                    <tr>
                        <td class="TdUzunlukAyari"> Misafir İsmi: </td>
                        <td class="TdUzunlukAyari"> Misafir İletişim: </td>
                        <td class="TdUzunlukAyari"> Masa No: </td>
                        <td class="TdUzunlukAyari"> Kişi Sayısı: </td>
                        <td class="TdUzunlukAyari"> Ziyaret Saati: </td>
                    </tr>
                    @foreach (var Kisi in (List<Kisiler>)Model)
                    {
                        <tr>
                            <td> @Kisi.Ad </td>
                            <td> @Kisi.TelNo </td>
                            <td> @Kisi.MasaNo </td>
                            <td> @Kisi.KisiSayisi </td>
                            <td> @Kisi.SaatAraligi </td>
                            <td> <a href="/Home/KisiGuncelle/@Kisi.id" role="button" style="width:80%; margin: 10% 10% 1% 10%; font-weight:bold; color: black"> Güncelle </a> </td>
                            <td> <a href="/Home/KisiSil/@Kisi.id" role="button" style="width:80%; margin: 1% 10% 1% 10%; font-weight:bold; color: black"> Sil </a> </td>
                        </tr>
                    }
                    <tr>


                    <tr>
                        <td style="height:50px;">
                            <a href="/Home/KisiEkle" role="button" style="width:80%; margin: 10% 10% 1% 10%; font-weight:bold; color: black"> Yeni Misafir Ekle </a>
                        </td>
                    </tr>
                    

                </table>
                    </table>
                </td>
                <td>
                    <table class="IcTabloIki">
                        <tr>
                            <td> <asp:Image ID="Image1" runat="server" ImageUrl="~/Yemek Masası.jpg" CssClass="GorselOzellikleri" /></td>
                            <td> <asp:Image ID="Image2" runat="server" ImageUrl="~/Yemek Masası.jpg" CssClass="GorselOzellikleri"/> </td>
                        </tr>
                        <tr>
                            <td> <asp:Image ID="Image3" runat="server" ImageUrl="~/Yemek Masası.jpg" CssClass="GorselOzellikleri"/> </td>
                            <td> <asp:Image ID="Image4" runat="server" ImageUrl="~/Yemek Masası.jpg" CssClass="GorselOzellikleri"/> </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>

    </form>
</body>
</html>

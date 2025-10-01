<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HelloWorld._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">ASP.NET</h1>
            <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
            <p><a href="http://www.asp.net" class="btn btn-primary btn-md">HOOALA MIAFINA &raquo;</a></p>
        </section>

        <div>
            <asp:Label ID="labelTexto" runat="server" Text="Ayuda"></asp:Label>
            <asp:Button ID="Button1" runat="server" Text="BOTON DE LA MUERTE" OnClick="Button1_Click2"/>
        </div>
    </main>

</asp:Content>

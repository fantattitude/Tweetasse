<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Tweetasse - Manage your account
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	
		
		<div class='contentDiv'>
		<p style="text-align: center;">Bonjour <%= ViewData["username"]%>
		<% if (Session["LoggedTwitter"] == null)
	 {%>
			, votre compte n'est pas associé à un compte Twitter, vous ne pouvez donc rien faire pour l'instant.<br />Pour associer votre compte à un compte Twitter cliquez sur le bouton ci-dessous.<br /><br /><a class="connectToTwitter" href="/Account/ConnectToTwitter"></a><%}
	 else
	 {%>
			, votre compte est associé au compte Twitter : <strong>@<%= ((Tweetasse.Models.User)Session["LoggedUser"]).TwitterUsername%></strong><br />Vous pouvez donc utiliser toutes les fonctionnalités du client!
		<%} %>

		</p>
	</div>
</asp:Content>

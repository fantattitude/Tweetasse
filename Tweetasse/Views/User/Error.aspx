<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Tweetasse - Error occured :'(
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="contentDiv">
		<% if (ViewData["errorMessage"] != null)
		 { %>
			<p style="text-align: center;">
				<strong><%= ViewData["errorMessage"]%><br />
				<img src='/Content/TrollFace.png' /><br />
				Problem ?</strong>
			</p>
		<%} %>

	</div>
</asp:Content>

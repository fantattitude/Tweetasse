<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Tweetasse - User profile of <%= ViewData["username"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class='merciDavid'><% Html.BeginForm("GoToUser", "Home"); %>
				<input type="text" name="username" placeholder="Search for User" />
				<input type="submit" value="Search for User!" />
			<% Html.EndForm(); %></div>
		<div class="contentDiv">
			
		<strong><%= ViewData["content"]%></strong>
		<hr />
	
		<%= ViewData["tweets"]%>
		
	</div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Tweetasse, le client Twitter des shagasse
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
		<div class='merciDavid'><% Html.BeginForm("GoToUser", "Home"); %>
				<input type="text" name="username" placeholder="Search for User" />
				<input type="submit" value="Search for User!" />
			<% Html.EndForm(); %></div><br />
		<% if (Session["LoggedASP"] != null && Session["LoggedTwitter"] != null && Session["DatabaseMode"] == null)
		 { %>
			<a id="saveToDb" href="#"><strong>Save your Home Timeline to DB</strong></a>
		<%} %>
		<div class="contentDiv">
		<% if (Session["LoggedTwitter"] != null && Session["DatabaseMode"] == null)
		 {
			 Html.BeginForm("HandleTweet", "Home"); %>
				<%: Html.TextArea("tweet")%>
				<input class='submitTweet' type="submit" value="Tweet !" />
				<% Html.EndForm(); %>
		 
		<hr />
		<%}%>
		
			<%= ViewData["Message"]%>
		</div>
		<div id="editFuckingTweet">
			<form action="/Tweet/Edit" method="POST" id="editFuckingTweetForm">
				<input type="text" placeholder="Text" name="textTweet" id="textTweet" /><br />
				<input type="hidden" id="hiddenID" name="hiddenID" value="" />
				<input type="button" id="cancelEditTweet" value="Cancel" /><input type="submit" value="Edit!" />
			</form>
		</div>
		<script type="text/javascript" language="javascript">
			$(document).ready(function () {
				$(".editTweetA").click(function () {
					var currentLink = $(this);
					$.ajax({
						type: "POST",
						url: $(this).attr("href"),
						success: function (msg) {
							if (msg != "Fail") {
								$("#textTweet").val(msg);
								$("#editFuckingTweet").fadeIn("slow");
								$("#hiddenID").val(currentLink.attr('rel'));
							}
						}
					});
					return false;
				});

				$("#cancelEditTweet").click(function () {
					$("#editFuckingTweet").fadeOut("slow");
					return false;
				});

				$("#editFuckingTweetForm").submit(function () {
					$.ajax({
						type: "POST",
						url: '/Tweet/EditPost/',
						data: 'id=' + $("#hiddenID").val() + '&text=' + $('#textTweet').val(),
						success: function (msg) {
							$("#editFuckingTweet").fadeOut("slow");
							$.ajax({
								type: "POST",
								url: '/Tweet/GetTweetCode/',
								data: 'id='+$("#hiddenID").val(),
								success: function (msg2) {
									$(".editTweetA[rel='" + $("#hiddenID").val() + "']").parent().parent().html(msg2);
								}
							});

						}
					});
					return false;
				});

				$('#saveToDb').click(function () {
					$.ajax({
						type: "POST",
						url: "/Home/AjaxSaveToDB",
						beforeSend: function () {
							$("body").append("<div class='popupYeah' style='color: white;display:none; background-color: rgba(0,0,0,0.75); border-radius: 6px; position: fixed; width: 200px; height: 200px; left: 50%; top: 50%; margin-left: -100px; margin-top: -100px;'><br /><br /><br /><img src='/Content/ajax-loader.gif' /><p><strong>Loading !</strong></p></div>");
							$('.popupYeah').fadeIn("slow");
						},
						success: function (msg) {
							if (msg == "Success") {
								$('.popupYeah').queue(function (n) {
									$('.popupYeah').html("<br /><br /><img style='width: 64px; height:64px;' src='/Content/tick.png' /><p><strong>Success!</strong></p>");
									n();
								}).delay(4000).fadeOut("slow", function () {
									$('.popupYeah').remove();
								});
							}
							else {
								$('.popupYeah').queue(function (n) {
									$('.popupYeah').html("<br /><br /><img style='width: 64px; height:64px;' src='/Content/sad-face.png' /><p><strong>Fail!</strong></p>");
									n();
								}).delay(4000).fadeOut("slow", function () {
									$('.popupYeah').remove();
								});
							}
						}
					});
					return false;
				});

				$('.deleteLink').click(function () {
					var currentLink = $(this);
					$.ajax({
						type: "POST",
						url: currentLink.attr('href'),
						success: function (msg) {
							if (msg == "Success") {
								currentLink.parent().parent().hide('slow', function () {
									currentLink.parent().parent().remove();
								});
							}
							else if (msg == "Fail1") {
								currentLink.parent().parent().hide('slow', function () {
									currentLink.parent().parent().remove();
								});
							}
							else
								$("body").append("DAMNED");
						}
					});
					return false;
				});
			});
		</script>
</asp:Content>

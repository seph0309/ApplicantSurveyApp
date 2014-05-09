<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SurveyPageFinish.aspx.cs" Inherits="ApplicantSurveyApp.Web.SurveyPageFinish" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server"> 
    <%--<link rel="stylesheet" href="Scripts/WebForms/Carousel/CSS/demo.css" type="text/css" media="screen" />--%>
    <link rel="stylesheet" href="Scripts/WebForms/Carousel/CSS/flexslider.css" type="text/css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    
      <section class="featured">
        <div class="content-wrapper">
        <hgroup class="title">
         <h2>
                Thank you for answering the survey! :)
         </h2>
        </hgroup>  
        </div> 
          </section> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
        <h3>
            <p>
                To learn more about Deltek, visit <a href="http://Deltek.com" title="Deltek Website">http://deltek.com</a>.
                Or like us on: <br />
                <a href="https://www.facebook.com/HappyAtDeltek">
                    www.facebook.com/HappyAtDeltek
                              </a> 
            </p>
        </h3> 
      <div id="loadingDiv">
          <b>Loading images.... </b>
          <img src="Images/LoadingBar.gif" />
      </div>
      <section class="slider">
        <div id="slider" class="flexslider">
          <ul class="slides" id="ulSlides">
          <%--      <li>
  	    	    <img src="Images/CarouselImages/IMG_4569.JPG" />
                </li>--%>
  	              <%--OTHER IMAGES WILL BE LOADED FROM GetImages()--%>
          </ul>
        </div> 
      </section> 

    <h3>
    <asp:HyperLink runat="server" ID="SurveyPage" NavigateUrl="~/SurveyPage.aspx" Text="Go back to Survey"></asp:HyperLink>
    </h3>

    <script defer src="Scripts/WebForms/Carousel/jquery.flexslider.js"></script>

    <script type="text/javascript">
        //Get Images
        $(document).ready(function () {

            var $loading = $('#loadingDiv').hide();
            $(document)
              .ajaxStart(function () {
                  $loading.show();
              });

            $.ajax({
                type: "POST",
                async: false,
                url: "SurveyPageFinish.aspx/GetImages",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var images = response.d;
                    $.each(images, function (index, image) {
                        $('#ulSlides').append(
                            '<li>' +
                            '<img src="' + image.location + '" />' +
                            '</li>'
                            );
                    });
                },
                failure: function (msg) {
                    alert(msg.d);
                }
            });
        });

        $(window).load(function () {
               $('#slider').flexslider({
                animation: "slide",
                controlNav: true,
                animationLoop: false,
                slideshow: true,
                slideshowSpeed: 3000,
                randomize: true,
                directionNav: false,
                smoothHeight: false
               });

               $('#loadingDiv').hide(); 
        });
    </script>
</asp:Content>

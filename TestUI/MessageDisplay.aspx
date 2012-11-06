<%@ Page language="VB" Inherits="MessageDisplay"  enableViewState="false"  %>

<html>
   <head>
      <title>
      <%=Me.Header%>
      </title>
      <%=Me.RedirectMetaTag%>
      <base href='<%= Me.BasePath %>/' />
       <link href="App_Themes/MMTheme/mm.css" rel="stylesheet" type="text/css" />
   </head>
   <body style="margin-top:0px;margin-left:0px">
      
      <table BORDER="0" CELLSPACING="0" CELLPADDING="0" WIDTH="100%"  style="height:100%">
         <tr>
           <td class="categorylistbackground" valign="top"><br>
            </td>

            <!-- Custom Form Stuff -->
            <td VALIGN="top" BGCOLOR="#ffffff" CLASS="body" WIDTH="*">
               <form ID="form1" RUNAT="server">
                  <br>
                  <table border="0" width="97%">
                     <tr>
                        <td class="gridheader"  align="center" height="35">
                           <asp:label ID="lblHeader" RUNAT="server" FONT-BOLD="True" Font-Size="16pt"></asp:label>
                        </td>
                     </tr>
                     <tr>
                        <td>
                           <br>
                           <blockquote>
                              <asp:label ID="lblMessage" RUNAT="server"></asp:label>
                              <br>
                              <p></p>
                           </blockquote>
                           <center><small><asp:label ID="lblRedirectHyperLink" RUNAT="server"></asp:label></small></center>
                        </td>
                     </tr>
                  </table>
               </form>
            </td>
         </tr>
         <!-- End Custom Form Stuff -->
      </table>
   </body>
</html>

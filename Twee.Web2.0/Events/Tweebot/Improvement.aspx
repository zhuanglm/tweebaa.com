<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPages/Tweebot.Master" AutoEventWireup="true" CodeBehind="Improvement.aspx.cs" Inherits="TweebaaWebApp2.Events.Tweebot.Improvement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="WebTitle" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="WebCssAndJs" runat="server">
    <link rel="stylesheet" href="/plugins/sky-forms/version-2.0.1/css/custom-sky-forms.css"> 
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="WebContent" runat="server">
  <!--=== Breadcrumbs ===-->
    <div class="breadcrumbs">
        <div class="container">
            <h1 class="pull-left">Improvement</h1>
            <ul class="pull-right breadcrumb">
                <li><a href="/Events/Tweebot/">Home</a></li>
                <li><a href="#">Improvement</a></li>
                
            </ul>
        </div>
    </div>
    <!--=== End Breadcrumbs ===-->  
 
     <div class="container content"> 
     <div class="row margin-bottom-30">
     <div class="col-sm-3">
      <form class="sky-form">     
          <section>
      <label class="select">
            <select>
                                    <option value="0">Out fit</option>
                                    <option value="1">Sound</option>
                                    <option value="2">Alice</option>
                                    <option value="3">Anastasia</option>
                                    <option value="4">Avelina</option>
                                </select>
                                <i></i>
                            </label>
                        </section></form></div>
     <div class="col-sm-3">
      <form class="sky-form">     
          <section>
      <label class="input">
                                            <i class="icon-append fa fa-calendar"></i>
                                            <input type="text" name="date" id="date" class="hasDatepicker">
                                        </label>
                        </section></form></div>                   
     <div class="col-sm-6">
     <div class="input-group">
                    <input type="text" class="form-control" placeholder="Search words with regular expressions ...">
                    <span class="input-group-btn">
                        <button class="btn-u" type="button"><i class="fa fa-search"></i></button>
                    </span>
                     
                </div></div>
      
                
       </div>         
     <div class="row margin-bottom-30 pull-right">
     <button class="btn btn-lg rounded btn-primary" type="button" onclick="window.location.href='/Events/Tweebot/Submit_Suggestion.aspx'">Submit Suggestion</button>
     </div>           
                  
<div class="table-search-v1 margin-bottom-30">
                        <div class="table-responsive">
                            <table class="table table-hover">
                                <thead>
                                    <tr>
                                        <th  width="15%" class="hidden-sm">Classification</th>
                                        <th width="55%">Title/Description</th>
                                      
                                        <th >Submitter</th>
                                        <th width="15%" class="hidden-sm">Time</th>
                                        
                                    </tr>
                                </thead>
                                <tbody id="suggestion_listings">
<!--
                                    <tr>
                                        <td>
                                            <a href="#">Out Fit </a>
                                        </td>
                                        <td class="td-width">
                                        <h3><a href="#">Sed nec elit arcu</a></h3>
                                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec porttitor arcu.</td>
                                       
                                   <td>
                                       Snow
                                        </td>
                                          <td>
                                      JUN 02 2015
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="#">Out Fit </a>
                                        </td>
                                        <td class="td-width">
                                        <h3><a href="#">Sed nec elit arcu</a></h3>
                                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec porttitor arcu.</td>
                                       
                                   <td>
                                       Snow
                                        </td>
                                          <td>
                                      JUN 02 2015
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="#">Out Fit </a>
                                        </td>
                                        <td class="td-width">
                                        <h3><a href="#">Sed nec elit arcu</a></h3>
                                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec porttitor arcu.</td>
                                       
                                   <td>
                                       Snow
                                        </td>
                                          <td>
                                      JUN 02 2015
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="#">Out Fit </a>
                                        </td>
                                        <td class="td-width">
                                        <h3><a href="#">Sed nec elit arcu</a></h3>
                                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec porttitor arcu.</td>
                                       
                                   <td>
                                       Snow
                                        </td>
                                          <td>
                                      JUN 02 2015
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="#">Out Fit </a>
                                        </td>
                                        <td class="td-width">
                                        <h3><a href="#">Sed nec elit arcu</a></h3>
                                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec porttitor arcu.</td>
                                       
                                   <td>
                                       Snow
                                        </td>
                                          <td>
                                      JUN 02 2015
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <a href="#">Out Fit </a>
                                        </td>
                                        <td class="td-width">
                                        <h3><a href="#">Sed nec elit arcu</a></h3>
                                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec porttitor arcu.</td>
                                       
                                   <td>
                                       Snow
                                        </td>
                                          <td>
                                      JUN 02 2015
                                        </td>
                                    </tr>
 -->                                  
                                </tbody>
                            </table>
                            <div class="text-right">
                                <ul class="pagination" id="pageNav">
                                </ul>
                            </div>
                        </div>    
                    </div>
         </div>            
     
   <script type="text/javascript">
       $(document).ready(function () {
           Load_Suggestions_total();
       });
   </script>     
</asp:Content>

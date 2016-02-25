<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePersonalData.aspx.cs" Inherits="TweebaaWebApp.Home.HomePersonalData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">
<head>
    <meta http-equiv="Content-Type" content="text/html;charset=UTF-8" />
    <title>Personal Settings</title>
    <link rel="stylesheet" href="../css/index.css" />
    <link rel="stylesheet" href="../css/home.css" />
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery.placeholder.js" type="text/javascript"></script>
    <script src="../js/selectNav.js" type="text/javascript"></script>
    <script src="../js/homePage.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/jquery-hcheckbox.js"></script>
    <link rel="stylesheet" href="../css/selectCss.css" />
    <script src="../js/selectCss.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/public.js"></script>
    <script type="text/javascript" src="../MethodJs/homePersonalData.js"></script>
</head>
<body>
    <div class="home-main fl">
        <div class="personal-main">
            <h2 class="t">Profile Setting</h2>
            <table width="100%">
                <tr>
                    <td class="tr">User Name
                    </td>
                    <td><span id="user-name"></span>
                    </td>
                </tr>
                <tr>
                    <td class="tr">Personal Image
                    </td>
                    <td>
                        <iframe src="HomePersionalDataUploadHead.aspx" style="overflow: hidden; border:none;" frameborder=0,scrolling="no" ></iframe>
                    </td>
                </tr>
                <tr>
                    <td class="tr">Sex
                    </td>
                    <td>
                        <div id="radiolist" style="font-size: 14px;">
                            <input name="r" type="radio" value="11" checked="" style="display: none;"><label id="gender-man" class="hRadio">Male</label>
                            <input name="r" type="radio" value="21" style="display: none;"><label id="gender-woman" class="hRadio">Female</label>
                            <input name="r" type="radio" value="31" style="display: none;"><label id="gender-secret" class="hRadio_Checked hRadio">Confidential</label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="tr">Date of Birth
                    </td>
                    <td>
                        <div class="clearfix y-m-d">
                            <div class="selectBox pr fl month">
                                <select id="birthday-month" name="birthday-month" class="selects">
                                    <option selected="selected" value="-1">Month</option>
                                    <% for (int i = 1; i <= 12; i++)
                                       { %>
                                    <option value="<%= i %>"><%= i %></option>
                                    <%  } %>
                                </select>
                            </div>
                            <div class="selectBox pr fl day">
                                <select id="birthday-date" name="birthday-date" class="selects">
                                    <option value="-1">day</option>
                                    <% for (int i = 1; i <= 31; i++)
                                       { %>
                                    <option value="<%= i %>"><%= i %></option>
                                    <%  } %>
                                </select>
                            </div>
                            <div class="selectBox pr fl year">
                                <select id="birthday-year" name="birthday-year" class="selects">
                                    <option value="-1">Year</option>
                                    <% for (int i = 1950; i <= DateTime.Now.Year; i++)
                                       { %>
                                    <option value="<%= i %>"><%= i %></option>
                                    <%  } %>
                                </select>
                            </div>
                        </div>

                    </td>
                </tr>
                <tr style="display:none">
                    <td class="tr">Occupation
                    </td>
                    <td>
                        <div class="selectBox pr fl">
                            <select id="job" name="job" class="selects">
                                <option value="-1">--select--</option>
                                <%  var mgr = new Twee.Mgr.UserMgr();
                                    foreach (var item in mgr.GetJobList())
                                    {%>
                                <option value="<%=item.Id.ToString() %>"><%=item.Name %></option>
                                <%} %>
                            </select>
                        </div>
                    </td>
                </tr>
                <tr><td class="tr">	</td> 
                    <td><a href="#" class="btns btn-2"  style="padding:8px 30px;" id="save-personal">Save</a>	</td></tr>
            </table>
        </div>
    </div>
    <script type="text/javascript">
        // select 美化
        $(".selects").selectCss();
    </script>
</body>
</html>

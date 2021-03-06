﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="TweebaaWebApp2.Mgr.main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="ui/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="ui/themes/demo.css" rel="stylesheet" type="text/css" />
    <link href="ui/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="ui/jquery.min.js" type="text/javascript"></script>
    <script src="ui/jquery.easyui.min.js" type="text/javascript"></script>
</head>
<body class="easyui-layout">
    <form id="form1" runat="server">
    <div data-options="region:'north',border:false" style="height:40px;background:#005999;padding:10px; vertical-align:middle; color:white; font-weight:bolder; font-size:15px;">
        Welcome[<%=current_username %>]to management system 
    </div>

	<div data-options="region:'west',split:true,title:'Menu'" style="width:200px;padding:10px;">
    <ul id="tt" data-options="lines:true"></ul>
	</div>
	
	<div data-options="region:'south',border:false" style="height:30px;background:#A9FACD;padding:5px; vertical-align:middle;">Login Time：<%=System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")%></div>
	
    <div data-options="region:'center',title:''">
        <div id="tab" class="easyui-tabs">   
            <div title="First Page" style="">   
                Welcome to Tweebaa backend management system!
            </div>   
            
            
        </div> 
    </div>

    <script type="text/javascript">
        $('#tt').tree({
          data: eval(<%=_treeJson %>),
          onClick:function(node){
            if(node.id>1000){
               //alert(node.id+" This function is:  "+ node.attributes.url);
               var targetUrl=node.attributes.url;
               var title=node.text;
               $("#tab").tabs("add",{
                  fit:true,
                  border:true,
                  title:title,
                  selected:true,
                  closable:true,
                  content:"<iframe style='border:0px; width:100%; height:100%;' src="+targetUrl+" style='margin:0px;padding:0px; width:100%;' frameborder=\"0\" marginheight=\"0\" scrolling=\"auto\"></iframe>"
               });
            }
            else {
                //alert(node.id+"<1000");
                var child = $("#tt").tree('getChildren',node.target);
            	//如果选中的节点状态是关闭，且还有子节点则展开选中节点
	            if(child.length>0 && $("#tt").tree('getSelected').state=='closed'){
	                $("#tt").tree('expand',node.target);
	            }else if(child.length>0 && $("#tt").tree('getSelected').state=='open'){
	            	 $("#tt").tree('collapse',node.target);
	            }else{
	            	//没有分配子节点的操作
	            	alert('未分配子节点操作权限,请联系管理员!');
	            	return false;
	            }
            }
             
          },
        });

     $("#tab").tabs({
        fit:true,
     });

     function _addTab(title,url)
     {
         $("#tab").tabs("add",{
                  fit:true,
                  border:true,
                  title:title,
                  selected:true,
                  closable:true,
                  content:"<iframe style='border:0px; width:100%; height:100%;' src="+url+" style='margin:0px;padding:0px; width:100%;' frameborder=\"0\" marginheight=\"0\" scrolling=\"auto\"></iframe>"
               });
     }


    </script>



    </form>
</body>
</html>

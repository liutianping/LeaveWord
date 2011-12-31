﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BlogManagerMenu.ascx.cs" Inherits="UserControls_BlogManagerMenu" %>
    <!-- QuickMenu Structure [Menu 0] -->
    <ul id="qm0" class="qmmc">
        <li><a class="qmparent" href="javascript:void(0)">博客管理</a>
            <ul>
            <li><a href="~/Blog/BlogListByUser.aspx" runat="server" id="a1">我的博客</a></li>
                <li><a href="~/Blog/BlogAdd.aspx" runat="server" id="a2">发表博客</a></li>
                <li><a href="~/Blog/BlogManager.aspx" runat="server" id="a3">博客管理</a></li>
                
            </ul>
        </li>
        <li><a class="qmparent" href="javascript:void(0)">类别管理</a>
            <ul>
            <li><a href="~/Blog/BlogCategoryList.aspx" runat="server" id="a4">我的类别</a></li>
                <li><a href="~/Blog/BlogCategoryAdd.aspx" runat="server" id="a5">新增类别</a></li>
                <li><a href="~/Blog/BlogCategoryDelete.aspx" runat="server" id="a6">删除类别</a></li>
            </ul>
        </li>
        <li><a class="qmparent" href="javascript:void(0)">留言管理</a>
            <ul>
                <li><a href="javascript:void(0)">我的留言</a></li>
                <li><a href="javascript:void(0)">博客评论</a></li>
                
            </ul>
        </li>
        
        <li><a class="qmparent" href="javascript:void(0)">回收站</a>
            <ul>
                <li><a href="~/Blog/BlogCollection.aspx" runat="server" id="a7">博客回收站</a></li>
                <li><a href="javascript:void(0)">评论回收站</a></li>
                
            </ul>
        </li>
        
        <li><a class="qmparent" href="javascript:void(0)">个人信息维护</a>
            <ul>
                <li><a href="javascript:void(0)">我的个人信息</a></li>
                <li><a href="javascript:void(0)">更新个人信息</a></li>
                <li><a href="javascript:void(0)">注销帐户</a></li>
            </ul>
        </li>
        <li class="qmclear">&nbsp;</li></ul>
    <!-- Create Menu Settings: (Menu ID, Is Vertical, Show Timer, Hide Timer, On Click (options: 'all' * 'all-always-open' * 'main' * 'lev2'), Right to Left, Horizontal Subs, Flush Left, Flush Top) -->

    <script type="text/javascript">qm_create(0,true,0,0,false,false,false,false,false);</script>

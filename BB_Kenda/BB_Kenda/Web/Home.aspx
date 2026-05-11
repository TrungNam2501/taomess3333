 <%@ Page Title="" Language="C#" MasterPageFile="~/Web/MasterWeb.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BB_Kenda.Web.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .gradient-border {
            --border-width: 3px;
            margin:auto;
            display: block;
            justify-content: center;
            align-items: center;
            width: 70%;
            font-family: Lato, sans-serif;
            font-size: 2.5rem;
            text-transform: uppercase;
            color: white;
            background: transparent;
            border-radius: var(--border-width);
        }

            .gradient-border::after {
                position: absolute;
                content: "";
                top: calc(-1 * var(--border-width));
                left: calc(-1 * var(--border-width));
                z-index: -1;
                width: calc(100% + var(--border-width));
                height: calc(100% + var(--border-width));
                background: linear-gradient( 60deg, hsl(224, 85%, 66%), hsl(269, 85%, 66%), hsl(314, 85%, 66%), hsl(359, 85%, 66%), hsl(44, 85%, 66%), hsl(89, 85%, 66%), hsl(134, 85%, 66%), hsl(179, 85%, 66%));
                background-size: 300% 300%;
                background-position: 0 50%;
                border-radius: calc(2 * var(--border-width));
                animation: moveGradient 4s alternate infinite;
            }

        @keyframes moveGradient {
            50% {
                background-position: 100% 50%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="gradient-border" style="max-width: 100%; height: 100%;">
        <img src="../Assets/image/kd.png" style="display: block; width: 70%; margin: auto;margin-top:150px" />
    </div>
</asp:Content>

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.34209.
// 
#pragma warning disable 1591

namespace TweebaaWebApp2.TweebaaWebService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="MobileAppDBWebServiceSoap", Namespace="http://tempuri.org/")]
    public partial class MobileAppDBWebService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback HelloWorldOperationCompleted;
        
        private System.Threading.SendOrPostCallback MobileAppRemoveMyCollageOperationCompleted;
        
        private System.Threading.SendOrPostCallback MobileAppDoRegisterOperationCompleted;
        
        private System.Threading.SendOrPostCallback SaveGameInformationAfterUserWinOperationCompleted;
        
        private System.Threading.SendOrPostCallback SaveSpinRequestOperationCompleted;
        
        private System.Threading.SendOrPostCallback SaveSpinOperationCompleted;
        
        private System.Threading.SendOrPostCallback SaveCollageOperationCompleted;
        
        private System.Threading.SendOrPostCallback SaveCollageExOperationCompleted;
        
        private System.Threading.SendOrPostCallback RemoveFavourOperationCompleted;
        
        private System.Threading.SendOrPostCallback SaveFavourOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public MobileAppDBWebService() {
            this.Url = global::TweebaaWebApp2.Properties.Settings.Default.TweebaaWebApp2_TweebaaWebService_MobileAppDBWebService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event HelloWorldCompletedEventHandler HelloWorldCompleted;
        
        /// <remarks/>
        public event MobileAppRemoveMyCollageCompletedEventHandler MobileAppRemoveMyCollageCompleted;
        
        /// <remarks/>
        public event MobileAppDoRegisterCompletedEventHandler MobileAppDoRegisterCompleted;
        
        /// <remarks/>
        public event SaveGameInformationAfterUserWinCompletedEventHandler SaveGameInformationAfterUserWinCompleted;
        
        /// <remarks/>
        public event SaveSpinRequestCompletedEventHandler SaveSpinRequestCompleted;
        
        /// <remarks/>
        public event SaveSpinCompletedEventHandler SaveSpinCompleted;
        
        /// <remarks/>
        public event SaveCollageCompletedEventHandler SaveCollageCompleted;
        
        /// <remarks/>
        public event SaveCollageExCompletedEventHandler SaveCollageExCompleted;
        
        /// <remarks/>
        public event RemoveFavourCompletedEventHandler RemoveFavourCompleted;
        
        /// <remarks/>
        public event SaveFavourCompletedEventHandler SaveFavourCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/HelloWorld", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string HelloWorld() {
            object[] results = this.Invoke("HelloWorld", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void HelloWorldAsync() {
            this.HelloWorldAsync(null);
        }
        
        /// <remarks/>
        public void HelloWorldAsync(object userState) {
            if ((this.HelloWorldOperationCompleted == null)) {
                this.HelloWorldOperationCompleted = new System.Threading.SendOrPostCallback(this.OnHelloWorldOperationCompleted);
            }
            this.InvokeAsync("HelloWorld", new object[0], this.HelloWorldOperationCompleted, userState);
        }
        
        private void OnHelloWorldOperationCompleted(object arg) {
            if ((this.HelloWorldCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.HelloWorldCompleted(this, new HelloWorldCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/MobileAppRemoveMyCollage", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int MobileAppRemoveMyCollage(string sDesignID, string sUserID) {
            object[] results = this.Invoke("MobileAppRemoveMyCollage", new object[] {
                        sDesignID,
                        sUserID});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void MobileAppRemoveMyCollageAsync(string sDesignID, string sUserID) {
            this.MobileAppRemoveMyCollageAsync(sDesignID, sUserID, null);
        }
        
        /// <remarks/>
        public void MobileAppRemoveMyCollageAsync(string sDesignID, string sUserID, object userState) {
            if ((this.MobileAppRemoveMyCollageOperationCompleted == null)) {
                this.MobileAppRemoveMyCollageOperationCompleted = new System.Threading.SendOrPostCallback(this.OnMobileAppRemoveMyCollageOperationCompleted);
            }
            this.InvokeAsync("MobileAppRemoveMyCollage", new object[] {
                        sDesignID,
                        sUserID}, this.MobileAppRemoveMyCollageOperationCompleted, userState);
        }
        
        private void OnMobileAppRemoveMyCollageOperationCompleted(object arg) {
            if ((this.MobileAppRemoveMyCollageCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.MobileAppRemoveMyCollageCompleted(this, new MobileAppRemoveMyCollageCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/MobileAppDoRegister", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int MobileAppDoRegister(string sUserGuid, string userName, string strNameEmailTel, string phone, string strPass, int countryId, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] System.Nullable<int> knowwayid, string tuijieEmail, bool consent) {
            object[] results = this.Invoke("MobileAppDoRegister", new object[] {
                        sUserGuid,
                        userName,
                        strNameEmailTel,
                        phone,
                        strPass,
                        countryId,
                        knowwayid,
                        tuijieEmail,
                        consent});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void MobileAppDoRegisterAsync(string sUserGuid, string userName, string strNameEmailTel, string phone, string strPass, int countryId, System.Nullable<int> knowwayid, string tuijieEmail, bool consent) {
            this.MobileAppDoRegisterAsync(sUserGuid, userName, strNameEmailTel, phone, strPass, countryId, knowwayid, tuijieEmail, consent, null);
        }
        
        /// <remarks/>
        public void MobileAppDoRegisterAsync(string sUserGuid, string userName, string strNameEmailTel, string phone, string strPass, int countryId, System.Nullable<int> knowwayid, string tuijieEmail, bool consent, object userState) {
            if ((this.MobileAppDoRegisterOperationCompleted == null)) {
                this.MobileAppDoRegisterOperationCompleted = new System.Threading.SendOrPostCallback(this.OnMobileAppDoRegisterOperationCompleted);
            }
            this.InvokeAsync("MobileAppDoRegister", new object[] {
                        sUserGuid,
                        userName,
                        strNameEmailTel,
                        phone,
                        strPass,
                        countryId,
                        knowwayid,
                        tuijieEmail,
                        consent}, this.MobileAppDoRegisterOperationCompleted, userState);
        }
        
        private void OnMobileAppDoRegisterOperationCompleted(object arg) {
            if ((this.MobileAppDoRegisterCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.MobileAppDoRegisterCompleted(this, new MobileAppDoRegisterCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SaveGameInformationAfterUserWin", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string SaveGameInformationAfterUserWin(string layer, string plat_form, string screen, string userGuid, string sLocalPoint, string sLevel, string sVirtualProps, string game1, string game2, string game3, string game4, string game5, string game6) {
            object[] results = this.Invoke("SaveGameInformationAfterUserWin", new object[] {
                        layer,
                        plat_form,
                        screen,
                        userGuid,
                        sLocalPoint,
                        sLevel,
                        sVirtualProps,
                        game1,
                        game2,
                        game3,
                        game4,
                        game5,
                        game6});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void SaveGameInformationAfterUserWinAsync(string layer, string plat_form, string screen, string userGuid, string sLocalPoint, string sLevel, string sVirtualProps, string game1, string game2, string game3, string game4, string game5, string game6) {
            this.SaveGameInformationAfterUserWinAsync(layer, plat_form, screen, userGuid, sLocalPoint, sLevel, sVirtualProps, game1, game2, game3, game4, game5, game6, null);
        }
        
        /// <remarks/>
        public void SaveGameInformationAfterUserWinAsync(string layer, string plat_form, string screen, string userGuid, string sLocalPoint, string sLevel, string sVirtualProps, string game1, string game2, string game3, string game4, string game5, string game6, object userState) {
            if ((this.SaveGameInformationAfterUserWinOperationCompleted == null)) {
                this.SaveGameInformationAfterUserWinOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSaveGameInformationAfterUserWinOperationCompleted);
            }
            this.InvokeAsync("SaveGameInformationAfterUserWin", new object[] {
                        layer,
                        plat_form,
                        screen,
                        userGuid,
                        sLocalPoint,
                        sLevel,
                        sVirtualProps,
                        game1,
                        game2,
                        game3,
                        game4,
                        game5,
                        game6}, this.SaveGameInformationAfterUserWinOperationCompleted, userState);
        }
        
        private void OnSaveGameInformationAfterUserWinOperationCompleted(object arg) {
            if ((this.SaveGameInformationAfterUserWinCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SaveGameInformationAfterUserWinCompleted(this, new SaveGameInformationAfterUserWinCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SaveSpinRequest", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int SaveSpinRequest(string sMD5, string sTime) {
            object[] results = this.Invoke("SaveSpinRequest", new object[] {
                        sMD5,
                        sTime});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void SaveSpinRequestAsync(string sMD5, string sTime) {
            this.SaveSpinRequestAsync(sMD5, sTime, null);
        }
        
        /// <remarks/>
        public void SaveSpinRequestAsync(string sMD5, string sTime, object userState) {
            if ((this.SaveSpinRequestOperationCompleted == null)) {
                this.SaveSpinRequestOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSaveSpinRequestOperationCompleted);
            }
            this.InvokeAsync("SaveSpinRequest", new object[] {
                        sMD5,
                        sTime}, this.SaveSpinRequestOperationCompleted, userState);
        }
        
        private void OnSaveSpinRequestOperationCompleted(object arg) {
            if ((this.SaveSpinRequestCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SaveSpinRequestCompleted(this, new SaveSpinRequestCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SaveSpin", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int SaveSpin(string userGuid, string sMD5, string sPrizeID) {
            object[] results = this.Invoke("SaveSpin", new object[] {
                        userGuid,
                        sMD5,
                        sPrizeID});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void SaveSpinAsync(string userGuid, string sMD5, string sPrizeID) {
            this.SaveSpinAsync(userGuid, sMD5, sPrizeID, null);
        }
        
        /// <remarks/>
        public void SaveSpinAsync(string userGuid, string sMD5, string sPrizeID, object userState) {
            if ((this.SaveSpinOperationCompleted == null)) {
                this.SaveSpinOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSaveSpinOperationCompleted);
            }
            this.InvokeAsync("SaveSpin", new object[] {
                        userGuid,
                        sMD5,
                        sPrizeID}, this.SaveSpinOperationCompleted, userState);
        }
        
        private void OnSaveSpinOperationCompleted(object arg) {
            if ((this.SaveSpinCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SaveSpinCompleted(this, new SaveSpinCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SaveCollage", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void SaveCollage(string sDesignID, string sType, string sTitle, string sDescription, string sDesignerGuid, string CollageDesign_HTML, string sImg, string[] products) {
            this.Invoke("SaveCollage", new object[] {
                        sDesignID,
                        sType,
                        sTitle,
                        sDescription,
                        sDesignerGuid,
                        CollageDesign_HTML,
                        sImg,
                        products});
        }
        
        /// <remarks/>
        public void SaveCollageAsync(string sDesignID, string sType, string sTitle, string sDescription, string sDesignerGuid, string CollageDesign_HTML, string sImg, string[] products) {
            this.SaveCollageAsync(sDesignID, sType, sTitle, sDescription, sDesignerGuid, CollageDesign_HTML, sImg, products, null);
        }
        
        /// <remarks/>
        public void SaveCollageAsync(string sDesignID, string sType, string sTitle, string sDescription, string sDesignerGuid, string CollageDesign_HTML, string sImg, string[] products, object userState) {
            if ((this.SaveCollageOperationCompleted == null)) {
                this.SaveCollageOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSaveCollageOperationCompleted);
            }
            this.InvokeAsync("SaveCollage", new object[] {
                        sDesignID,
                        sType,
                        sTitle,
                        sDescription,
                        sDesignerGuid,
                        CollageDesign_HTML,
                        sImg,
                        products}, this.SaveCollageOperationCompleted, userState);
        }
        
        private void OnSaveCollageOperationCompleted(object arg) {
            if ((this.SaveCollageCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SaveCollageCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SaveCollageEx", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int SaveCollageEx(string sDesignID, string sType, string sTitle, string sDescription, string sDesignerGuid, string CollageDesign_HTML, string sImg, string products) {
            object[] results = this.Invoke("SaveCollageEx", new object[] {
                        sDesignID,
                        sType,
                        sTitle,
                        sDescription,
                        sDesignerGuid,
                        CollageDesign_HTML,
                        sImg,
                        products});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void SaveCollageExAsync(string sDesignID, string sType, string sTitle, string sDescription, string sDesignerGuid, string CollageDesign_HTML, string sImg, string products) {
            this.SaveCollageExAsync(sDesignID, sType, sTitle, sDescription, sDesignerGuid, CollageDesign_HTML, sImg, products, null);
        }
        
        /// <remarks/>
        public void SaveCollageExAsync(string sDesignID, string sType, string sTitle, string sDescription, string sDesignerGuid, string CollageDesign_HTML, string sImg, string products, object userState) {
            if ((this.SaveCollageExOperationCompleted == null)) {
                this.SaveCollageExOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSaveCollageExOperationCompleted);
            }
            this.InvokeAsync("SaveCollageEx", new object[] {
                        sDesignID,
                        sType,
                        sTitle,
                        sDescription,
                        sDesignerGuid,
                        CollageDesign_HTML,
                        sImg,
                        products}, this.SaveCollageExOperationCompleted, userState);
        }
        
        private void OnSaveCollageExOperationCompleted(object arg) {
            if ((this.SaveCollageExCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SaveCollageExCompleted(this, new SaveCollageExCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/RemoveFavour", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int RemoveFavour(string sDesignID, string sUserGuid) {
            object[] results = this.Invoke("RemoveFavour", new object[] {
                        sDesignID,
                        sUserGuid});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void RemoveFavourAsync(string sDesignID, string sUserGuid) {
            this.RemoveFavourAsync(sDesignID, sUserGuid, null);
        }
        
        /// <remarks/>
        public void RemoveFavourAsync(string sDesignID, string sUserGuid, object userState) {
            if ((this.RemoveFavourOperationCompleted == null)) {
                this.RemoveFavourOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRemoveFavourOperationCompleted);
            }
            this.InvokeAsync("RemoveFavour", new object[] {
                        sDesignID,
                        sUserGuid}, this.RemoveFavourOperationCompleted, userState);
        }
        
        private void OnRemoveFavourOperationCompleted(object arg) {
            if ((this.RemoveFavourCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RemoveFavourCompleted(this, new RemoveFavourCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SaveFavour", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int SaveFavour(string sDesignID, string sUserGuid) {
            object[] results = this.Invoke("SaveFavour", new object[] {
                        sDesignID,
                        sUserGuid});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void SaveFavourAsync(string sDesignID, string sUserGuid) {
            this.SaveFavourAsync(sDesignID, sUserGuid, null);
        }
        
        /// <remarks/>
        public void SaveFavourAsync(string sDesignID, string sUserGuid, object userState) {
            if ((this.SaveFavourOperationCompleted == null)) {
                this.SaveFavourOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSaveFavourOperationCompleted);
            }
            this.InvokeAsync("SaveFavour", new object[] {
                        sDesignID,
                        sUserGuid}, this.SaveFavourOperationCompleted, userState);
        }
        
        private void OnSaveFavourOperationCompleted(object arg) {
            if ((this.SaveFavourCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SaveFavourCompleted(this, new SaveFavourCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void HelloWorldCompletedEventHandler(object sender, HelloWorldCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class HelloWorldCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal HelloWorldCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void MobileAppRemoveMyCollageCompletedEventHandler(object sender, MobileAppRemoveMyCollageCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class MobileAppRemoveMyCollageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal MobileAppRemoveMyCollageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void MobileAppDoRegisterCompletedEventHandler(object sender, MobileAppDoRegisterCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class MobileAppDoRegisterCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal MobileAppDoRegisterCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void SaveGameInformationAfterUserWinCompletedEventHandler(object sender, SaveGameInformationAfterUserWinCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SaveGameInformationAfterUserWinCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SaveGameInformationAfterUserWinCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void SaveSpinRequestCompletedEventHandler(object sender, SaveSpinRequestCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SaveSpinRequestCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SaveSpinRequestCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void SaveSpinCompletedEventHandler(object sender, SaveSpinCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SaveSpinCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SaveSpinCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void SaveCollageCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void SaveCollageExCompletedEventHandler(object sender, SaveCollageExCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SaveCollageExCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SaveCollageExCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void RemoveFavourCompletedEventHandler(object sender, RemoveFavourCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RemoveFavourCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RemoveFavourCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    public delegate void SaveFavourCompletedEventHandler(object sender, SaveFavourCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.34209")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SaveFavourCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SaveFavourCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591
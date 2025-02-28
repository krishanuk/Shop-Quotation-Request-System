﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace TechFix.localhostProductManage {
    using System.Diagnostics;
    using System;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System.Web.Services;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="WebService1Soap", Namespace="http://tempuri.org/")]
    public partial class WebService1 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback InsertProductOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateProductOperationCompleted;
        
        private System.Threading.SendOrPostCallback DeleteProductOperationCompleted;
        
        private System.Threading.SendOrPostCallback FindProductOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetAllProductsOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetProductsBySupplierOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetLowStockNotificationOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public WebService1() {
            this.Url = global::TechFix.Properties.Settings.Default.TechFix_localhostProductManage_WebService1;
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
        public event InsertProductCompletedEventHandler InsertProductCompleted;
        
        /// <remarks/>
        public event UpdateProductCompletedEventHandler UpdateProductCompleted;
        
        /// <remarks/>
        public event DeleteProductCompletedEventHandler DeleteProductCompleted;
        
        /// <remarks/>
        public event FindProductCompletedEventHandler FindProductCompleted;
        
        /// <remarks/>
        public event GetAllProductsCompletedEventHandler GetAllProductsCompleted;
        
        /// <remarks/>
        public event GetProductsBySupplierCompletedEventHandler GetProductsBySupplierCompleted;
        
        /// <remarks/>
        public event GetLowStockNotificationCompletedEventHandler GetLowStockNotificationCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/InsertProduct", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int InsertProduct(string productName, string productPrice, string productQuantity, string productDescription, string category, string supplier, [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")] byte[] productImage) {
            object[] results = this.Invoke("InsertProduct", new object[] {
                        productName,
                        productPrice,
                        productQuantity,
                        productDescription,
                        category,
                        supplier,
                        productImage});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void InsertProductAsync(string productName, string productPrice, string productQuantity, string productDescription, string category, string supplier, byte[] productImage) {
            this.InsertProductAsync(productName, productPrice, productQuantity, productDescription, category, supplier, productImage, null);
        }
        
        /// <remarks/>
        public void InsertProductAsync(string productName, string productPrice, string productQuantity, string productDescription, string category, string supplier, byte[] productImage, object userState) {
            if ((this.InsertProductOperationCompleted == null)) {
                this.InsertProductOperationCompleted = new System.Threading.SendOrPostCallback(this.OnInsertProductOperationCompleted);
            }
            this.InvokeAsync("InsertProduct", new object[] {
                        productName,
                        productPrice,
                        productQuantity,
                        productDescription,
                        category,
                        supplier,
                        productImage}, this.InsertProductOperationCompleted, userState);
        }
        
        private void OnInsertProductOperationCompleted(object arg) {
            if ((this.InsertProductCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.InsertProductCompleted(this, new InsertProductCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/UpdateProduct", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int UpdateProduct(int productID, string productName, string productPrice, string productQuantity, string productDescription, string category, string supplier, [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")] byte[] productImage) {
            object[] results = this.Invoke("UpdateProduct", new object[] {
                        productID,
                        productName,
                        productPrice,
                        productQuantity,
                        productDescription,
                        category,
                        supplier,
                        productImage});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void UpdateProductAsync(int productID, string productName, string productPrice, string productQuantity, string productDescription, string category, string supplier, byte[] productImage) {
            this.UpdateProductAsync(productID, productName, productPrice, productQuantity, productDescription, category, supplier, productImage, null);
        }
        
        /// <remarks/>
        public void UpdateProductAsync(int productID, string productName, string productPrice, string productQuantity, string productDescription, string category, string supplier, byte[] productImage, object userState) {
            if ((this.UpdateProductOperationCompleted == null)) {
                this.UpdateProductOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateProductOperationCompleted);
            }
            this.InvokeAsync("UpdateProduct", new object[] {
                        productID,
                        productName,
                        productPrice,
                        productQuantity,
                        productDescription,
                        category,
                        supplier,
                        productImage}, this.UpdateProductOperationCompleted, userState);
        }
        
        private void OnUpdateProductOperationCompleted(object arg) {
            if ((this.UpdateProductCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateProductCompleted(this, new UpdateProductCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/DeleteProduct", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int DeleteProduct(int productID) {
            object[] results = this.Invoke("DeleteProduct", new object[] {
                        productID});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void DeleteProductAsync(int productID) {
            this.DeleteProductAsync(productID, null);
        }
        
        /// <remarks/>
        public void DeleteProductAsync(int productID, object userState) {
            if ((this.DeleteProductOperationCompleted == null)) {
                this.DeleteProductOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeleteProductOperationCompleted);
            }
            this.InvokeAsync("DeleteProduct", new object[] {
                        productID}, this.DeleteProductOperationCompleted, userState);
        }
        
        private void OnDeleteProductOperationCompleted(object arg) {
            if ((this.DeleteProductCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DeleteProductCompleted(this, new DeleteProductCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/FindProduct", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet FindProduct(int productID, string productName) {
            object[] results = this.Invoke("FindProduct", new object[] {
                        productID,
                        productName});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void FindProductAsync(int productID, string productName) {
            this.FindProductAsync(productID, productName, null);
        }
        
        /// <remarks/>
        public void FindProductAsync(int productID, string productName, object userState) {
            if ((this.FindProductOperationCompleted == null)) {
                this.FindProductOperationCompleted = new System.Threading.SendOrPostCallback(this.OnFindProductOperationCompleted);
            }
            this.InvokeAsync("FindProduct", new object[] {
                        productID,
                        productName}, this.FindProductOperationCompleted, userState);
        }
        
        private void OnFindProductOperationCompleted(object arg) {
            if ((this.FindProductCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.FindProductCompleted(this, new FindProductCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetAllProducts", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet GetAllProducts() {
            object[] results = this.Invoke("GetAllProducts", new object[0]);
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void GetAllProductsAsync() {
            this.GetAllProductsAsync(null);
        }
        
        /// <remarks/>
        public void GetAllProductsAsync(object userState) {
            if ((this.GetAllProductsOperationCompleted == null)) {
                this.GetAllProductsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetAllProductsOperationCompleted);
            }
            this.InvokeAsync("GetAllProducts", new object[0], this.GetAllProductsOperationCompleted, userState);
        }
        
        private void OnGetAllProductsOperationCompleted(object arg) {
            if ((this.GetAllProductsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetAllProductsCompleted(this, new GetAllProductsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetProductsBySupplier", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet GetProductsBySupplier(string supplierName) {
            object[] results = this.Invoke("GetProductsBySupplier", new object[] {
                        supplierName});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void GetProductsBySupplierAsync(string supplierName) {
            this.GetProductsBySupplierAsync(supplierName, null);
        }
        
        /// <remarks/>
        public void GetProductsBySupplierAsync(string supplierName, object userState) {
            if ((this.GetProductsBySupplierOperationCompleted == null)) {
                this.GetProductsBySupplierOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetProductsBySupplierOperationCompleted);
            }
            this.InvokeAsync("GetProductsBySupplier", new object[] {
                        supplierName}, this.GetProductsBySupplierOperationCompleted, userState);
        }
        
        private void OnGetProductsBySupplierOperationCompleted(object arg) {
            if ((this.GetProductsBySupplierCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetProductsBySupplierCompleted(this, new GetProductsBySupplierCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetLowStockNotification", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] GetLowStockNotification(string supplierName) {
            object[] results = this.Invoke("GetLowStockNotification", new object[] {
                        supplierName});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void GetLowStockNotificationAsync(string supplierName) {
            this.GetLowStockNotificationAsync(supplierName, null);
        }
        
        /// <remarks/>
        public void GetLowStockNotificationAsync(string supplierName, object userState) {
            if ((this.GetLowStockNotificationOperationCompleted == null)) {
                this.GetLowStockNotificationOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetLowStockNotificationOperationCompleted);
            }
            this.InvokeAsync("GetLowStockNotification", new object[] {
                        supplierName}, this.GetLowStockNotificationOperationCompleted, userState);
        }
        
        private void OnGetLowStockNotificationOperationCompleted(object arg) {
            if ((this.GetLowStockNotificationCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetLowStockNotificationCompleted(this, new GetLowStockNotificationCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void InsertProductCompletedEventHandler(object sender, InsertProductCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class InsertProductCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal InsertProductCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void UpdateProductCompletedEventHandler(object sender, UpdateProductCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdateProductCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UpdateProductCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void DeleteProductCompletedEventHandler(object sender, DeleteProductCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DeleteProductCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal DeleteProductCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void FindProductCompletedEventHandler(object sender, FindProductCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class FindProductCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal FindProductCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void GetAllProductsCompletedEventHandler(object sender, GetAllProductsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetAllProductsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetAllProductsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void GetProductsBySupplierCompletedEventHandler(object sender, GetProductsBySupplierCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetProductsBySupplierCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetProductsBySupplierCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void GetLowStockNotificationCompletedEventHandler(object sender, GetLowStockNotificationCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetLowStockNotificationCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetLowStockNotificationCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591
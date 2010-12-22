﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.3082
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50727.3082.
'
Namespace arcgis_Server
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="ServiceCatalogBinding", [Namespace]:="http://www.esri.com/schemas/ArcGIS/9.3")>  _
    Partial Public Class Catalog
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private GetMessageVersionOperationCompleted As System.Threading.SendOrPostCallback
        
        Private GetMessageFormatsOperationCompleted As System.Threading.SendOrPostCallback
        
        Private GetTokenServiceURLOperationCompleted As System.Threading.SendOrPostCallback
        
        Private GetFoldersOperationCompleted As System.Threading.SendOrPostCallback
        
        Private GetServiceDescriptionsOperationCompleted As System.Threading.SendOrPostCallback
        
        Private RequiresTokensOperationCompleted As System.Threading.SendOrPostCallback
        
        Private GetServiceDescriptionsExOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.Testy.My.MySettings.Default.Testy_arcgis_Server_Catalog
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
            End If
        End Sub
        
        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = true)  _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = false))  _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = false)) Then
                    MyBase.UseDefaultCredentials = false
                End If
                MyBase.Url = value
            End Set
        End Property
        
        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = true
            End Set
        End Property
        
        '''<remarks/>
        Public Event GetMessageVersionCompleted As GetMessageVersionCompletedEventHandler
        
        '''<remarks/>
        Public Event GetMessageFormatsCompleted As GetMessageFormatsCompletedEventHandler
        
        '''<remarks/>
        Public Event GetTokenServiceURLCompleted As GetTokenServiceURLCompletedEventHandler
        
        '''<remarks/>
        Public Event GetFoldersCompleted As GetFoldersCompletedEventHandler
        
        '''<remarks/>
        Public Event GetServiceDescriptionsCompleted As GetServiceDescriptionsCompletedEventHandler
        
        '''<remarks/>
        Public Event RequiresTokensCompleted As RequiresTokensCompletedEventHandler
        
        '''<remarks/>
        Public Event GetServiceDescriptionsExCompleted As GetServiceDescriptionsExCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace:="http://www.esri.com/schemas/ArcGIS/9.3", ResponseNamespace:="http://www.esri.com/schemas/ArcGIS/9.3", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetMessageVersion() As <System.Xml.Serialization.XmlElementAttribute("MessageVersion", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)> esriArcGISVersion
            Dim results() As Object = Me.Invoke("GetMessageVersion", New Object(-1) {})
            Return CType(results(0),esriArcGISVersion)
        End Function
        
        '''<remarks/>
        Public Overloads Sub GetMessageVersionAsync()
            Me.GetMessageVersionAsync(Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GetMessageVersionAsync(ByVal userState As Object)
            If (Me.GetMessageVersionOperationCompleted Is Nothing) Then
                Me.GetMessageVersionOperationCompleted = AddressOf Me.OnGetMessageVersionOperationCompleted
            End If
            Me.InvokeAsync("GetMessageVersion", New Object(-1) {}, Me.GetMessageVersionOperationCompleted, userState)
        End Sub
        
        Private Sub OnGetMessageVersionOperationCompleted(ByVal arg As Object)
            If (Not (Me.GetMessageVersionCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetMessageVersionCompleted(Me, New GetMessageVersionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace:="http://www.esri.com/schemas/ArcGIS/9.3", ResponseNamespace:="http://www.esri.com/schemas/ArcGIS/9.3", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetMessageFormats() As <System.Xml.Serialization.XmlElementAttribute("MessageFormats", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)> esriServiceCatalogMessageFormat
            Dim results() As Object = Me.Invoke("GetMessageFormats", New Object(-1) {})
            Return CType(results(0),esriServiceCatalogMessageFormat)
        End Function
        
        '''<remarks/>
        Public Overloads Sub GetMessageFormatsAsync()
            Me.GetMessageFormatsAsync(Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GetMessageFormatsAsync(ByVal userState As Object)
            If (Me.GetMessageFormatsOperationCompleted Is Nothing) Then
                Me.GetMessageFormatsOperationCompleted = AddressOf Me.OnGetMessageFormatsOperationCompleted
            End If
            Me.InvokeAsync("GetMessageFormats", New Object(-1) {}, Me.GetMessageFormatsOperationCompleted, userState)
        End Sub
        
        Private Sub OnGetMessageFormatsOperationCompleted(ByVal arg As Object)
            If (Not (Me.GetMessageFormatsCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetMessageFormatsCompleted(Me, New GetMessageFormatsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace:="http://www.esri.com/schemas/ArcGIS/9.3", ResponseNamespace:="http://www.esri.com/schemas/ArcGIS/9.3", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetTokenServiceURL() As <System.Xml.Serialization.XmlElementAttribute("TokenServiceURL", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)> String
            Dim results() As Object = Me.Invoke("GetTokenServiceURL", New Object(-1) {})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub GetTokenServiceURLAsync()
            Me.GetTokenServiceURLAsync(Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GetTokenServiceURLAsync(ByVal userState As Object)
            If (Me.GetTokenServiceURLOperationCompleted Is Nothing) Then
                Me.GetTokenServiceURLOperationCompleted = AddressOf Me.OnGetTokenServiceURLOperationCompleted
            End If
            Me.InvokeAsync("GetTokenServiceURL", New Object(-1) {}, Me.GetTokenServiceURLOperationCompleted, userState)
        End Sub
        
        Private Sub OnGetTokenServiceURLOperationCompleted(ByVal arg As Object)
            If (Not (Me.GetTokenServiceURLCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetTokenServiceURLCompleted(Me, New GetTokenServiceURLCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace:="http://www.esri.com/schemas/ArcGIS/9.3", ResponseNamespace:="http://www.esri.com/schemas/ArcGIS/9.3", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetFolders() As <System.Xml.Serialization.XmlArrayAttribute("FolderNames", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified), System.Xml.Serialization.XmlArrayItemAttribute("String", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=false)> String()
            Dim results() As Object = Me.Invoke("GetFolders", New Object(-1) {})
            Return CType(results(0),String())
        End Function
        
        '''<remarks/>
        Public Overloads Sub GetFoldersAsync()
            Me.GetFoldersAsync(Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GetFoldersAsync(ByVal userState As Object)
            If (Me.GetFoldersOperationCompleted Is Nothing) Then
                Me.GetFoldersOperationCompleted = AddressOf Me.OnGetFoldersOperationCompleted
            End If
            Me.InvokeAsync("GetFolders", New Object(-1) {}, Me.GetFoldersOperationCompleted, userState)
        End Sub
        
        Private Sub OnGetFoldersOperationCompleted(ByVal arg As Object)
            If (Not (Me.GetFoldersCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetFoldersCompleted(Me, New GetFoldersCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace:="http://www.esri.com/schemas/ArcGIS/9.3", ResponseNamespace:="http://www.esri.com/schemas/ArcGIS/9.3", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetServiceDescriptions() As <System.Xml.Serialization.XmlArrayAttribute("ServiceDescriptions", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified), System.Xml.Serialization.XmlArrayItemAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=false)> ServiceDescription()
            Dim results() As Object = Me.Invoke("GetServiceDescriptions", New Object(-1) {})
            Return CType(results(0),ServiceDescription())
        End Function
        
        '''<remarks/>
        Public Overloads Sub GetServiceDescriptionsAsync()
            Me.GetServiceDescriptionsAsync(Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GetServiceDescriptionsAsync(ByVal userState As Object)
            If (Me.GetServiceDescriptionsOperationCompleted Is Nothing) Then
                Me.GetServiceDescriptionsOperationCompleted = AddressOf Me.OnGetServiceDescriptionsOperationCompleted
            End If
            Me.InvokeAsync("GetServiceDescriptions", New Object(-1) {}, Me.GetServiceDescriptionsOperationCompleted, userState)
        End Sub
        
        Private Sub OnGetServiceDescriptionsOperationCompleted(ByVal arg As Object)
            If (Not (Me.GetServiceDescriptionsCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetServiceDescriptionsCompleted(Me, New GetServiceDescriptionsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace:="http://www.esri.com/schemas/ArcGIS/9.3", ResponseNamespace:="http://www.esri.com/schemas/ArcGIS/9.3", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function RequiresTokens() As <System.Xml.Serialization.XmlElementAttribute("Result", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)> Boolean
            Dim results() As Object = Me.Invoke("RequiresTokens", New Object(-1) {})
            Return CType(results(0),Boolean)
        End Function
        
        '''<remarks/>
        Public Overloads Sub RequiresTokensAsync()
            Me.RequiresTokensAsync(Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub RequiresTokensAsync(ByVal userState As Object)
            If (Me.RequiresTokensOperationCompleted Is Nothing) Then
                Me.RequiresTokensOperationCompleted = AddressOf Me.OnRequiresTokensOperationCompleted
            End If
            Me.InvokeAsync("RequiresTokens", New Object(-1) {}, Me.RequiresTokensOperationCompleted, userState)
        End Sub
        
        Private Sub OnRequiresTokensOperationCompleted(ByVal arg As Object)
            If (Not (Me.RequiresTokensCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent RequiresTokensCompleted(Me, New RequiresTokensCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestNamespace:="http://www.esri.com/schemas/ArcGIS/9.3", ResponseNamespace:="http://www.esri.com/schemas/ArcGIS/9.3", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetServiceDescriptionsEx(<System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)> ByVal FolderName As String) As <System.Xml.Serialization.XmlArrayAttribute("ServiceDescriptions", Form:=System.Xml.Schema.XmlSchemaForm.Unqualified), System.Xml.Serialization.XmlArrayItemAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable:=false)> ServiceDescription()
            Dim results() As Object = Me.Invoke("GetServiceDescriptionsEx", New Object() {FolderName})
            Return CType(results(0),ServiceDescription())
        End Function
        
        '''<remarks/>
        Public Overloads Sub GetServiceDescriptionsExAsync(ByVal FolderName As String)
            Me.GetServiceDescriptionsExAsync(FolderName, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub GetServiceDescriptionsExAsync(ByVal FolderName As String, ByVal userState As Object)
            If (Me.GetServiceDescriptionsExOperationCompleted Is Nothing) Then
                Me.GetServiceDescriptionsExOperationCompleted = AddressOf Me.OnGetServiceDescriptionsExOperationCompleted
            End If
            Me.InvokeAsync("GetServiceDescriptionsEx", New Object() {FolderName}, Me.GetServiceDescriptionsExOperationCompleted, userState)
        End Sub
        
        Private Sub OnGetServiceDescriptionsExOperationCompleted(ByVal arg As Object)
            If (Not (Me.GetServiceDescriptionsExCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent GetServiceDescriptionsExCompleted(Me, New GetServiceDescriptionsExCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
        
        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing)  _
                        OrElse (url Is String.Empty)) Then
                Return false
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024)  _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return true
            End If
            Return false
        End Function
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3082"),  _
     System.SerializableAttribute(),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.esri.com/schemas/ArcGIS/9.3")>  _
    Public Enum esriArcGISVersion
        
        '''<remarks/>
        esriArcGISVersion83
        
        '''<remarks/>
        esriArcGISVersion90
        
        '''<remarks/>
        esriArcGISVersion92
        
        '''<remarks/>
        esriArcGISVersion93
    End Enum
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3082"),  _
     System.SerializableAttribute(),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.esri.com/schemas/ArcGIS/9.3")>  _
    Public Enum esriServiceCatalogMessageFormat
        
        '''<remarks/>
        esriServiceCatalogMessageFormatSoap
        
        '''<remarks/>
        esriServiceCatalogMessageFormatBin
        
        '''<remarks/>
        esriServiceCatalogMessageFormatSoapOrBin
    End Enum
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3082"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://www.esri.com/schemas/ArcGIS/9.3")>  _
    Partial Public Class ServiceDescription
        
        Private nameField As String
        
        Private typeField As String
        
        Private urlField As String
        
        Private parentTypeField As String
        
        Private capabilitiesField As String
        
        Private descriptionField As String
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>  _
        Public Property Name() As String
            Get
                Return Me.nameField
            End Get
            Set
                Me.nameField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>  _
        Public Property Type() As String
            Get
                Return Me.typeField
            End Get
            Set
                Me.typeField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>  _
        Public Property Url() As String
            Get
                Return Me.urlField
            End Get
            Set
                Me.urlField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>  _
        Public Property ParentType() As String
            Get
                Return Me.parentTypeField
            End Get
            Set
                Me.parentTypeField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>  _
        Public Property Capabilities() As String
            Get
                Return Me.capabilitiesField
            End Get
            Set
                Me.capabilitiesField = value
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Form:=System.Xml.Schema.XmlSchemaForm.Unqualified)>  _
        Public Property Description() As String
            Get
                Return Me.descriptionField
            End Get
            Set
                Me.descriptionField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")>  _
    Public Delegate Sub GetMessageVersionCompletedEventHandler(ByVal sender As Object, ByVal e As GetMessageVersionCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GetMessageVersionCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As esriArcGISVersion
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),esriArcGISVersion)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")>  _
    Public Delegate Sub GetMessageFormatsCompletedEventHandler(ByVal sender As Object, ByVal e As GetMessageFormatsCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GetMessageFormatsCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As esriServiceCatalogMessageFormat
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),esriServiceCatalogMessageFormat)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")>  _
    Public Delegate Sub GetTokenServiceURLCompletedEventHandler(ByVal sender As Object, ByVal e As GetTokenServiceURLCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GetTokenServiceURLCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")>  _
    Public Delegate Sub GetFoldersCompletedEventHandler(ByVal sender As Object, ByVal e As GetFoldersCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GetFoldersCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String()
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String())
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")>  _
    Public Delegate Sub GetServiceDescriptionsCompletedEventHandler(ByVal sender As Object, ByVal e As GetServiceDescriptionsCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GetServiceDescriptionsCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As ServiceDescription()
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),ServiceDescription())
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")>  _
    Public Delegate Sub RequiresTokensCompletedEventHandler(ByVal sender As Object, ByVal e As RequiresTokensCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class RequiresTokensCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As Boolean
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),Boolean)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053")>  _
    Public Delegate Sub GetServiceDescriptionsExCompletedEventHandler(ByVal sender As Object, ByVal e As GetServiceDescriptionsExCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.3053"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class GetServiceDescriptionsExCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As ServiceDescription()
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),ServiceDescription())
            End Get
        End Property
    End Class
End Namespace

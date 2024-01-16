Imports System
Imports System.Windows.Forms
Imports System.Math
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Public Class WorkOrder
    Inherits System.Windows.Forms.Form

    'Setup data connection and variables
    Dim con As SqlConnection = New SqlConnection("Data Source=TFP-SQL;Initial Catalog=TFPOperationsDatabase;Integrated Security=True;Connect Timeout=30")
    Dim cmd As SqlCommand
    Dim myAdapter, myAdapter1, myAdapter2, myAdapter3, myAdapter4, myAdapter5, myAdapter6, myAdapter7, myAdapter8, myAdapter9, myAdapter10 As New SqlDataAdapter
    Dim comBuilder As SqlCommandBuilder
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8, ds9, ds10 As DataSet
    Dim DivisionDataset As DataSet
    Dim DivisionAdapter As New SqlDataAdapter
    Dim dt As DataTable

    Dim FIFOCost As Double = 0
    Dim StandardCost As Double = 0
    Dim ItemClass As String = ""
    Dim CreditAccount As String = ""
    Dim DebitAccount As String = ""
    Dim NextTransactionNumber, LastTransactionNumber As Integer
    Dim NextSONumber, LastSONumber As Integer

    'Work Order Totals for formatting
    Dim FormProductTotal As Double = 0
    Dim FormFreightTotal As Double = 0
    Dim FormTaxTotal As Double = 0
    Dim FormWOTotal As Double = 0

    'WO variable for scanned docs
    Dim WorkOrderFileName As String = ""
    Dim WorkOrderFilenameAndPath As String = ""
    Dim strWorkOrderNumber As String = ""
    Dim intWorkOrderNumber As Integer = 0

    'Initialize error variables
    Dim ErrorDate As String = ""
    Dim ErrorDescription As String = ""
    Dim ErrorUser As String = ""
    Dim ErrorComment As String = ""
    Dim ErrorDivision As String = ""
    Dim ErrorReferenceNumber As String = ""

    Private Sub WorkOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Load data for all divisions
        LoadCurrentDivision()
        LoadShipMethod()
        LoadCountry()

        'Clear fields and load company defaults
        ClearDataInDatagrid()
        ClearVariables()
        ClearData()
    End Sub

    Public Sub TFPErrorLogUpdate()
        If ErrorComment.Length < 400 Then
            'Do nothing
        Else
            ErrorComment = ErrorComment.Substring(0, 399)
        End If

        'Insert Data into error log
        cmd = New SqlCommand("INSERT INTO TFPErrorLog (ErrorDate, ErrorDescription, ErrorReferenceNumber, ErrorUserID, ErrorComment, ErrorDivision) values (@ErrorDate, @ErrorDescription, @ErrorReferenceNumber, @ErrorUserID, @ErrorComment, @ErrorDivision)", con)

        With cmd.Parameters
            .Add("@ErrorDate", SqlDbType.VarChar).Value = ErrorDate
            .Add("@ErrorDescription", SqlDbType.VarChar).Value = ErrorDescription
            .Add("@ErrorReferenceNumber", SqlDbType.VarChar).Value = ErrorReferenceNumber
            .Add("@ErrorUserID", SqlDbType.VarChar).Value = ErrorUser
            .Add("@ErrorComment", SqlDbType.VarChar).Value = ErrorComment
            .Add("@ErrorDivision", SqlDbType.VarChar).Value = ErrorDivision
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub ShowData()
        cmd = New SqlCommand("SELECT * FROM WorkOrderLineTable WHERE WorkOrderNumber = @WorkOrderNumber AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@WorkOrderNumber", SqlDbType.VarChar).Value = Val(cboWorkOrderNumber.Text)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ds = New DataSet()
        myAdapter.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter.Fill(ds, "WorkOrderLineTable")
        con.Close()

        dgvWorkOrderLines.DataSource = ds.Tables("WorkOrderLineTable")
    End Sub

    Private Sub LoadWorkOrderNumber()
        cmd = New SqlCommand("SELECT WorkOrderNumber FROM WorkOrderHeaderTable WHERE DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ds1 = New DataSet()
        myAdapter1.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter1.Fill(ds1, "WorkOrderHeaderTable")
        con.Close()

        cboWorkOrderNumber.DataSource = ds1.Tables("WorkOrderHeaderTable")
        cboWorkOrderNumber.SelectedIndex = -1
    End Sub

    Private Sub LoadCustomerList()
        'Create commands to load Customer List for each division
        cmd = New SqlCommand("SELECT CustomerID FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        ds2 = New DataSet()
        myAdapter2.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter2.Fill(ds2, "CustomerList")
        con.Close()

        cboCustomerID.DataSource = ds2.Tables("CustomerList")
        cboCustomerID.SelectedIndex = -1
    End Sub

    Private Sub LoadItemList()
        'Create commands to load Item List for each division
        cmd = New SqlCommand("SELECT ItemID FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        ds3 = New DataSet()
        myAdapter3.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter3.Fill(ds3, "ItemList")
        con.Close()

        cboPartNumber.DataSource = ds3.Tables("ItemList")
        cboPartNumber.SelectedIndex = -1
    End Sub

    Private Sub LoadPartDescription()
        'Create commands to load Item List for each division
        cmd = New SqlCommand("SELECT ShortDescription FROM ItemList WHERE DivisionID = @DivisionID AND ItemClass <> @ItemClass ORDER BY ItemID", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@ItemClass", SqlDbType.VarChar).Value = "DEACTIVATED-PART"
        ds4 = New DataSet()
        myAdapter4.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter4.Fill(ds4, "ItemList")
        con.Close()

        cboPartDescription.DataSource = ds4.Tables("ItemList")
        cboPartDescription.SelectedIndex = -1
    End Sub

    Public Sub LoadAdditionalShipTo()
        cmd = New SqlCommand("SELECT ShipToID FROM AdditionalShipTo WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID", con)
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        ds5 = New DataSet()
        myAdapter5.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter5.Fill(ds5, "AdditionalShipTo")
        con.Close()

        cboShipToID.DataSource = ds5.Tables("AdditionalShipTo")
        cboShipToID.SelectedIndex = -1
    End Sub

    Public Sub LoadShipMethod()
        cmd = New SqlCommand("SELECT ShipMethID FROM ShipMethod", con)
        ds6 = New DataSet()
        myAdapter6.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter6.Fill(ds6, "ShipMethod")
        con.Close()

        cboShipVia.DataSource = ds6.Tables("ShipMethod")
        cboShipVia.SelectedIndex = -1
    End Sub

    Private Sub LoadCustomerName()
        'Create commands to load Customer List for each division
        cmd = New SqlCommand("SELECT CustomerName FROM CustomerList WHERE DivisionID = @DivisionID AND CustomerClass <> @CustomerClass ORDER BY CustomerName", con)
        cmd.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        cmd.Parameters.Add("@CustomerClass", SqlDbType.VarChar).Value = "DE-ACTIVATED"
        ds7 = New DataSet()
        myAdapter7.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter7.Fill(ds7, "CustomerList")
        con.Close()

        cboCustomerName.DataSource = ds7.Tables("CustomerList")
        cboCustomerName.SelectedIndex = -1
    End Sub

    Public Sub LoadCountry()
        cmd = New SqlCommand("SELECT Country FROM CountryCodes", con)
        ds8 = New DataSet()
        myAdapter8.SelectCommand = cmd

        If con.State = ConnectionState.Closed Then con.Open()
        myAdapter8.Fill(ds8, "CountryCodes")
        con.Close()

        cboCountryName.DataSource = ds8.Tables("CountryCodes")
        cboCountryName.SelectedIndex = -1
        txtCountry.Clear()
    End Sub

    Public Sub LoadWOTotals()
        Dim SumProductTotal, SumSalesTax As Double
        Dim WOTotal, TotalFreight As Double

        Dim SumProductTotalStatement As String = "SELECT SUM(ExtendedAmount) FROM WorkOrderLineTable WHERE WorkOrderNumber = @WorkOrderNumber AND DivisionID = @DivisionID"
        Dim SumProductTotalCommand As New SqlCommand(SumProductTotalStatement, con)
        SumProductTotalCommand.Parameters.Add("@WorkOrderNumber", SqlDbType.VarChar).Value = Val(cboWorkOrderNumber.Text)
        SumProductTotalCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        Dim SumSalestaxStatement As String = "SELECT SUM(SalesTax) FROM WorkOrderLineTable WHERE WorkOrderNumber = @WorkOrderNumber AND DivisionID = @DivisionID"
        Dim SumSalestaxCommand As New SqlCommand(SumSalestaxStatement, con)
        SumSalestaxCommand.Parameters.Add("@WorkOrderNumber", SqlDbType.VarChar).Value = Val(cboWorkOrderNumber.Text)
        SumSalestaxCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            SumProductTotal = CInt(SumProductTotalCommand.ExecuteScalar)
        Catch ex As Exception
            SumProductTotal = 0
        End Try
        Try
            SumSalesTax = CInt(SumSalestaxCommand.ExecuteScalar)
        Catch ex As Exception
            SumSalesTax = 0
        End Try
        con.Close()

        TotalFreight = Val(txtEstFreight.Text)

        TotalFreight = Math.Round(TotalFreight, 2)
        SumProductTotal = Math.Round(SumProductTotal, 2)
        SumSalesTax = Math.Round(SumSalesTax, 2)
        WOTotal = TotalFreight + SumProductTotal + SumSalesTax

        'Transfer to Formal Variables
        FormWOTotal = WOTotal
        FormFreightTotal = TotalFreight
        FormTaxTotal = SumSalesTax
        FormProductTotal = SumProductTotal

        txtTotalExtendedCost.Text = FormatCurrency(SumProductTotal, 2)
        txtTotalFreight.Text = FormatCurrency(TotalFreight, 2)
        txtTotalTax.Text = FormatCurrency(SumSalesTax, 2)
        txtWorkOrderTotal.Text = FormatCurrency(WOTotal, 2)
    End Sub

    Public Sub LoadCountryCodeByCountryName()
        Dim CountryCode1 As String = ""

        Dim GetCountryCodeStatement As String = "SELECT CountryCode FROM CountryCodes WHERE Country = @Country"
        Dim GetCountryCodeCommand As New SqlCommand(GetCountryCodeStatement, con)
        GetCountryCodeCommand.Parameters.Add("@Country", SqlDbType.VarChar).Value = cboCountryName.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountryCode1 = CStr(GetCountryCodeCommand.ExecuteScalar)
        Catch ex As Exception
            CountryCode1 = ""
        End Try
        con.Close()

        If cboCountryName.Text <> "" Then
            txtCountry.Text = CountryCode1
        Else
            'Do nothing
        End If
    End Sub

    Public Sub LoadCountryNameByCountryCode()
        Dim CountryName1 As String = ""

        Dim GetCountryNameStatement As String = "SELECT Country FROM CountryCodes WHERE CountryCode = @CountryCode"
        Dim GetCountryNameCommand As New SqlCommand(GetCountryNameStatement, con)
        GetCountryNameCommand.Parameters.Add("@CountryCode", SqlDbType.VarChar).Value = txtCountry.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CountryName1 = CStr(GetCountryNameCommand.ExecuteScalar)
        Catch ex As Exception
            CountryName1 = ""
        End Try
        con.Close()

        If txtCountry.Text <> "" Then
            cboCountryName.Text = CountryName1
        Else
            'Do nothing
        End If
    End Sub

    Public Sub LoadCustomerIDByName()
        Dim CustomerID1 As String = ""

        Dim CustomerID1Statement As String = "SELECT CustomerID FROM CustomerList WHERE CustomerName = @CustomerName AND DivisionID = @DivisionID"
        Dim CustomerID1Command As New SqlCommand(CustomerID1Statement, con)
        CustomerID1Command.Parameters.Add("@CustomerName", SqlDbType.VarChar).Value = cboCustomerName.Text
        CustomerID1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerID1 = CStr(CustomerID1Command.ExecuteScalar)
        Catch ex As Exception
            CustomerID1 = ""
        End Try
        con.Close()

        cboCustomerID.Text = CustomerID1
    End Sub

    Public Sub LoadCustomerNameByID()
        Dim CustomerName1 As String = ""

        Dim CustomerName1Statement As String = "SELECT CustomerName FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim CustomerName1Command As New SqlCommand(CustomerName1Statement, con)
        CustomerName1Command.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        CustomerName1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CustomerName1 = CStr(CustomerName1Command.ExecuteScalar)
        Catch ex As Exception
            CustomerName1 = ""
        End Try
        con.Close()

        cboCustomerName.Text = CustomerName1
    End Sub

    Public Sub LoadLongDescription()
        Dim LongDescription As String = ""

        Dim LongDescriptionStatement As String = "SELECT LongDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim LongDescriptionCommand As New SqlCommand(LongDescriptionStatement, con)
        LongDescriptionCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        LongDescriptionCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LongDescription = CStr(LongDescriptionCommand.ExecuteScalar)
        Catch ex As Exception
            LongDescription = ""
        End Try
        con.Close()

        txtLongDescription.Text = LongDescription
    End Sub

    Public Sub LoadWorkOrderStatus()
        'Load status and lock controls if necessary
        'OPEN - all controls open, any changes can be made.
        'POSTED - Cannot delete lines or change quantity, because inventory already adjusted. Can make changes in header fields.
        'CLOSED - No changes

        Dim GetWOStatus As String = ""

        Dim GetWOStatusStatement As String = "SELECT WorkOrderStatus FROM WorkOrderHeaderTable WHERE WorkOrderNumber = @WorkOrderNumber AND DivisionID = @DivisionID"
        Dim GetWOStatusCommand As New SqlCommand(GetWOStatusStatement, con)
        GetWOStatusCommand.Parameters.Add("@WorkOrderNumber", SqlDbType.VarChar).Value = cboWorkOrderNumber.Text
        GetWOStatusCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetWOStatus = CStr(GetWOStatusCommand.ExecuteScalar)
        Catch ex As Exception
            GetWOStatus = ""
        End Try
        con.Close()

        txtWOStatus.Text = GetWOStatus

        If GetWOStatus = "OPEN" Then
            cmdCreateSO.Enabled = True
            cmdDelete.Enabled = True
            cmdPostWorkOrder.Enabled = True
            cmdSave.Enabled = True
            gpxAddLineItem.Enabled = True
            gpxDeleteLine.Enabled = True
        ElseIf GetWOStatus = "POSTED" Then
            cmdCreateSO.Enabled = True
            cmdDelete.Enabled = False
            cmdPostWorkOrder.Enabled = False
            cmdSave.Enabled = True
            gpxAddLineItem.Enabled = False
            gpxDeleteLine.Enabled = False
        ElseIf GetWOStatus = "CLOSED" Then
            cmdCreateSO.Enabled = False
            cmdDelete.Enabled = False
            cmdPostWorkOrder.Enabled = False
            cmdSave.Enabled = False
            gpxAddLineItem.Enabled = False
            gpxDeleteLine.Enabled = False
        Else
            cmdCreateSO.Enabled = True
            cmdDelete.Enabled = True
            cmdPostWorkOrder.Enabled = True
            cmdSave.Enabled = True
            gpxAddLineItem.Enabled = True
            gpxDeleteLine.Enabled = True
        End If
    End Sub

    Public Sub LoadGLAccounts()
        Dim ItemClassStatement As String = "SELECT ItemClass FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim ItemClassCommand As New SqlCommand(ItemClassStatement, con)
        ItemClassCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        ItemClassCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            ItemClass = CStr(ItemClassCommand.ExecuteScalar)
        Catch ex As Exception
            ItemClass = ""
        End Try
        con.Close()

        Dim CreditAccountStatement As String = "SELECT GLInventoryAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
        Dim CreditAccountCommand As New SqlCommand(CreditAccountStatement, con)
        CreditAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = ItemClass
 
        Dim DebitAccountStatement As String = "SELECT GLSalesOffsetAccount FROM ItemClass WHERE ItemClassID = @ItemClassID"
        Dim DebitAccountCommand As New SqlCommand(DebitAccountStatement, con)
        DebitAccountCommand.Parameters.Add("@ItemClassID", SqlDbType.VarChar).Value = ItemClass

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            CreditAccount = CStr(CreditAccountCommand.ExecuteScalar)
        Catch ex As Exception
            CreditAccount = ""
        End Try
        Try
            DebitAccount = CStr(DebitAccountCommand.ExecuteScalar)
        Catch ex As Exception
            DebitAccount = ""
        End Try
        con.Close()
    End Sub

    Public Sub LoadPartByDescription()
        Dim PartNumber1 As String = ""

        Dim PartNumber1Statement As String = "SELECT ItemID FROM ItemList WHERE ShortDescription = @ShortDescription AND DivisionID = @DivisionID"
        Dim PartNumber1Command As New SqlCommand(PartNumber1Statement, con)
        PartNumber1Command.Parameters.Add("@ShortDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
        PartNumber1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartNumber1 = CStr(PartNumber1Command.ExecuteScalar)
        Catch ex As Exception
            PartNumber1 = ""
        End Try
        con.Close()

        cboPartNumber.Text = PartNumber1
    End Sub

    Public Sub LoadDescriptionByPart()
        Dim PartDescription1 As String = ""

        Dim PartDescription1Statement As String = "SELECT ShortDescription FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
        Dim PartDescription1Command As New SqlCommand(PartDescription1Statement, con)
        PartDescription1Command.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
        PartDescription1Command.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            PartDescription1 = CStr(PartDescription1Command.ExecuteScalar)
        Catch ex As Exception
            PartDescription1 = ""
        End Try
        con.Close()

        cboPartDescription.Text = PartDescription1
    End Sub

    Public Sub LoadAddShipToData()
        'Clear Fields
        txtAddress1.Clear()
        txtAddress2.Clear()
        txtCity.Clear()
        txtCountry.Clear()
        txtShipToName.Clear()
        txtZip.Clear()
        txtState.Clear()

        Dim Ship2Address1, Ship2Address2, Ship2City, Ship2State, Ship2Zip, Ship2Country, Ship2Name As String

        Dim GetAddShipToDataString As String = "SELECT * FROM AdditionalShipTo WHERE ShipToID = @ShipToID AND CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim GetAddShipToDataCommand As New SqlCommand(GetAddShipToDataString, con)
        GetAddShipToDataCommand.Parameters.Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
        GetAddShipToDataCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        GetAddShipToDataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetAddShipToDataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("Name")) Then
                Ship2Name = ""
            Else
                Ship2Name = reader.Item("Name")
            End If
            If IsDBNull(reader.Item("Address1")) Then
                Ship2Address1 = ""
            Else
                Ship2Address1 = reader.Item("Address1")
            End If
            If IsDBNull(reader.Item("Address2")) Then
                Ship2Address2 = ""
            Else
                Ship2Address2 = reader.Item("Address2")
            End If
            If IsDBNull(reader.Item("City")) Then
                Ship2City = ""
            Else
                Ship2City = reader.Item("City")
            End If
            If IsDBNull(reader.Item("State")) Then
                Ship2State = ""
            Else
                Ship2State = reader.Item("State")
            End If
            If IsDBNull(reader.Item("Zip")) Then
                Ship2Zip = ""
            Else
                Ship2Zip = reader.Item("Zip")
            End If
            If IsDBNull(reader.Item("Country")) Then
                Ship2Country = ""
            Else
                Ship2Country = reader.Item("Country")
            End If
        Else
            Ship2Name = ""
            Ship2Address1 = ""
            Ship2Address2 = ""
            Ship2City = ""
            Ship2State = ""
            Ship2Zip = ""
            Ship2Country = ""
        End If
        reader.Close()
        con.Close()

        txtAddress1.Text = Ship2Address1
        txtAddress2.Text = Ship2Address2
        txtCity.Text = Ship2City
        txtCountry.Text = Ship2Country
        txtZip.Text = Ship2Zip
        txtState.Text = Ship2State
        txtShipToName.Text = Ship2Name
    End Sub

    Public Sub LoadDefaultShipTo()
        'Clear Fields
        txtAddress1.Clear()
        txtAddress2.Clear()
        txtCity.Clear()
        txtCountry.Clear()
        txtShipToName.Clear()
        txtZip.Clear()
        txtState.Clear()

        Dim DefShip2Address1, DefShip2Address2, DefShip2City, DefShip2State, DefShip2Zip, DefShip2Country As String

        Dim GetDefaultShipToString As String = "SELECT ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry FROM CustomerList WHERE CustomerID = @CustomerID AND DivisionID = @DivisionID"
        Dim GetDefaultShipToCommand As New SqlCommand(GetDefaultShipToString, con)
        GetDefaultShipToCommand.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
        GetDefaultShipToCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetDefaultShipToCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("ShipToAddress1")) Then
                DefShip2Address1 = ""
            Else
                DefShip2Address1 = reader.Item("ShipToAddress1")
            End If
            If IsDBNull(reader.Item("ShipToAddress2")) Then
                DefShip2Address2 = ""
            Else
                DefShip2Address2 = reader.Item("ShipToAddress2")
            End If
            If IsDBNull(reader.Item("ShipToCity")) Then
                DefShip2City = ""
            Else
                DefShip2City = reader.Item("ShipToCity")
            End If
            If IsDBNull(reader.Item("ShipToState")) Then
                DefShip2State = ""
            Else
                DefShip2State = reader.Item("ShipToState")
            End If
            If IsDBNull(reader.Item("ShipToZip")) Then
                DefShip2Zip = ""
            Else
                DefShip2Zip = reader.Item("ShipToZip")
            End If
            If IsDBNull(reader.Item("ShipToCountry")) Then
                DefShip2Country = ""
            Else
                DefShip2Country = reader.Item("ShipToCountry")
            End If
        Else
            DefShip2Address1 = ""
            DefShip2Address2 = ""
            DefShip2City = ""
            DefShip2State = ""
            DefShip2Zip = ""
            DefShip2Country = ""
        End If
        reader.Close()
        con.Close()

        txtAddress1.Text = DefShip2Address1
        txtAddress2.Text = DefShip2Address2
        txtCity.Text = DefShip2City
        txtCountry.Text = DefShip2Country
        txtZip.Text = DefShip2Zip
        txtState.Text = DefShip2State
        txtShipToName.Text = cboCustomerName.Text
    End Sub

    Public Sub LoadCurrentDivision()
        'Load these for every form
        'Dim DivisionDataset As DataSet
        'Dim DivisionAdapter As New SqlDataAdapter

        Select Case EmployeeCompanyCode
            Case "ADM"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "ALB"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'ALB'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "ATL"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'ATL'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CBS"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CBS'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CHT"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CHT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "CGO"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'CGO'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "DEN"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'DEN'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "HOU"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'HOU'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "LLH"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'LLH'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "SLC"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'SLC'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFF"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFF'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFJ"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFJ'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TFP"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFP' OR DivisionKey = 'TWD'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "TFT"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TFT'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TOR"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TOR'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case "TWD"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWD' OR DivisionKey = 'TFP' OR DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = True
            Case "TWE"
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable WHERE DivisionKey = 'TWE'", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
            Case Else
                cmd = New SqlCommand("SELECT DivisionKey FROM DivisionTable", con)
                If con.State = ConnectionState.Closed Then con.Open()
                DivisionDataset = New DataSet()
                DivisionAdapter.SelectCommand = cmd
                DivisionAdapter.Fill(DivisionDataset, "DivisionTable")
                cboDivisionID.DataSource = DivisionDataset.Tables("DivisionTable")
                con.Close()

                cboDivisionID.Text = EmployeeCompanyCode
                cboDivisionID.Enabled = False
        End Select
    End Sub

    Public Sub LoadFIFOCost()
        Dim TotalQuantityShipped As Double = 0
        Dim TransactionCost As Double = 0
        Dim MaxCost As Integer = 0
        Dim GetMaxTransactionNumber As Integer = 0
        Dim GetUpperLimit As Double = 0
        '******************************************************************************************************************************************
        'Determine Total Quantity Shipped
        Dim TotalQuantityShippedStatement As String = "SELECT SUM(QuantityShipped) FROM ShipmentLineQuery WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND ShipDate <= @ShipDate AND Dropship <> @Dropship AND LineStatus <> @LineStatus"
        Dim TotalQuantityShippedCommand As New SqlCommand(TotalQuantityShippedStatement, con)
        TotalQuantityShippedCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        TotalQuantityShippedCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        TotalQuantityShippedCommand.Parameters.Add("@ShipDate", SqlDbType.VarChar).Value = dtpWorkOrderDate.Text
        TotalQuantityShippedCommand.Parameters.Add("@Dropship", SqlDbType.VarChar).Value = "YES"
        TotalQuantityShippedCommand.Parameters.Add("@LineStatus", SqlDbType.VarChar).Value = "PENDING"

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            TotalQuantityShipped = CDbl(TotalQuantityShippedCommand.ExecuteScalar)
        Catch ex As Exception
            TotalQuantityShipped = 0
        End Try
        con.Close()
        '******************************************************************************************************************************************
        'Add Total Quantity used in assemblies
        Dim GetBuildQuantity As Double = 0

        Dim TotalBuildQuantityStatement As String = "SELECT SUM(BuildQuantity) FROM AssemblyBuildQuery WHERE ComponentPartNumber = @ComponentPartNumber AND DivisionID = @DivisionID AND ComponentPartNumber <> AssemblyPartNumber"
        Dim TotalBuildQuantityCommand As New SqlCommand(TotalBuildQuantityStatement, con)
        TotalBuildQuantityCommand.Parameters.Add("@ComponentPartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        TotalBuildQuantityCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetBuildQuantity = CDbl(TotalBuildQuantityCommand.ExecuteScalar)
        Catch ex As Exception
            GetBuildQuantity = 0
        End Try
        con.Close()

        GetBuildQuantity = GetBuildQuantity * -1

        TotalQuantityShipped = TotalQuantityShipped + GetBuildQuantity
        '******************************************************************************************************************************************
        'Check to see if Total Quantity Shipped falls within the Cost Tiers
        Dim GetMaxTransactionNumberStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND CostingDate <= @CostingDate"
        Dim GetMaxTransactionNumberCommand As New SqlCommand(GetMaxTransactionNumberStatement, con)
        GetMaxTransactionNumberCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
        GetMaxTransactionNumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
        GetMaxTransactionNumberCommand.Parameters.Add("@CostingDate", SqlDbType.VarChar).Value = dtpWorkOrderDate.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetMaxTransactionNumber = CInt(GetMaxTransactionNumberCommand.ExecuteScalar)
        Catch ex As Exception
            GetMaxTransactionNumber = 0
        End Try
        con.Close()

        Dim GetUpperLimitStatement As String = "SELECT UpperLimit FROM InventoryCosting WHERE TransactionNumber = @TransactionNumber AND DivisionID = @DivisionID"
        Dim GetUpperLimitCommand As New SqlCommand(GetUpperLimitStatement, con)
        GetUpperLimitCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber
        GetUpperLimitCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetUpperLimit = CDbl(GetUpperLimitCommand.ExecuteScalar)
        Catch ex As Exception
            GetUpperLimit = 0
        End Try
        con.Close()

        If TotalQuantityShipped = 0 Then
            TotalQuantityShipped = 1
        Else
            TotalQuantityShipped = TotalQuantityShipped + 1
        End If

        If TotalQuantityShipped < GetUpperLimit Then
            'Determine Item Cost where Quantity Shipped falls in the Inventory Costing Table
            Dim ItemCostStatement As String = "SELECT ItemCost FROM InventoryCosting WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND @TotalQuantityShipped BETWEEN LowerLimit AND UpperLimit"
            Dim ItemCostCommand As New SqlCommand(ItemCostStatement, con)
            ItemCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            ItemCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            ItemCostCommand.Parameters.Add("@TotalQuantityShipped", SqlDbType.VarChar).Value = TotalQuantityShipped
            'ItemCostCommand.Parameters.Add("@TransactionNumber", SqlDbType.VarChar).Value = GetMaxTransactionNumber

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                FIFOCost = CDbl(ItemCostCommand.ExecuteScalar)
            Catch ex As Exception
                FIFOCost = 0
            End Try
            con.Close()
        Else
            FIFOCost = 0
        End If
        '*****************************************************************************************************************************************
        If FIFOCost = 0 Then
            'Select Last Transaction
            Dim MaxCostStatement As String = "SELECT MAX(TransactionNumber) FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID"
            Dim MaxCostCommand As New SqlCommand(MaxCostStatement, con)
            MaxCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            MaxCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MaxCost = CInt(MaxCostCommand.ExecuteScalar)
            Catch ex As Exception
                MaxCost = 0
            End Try
            con.Close()

            'Load Last Transaction Cost if FIFO = 0
            Dim TransactionCostStatement As String = "SELECT ItemCost FROM InventoryTransactionTable WHERE PartNumber = @PartNumber AND DivisionID = @DivisionID AND TransactionNumber =  @MaxCost"
            Dim TransactionCostCommand As New SqlCommand(TransactionCostStatement, con)
            TransactionCostCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            TransactionCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            TransactionCostCommand.Parameters.Add("@MaxCost", SqlDbType.VarChar).Value = MaxCost

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                TransactionCost = CDbl(TransactionCostCommand.ExecuteScalar)
            Catch ex As Exception
                TransactionCost = 0
            End Try
            con.Close()

            FIFOCost = TransactionCost
        End If
        '*****************************************************************************************************************************************
        If FIFOCost = 0 Then
            Dim LastPurchaseCost As Double = 0
            Dim MaxDate As Integer = 0

            Dim MAXDateStatement As String = "SELECT MAX(ReceivingHeaderKey) FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber"
            Dim MAXDateCommand As New SqlCommand(MAXDateStatement, con)
            MAXDateCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            MAXDateCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                MaxDate = CInt(MAXDateCommand.ExecuteScalar)
            Catch ex As Exception
                MaxDate = 0
            End Try
            con.Close()

            Dim LastPriceStatement As String = "SELECT UnitCost FROM ReceivingLineQuery WHERE DivisionID = @DivisionID AND PartNumber = @PartNumber AND ReceivingHeaderKey = @ReceivingHeaderKey"
            Dim LastPriceCommand As New SqlCommand(LastPriceStatement, con)
            LastPriceCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            LastPriceCommand.Parameters.Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            LastPriceCommand.Parameters.Add("@ReceivingHeaderKey", SqlDbType.VarChar).Value = MaxDate

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastPurchaseCost = CDbl(LastPriceCommand.ExecuteScalar)
            Catch ex As Exception
                LastPurchaseCost = 0
            End Try
            con.Close()

            FIFOCost = LastPurchaseCost
        End If
        '*****************************************************************************************************************************************
        'Load Standard Unit Cost if Transaction Cost = 0
        If FIFOCost = 0 Then
            'Select Last Transaction
            Dim StandardCostStatement As String = "SELECT StandardCost FROM ItemList WHERE ItemID = @ItemID AND DivisionID = @DivisionID"
            Dim StandardCostCommand As New SqlCommand(StandardCostStatement, con)
            StandardCostCommand.Parameters.Add("@ItemID", SqlDbType.VarChar).Value = cboPartNumber.Text
            StandardCostCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                StandardCost = CDbl(StandardCostCommand.ExecuteScalar)
            Catch ex As Exception
                StandardCost = 0
            End Try
            con.Close()

            FIFOCost = StandardCost
        End If
        '*****************************************************************************************************************************************
        txtUnitCost.Text = FIFOCost
    End Sub

    Public Sub ClearVariables()
        FIFOCost = 0
        StandardCost = 0
        ItemClass = ""
        CreditAccount = ""
        DebitAccount = ""
        NextTransactionNumber = 0
        LastTransactionNumber = 0
        NextSONumber = 0
        LastSONumber = 0

        FormProductTotal = 0
        FormTaxTotal = 0
        FormWOTotal = 0
        FormFreightTotal = 0
    End Sub

    Public Sub ClearLines()
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        txtLongDescription.Clear()
        txtLineInstructions.Clear()
        txtUnitCost.Clear()
        txtQuantity.Clear()
        txtExtendedCost.Clear()

        cboPartNumber.Focus()
    End Sub

    Public Sub ClearData()
        cboCountryName.SelectedIndex = -1
        cboCustomerID.SelectedIndex = -1
        cboCustomerName.SelectedIndex = -1
        cboPartDescription.SelectedIndex = -1
        cboPartNumber.SelectedIndex = -1
        cboShipMethod.SelectedIndex = -1
        cboShipVia.SelectedIndex = -1
        cboWorkOrderNumber.SelectedIndex = -1

        txtAddress1.Clear()
        txtAddress2.Clear()
        txtCity.Clear()
        txtCountry.Clear()
        txtCustomerPO.Clear()
        txtExtendedCost.Clear()
        txtHeaderComment.Clear()
        txtLineInstructions.Clear()
        txtLongDescription.Clear()
        txtQuantity.Clear()
        txtSalesOrderNumber.Clear()
        txtShipToName.Clear()
        txtSpecialShippingInstructions.Clear()
        txtState.Clear()
        txtUnitCost.Clear()
        txtZip.Clear()
        txtEstFreight.Clear()
        txtWOStatus.Clear()

        dtpWorkOrderDate.Text = ""
        dtpWorkOrderDate.Value = Today()

        cmdUploadViewDocs.Text = "Upload / View Docs"

        cboWorkOrderNumber.Focus()
    End Sub

    Public Sub ClearDataInDatagrid()
        Me.dgvWorkOrderLines.DataSource = Nothing
    End Sub

    'Update and Save Routines

    Public Sub InsertWorkOrderHeaderTable()
        'Insert
        cmd = New SqlCommand("INSERT INTO WorkOrderHeaderTable (WorkOrderNumber, WorkOrderDate, PromiseDate, DivisionID, CustomerID, ShipVia, ShipMethod, CustomerPO, SalesOrderNumber, HeaderComment, SpecialInstructions, ShipToID, ShipToName, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry, ThirdPartyShipping, Salesperson, TotalExtendedCost, TotalFreight, TotalTax, WorkOrderTotal, WorkOrderStatus, DateClosed) Values (@WorkOrderNumber, @WorkOrderDate, @PromiseDate, @DivisionID, @CustomerID, @ShipVia, @ShipMethod, @CustomerPO, @SalesOrderNumber, @HeaderComment, @SpecialInstructions, @ShipToID, @ShipToName, @ShipToAddress1, @ShipToAddress2, @ShipToCity, @ShipToState, @ShipToZip, @ShipToCountry, @ThirdPartyShipping, @Salesperson, @TotalExtendedCost, @TotalFreight, @TotalTax, @WorkOrderTotal, @WorkOrderStatus, @DateClosed)", con)

        With cmd.Parameters
            .Add("@WorkOrderNumber", SqlDbType.VarChar).Value = Val(cboWorkOrderNumber.Text)
            .Add("@WorkOrderDate", SqlDbType.VarChar).Value = dtpWorkOrderDate.Text
            .Add("@PromiseDate", SqlDbType.VarChar).Value = txtPromiseDate.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
            .Add("@ShipMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
            .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
            .Add("@SalesOrderNumber", SqlDbType.VarChar).Value = txtSalesOrderNumber.Text
            .Add("@HeaderComment", SqlDbType.VarChar).Value = txtHeaderComment.Text
            .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialShippingInstructions.Text
            .Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
            .Add("@ShipToName", SqlDbType.VarChar).Value = txtShipToName.Text
            .Add("@ShipToAddress1", SqlDbType.VarChar).Value = txtAddress1.Text
            .Add("@ShipToAddress2", SqlDbType.VarChar).Value = txtAddress2.Text
            .Add("@ShipToCity", SqlDbType.VarChar).Value = txtCity.Text
            .Add("@ShipToState", SqlDbType.VarChar).Value = txtState.Text
            .Add("@ShipToZip", SqlDbType.VarChar).Value = txtZip.Text
            .Add("@ShipToCountry", SqlDbType.VarChar).Value = txtCountry.Text
            .Add("@ThirdPartyShipping", SqlDbType.VarChar).Value = txtThirdPartyAddress.Text
            .Add("@Salesperson", SqlDbType.VarChar).Value = EmployeeSalespersonCode
            .Add("@TotalExtendedCost", SqlDbType.VarChar).Value = 0
            .Add("@TotalFreight", SqlDbType.VarChar).Value = 0
            .Add("@TotalTax", SqlDbType.VarChar).Value = 0
            .Add("@WorkOrderTotal", SqlDbType.VarChar).Value = 0
            .Add("@WorkOrderStatus", SqlDbType.VarChar).Value = "OPEN"
            .Add("@DateClosed", SqlDbType.VarChar).Value = ""
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub UpdateWorkOrderHeaderTable()
        LoadWOTotals()

        'UPDATE
        cmd = New SqlCommand("UPDATE WorkOrderHeaderTable SET WorkOrderDate = @WorkOrderDate, PromiseDate = @PromiseDate, CustomerID = @CustomerID, ShipVia = @ShipVia, ShipMethod = @ShipMethod, CustomerPO = @CustomerPO, SalesOrderNumber = @SalesOrderNumber, HeaderComment = @HeaderComment, SpecialInstructions = @SpecialInstructions, ShipToID = @ShipToID, ShipToName = @ShipToName, ShipToAddress1 = @ShipToAddress1, ShipToAddress2 = @ShipToAddress2, ShipToCity = @ShipToCity, ShipToState = ShipToState, ShipToZip = ShipToZip, ShipToCountry = @ShipToCountry, ThirdPartyShipping = @ThirdPartyShipping, Salesperson = @Salesperson, TotalExtendedCost = @TotalExtendedCost, TotalFreight = @TotalFreight, TotalTax = @TotalTax, WorkOrderTotal = @WorkOrderTotal, WorkOrderStatus = @WorkOrderStatus, DateClosed = @DateClosed WHERE WorkOrderNumber = @WorkOrderNumber AND DivisionID = @DivisionID", con)

        With cmd.Parameters
            .Add("@WorkOrderNumber", SqlDbType.VarChar).Value = Val(cboWorkOrderNumber.Text)
            .Add("@WorkOrderDate", SqlDbType.VarChar).Value = dtpWorkOrderDate.Text
            .Add("@PromiseDate", SqlDbType.VarChar).Value = txtPromiseDate.Text
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
            .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
            .Add("@ShipMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
            .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
            .Add("@SalesOrderNumber", SqlDbType.VarChar).Value = txtSalesOrderNumber.Text
            .Add("@HeaderComment", SqlDbType.VarChar).Value = txtHeaderComment.Text
            .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialShippingInstructions.Text
            .Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
            .Add("@ShipToName", SqlDbType.VarChar).Value = txtShipToName.Text
            .Add("@ShipToAddress1", SqlDbType.VarChar).Value = txtAddress1.Text
            .Add("@ShipToAddress2", SqlDbType.VarChar).Value = txtAddress2.Text
            .Add("@ShipToCity", SqlDbType.VarChar).Value = txtCity.Text
            .Add("@ShipToState", SqlDbType.VarChar).Value = txtState.Text
            .Add("@ShipToZip", SqlDbType.VarChar).Value = txtZip.Text
            .Add("@ShipToCountry", SqlDbType.VarChar).Value = txtCountry.Text
            .Add("@ThirdPartyShipping", SqlDbType.VarChar).Value = txtThirdPartyAddress.Text
            .Add("@Salesperson", SqlDbType.VarChar).Value = EmployeeSalespersonCode
            .Add("@TotalExtendedCost", SqlDbType.VarChar).Value = FormProductTotal
            .Add("@TotalFreight", SqlDbType.VarChar).Value = FormFreightTotal
            .Add("@TotalTax", SqlDbType.VarChar).Value = FormTaxTotal
            .Add("@WorkOrderTotal", SqlDbType.VarChar).Value = FormWOTotal
            .Add("@WorkOrderStatus", SqlDbType.VarChar).Value = "OPEN"
            .Add("@DateClosed", SqlDbType.VarChar).Value = ""
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Sub InsertIntoSalesOrderHeader()
        Try
            Dim MAXStatement As String = "SELECT MAX(SalesOrderKey) FROM SalesOrderHeaderTable"
            Dim MAXCommand As New SqlCommand(MAXStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastTransactionNumber = CInt(MAXCommand.ExecuteScalar)
            Catch ex As System.Exception
                LastTransactionNumber = 500000
            End Try
            con.Close()

            NextTransactionNumber = LastTransactionNumber + 1
            txtSalesOrderNumber.Text = NextTransactionNumber

            'Write Data to Sales Order Header Database Table
            cmd = New SqlCommand("Insert Into SalesOrderHeaderTable(SalesOrderKey, SalesOrderDate, CustomerID, CustomerPO, SalesPerson, ShipVia, FreightCharge, TotalSalesTax, ProductTotal, SOTotal, SOStatus, DivisionKey, PRONumber, ShippingDate, HeaderComment, AdditionalShipTo, ShippingWeight, QuoteNumber, QuotedFreight, SpecialInstructions, DropShipPONumber, CustomerPOType, TotalSalesTax2, TotalSalesTax3, TotalEstCOS, TaxRate1, TaxRate2, TaxRate3, Locked, FOB, CustomerClass, ShippingMethod, ThirdPartyShipper, ShipToName, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry, ShipEmail, ShippingAccount, SpecialLabelLine1, SpecialLabelLine2, SpecialLabelLine3, SalesOrderType, WorkOrderNumber)Values(@SalesOrderKey, @SalesOrderDate, @CustomerID, @CustomerPO, @SalesPerson, @ShipVia, @FreightCharge, @TotalSalesTax, @ProductTotal, @SOTotal, @SOStatus, @DivisionKey, @PRONumber, @ShippingDate, @HeaderComment, @AdditionalShipTo, @ShippingWeight, @QuoteNumber, @QuotedFreight, @SpecialInstructions, @DropShipPONumber, @CustomerPOType, @TotalSalesTax2, @TotalSalesTax3, @TotalEstCOS, @TaxRate1, @TaxRate2, @TaxRate3, @Locked, @FOB, @CustomerClass, @ShippingMethod, @ThirdPartyShipper, @ShipToName, @ShipToAddress1, @ShipToAddress2, @ShipToCity, @ShipToState, @ShipToZip, @ShipToCountry, @ShipEmail, @ShippingAccount, @SpecialLabelLine1, @SpecialLabelLine2, @SpecialLabelLine3, @SalesOrderType, @WorkOrderNumber)", con)

            With cmd.Parameters
                .Add("@SalesOrderKey", SqlDbType.VarChar).Value = NextTransactionNumber
                .Add("@SalesOrderDate", SqlDbType.VarChar).Value = Now.ToShortDateString
                .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
                .Add("@CustomerPOType", SqlDbType.VarChar).Value = ""
                .Add("@SalesPerson", SqlDbType.VarChar).Value = EmployeeSalespersonCode
                .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                .Add("@FreightCharge", SqlDbType.VarChar).Value = 0
                .Add("@TotalSalesTax", SqlDbType.VarChar).Value = 0
                .Add("@ProductTotal", SqlDbType.VarChar).Value = 0
                .Add("@SOTotal", SqlDbType.VarChar).Value = 0
                .Add("@SOStatus", SqlDbType.VarChar).Value = "OPEN"
                .Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@PRONumber", SqlDbType.VarChar).Value = ""
                .Add("@ShippingDate", SqlDbType.VarChar).Value = txtPromiseDate.Text
                .Add("@HeaderComment", SqlDbType.VarChar).Value = txtHeaderComment.Text
                .Add("@AdditionalShipTo", SqlDbType.VarChar).Value = cboShipToID.Text
                .Add("@ShippingWeight", SqlDbType.VarChar).Value = 0
                .Add("@QuoteNumber", SqlDbType.VarChar).Value = ""
                .Add("@QuotedFreight", SqlDbType.VarChar).Value = 0
                .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialShippingInstructions.Text
                .Add("@DropShipPONumber", SqlDbType.VarChar).Value = 0
                .Add("@TotalSalesTax2", SqlDbType.VarChar).Value = 0
                .Add("@TotalSalesTax3", SqlDbType.VarChar).Value = 0
                .Add("@TotalEstCOS", SqlDbType.VarChar).Value = 0
                .Add("@TaxRate1", SqlDbType.VarChar).Value = 0
                .Add("@TaxRate2", SqlDbType.VarChar).Value = 0
                .Add("@TaxRate3", SqlDbType.VarChar).Value = 0
                .Add("@Locked", SqlDbType.VarChar).Value = ""
                .Add("@FOB", SqlDbType.VarChar).Value = "STANDARD"
                .Add("@CustomerClass", SqlDbType.VarChar).Value = "STANDARD"
                .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdPartyAddress.Text
                .Add("@ShipToName", SqlDbType.VarChar).Value = txtShipToName.Text
                .Add("@ShipToAddress1", SqlDbType.VarChar).Value = txtAddress1.Text
                .Add("@ShipToAddress2", SqlDbType.VarChar).Value = txtAddress2.Text
                .Add("@ShipToCity", SqlDbType.VarChar).Value = txtCity.Text
                .Add("@ShipToState", SqlDbType.VarChar).Value = txtState.Text
                .Add("@ShipToZip", SqlDbType.VarChar).Value = txtZip.Text
                .Add("@ShipToCountry", SqlDbType.VarChar).Value = txtCountry.Text
                .Add("@ShipEmail", SqlDbType.VarChar).Value = ""
                .Add("@ShippingAccount", SqlDbType.VarChar).Value = ""
                .Add("@SpecialLabelLine1", SqlDbType.VarChar).Value = ""
                .Add("@SpecialLabelLine2", SqlDbType.VarChar).Value = ""
                .Add("@SpecialLabelLine3", SqlDbType.VarChar).Value = ""
                .Add("@SalesOrderType", SqlDbType.VarChar).Value = "WORK ORDER"
                .Add("@WorkOrderNumber", SqlDbType.VarChar).Value = Val(cboWorkOrderNumber.Text)
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As System.Exception
            'If Insert fails, write error message to database
            'Log error on update failure
            Dim TempSONumber As Integer = 0
            Dim strSONumber As String
            TempSONumber = Val(txtSalesOrderNumber.Text)
            strSONumber = CStr(TempSONumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Insert Command --- SO Form (L16143)"
            ErrorReferenceNumber = "SO # " + strSONumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
    End Sub

    Public Sub SaveSalesOrderHeader()
        Try
            '********************************************************************************
            'Save all updates to Sales Order Header Table
            cmd = New SqlCommand("UPDATE SalesOrderHeaderTable SET CustomerID = @CustomerID, CustomerPO = @CustomerPO, Salesperson = @Salesperson, ShipVia = @ShipVia, HeaderComment = @HeaderComment, AdditionalShipTo = @AdditionalShipTo, ShippingWeight = @ShippingWeight, SpecialInstructions = @SpecialInstructions, ShippingMethod = @ShippingMethod, ThirdPartyShipper = @ThirdPartyShipper, ShipToName = @ShipToName, ShipToAddress1 = @ShipToAddress1, ShipToAddress2 = @ShipToAddress2, ShipToCity = @ShipToCity, ShipToState = @ShipToState, ShipToZip = @ShipToZip,  ShipToCountry = @ShipToCountry, SalesOrderType = @SalesOrderType, WorkOrderNumber = @WorkOrderNumber  WHERE SalesOrderKey = @SalesOrderKey AND DivisionKey = @DivisionKey", con)

            With cmd.Parameters
                .Add("@SalesOrderKey", SqlDbType.VarChar).Value = Val(txtSalesOrderNumber.Text)
                .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
                .Add("@SalesPerson", SqlDbType.VarChar).Value = EmployeeSalespersonCode
                .Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                .Add("@HeaderComment", SqlDbType.VarChar).Value = txtHeaderComment.Text
                .Add("@AdditionalShipTo", SqlDbType.VarChar).Value = cboShipToID.Text
                .Add("@ShippingWeight", SqlDbType.VarChar).Value = Val(txtTotalShippingWeight.Text)
                .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialShippingInstructions.Text
                .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = txtThirdPartyAddress.Text
                .Add("@ShipToName", SqlDbType.VarChar).Value = txtShipToName.Text
                .Add("@ShipToAddress1", SqlDbType.VarChar).Value = txtAddress1.Text
                .Add("@ShipToAddress2", SqlDbType.VarChar).Value = txtAddress2.Text
                .Add("@ShipToCity", SqlDbType.VarChar).Value = txtCity.Text
                .Add("@ShipToState", SqlDbType.VarChar).Value = txtState.Text
                .Add("@ShipToZip", SqlDbType.VarChar).Value = txtZip.Text
                .Add("@ShipToCountry", SqlDbType.VarChar).Value = txtCountry.Text
                .Add("@SalesOrderType", SqlDbType.VarChar).Value = "WORK ORDER"
                .Add("@WorkOrderNumber", SqlDbType.VarChar).Value = Val(cboWorkOrderNumber.Text)
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As System.Exception
            'If Insert fails, write error message to database
            'Log error on update failure
            Dim TempSONumber As Integer = 0
            Dim strSONumber As String
            TempSONumber = Val(txtSalesOrderNumber.Text)
            strSONumber = CStr(TempSONumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Update SO from WO"
            ErrorReferenceNumber = "SO # " + strSONumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()
        End Try
    End Sub


    'Menu Strip Items

    Private Sub ExitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem1.Click
        Me.Dispose()
        Me.Close()
    End Sub




    'Command Buttons

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Dispose()
        Me.Close()
    End Sub

    Private Sub cmdPostWorkOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPostWorkOrder.Click
        Dim LinePartNumber As String = ""
        Dim LineUnitCost As Double = 0
        Dim LineQuantity As Double = 0
        Dim LineGLAccount As String = ""
        Dim LineDescription As String = ""
        Dim WorkOrderNumber As Integer = 0
        Dim strWorkOrderNumber As String = CStr(WorkOrderNumber)
        Dim SalesOrderNumber As Integer = 0
        Dim strSalesOrderNumber As String = CStr(SalesOrderNumber)
        Dim LineLineNumber As Integer = 0

        'Verification before removing inventory
        If cboWorkOrderNumber.Text = "" Or Val(cboWorkOrderNumber.Text) = 0 Then
            MsgBox("You must have a valid work order selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Do nothing - continue
        End If
        If Me.dgvWorkOrderLines.RowCount = 0 Then
            MsgBox("Cannot post a work order with no line items.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '******************************************************************************
        'Get Inventory Adjustment Batch Number
        Dim GetBatchNumber As Integer = 0
        Dim NextBatchNumber As Integer = 0

        Dim GetBatchNumberStatement As String = "SELECT MAX(BatchNumber) FROM InventoryAdjustmentTable"
        Dim GetBatchNumberCommand As New SqlCommand(GetBatchNumberStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetBatchNumber = CInt(GetBatchNumberCommand.ExecuteScalar)
        Catch ex As Exception
            GetBatchNumber = 0
        End Try
        con.Close()

        NextBatchNumber = GetBatchNumber + 1
        '*************************************************************************************************************
        Dim button As DialogResult = MessageBox.Show("This process will adjust inventory - do you wish to continue?", "POST/ADJUST INVENTORY", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If button = DialogResult.Yes Then
            'Create inventory adjustment to remove inventory.
            For Each LineRow As DataGridViewRow In dgvWorkOrderLines.Rows
                Try
                    LinePartNumber = LineRow.Cells("PartNumberColumn").Value
                Catch ex As System.Exception
                    LinePartNumber = ""
                End Try
                Try
                    LineDescription = LineRow.Cells("PartDescriptionColumn").Value
                Catch ex As System.Exception
                    LineDescription = ""
                End Try
                Try
                    LineUnitCost = LineRow.Cells("UnitCostColumn").Value
                Catch ex As System.Exception
                    LineUnitCost = 0
                End Try
                Try
                    LineQuantity = LineRow.Cells("QuantityColumn").Value
                Catch ex As System.Exception
                    LineQuantity = 0
                End Try
                Try
                    LineGLAccount = LineRow.Cells("CreditGLAccountColumn").Value
                Catch ex As System.Exception
                    LineGLAccount = ""
                End Try
                Try
                    LineLineNumber = LineRow.Cells("WorkOrderLineNumberColumn").Value
                Catch ex As System.Exception
                    LineLineNumber = 0
                End Try

                Dim LineExtendedAmount As Double = 0
                LineExtendedAmount = LineQuantity * LineUnitCost
                LineExtendedAmount = Math.Round(LineExtendedAmount, 2)
                '**********************************************************************************
                'Get next Inventory adjustment number
                Dim LastAdjustmentNumber As Integer = 0
                Dim NextAdjustmentNumber As Integer = 0

                Dim GetAdjustmentNumberStatement As String = "SELECT MAX(AdjustmentNumber) FROM InventoryAdjustmentTable"
                Dim GetAdjustmentNumberCommand As New SqlCommand(GetAdjustmentNumberStatement, con)

                If con.State = ConnectionState.Closed Then con.Open()
                Try
                    LastAdjustmentNumber = CInt(GetAdjustmentNumberCommand.ExecuteScalar)
                Catch ex As Exception
                    LastAdjustmentNumber = 0
                End Try
                con.Close()

                NextAdjustmentNumber = LastAdjustmentNumber + 1
                '**********************************************************************************
                Try
                    'Write Data to Inventory Adjustment Header Database Table
                    cmd = New SqlCommand("Insert Into InventoryAdjustmentTable(AdjustmentNumber, AdjustmentDate, DivisionID, PartNumber, Description, Reason, Quantity, Cost, Total, Status, BatchNumber, InventoryAccount, AdjustmentAccount, LineComment, AdjustmentAgent, PrintDate)Values(@AdjustmentNumber, @AdjustmentDate, @DivisionID, @PartNumber, @Description, @Reason, @Quantity, @Cost, @Total, @Status, @BatchNumber, @InventoryAccount, @AdjustmentAccount, @LineComment, @AdjustmentAgent, @PrintDate)", con)

                    With cmd.Parameters
                        .Add("@AdjustmentNumber", SqlDbType.VarChar).Value = NextAdjustmentNumber
                        .Add("@AdjustmentDate", SqlDbType.VarChar).Value = dtpWorkOrderDate.Text
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@PartNumber", SqlDbType.VarChar).Value = LinePartNumber
                        .Add("@Description", SqlDbType.VarChar).Value = LineDescription
                        .Add("@Quantity", SqlDbType.VarChar).Value = LineQuantity
                        .Add("@Cost", SqlDbType.VarChar).Value = LineUnitCost
                        .Add("@Total", SqlDbType.VarChar).Value = LineExtendedAmount
                        .Add("@Reason", SqlDbType.VarChar).Value = "WORKORDER"
                        .Add("@Status", SqlDbType.VarChar).Value = "POSTED"
                        .Add("@BatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
                        .Add("@InventoryAccount", SqlDbType.VarChar).Value = LineGLAccount
                        .Add("@AdjustmentAccount", SqlDbType.VarChar).Value = ""
                        .Add("@AdjustmentAgent", SqlDbType.VarChar).Value = EmployeeLoginName
                        .Add("@LineComment", SqlDbType.VarChar).Value = "SO# - " + strSalesOrderNumber + " \ WO# - " + strWorkOrderNumber
                        .Add("@PrintDate", SqlDbType.VarChar).Value = Now.ToShortDateString()
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '********************************************************************************
                    'Enter Inventory Transaction
                    cmd = New SqlCommand("Insert Into InventoryTransactionTable (TransactionNumber, TransactionDate, TransactionType, TransactionTypeNumber, TransactionTypeLineNumber, PartNumber,  PartDescription, Quantity, ItemCost, ExtendedCost, ItemPrice, ExtendedAmount, DivisionID, TransactionMath, GLAccount)values((SELECT isnull(MAX(TransactionNumber) + 1, 220000) FROM InventoryTransactionTable), TransactionDate, @TransactionType, @TransactionTypeNumber, @TransactionTypeLineNumber, @PartNumber, @PartDescription, @Quantity, @ItemCost, @ExtendedCost, @ItemPrice, @ExtendedAmount, @DivisionID, @TransactionMath, @GLAccount", con)

                    With cmd.Parameters
                        '.Add("@TransactionNumber", SqlDbType.VarChar).Value = NextGLNumber
                        .Add("@TransactionDate", SqlDbType.VarChar).Value = dtpWorkOrderDate.Text
                        .Add("@TransactionType", SqlDbType.VarChar).Value = "Inventory Adjustment - Work Order"
                        .Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = WorkOrderNumber
                        .Add("@TransactionTypeLineNumber", SqlDbType.VarChar).Value = LineLineNumber
                        .Add("@PartNumber", SqlDbType.VarChar).Value = LinePartNumber
                        .Add("@PartDescription", SqlDbType.VarChar).Value = LineDescription
                        .Add("@Quantity", SqlDbType.VarChar).Value = LineQuantity * -1
                        .Add("@ItemCost", SqlDbType.VarChar).Value = LineUnitCost
                        .Add("@ExtendedCost", SqlDbType.VarChar).Value = LineExtendedAmount * -1
                        .Add("@ItemPrice", SqlDbType.VarChar).Value = 0
                        .Add("@ExtendedAmount", SqlDbType.VarChar).Value = 0
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@TransactionMath", SqlDbType.VarChar).Value = "ADD"
                        .Add("@GLAccount", SqlDbType.VarChar).Value = LineGLAccount
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()
                    '********************************************************************************
                    'Enter the GL Transaction

                    'Command to write Line Amount to GL (CREDIT INVENTORY)
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = LineGLAccount
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Inventory Adjustment - Work Order"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpWorkOrderDate.Text
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "SO# - " + strSalesOrderNumber + " \ WO# - " + strWorkOrderNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = NextAdjustmentNumber
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Command to write Line Amount to GL (DEBIT WIP)
                    cmd = New SqlCommand("Insert Into GLTransactionMasterList (GLTransactionKey, GLAccountNumber, GLTransactionDescription, GLTransactionDate, GLTransactionDebitAmount, GLTransactionCreditAmount,  GLTransactionComment, DivisionID, GLJournalID, GLBatchNumber, GLReferenceNumber, GLReferenceLine, GLTransactionStatus)values((SELECT isnull(MAX(GLTransactionKey) + 1, 220000) FROM GLTransactionMasterList), @GLAccountNumber, @GLTransactionDescription, @GLTransactionDate, @GLTransactionDebitAmount, @GLTransactionCreditAmount,  @GLTransactionComment, @DivisionID, @GLJournalID, @GLBatchNumber, @GLReferenceNumber, @GLReferenceLine, @GLTransactionStatus)", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                        .Add("@GLAccountNumber", SqlDbType.VarChar).Value = "12800"
                        .Add("@GLTransactionDescription", SqlDbType.VarChar).Value = "Inventory Adjustment - Work Order"
                        .Add("@GLTransactionDate", SqlDbType.VarChar).Value = dtpWorkOrderDate.Text
                        .Add("@GLTransactionDebitAmount", SqlDbType.VarChar).Value = LineExtendedAmount
                        .Add("@GLTransactionCreditAmount", SqlDbType.VarChar).Value = 0
                        .Add("@GLTransactionComment", SqlDbType.VarChar).Value = "SO# - " + strSalesOrderNumber + " \ WO# - " + strWorkOrderNumber
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@GLJournalID", SqlDbType.VarChar).Value = "INVJOURNAL"
                        .Add("@GLBatchNumber", SqlDbType.VarChar).Value = NextBatchNumber
                        .Add("@GLReferenceNumber", SqlDbType.VarChar).Value = NextAdjustmentNumber
                        .Add("@GLReferenceLine", SqlDbType.VarChar).Value = 1
                        .Add("@GLTransactionStatus", SqlDbType.VarChar).Value = "POSTED"
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Update Work Order Header Table
                    cmd = New SqlCommand("UPDATE WorkOrderHeaderTable SET WorkOrderStatus = @WorkOrderStatus WHERE WorkOrderNumber = @WorkOrderNumber AND DivisionID = @DivisionID", con)

                    With cmd.Parameters
                        '.Add("@GLTransactionKey", SqlDbType.VarChar).Value = NextGLNumber
                        .Add("@WorkOrderNumber", SqlDbType.VarChar).Value = Val(cboWorkOrderNumber.Text)
                        .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                        .Add("@WorkOrderStatus", SqlDbType.VarChar).Value = "POSTED"
                     End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    'Load status
                    LoadWorkOrderStatus()
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempWONumber As Integer = 0
                    Dim strWONumber As String
                    TempWONumber = Val(cboWorkOrderNumber.Text)
                    strWONumber = CStr(TempWONumber)

                    ErrorDate = Today()
                    ErrorComment = ex.ToString()
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Inventory Adjustment Work Order"
                    ErrorReferenceNumber = "WO# " + strWONumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()
                End Try

                'Clear certain variables before next loop reiteration
                LinePartNumber = ""
                LineUnitCost = 0
                LineQuantity = 0
                LineGLAccount = ""
                LineDescription = ""
                WorkOrderNumber = 0
                strWorkOrderNumber = ""
                SalesOrderNumber = 0
                strSalesOrderNumber = ""
                LineLineNumber = 0
            Next

            MsgBox("WO posted and inventory updated.", MsgBoxStyle.OkOnly)
            'Update status
            LoadWorkOrderStatus()
        ElseIf button = DialogResult.No Then
            'Do nothing
        End If
    End Sub

    Private Sub cmdCreateSO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateSO.Click
        'Validation
        If cboWorkOrderNumber.Text = "" Or Val(cboWorkOrderNumber.Text) = 0 Then
            MsgBox("You must have a valid work order number.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Continue
        End If
        If txtWOStatus.Text = "CLOSED" Then
            MsgBox("This work order is closed - you must re-open it first.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Continue
        End If

        'Check to see if another sales order is linked to this work order
        Dim GetSONumber As Integer = 0

        Dim GetSONumberStatement As String = "SELECT COUNT(WorkOrderNumber) FROM SalesOrderHeaderTable WHERE WorkOrderNumber = @WorkOrderNumber AND DivisionID = @DivisionID AND WorkOrderNumber <> 0"
        Dim GetSONumberCommand As New SqlCommand(GetSONumberStatement, con)
        GetSONumberCommand.Parameters.Add("@WorkOrderNumber", SqlDbType.VarChar).Value = cboWorkOrderNumber.Text
        GetSONumberCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            GetSONumber = CInt(GetSONumberCommand.ExecuteScalar)
        Catch ex As Exception
            GetSONumber = 0
        End Try
        con.Close()

        If GetSONumber = 0 Then ''No work order associated with any sales order
            'Write to Sales Order Header Table
            InsertIntoSalesOrderHeader()

            'Save sales order number in Work Order Header Table
            UpdateWorkOrderHeaderTable()

            MsgBox("Sales order has been created.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Error log





        End If
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        GlobalDivisionCode = cboDivisionID.Text
        GlobalWorkOrderNumber = Val(cboWorkOrderNumber.Text)

        Using NewPrintWorkOrder As New PrintWorkOrder
            Dim Result = NewPrintWorkOrder.ShowDialog
        End Using
    End Sub

    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        'If Work Order has relieved inventory, it cannot be deleted as an inventory adjustment has already been done

        'Get work order status
        Dim WOStatus As String = ""

        Dim WOStatusStatement As String = "SELECT WorkOrderStatus FROM WorkOrderHeaderTable WHERE WorkOrderNumber = @WorkOrderNumber"
        Dim WOStatusCommand As New SqlCommand(WOStatusStatement, con)
        WOStatusCommand.Parameters.Add("@WorkOrderNumber", SqlDbType.VarChar).Value = Val(cboWorkOrderNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            WOStatus = CStr(WOStatusCommand.ExecuteScalar)
        Catch ex As Exception
            WOStatus = ""
        End Try
        con.Close()

        If WOStatus = "OPEN" Then
            'Delete work order
            Try
                cmd = New SqlCommand("Delete From WorkOrderHeaderTable WHERE  WorkOrderNumber = @WorkOrderNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@WorkOrderNumber", SqlDbType.VarChar).Value = Val(cboWorkOrderNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                MsgBox("Work Order has been deleted.", MsgBoxStyle.OkOnly)

                ClearDataInDatagrid()
                ClearVariables()
                ClearData()
            Catch ex As Exception
                'Error Log
            End Try
        Else
            MsgBox("Work order is not open and cannot be deleted.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        'Validation - Check mandatory fields
        If cboWorkOrderNumber.Text = "" Then
            MsgBox("You must have a valid Work Order #", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        Try
            LoadWOTotals()
            UpdateWorkOrderHeaderTable()
            LoadWorkOrderStatus()

            MsgBox("Work Order has been saved.", MsgBoxStyle.OkOnly)
        Catch ex As Exception
            'Error Log
        End Try

    End Sub

    Private Sub cmdClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearAll.Click
        ClearVariables()
        ClearDataInDatagrid()
        ClearData()
    End Sub

    Private Sub cmdAddLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddLine.Click
        'Validate fields
        If cboWorkOrderNumber.Text = "" Then
            MsgBox("You must have a valid Work Order selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Continue
        End If

        'Verify if current work order number exists in the database
        Dim WorkOrderExists As Integer = 0

        Dim CountWorkOrdersStatement As String = "SELECT COUNT(WorkOrderNumber) FROM WorkOrderHeaderTable WHERE WorkOrderNumber = @WorkOrderNumber"
        Dim CountWorkOrdersCommand As New SqlCommand(CountWorkOrdersStatement, con)
        CountWorkOrdersCommand.Parameters.Add("@WorkOrderNumber", SqlDbType.VarChar).Value = Val(cboWorkOrderNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            WorkOrderExists = CInt(CountWorkOrdersCommand.ExecuteScalar)
        Catch ex As Exception
            WorkOrderExists = 0
        End Try
        con.Close()

        If WorkOrderExists = 1 Then
            'Work order does exist - continue
        Else
            MsgBox("Work Order # does not exist", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If cboPartNumber.Text = "" Or cboPartDescription.Text = "" Then
            MsgBox("You must have a part # and description.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'Continue
        End If

        'Save Header Data
        UpdateWorkOrderHeaderTable()

        'Load GL Accounts
        LoadGLAccounts()

        'Get next line number
        Dim NextWorkOrderLineNumber, LastWorkorderLineNumber As Integer

        Dim GetMAXLineNumberStatement As String = "SELECT MAX(WorkOrderLineNumber) FROM WorkOrderLineTable WHERE WorkOrderNumber = @WorkOrderNumber"
        Dim GetMAXLineNumberCommand As New SqlCommand(GetMAXLineNumberStatement, con)
        GetMAXLineNumberCommand.Parameters.Add("@WorkOrderNumber", SqlDbType.VarChar).Value = Val(cboWorkOrderNumber.Text)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastWorkorderLineNumber = CInt(GetMAXLineNumberCommand.ExecuteScalar)
        Catch ex As Exception
            LastWorkorderLineNumber = 0
        End Try
        con.Close()

        NextWorkOrderLineNumber = LastWorkorderLineNumber + 1

        'Write to database
        'Try
        cmd = New SqlCommand("INSERT INTO WorkOrderLineTable (WorkOrderNumber, WorkOrderLineNumber, PartNumber, PartDescription, LongDescription, Quantity, UnitCost, SalesTax, ExtendedAmount, LineComment, CreditGLAccount, DebitGLAccount, DivisionID, LineStatus) Values (@WorkOrderNumber, @WorkOrderLineNumber, @PartNumber, @PartDescription, @LongDescription, @Quantity, @UnitCost, @SalesTax, @ExtendedAmount, @LineComment, @CreditGLAccount, @DebitGLAccount, @DivisionID, @LineStatus)", con)

        With cmd.Parameters
            .Add("@WorkOrderNumber", SqlDbType.VarChar).Value = Val(cboWorkOrderNumber.Text)
            .Add("@WorkOrderLineNumber", SqlDbType.VarChar).Value = NextWorkOrderLineNumber
            .Add("@PartNumber", SqlDbType.VarChar).Value = cboPartNumber.Text
            .Add("@PartDescription", SqlDbType.VarChar).Value = cboPartDescription.Text
            .Add("@LongDescription", SqlDbType.VarChar).Value = txtLongDescription.Text
            .Add("@Quantity", SqlDbType.VarChar).Value = Val(txtQuantity.Text)
            .Add("@UnitCost", SqlDbType.VarChar).Value = Val(txtUnitCost.Text)
            .Add("@SalesTax", SqlDbType.VarChar).Value = 0
            .Add("@ExtendedAmount", SqlDbType.VarChar).Value = Val(txtExtendedCost.Text)
            .Add("@LineComment", SqlDbType.VarChar).Value = txtLineInstructions.Text
            .Add("@CreditGLAccount", SqlDbType.VarChar).Value = CreditAccount
            .Add("@DebitGLAccount", SqlDbType.VarChar).Value = DebitAccount
            .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
        End With

        If con.State = ConnectionState.Closed Then con.Open()
        cmd.ExecuteNonQuery()
        con.Close()

        'Clear Fields
        ClearLines()

        'Reload datagrid
        ShowData()

        'Load totals
        LoadWOTotals()

        cboPartNumber.Focus()
    End Sub

    Private Sub cmdClearLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearLine.Click
        ClearLines()
    End Sub

    Private Sub cmdGenerateNewWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenerateNewWO.Click
        'Clear All Fields
        ClearVariables()
        ClearDataInDatagrid()
        ClearData()

        'Get next number
        Dim NextWorkOrderNumber, LastWorkorderNumber As Integer

        Dim GetMaxWONumberStatement As String = "SELECT MAX(WorkOrderNumber) FROM WorkOrderHeaderTable"
        Dim GetMaxWONumberCommand As New SqlCommand(GetMaxWONumberStatement, con)
  
        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastWorkorderNumber = CInt(GetMaxWONumberCommand.ExecuteScalar)
        Catch ex As Exception
            LastWorkorderNumber = 21000000
        End Try
        con.Close()

        NextWorkOrderNumber = LastWorkorderNumber + 1

        cboWorkOrderNumber.Text = NextWorkOrderNumber

        'Write to database
        Try
            InsertWorkOrderHeaderTable()
            LoadWorkOrderStatus()
        Catch ex As Exception
            'Error Log
        End Try

    End Sub

    Private Sub cmdDeleteLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteLine.Click
        'Validate and Delete line
        If cboWorkOrderNumber.Text = "" Then
            MsgBox("You must have a valid work order number selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        If txtWOStatus.Text = "OPEN" Then
            'Continue
        Else
            MsgBox("This work order is not open.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        If Me.dgvWorkOrderLines.RowCount > 0 Then
            Try
                'UPDATE Purchase Order Extended Amount based on line changes
                cmd = New SqlCommand("DELETE FROM WorkOrderLineTable WHERE WorkOrderNumber = @WorkOrderNumber AND WorkOrderLineNumber = @WorkOrderLineNumber", con)

                With cmd.Parameters
                    .Add("@WorkOrderNumber", SqlDbType.VarChar).Value = cboWorkOrderNumber.Text
                    .Add("@WorkOrderLineNumber", SqlDbType.VarChar).Value = nbrLineNumber.Value
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                'Do nothing
            End Try

            'Re-number existing rows, if any
            Dim CountLines As Integer = 0

            Dim CountWONumberStatement As String = "SELECT COUNT(WorkOrderNumber) FROM WorkOrderLineTable WHERE WorkOrderNumber = @WorkOrderNumber"
            Dim CountWONumberCommand As New SqlCommand(CountWONumberStatement, con)
            CountWONumberCommand.Parameters.Add("@WorkOrderNumber", SqlDbType.VarChar).Value = cboWorkOrderNumber.Text
            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CountLines = CInt(CountWONumberCommand.ExecuteScalar)
            Catch ex As Exception
                CountLines = 0
            End Try
            con.Close()

            If CountLines = 0 Then
                'Do nothing
            Else
                'Renumber lines
                Dim TempLineNumber As Integer = 1000

                For Each row As DataGridViewRow In dgvWorkOrderLines.Rows
                    Dim LineNumber As Integer
                    Try
                        LineNumber = row.Cells("WorkOrderLineNumberColumn").Value
                    Catch ex As Exception
                        LineNumber = 0
                    End Try

                    'UPDATE Work Order Lines
                    cmd = New SqlCommand("UPDATE WorkOrderLineTable SET WorkOrderLineNumber = @WorkOrderLineNumber WHERE WorkOrderNumber = @WorkOrderNumber AND WorkOrderLineNumber = @WorkOrderLineNumber2", con)

                    With cmd.Parameters
                        .Add("@WorkOrderNumber", SqlDbType.VarChar).Value = Val(cboWorkOrderNumber.Text)
                        .Add("@WorkOrderLineNumber", SqlDbType.VarChar).Value = TempLineNumber
                        .Add("@WorkOrderLineNumber2", SqlDbType.VarChar).Value = LineNumber
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    TempLineNumber = TempLineNumber + 1
                Next

                'Reload datagrid
                ShowData()

                'Renumber lines
                Dim TempLineNumber2 As Integer = 1

                For Each row As DataGridViewRow In dgvWorkOrderLines.Rows
                    Dim LineNumber As Integer

                    Try
                        LineNumber = row.Cells("WorkOrderLineNumberColumn").Value
                    Catch ex As Exception
                        LineNumber = 0
                    End Try

                    'UPDATE Work Order Lines
                    cmd = New SqlCommand("UPDATE WorkOrderLineTable SET WorkOrderLineNumber = @WorkOrderLineNumber WHERE WorkOrderNumber = @WorkOrderNumber AND WorkOrderLineNumber = @WorkOrderLineNumber2", con)

                    With cmd.Parameters
                        .Add("@WorkOrderNumber", SqlDbType.VarChar).Value = Val(cboWorkOrderNumber.Text)
                        .Add("@WorkOrderLineNumber", SqlDbType.VarChar).Value = TempLineNumber2
                        .Add("@WorkOrderLineNumber2", SqlDbType.VarChar).Value = LineNumber
                    End With

                    If con.State = ConnectionState.Closed Then con.Open()
                    cmd.ExecuteNonQuery()
                    con.Close()

                    TempLineNumber2 = TempLineNumber2 + 1
                Next
            End If

            'Reload datagrid
            ShowData()

            MsgBox("Line deleted.", MsgBoxStyle.OkOnly)
        Else
            'Do nothing - no rows in datagrid
        End If
    End Sub

    Public Sub SaveInsertIntoSalesOrderHeader()
        Try
            Dim MAXStatement As String = "SELECT MAX(SalesOrderKey) FROM SalesOrderHeaderTable"
            Dim MAXCommand As New SqlCommand(MAXStatement, con)

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                LastSONumber = CInt(MAXCommand.ExecuteScalar)
            Catch ex As System.Exception
                LastSONumber = 500000
            End Try
            con.Close()

            NextSONumber = LastSONumber + 1
            txtSalesOrderNumber.Text = NextSONumber

            'Write Data to Sales Order Header Database Table
            cmd = New SqlCommand("Insert Into SalesOrderHeaderTable(SalesOrderKey, SalesOrderDate, CustomerID, CustomerPO, SalesPerson, ShipVia, FreightCharge, TotalSalesTax, ProductTotal, SOTotal, SOStatus, DivisionKey, PRONumber, ShippingDate, HeaderComment, AdditionalShipTo, ShippingWeight, QuoteNumber, QuotedFreight, SpecialInstructions, DropShipPONumber, CustomerPOType, TotalSalesTax2, TotalSalesTax3, TotalEstCOS, TaxRate1, TaxRate2, TaxRate3, Locked, FOB, CustomerClass, ShippingMethod, ThirdPartyShipper, ShipToName, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry, ShipEmail, ShippingAccount, SpecialLabelLine1, SpecialLabelLine2, SpecialLabelLine3)Values(@SalesOrderKey, @SalesOrderDate, @CustomerID, @CustomerPO, @SalesPerson, @ShipVia, @FreightCharge, @TotalSalesTax, @ProductTotal, @SOTotal, @SOStatus, @DivisionKey, @PRONumber, @ShippingDate, @HeaderComment, @AdditionalShipTo, @ShippingWeight, @QuoteNumber, @QuotedFreight, @SpecialInstructions, @DropShipPONumber, @CustomerPOType, @TotalSalesTax2, @TotalSalesTax3, @TotalEstCOS, @TaxRate1, @TaxRate2, @TaxRate3, @Locked, @FOB, @CustomerClass, @ShippingMethod, @ThirdPartyShipper, @ShipToName, @ShipToAddress1, @ShipToAddress2, @ShipToCity, @ShipToState, @ShipToZip, @ShipToCountry, @ShipEmail, @ShippingAccount, @SpecialLabelLine1, @SpecialLabelLine2, @SpecialLabelLine3)", con)

            With cmd.Parameters
                .Add("@SalesOrderKey", SqlDbType.VarChar).Value = NextSONumber
                .Add("@SalesOrderDate", SqlDbType.VarChar).Value = Now()
                .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
                .Add("@CustomerPOType", SqlDbType.VarChar).Value = ""
                .Add("@SalesPerson", SqlDbType.VarChar).Value = EmployeeSalespersonCode
                .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                .Add("@FreightCharge", SqlDbType.VarChar).Value = 0
                .Add("@TotalSalesTax", SqlDbType.VarChar).Value = 0
                .Add("@ProductTotal", SqlDbType.VarChar).Value = 0
                .Add("@SOTotal", SqlDbType.VarChar).Value = 0
                .Add("@SOStatus", SqlDbType.VarChar).Value = "OPEN"
                .Add("@DivisionKey", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@PRONumber", SqlDbType.VarChar).Value = ""
                .Add("@ShippingDate", SqlDbType.VarChar).Value = txtPromiseDate.Text
                .Add("@HeaderComment", SqlDbType.VarChar).Value = txtHeaderComment.Text
                .Add("@AdditionalShipTo", SqlDbType.VarChar).Value = cboShipToID.Text
                .Add("@ShippingWeight", SqlDbType.VarChar).Value = 0
                .Add("@QuoteNumber", SqlDbType.VarChar).Value = ""
                .Add("@QuotedFreight", SqlDbType.VarChar).Value = 0
                .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialShippingInstructions.Text
                .Add("@DropShipPONumber", SqlDbType.VarChar).Value = 0
                .Add("@TotalSalesTax2", SqlDbType.VarChar).Value = 0
                .Add("@TotalSalesTax3", SqlDbType.VarChar).Value = 0
                .Add("@TotalEstCOS", SqlDbType.VarChar).Value = 0
                .Add("@TaxRate1", SqlDbType.VarChar).Value = 0
                .Add("@TaxRate2", SqlDbType.VarChar).Value = 0
                .Add("@TaxRate3", SqlDbType.VarChar).Value = 0
                .Add("@Locked", SqlDbType.VarChar).Value = EmployeeLoginName
                .Add("@FOB", SqlDbType.VarChar).Value = ""
                .Add("@CustomerClass", SqlDbType.VarChar).Value = ""
                .Add("@ShippingMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                .Add("@ThirdPartyShipper", SqlDbType.VarChar).Value = ""
                .Add("@ShipToName", SqlDbType.VarChar).Value = txtShipToName.Text
                .Add("@ShipToAddress1", SqlDbType.VarChar).Value = txtAddress1.Text
                .Add("@ShipToAddress2", SqlDbType.VarChar).Value = txtAddress2.Text
                .Add("@ShipToCity", SqlDbType.VarChar).Value = txtCity.Text
                .Add("@ShipToState", SqlDbType.VarChar).Value = txtState.Text
                .Add("@ShipToZip", SqlDbType.VarChar).Value = txtZip.Text
                .Add("@ShipToCountry", SqlDbType.VarChar).Value = txtCountry.Text
                .Add("@ShipEmail", SqlDbType.VarChar).Value = ""
                .Add("@ShippingAccount", SqlDbType.VarChar).Value = ""
                .Add("@SpecialLabelLine1", SqlDbType.VarChar).Value = ""
                .Add("@SpecialLabelLine2", SqlDbType.VarChar).Value = ""
                .Add("@SpecialLabelLine3", SqlDbType.VarChar).Value = ""
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As System.Exception
            'If Insert fails, write error message to database
            Dim TempWONumber As Integer = 0
            Dim strWONumber As String
            TempWONumber = Val(cboWorkOrderNumber.Text)
            strWONumber = CStr(TempWONumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Insert Command --- Work Order Form"
            ErrorReferenceNumber = "WO # " + strWONumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()

            ClearData()
            ClearDataInDatagrid()
            ClearVariables()
        End Try
    End Sub

    Private Sub cboDivisionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDivisionID.SelectedIndexChanged
        LoadCustomerList()
        LoadCustomerName()
        LoadItemList()
        LoadPartDescription()
        LoadWorkOrderNumber()
        LoadShipMethod()
        LoadWorkOrderStatus()

        ClearVariables()
        ClearDataInDatagrid()
        ClearData()
    End Sub

    Private Sub cboCustomerID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerID.SelectedIndexChanged
        LoadCustomerNameByID()
        LoadAdditionalShipTo()
        LoadDefaultShipTo()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerName.SelectedIndexChanged
        LoadCustomerIDByName()
    End Sub

    Private Sub cboWorkOrderNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboWorkOrderNumber.SelectedIndexChanged
        If cboWorkOrderNumber.Text = "" Then
            'Do nothing
        Else
            ShowData()
            LoadWorkOrderData()
            LoadWorkOrderStatus()
            LoadScannedDocuments()
        End If
    End Sub

    Private Sub cboShipToID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboShipToID.SelectedIndexChanged
        LoadAddShipToData()
    End Sub

    Private Sub cboPartNumber_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartNumber.SelectedIndexChanged
        LoadDescriptionByPart()
        LoadFIFOCost()
        LoadLongDescription()
    End Sub

    Private Sub cboPartDescription_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPartDescription.SelectedIndexChanged
        LoadPartByDescription()
    End Sub

    Private Sub cboCountryName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCountryName.SelectedIndexChanged
        If cboCountryName.Text <> "" Then
            LoadCountryCodeByCountryName()
        Else
            'Do nothing
        End If
    End Sub

    Private Sub txtCountry_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCountry.TextChanged
        If txtCountry.Text <> "" Then
            LoadCountryNameByCountryCode()
        Else
            'Do nothing
        End If
    End Sub

    Private Sub txtQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantity.TextChanged
        Dim LineQuantity As Double = 0
        Dim LineUnitCost As Double = 0
        Dim LineExtendedAmount As Double = 0

        LineQuantity = Val(txtQuantity.Text)
        LineUnitCost = Val(txtUnitCost.Text)
        LineExtendedAmount = LineQuantity * LineUnitCost
        LineExtendedAmount = Math.Round(LineExtendedAmount, 2)

        If Val(txtQuantity.Text) = 0 Or txtQuantity.Text = "" Then
            txtExtendedCost.Clear()
        Else
            txtExtendedCost.Text = LineExtendedAmount
        End If
    End Sub

    Public Sub LoadWorkOrderData()
        'Defina variables
        Dim WorkOrderDate, PromiseDate, CustomerID, ShipVia, ShipMethod, ThirdPartyBilling, CustomerPO, HeaderComment, SpecialInstructions, ShipToID, ShipToName, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry, Salesperson, WOStatus, DateClosed As String
        Dim SalesOrderNumber As Integer
        Dim TotalExtendedCost, TotalFreight, TotalTax, WorkOrderTotal As Double

        Dim GetWODataString As String = "SELECT * FROM WorkOrderHeaderTable WHERE WorkOrderNumber = @WorkOrderNumber AND DivisionID = @DivisionID"
        Dim GetWODataCommand As New SqlCommand(GetWODataString, con)
        GetWODataCommand.Parameters.Add("@WorkOrderNumber", SqlDbType.VarChar).Value = cboWorkOrderNumber.Text
        GetWODataCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

        If con.State = ConnectionState.Closed Then con.Open()
        Dim reader As SqlDataReader = GetWODataCommand.ExecuteReader()
        If reader.HasRows Then
            reader.Read()
            If IsDBNull(reader.Item("WorkOrderDate")) Then
                WorkOrderDate = ""
            Else
                WorkOrderDate = reader.Item("WorkOrderDate")
            End If
            If IsDBNull(reader.Item("PromiseDate")) Then
                PromiseDate = ""
            Else
                PromiseDate = reader.Item("PromiseDate")
            End If
            If IsDBNull(reader.Item("CustomerID")) Then
                CustomerID = ""
            Else
                CustomerID = reader.Item("CustomerID")
            End If
            If IsDBNull(reader.Item("ShipVia")) Then
                ShipVia = ""
            Else
                ShipVia = reader.Item("ShipVia")
            End If
            If IsDBNull(reader.Item("Shipmethod")) Then
                ShipMethod = ""
            Else
                ShipMethod = reader.Item("Shipmethod")
            End If
            If IsDBNull(reader.Item("ThirdPartyShipping")) Then
                ThirdPartyBilling = ""
            Else
                ThirdPartyBilling = reader.Item("ThirdPartyShipping")
            End If
            If IsDBNull(reader.Item("CustomerPO")) Then
                CustomerPO = ""
            Else
                CustomerPO = reader.Item("CustomerPO")
            End If
            If IsDBNull(reader.Item("SalesOrderNumber")) Then
                SalesOrderNumber = 0
            Else
                SalesOrderNumber = reader.Item("SalesOrderNumber")
            End If
            If IsDBNull(reader.Item("HeaderComment")) Then
                HeaderComment = ""
            Else
                HeaderComment = reader.Item("HeaderComment")
            End If
            If IsDBNull(reader.Item("SpecialInstructions")) Then
                SpecialInstructions = ""
            Else
                SpecialInstructions = reader.Item("SpecialInstructions")
            End If
            If IsDBNull(reader.Item("ShipToID")) Then
                ShipToID = ""
            Else
                ShipToID = reader.Item("ShipToID")
            End If
            If IsDBNull(reader.Item("ShipToName")) Then
                ShipToName = ""
            Else
                ShipToName = reader.Item("ShipToName")
            End If
            If IsDBNull(reader.Item("ShipToAddress1")) Then
                ShipToAddress1 = ""
            Else
                ShipToAddress1 = reader.Item("ShipToAddress1")
            End If
            If IsDBNull(reader.Item("ShipToAddress2")) Then
                ShipToAddress2 = ""
            Else
                ShipToAddress2 = reader.Item("ShipToAddress2")
            End If
            If IsDBNull(reader.Item("ShipToCity")) Then
                ShipToCity = ""
            Else
                ShipToCity = reader.Item("ShipToCity")
            End If
            If IsDBNull(reader.Item("ShipToState")) Then
                ShipToState = ""
            Else
                ShipToState = reader.Item("ShipToState")
            End If
            If IsDBNull(reader.Item("ShipToZip")) Then
                ShipToZip = ""
            Else
                ShipToZip = reader.Item("ShipToZip")
            End If
            If IsDBNull(reader.Item("ShipToCountry")) Then
                ShipToCountry = ""
            Else
                ShipToCountry = reader.Item("ShipToCountry")
            End If
            If IsDBNull(reader.Item("Salesperson")) Then
                Salesperson = ""
            Else
                Salesperson = reader.Item("Salesperson")
            End If
            If IsDBNull(reader.Item("TotalExtendedCost")) Then
                TotalExtendedCost = 0
            Else
                TotalExtendedCost = reader.Item("TotalExtendedCost")
            End If
            If IsDBNull(reader.Item("TotalFreight")) Then
                TotalFreight = 0
            Else
                TotalFreight = reader.Item("TotalFreight")
            End If
            If IsDBNull(reader.Item("TotalTax")) Then
                TotalTax = 0
            Else
                TotalTax = reader.Item("TotalTax")
            End If
            If IsDBNull(reader.Item("WorkOrderTotal")) Then
                WorkOrderTotal = 0
            Else
                WorkOrderTotal = reader.Item("WorkOrderTotal")
            End If
            If IsDBNull(reader.Item("WorkOrderStatus")) Then
                WOStatus = ""
            Else
                WOStatus = reader.Item("WorkOrderStatus")
            End If
            If IsDBNull(reader.Item("DateClosed")) Then
                DateClosed = ""
            Else
                DateClosed = reader.Item("DateClosed")
            End If
        Else
            WorkOrderDate = ""
            PromiseDate = ""
            CustomerID = ""
            ShipVia = ""
            ShipMethod = ""
            ThirdPartyBilling = ""
            CustomerPO = ""
            HeaderComment = ""
            SpecialInstructions = ""
            ShipToID = ""
            ShipToName = ""
            ShipToAddress1 = ""
            ShipToAddress2 = ""
            ShipToCity = ""
            ShipToState = ""
            ShipToZip = ""
            ShipToCountry = ""
            Salesperson = ""
            WOStatus = ""
            DateClosed = ""
            SalesOrderNumber = 0
            TotalExtendedCost = 0
            TotalFreight = 0
            TotalTax = 0
            WorkOrderTotal = 0
        End If
        reader.Close()
        con.Close()

        dtpWorkOrderDate.Text = WorkOrderDate
        txtPromiseDate.Text = PromiseDate
        cboCustomerID.Text = CustomerID
        cboShipVia.Text = ShipVia
        cboShipMethod.Text = ShipMethod
        txtThirdPartyAddress.Text = ThirdPartyBilling
        txtCustomerPO.Text = CustomerPO
        txtHeaderComment.Text = HeaderComment
        txtSpecialShippingInstructions.Text = SpecialInstructions
        cboShipToID.Text = ShipToID
        txtShipToName.Text = ShipToName
        txtAddress1.Text = ShipToAddress1
        txtAddress2.Text = ShipToAddress2
        txtCity.Text = ShipToCity
        txtState.Text = ShipToState
        txtZip.Text = ShipToState
        txtCountry.Text = ShipToCountry
        cboCountryName.Text = ShipToCountry
        cboSalesperson.Text = Salesperson
        txtWOStatus.Text = WOStatus
        txtDateClosed.Text = DateClosed
        txtSalesOrderNumber.Text = SalesOrderNumber
        txtTotalExtendedCost.Text = FormatCurrency(TotalExtendedCost, 2)
        txtTotalFreight.Text = FormatCurrency(TotalFreight, 2)
        txtTotalTax.Text = FormatCurrency(TotalTax, 2)
        txtWorkOrderTotal.Text = FormatCurrency(WorkOrderTotal, 2)
        txtEstFreight.Text = TotalFreight

        LoadWorkOrderStatus()
        cboWorkOrderNumber.Focus()
    End Sub


    Private Sub dgvWorkOrderLines_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvWorkOrderLines.CellClick
        If Me.dgvWorkOrderLines.RowCount > 0 Then
            Dim RowLineNumber As Integer = 0

            Dim RowIndex As Integer = Me.dgvWorkOrderLines.CurrentCell.RowIndex

            Try
                RowLineNumber = Me.dgvWorkOrderLines.Rows(RowIndex).Cells("WorkOrderLineNumberColumn").Value
            Catch ex As Exception
                RowLineNumber = 0
            End Try

            nbrLineNumber.Value = RowLineNumber
        End If
    End Sub

    Private Sub dgvWorkOrderLines_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvWorkOrderLines.CellContentClick
        If Me.dgvWorkOrderLines.RowCount > 0 Then
            Dim RowLineNumber As Integer = 0

            Dim RowIndex As Integer = Me.dgvWorkOrderLines.CurrentCell.RowIndex

            Try
                RowLineNumber = Me.dgvWorkOrderLines.Rows(RowIndex).Cells("WorkOrderLineNumberColumn").Value
            Catch ex As Exception
                RowLineNumber = 0
            End Try

            nbrLineNumber.Value = RowLineNumber
        End If
    End Sub

    Private Sub dgvWorkOrderLines_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvWorkOrderLines.CellValueChanged
        'If status is CLOSED, allow changes to comments only
        'If status is POSTED, allow changes to comments only
        'If status is OPEN, allow changes to quantity, cost, comments, etc.

        Dim CurrentStatus As String = txtWOStatus.Text

        Select Case CurrentStatus
            Case "OPEN"

            Case "POSTED"

            Case "CLOSED"

            Case Else

        End Select
    End Sub

    Private Sub dgvWorkOrderLines_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvWorkOrderLines.RowHeaderMouseClick
        If Me.dgvWorkOrderLines.RowCount > 0 Then
            Dim RowLineNumber As Integer = 0

            Dim RowIndex As Integer = Me.dgvWorkOrderLines.CurrentCell.RowIndex

            Try
                RowLineNumber = Me.dgvWorkOrderLines.Rows(RowIndex).Cells("WorkOrderLineNumberColumn").Value
            Catch ex As Exception
                RowLineNumber = 0
            End Try

            nbrLineNumber.Value = RowLineNumber
        End If
    End Sub

    Private Sub cmdReIssueWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReIssueWO.Click
        If cboWorkOrderNumber.Text = "" Or Val(cboWorkOrderNumber.Text) = 0 Then
            MsgBox("You must have a valid work order selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        'Validate - check for lines and existing wo data
        If Me.dgvWorkOrderLines.RowCount = 0 Then
            MsgBox("This work order has no line items.", MsgBoxStyle.OkOnly)
            Exit Sub
        End If
        '***********************************************************************************
        'If there is a sales order associated with this work order, do not carry it to the new work order
        If txtSalesOrderNumber.Text = "" Then
            'Do nothing
        Else
            txtSalesOrderNumber.Clear()
        End If
        '***********************************************************************************
        'Get next work order number
        Dim LastWONumber, NextWONumber As Integer

        Dim MAXStatement As String = "SELECT MAX(WorkOrderNumber) FROM WorkOrderHeaderTable"
        Dim MAXCommand As New SqlCommand(MAXStatement, con)

        If con.State = ConnectionState.Closed Then con.Open()
        Try
            LastWONumber = CInt(MAXCommand.ExecuteScalar)
        Catch ex As System.Exception
            LastWONumber = 500000
        End Try
        con.Close()

        NextWONumber = LastWONumber + 1
        cboWorkOrderNumber.Text = NextWONumber
        '***********************************************************************************
        'Insert into work order header table.
        Try
            'Insert
            cmd = New SqlCommand("INSERT INTO WorkOrderHeaderTable (WorkOrderNumber, WorkOrderDate, PromiseDate, DivisionID, CustomerID, ShipVia, ShipMethod, CustomerPO, SalesOrderNumber, HeaderComment, SpecialInstructions, ShipToID, ShipToName, ShipToAddress1, ShipToAddress2, ShipToCity, ShipToState, ShipToZip, ShipToCountry, Salesperson, TotalExtendedCost, TotalFreight, TotalTax, WorkOrderTotal, WorkOrderStatus, DateClosed) Values (@WorkOrderNumber, @WorkOrderDate, @PromiseDate, @DivisionID, @CustomerID, @ShipVia, @ShipMethod, @CustomerPO, @SalesOrderNumber, @HeaderComment, @SpecialInstructions, @ShipToID, @ShipToName, @ShipToAddress1, @ShipToAddress2, @ShipToCity, @ShipToState, @ShipToZip, @ShipToCountry, @Salesperson, @TotalExtendedCost, @TotalFreight, @TotalTax, @WorkOrderTotal, @WorkOrderStatus, @DateClosed)", con)

            With cmd.Parameters
                .Add("@WorkOrderNumber", SqlDbType.VarChar).Value = NextWONumber
                .Add("@WorkOrderDate", SqlDbType.VarChar).Value = dtpWorkOrderDate.Text
                .Add("@PromiseDate", SqlDbType.VarChar).Value = txtPromiseDate.Text
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                .Add("@CustomerID", SqlDbType.VarChar).Value = cboCustomerID.Text
                .Add("@ShipVia", SqlDbType.VarChar).Value = cboShipVia.Text
                .Add("@ShipMethod", SqlDbType.VarChar).Value = cboShipMethod.Text
                .Add("@CustomerPO", SqlDbType.VarChar).Value = txtCustomerPO.Text
                .Add("@SalesOrderNumber", SqlDbType.VarChar).Value = 0
                .Add("@HeaderComment", SqlDbType.VarChar).Value = txtHeaderComment.Text
                .Add("@SpecialInstructions", SqlDbType.VarChar).Value = txtSpecialShippingInstructions.Text
                .Add("@ShipToID", SqlDbType.VarChar).Value = cboShipToID.Text
                .Add("@ShipToName", SqlDbType.VarChar).Value = txtShipToName.Text
                .Add("@ShipToAddress1", SqlDbType.VarChar).Value = txtAddress1.Text
                .Add("@ShipToAddress2", SqlDbType.VarChar).Value = txtAddress2.Text
                .Add("@ShipToCity", SqlDbType.VarChar).Value = txtCity.Text
                .Add("@ShipToState", SqlDbType.VarChar).Value = txtState.Text
                .Add("@ShipToZip", SqlDbType.VarChar).Value = txtZip.Text
                .Add("@ShipToCountry", SqlDbType.VarChar).Value = txtCountry.Text
                .Add("@Salesperson", SqlDbType.VarChar).Value = EmployeeSalespersonCode
                .Add("@TotalExtendedCost", SqlDbType.VarChar).Value = 0
                .Add("@TotalFreight", SqlDbType.VarChar).Value = 0
                .Add("@TotalTax", SqlDbType.VarChar).Value = 0
                .Add("@WorkOrderTotal", SqlDbType.VarChar).Value = 0
                .Add("@WorkOrderStatus", SqlDbType.VarChar).Value = "OPEN"
                .Add("@DateClosed", SqlDbType.VarChar).Value = ""
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            'Error Log
            'If Insert fails, write error message to database
            Dim TempWONumber As Integer = 0
            Dim strWONumber As String
            TempWONumber = Val(cboWorkOrderNumber.Text)
            strWONumber = CStr(TempWONumber)

            ErrorDate = Today()
            ErrorComment = ex.ToString()
            ErrorDivision = cboDivisionID.Text
            ErrorDescription = "Re-Issue Work Order --- Work Order Form"
            ErrorReferenceNumber = "WO # " + strWONumber
            ErrorUser = EmployeeLoginName

            TFPErrorLogUpdate()

            MsgBox("Work order re-issue failed.", MsgBoxStyle.OkOnly)
            Exit Sub
        End Try
        '****************************************************************************************
        'Declare line variables
        Dim RowLineNumber As Integer = 0
        Dim RowPartNumber As String = ""
        Dim RowPartDescription As String = ""
        Dim RowQuantity As Double = 0
        Dim RowUnitCost As Double = 0
        Dim RowLineComment As String = ""
        Dim RowCreditGLAccount As String = ""
        Dim RowDebitGLAccount As String = ""
        Dim RowLongDescription As String = ""
        Dim RowExtendedCost As Double = 0

        'Run a loop to add line items to new work order 
        For Each LineRow As DataGridViewRow In dgvWorkOrderLines.Rows
            Try
                RowLineNumber = LineRow.Cells("WorkOrderLineNumberColumn").Value
            Catch ex As System.Exception
                RowLineNumber = 1
            End Try
            Try
                RowPartNumber = LineRow.Cells("PartNumberColumn").Value
            Catch ex As System.Exception
                RowPartNumber = ""
            End Try
            Try
                RowPartDescription = LineRow.Cells("PartDecriptionColumn").Value
            Catch ex As System.Exception
                RowPartDescription = ""
            End Try
            Try
                RowLongDescription = LineRow.Cells("LongDescriptionColumn").Value
            Catch ex As System.Exception
                RowLongDescription = ""
            End Try
            Try
                RowQuantity = LineRow.Cells("QuantityColumn").Value
            Catch ex As System.Exception
                RowQuantity = 0
            End Try
            Try
                RowUnitCost = LineRow.Cells("UnitCostColumn").Value
            Catch ex As System.Exception
                RowUnitCost = 0
            End Try
            Try
                RowLineComment = LineRow.Cells("LineCommentColumn").Value
            Catch ex As System.Exception
                RowLineComment = ""
            End Try
            Try
                RowCreditGLAccount = LineRow.Cells("CreditGLAccountColumn").Value
            Catch ex As System.Exception
                RowCreditGLAccount = ""
            End Try
            Try
                RowDebitGLAccount = LineRow.Cells("DebitGLAccountColumn").Value
            Catch ex As System.Exception
                RowDebitGLAccount = ""
            End Try

            'Extended Cost
            RowExtendedCost = RowQuantity * RowUnitCost
            RowExtendedCost = Math.Round(RowExtendedCost, 2)

            'Write/Insert to line table
            Try
                cmd = New SqlCommand("INSERT INTO WorkOrderLineTable (WorkOrderNumber, WorkOrderLineNumber, PartNumber, PartDescription, LongDescription, Quantity, UnitCost, SalesTax, ExtendedAmount, LineComment, CreditGLAccount, DebitGLAccount, DivisionID, LineStatus) Values (@WorkOrderNumber, @WorkOrderLineNumber, @PartNumber, @PartDescription, @LongDescription, @Quantity, @UnitCost, @SalesTax, @ExtendedAmount, @LineComment, @CreditGLAccount, @DebitGLAccount, @DivisionID, @LineStatus)", con)

                With cmd.Parameters
                    .Add("@WorkOrderNumber", SqlDbType.VarChar).Value = NextWONumber
                    .Add("@WorkOrderLineNumber", SqlDbType.VarChar).Value = RowLineNumber
                    .Add("@PartNumber", SqlDbType.VarChar).Value = RowPartNumber
                    .Add("@PartDescription", SqlDbType.VarChar).Value = RowPartDescription
                    .Add("@LongDescription", SqlDbType.VarChar).Value = RowLongDescription
                    .Add("@Quantity", SqlDbType.VarChar).Value = RowQuantity
                    .Add("@UnitCost", SqlDbType.VarChar).Value = RowUnitCost
                    .Add("@SalesTax", SqlDbType.VarChar).Value = 0
                    .Add("@ExtendedAmount", SqlDbType.VarChar).Value = RowExtendedCost
                    .Add("@LineComment", SqlDbType.VarChar).Value = RowLineComment
                    .Add("@CreditGLAccount", SqlDbType.VarChar).Value = RowCreditGLAccount
                    .Add("@DebitGLAccount", SqlDbType.VarChar).Value = RowDebitGLAccount
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                    .Add("@LineStatus", SqlDbType.VarChar).Value = "OPEN"
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Clear Variables before next entry
                RowLineNumber = 0
                RowPartNumber = ""
                RowPartDescription = ""
                RowQuantity = 0
                RowUnitCost = 0
                RowLineComment = ""
                RowCreditGLAccount = ""
                RowDebitGLAccount = ""
                RowLongDescription = ""
                RowExtendedCost = 0
            Catch ex As Exception
                'Error log
                'If Insert fails, write error message to database
                Dim TempWONumber As Integer = 0
                Dim strWONumber As String = ""
                Dim strLineNumber As String = ""
                TempWONumber = Val(cboWorkOrderNumber.Text)
                strWONumber = CStr(TempWONumber)
                strLineNumber = CStr(RowLineNumber)

                ErrorDate = Today()
                ErrorComment = ex.ToString()
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Insert Line (Re-issue WO) --- Work Order Form"
                ErrorReferenceNumber = "WO # " + strWONumber + " Line #" + strLineNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()
            End Try
        Next

        'After line items are done, reload datagrid
        ShowData()

        MsgBox("Work Order has been issued with a new number.", MsgBoxStyle.OkOnly)
    End Sub

    Private Sub cmdCloseWorkOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCloseWorkOrder.Click
        If cboWorkOrderNumber.Text = "" Or Val(cboWorkOrderNumber.Text) = 0 Then
            MsgBox("You must have a work order number selected.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            'UPDATE Work Order Header
            cmd = New SqlCommand("UPDATE WorkOrderHeaderTable SET WorkOrderStatus = 'CLOSED' WHERE WorkOrderNumber = @WorkOrderNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@WorkOrderNumber", SqlDbType.VarChar).Value = Val(cboWorkOrderNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Re-Load WO Status
            LoadWorkOrderStatus()

            MsgBox("This work order is now closed.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub ReOpenWorkOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReOpenWorkOrderToolStripMenuItem.Click
        'Check status
        If txtWOStatus.Text = " CLOSED" Then
            'Check to see if inventory was removed.
            Dim CheckInventoryRecords As Integer = 0

            Dim CheckInventoryRecordsStatement As String = "SELECT Count(TranactionNumber) FROM InventoryTransactionTable WHERE TransactionTypeNumber = @TransactionTypeNumber and DivisionID = @DivisionID"
            Dim CheckInventoryRecordsCommand As New SqlCommand(CheckInventoryRecordsStatement, con)
            CheckInventoryRecordsCommand.Parameters.Add("@TransactionTypeNumber", SqlDbType.VarChar).Value = Val(cboWorkOrderNumber.Text)
            CheckInventoryRecordsCommand.Parameters.Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text

            If con.State = ConnectionState.Closed Then con.Open()
            Try
                CheckInventoryRecords = CInt(CheckInventoryRecordsCommand.ExecuteScalar)
            Catch ex As System.Exception
                CheckInventoryRecords = 0
            End Try
            con.Close()

            If CheckInventoryRecords = 0 Then
                txtWOStatus.Text = "OPEN"

                'UPDATE Work Order Header
                cmd = New SqlCommand("UPDATE WorkOrderHeaderTable SET WorkOrderStatus = 'OPEN' WHERE WorkOrderNumber = @WorkOrderNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@WorkOrderNumber", SqlDbType.VarChar).Value = Val(cboWorkOrderNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Re-Load WO Status
                LoadWorkOrderStatus()

                MsgBox("This work order is now open.", MsgBoxStyle.OkOnly)
            Else
                txtWOStatus.Text = "POSTED"

                'UPDATE Work Order Header
                cmd = New SqlCommand("UPDATE WorkOrderHeaderTable SET WorkOrderStatus = 'POSTED' WHERE WorkOrderNumber = @WorkOrderNumber AND DivisionID = @DivisionID", con)

                With cmd.Parameters
                    .Add("@WorkOrderNumber", SqlDbType.VarChar).Value = Val(cboWorkOrderNumber.Text)
                    .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
                End With

                If con.State = ConnectionState.Closed Then con.Open()
                cmd.ExecuteNonQuery()
                con.Close()

                'Re-Load WO Status
                LoadWorkOrderStatus()

                MsgBox("This work order is now posted.", MsgBoxStyle.OkOnly)
            End If
        ElseIf txtWOStatus.Text = "POSTED" Then
            MsgBox("Inventory has already been deducted - cannot set this to open.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            txtWOStatus.Text = "OPEN"

            'UPDATE Work Order Header
            cmd = New SqlCommand("UPDATE WorkOrderHeaderTable SET WorkOrderStatus = 'OPEN' WHERE WorkOrderNumber = @WorkOrderNumber AND DivisionID = @DivisionID", con)

            With cmd.Parameters
                .Add("@WorkOrderNumber", SqlDbType.VarChar).Value = Val(cboWorkOrderNumber.Text)
                .Add("@DivisionID", SqlDbType.VarChar).Value = cboDivisionID.Text
            End With

            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

            'Re-Load WO Status
            LoadWorkOrderStatus()

            MsgBox("This work order is now open.", MsgBoxStyle.OkOnly)
        End If
    End Sub

    Private Sub txtEstFreight_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEstFreight.TextChanged
        txtTotalFreight.Text = txtEstFreight.Text

        LoadWOTotals()
    End Sub

    Public Sub LoadScannedDocuments()
        intWorkOrderNumber = Val(cboWorkOrderNumber.Text)
        strWorkOrderNumber = CStr(intWorkOrderNumber)
        WorkOrderFileName = strWorkOrderNumber + ".pdf"
        WorkOrderFilenameAndPath = "\\TFP-FS\TransferData\WorkOrderUploads\" + WorkOrderFileName

        If File.Exists(WorkOrderFilenameAndPath) Then
            cmdUploadViewDocs.Text = "View Uploads"
        Else
            cmdUploadViewDocs.Text = "Upload Docs"
        End If
    End Sub

    Private Sub cmdUploadViewDocs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUploadViewDocs.Click
        'Verify that they have a work order selected
        If cboWorkOrderNumber.Text = "" Then
            MsgBox("You must select a valid work order.", MsgBoxStyle.OkOnly)
            Exit Sub
        Else
            intWorkOrderNumber = Val(cboWorkOrderNumber.Text)
            strWorkOrderNumber = CStr(intWorkOrderNumber)
            WorkOrderFileName = strWorkOrderNumber + ".pdf"
            WorkOrderFilenameAndPath = "\\TFP-FS\TransferData\WorkOrderUploads\" + WorkOrderFileName
        End If

        If File.Exists(WorkOrderFilenameAndPath) Then
            Dim button As DialogResult = MessageBox.Show("Do you wish to overwrite this scanned receiver?", "OVERWRITE EXISTING RECEIVER?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If button = DialogResult.Yes Then
                'Delete existing receiver before upload
                File.Delete(WorkOrderFilenameAndPath)

                Dim My_Process As New Process()
                'Dim My_Process_Info As New ProcessStartInfo

                Dim ApplicationFileAndPath As String = "C:\Program Files (x86)\NAPS2\NAPS2.Console.exe"

                Try
                    My_Process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                    My_Process.StartInfo.CreateNoWindow = True
                    My_Process.Start(ApplicationFileAndPath, "-o " & WorkOrderFilenameAndPath)
                    My_Process.Close()

                    cboWorkOrderNumber.Refresh()
                    LoadScannedDocuments()
                    cmdUploadViewDocs.Text = "View Docs"
                    MsgBox("Document(s) scanned.", MsgBoxStyle.OkOnly)
                Catch ex As Exception
                    'Log error on update failure
                    Dim TempWONumber As Integer = 0
                    Dim strReceiverNumber1 As String = ""
                    TempWONumber = Val(cboWorkOrderNumber.Text)
                    strReceiverNumber1 = CStr(TempWONumber)

                    ErrorDate = Now()
                    ErrorComment = ApplicationFileAndPath & "" & WorkOrderFileName
                    ErrorDivision = cboDivisionID.Text
                    ErrorDescription = "Work Orders --- Scan"
                    ErrorReferenceNumber = "Work Order # " + strWorkOrderNumber
                    ErrorUser = EmployeeLoginName

                    TFPErrorLogUpdate()

                    MsgBox("Scan Failed - L2824", MsgBoxStyle.OkOnly)
                End Try
            ElseIf button = DialogResult.No Then
                Exit Sub
            End If
        Else
            Dim My_Process As New Process()
            'Dim My_Process_Info As New ProcessStartInfo

            Dim ApplicationFileAndPath As String = "C:\Program Files (x86)\NAPS2\NAPS2.Console.exe"

            Try
                My_Process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
                My_Process.StartInfo.CreateNoWindow = True
                My_Process.Start(ApplicationFileAndPath, "-o " & WorkOrderFilenameAndPath)
                'My_Process.WaitForExit()
                My_Process.Close()

                cboWorkOrderNumber.Refresh()
                LoadScannedDocuments()

                MsgBox("Document(s) scanned.", MsgBoxStyle.OkOnly)
            Catch ex As Exception
                'Log error on update failure
                Dim TempWONumber As Integer = 0
                Dim strReceiverNumber1 As String = ""
                TempWONumber = Val(cboWorkOrderNumber.Text)
                strReceiverNumber1 = CStr(TempWONumber)

                ErrorDate = Now()
                ErrorComment = ApplicationFileAndPath & "" & WorkOrderFileName
                ErrorDivision = cboDivisionID.Text
                ErrorDescription = "Work Orders --- Scan"
                ErrorReferenceNumber = "Work Order # " + strWorkOrderNumber
                ErrorUser = EmployeeLoginName

                TFPErrorLogUpdate()

                MsgBox("Scan Failed - L2863", MsgBoxStyle.OkOnly)
            End Try
        End If
    End Sub
End Class

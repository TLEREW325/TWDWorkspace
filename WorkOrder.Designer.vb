<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WorkOrder
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReOpenWorkOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseWorkOrderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtWOStatus = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtPromiseDate = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtSalesOrderNumber = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.cmdGenerateNewWO = New System.Windows.Forms.Button
        Me.cboWorkOrderNumber = New System.Windows.Forms.ComboBox
        Me.WorkOrderHeaderTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SQLTFPOperationsDatabaseDataSet = New MOS09Program.SQLTFPOperationsDatabaseDataSet
        Me.txtCustomerPO = New System.Windows.Forms.TextBox
        Me.llCustomerID = New System.Windows.Forms.LinkLabel
        Me.Label703 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboCustomerName = New System.Windows.Forms.ComboBox
        Me.CustomerListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboDivisionID = New System.Windows.Forms.ComboBox
        Me.DivisionTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboCustomerID = New System.Windows.Forms.ComboBox
        Me.dtpWorkOrderDate = New System.Windows.Forms.DateTimePicker
        Me.Label701 = New System.Windows.Forms.Label
        Me.cboShipMethod = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboShipVia = New System.Windows.Forms.ComboBox
        Me.ShipMethodBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label709 = New System.Windows.Forms.Label
        Me.dgvWorkOrderLines = New System.Windows.Forms.DataGridView
        Me.WorkOrderNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WorkOrderLineNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartNumberColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PartDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.QuantityColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UnitCostColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesTaxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ExtendedAmountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineCommentColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LongDescriptionColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitGLAccountColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DivisionIDColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LineStatusColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WorkOrderLineTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtLongDescription = New System.Windows.Forms.TextBox
        Me.cmdAddLine = New System.Windows.Forms.Button
        Me.cmdClearLine = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtLineInstructions = New System.Windows.Forms.TextBox
        Me.txtExtendedCost = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtUnitCost = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtQuantity = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboPartNumber = New System.Windows.Forms.ComboBox
        Me.ItemListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label704 = New System.Windows.Forms.Label
        Me.cboPartDescription = New System.Windows.Forms.ComboBox
        Me.cmdClearAll = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdPostWorkOrder = New System.Windows.Forms.Button
        Me.DivisionTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
        Me.CustomerListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
        Me.ShipMethodTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
        Me.ItemListTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
        Me.txtHeaderComment = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboCountryName = New System.Windows.Forms.ComboBox
        Me.CountryCodesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtState = New System.Windows.Forms.TextBox
        Me.txtCity = New System.Windows.Forms.TextBox
        Me.txtCountry = New System.Windows.Forms.TextBox
        Me.txtZip = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtAddress2 = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.cboShipToID = New System.Windows.Forms.ComboBox
        Me.AdditionalShipToBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtShipToName = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtAddress1 = New System.Windows.Forms.TextBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.cmdCreateSO = New System.Windows.Forms.Button
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtSpecialShippingInstructions = New System.Windows.Forms.TextBox
        Me.WorkOrderLineTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.WorkOrderLineTableTableAdapter
        Me.AdditionalShipToTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AdditionalShipToTableAdapter
        Me.CountryCodesTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CountryCodesTableAdapter
        Me.WorkOrderHeaderTableTableAdapter = New MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.WorkOrderHeaderTableTableAdapter
        Me.tabWorkOrderMain = New System.Windows.Forms.TabControl
        Me.tabLineItems = New System.Windows.Forms.TabPage
        Me.tabShippingData = New System.Windows.Forms.TabPage
        Me.txtEstFreight = New System.Windows.Forms.TextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.txtTotalShippingWeight = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.txtDateClosed = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.cboSalesperson = New System.Windows.Forms.ComboBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtThirdPartyAddress = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.tabInstructions = New System.Windows.Forms.TabPage
        Me.cmdReIssueWO = New System.Windows.Forms.Button
        Me.gpxAddLineItem = New System.Windows.Forms.GroupBox
        Me.lblQOH = New System.Windows.Forms.Label
        Me.gpxDeleteLine = New System.Windows.Forms.GroupBox
        Me.nbrLineNumber = New System.Windows.Forms.NumericUpDown
        Me.Label22 = New System.Windows.Forms.Label
        Me.cmdDeleteLine = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtWorkOrderTotal = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.txtTotalTax = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.txtTotalFreight = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.txtTotalExtendedCost = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.gpxCloseWorkOrder = New System.Windows.Forms.GroupBox
        Me.cmdCloseWorkOrder = New System.Windows.Forms.Button
        Me.cmdUploadViewDocs = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.WorkOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvWorkOrderLines, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WorkOrderLineTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.CountryCodesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdditionalShipToBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.tabWorkOrderMain.SuspendLayout()
        Me.tabLineItems.SuspendLayout()
        Me.tabShippingData.SuspendLayout()
        Me.tabInstructions.SuspendLayout()
        Me.gpxAddLineItem.SuspendLayout()
        Me.gpxDeleteLine.SuspendLayout()
        CType(Me.nbrLineNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.gpxCloseWorkOrder.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1142, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReOpenWorkOrderToolStripMenuItem, Me.CloseWorkOrderToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'ReOpenWorkOrderToolStripMenuItem
        '
        Me.ReOpenWorkOrderToolStripMenuItem.Name = "ReOpenWorkOrderToolStripMenuItem"
        Me.ReOpenWorkOrderToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.ReOpenWorkOrderToolStripMenuItem.Text = "Re-Open Work Order"
        '
        'CloseWorkOrderToolStripMenuItem
        '
        Me.CloseWorkOrderToolStripMenuItem.Name = "CloseWorkOrderToolStripMenuItem"
        Me.CloseWorkOrderToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.CloseWorkOrderToolStripMenuItem.Text = "Close Work Order"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem1})
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtWOStatus)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.txtPromiseDate)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.txtSalesOrderNumber)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.cmdGenerateNewWO)
        Me.GroupBox1.Controls.Add(Me.cboWorkOrderNumber)
        Me.GroupBox1.Controls.Add(Me.txtCustomerPO)
        Me.GroupBox1.Controls.Add(Me.llCustomerID)
        Me.GroupBox1.Controls.Add(Me.Label703)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboCustomerName)
        Me.GroupBox1.Controls.Add(Me.cboDivisionID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cboCustomerID)
        Me.GroupBox1.Controls.Add(Me.dtpWorkOrderDate)
        Me.GroupBox1.Controls.Add(Me.Label701)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(354, 345)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Work Order Data"
        '
        'txtWOStatus
        '
        Me.txtWOStatus.BackColor = System.Drawing.Color.White
        Me.txtWOStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWOStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWOStatus.Location = New System.Drawing.Point(141, 128)
        Me.txtWOStatus.MaxLength = 50
        Me.txtWOStatus.Name = "txtWOStatus"
        Me.txtWOStatus.ReadOnly = True
        Me.txtWOStatus.Size = New System.Drawing.Size(194, 20)
        Me.txtWOStatus.TabIndex = 5
        Me.txtWOStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(11, 126)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(107, 19)
        Me.Label23.TabIndex = 91
        Me.Label23.Text = "WO Status"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPromiseDate
        '
        Me.txtPromiseDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPromiseDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPromiseDate.Location = New System.Drawing.Point(141, 308)
        Me.txtPromiseDate.MaxLength = 50
        Me.txtPromiseDate.Name = "txtPromiseDate"
        Me.txtPromiseDate.Size = New System.Drawing.Size(193, 20)
        Me.txtPromiseDate.TabIndex = 10
        Me.txtPromiseDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(11, 308)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(107, 19)
        Me.Label21.TabIndex = 89
        Me.Label21.Text = "Promise Date"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSalesOrderNumber
        '
        Me.txtSalesOrderNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSalesOrderNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSalesOrderNumber.Location = New System.Drawing.Point(141, 277)
        Me.txtSalesOrderNumber.MaxLength = 50
        Me.txtSalesOrderNumber.Name = "txtSalesOrderNumber"
        Me.txtSalesOrderNumber.Size = New System.Drawing.Size(193, 20)
        Me.txtSalesOrderNumber.TabIndex = 9
        Me.txtSalesOrderNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(11, 277)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(107, 19)
        Me.Label20.TabIndex = 87
        Me.Label20.Text = "Sales Order #"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdGenerateNewWO
        '
        Me.cmdGenerateNewWO.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.cmdGenerateNewWO.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmdGenerateNewWO.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGenerateNewWO.ForeColor = System.Drawing.Color.Crimson
        Me.cmdGenerateNewWO.Location = New System.Drawing.Point(110, 25)
        Me.cmdGenerateNewWO.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdGenerateNewWO.Name = "cmdGenerateNewWO"
        Me.cmdGenerateNewWO.Size = New System.Drawing.Size(29, 20)
        Me.cmdGenerateNewWO.TabIndex = 1
        Me.cmdGenerateNewWO.Text = ">>"
        Me.cmdGenerateNewWO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerateNewWO.UseVisualStyleBackColor = False
        '
        'cboWorkOrderNumber
        '
        Me.cboWorkOrderNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboWorkOrderNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboWorkOrderNumber.DataSource = Me.WorkOrderHeaderTableBindingSource
        Me.cboWorkOrderNumber.DisplayMember = "WorkOrderNumber"
        Me.cboWorkOrderNumber.FormattingEnabled = True
        Me.cboWorkOrderNumber.Location = New System.Drawing.Point(142, 26)
        Me.cboWorkOrderNumber.Name = "cboWorkOrderNumber"
        Me.cboWorkOrderNumber.Size = New System.Drawing.Size(195, 21)
        Me.cboWorkOrderNumber.TabIndex = 2
        '
        'WorkOrderHeaderTableBindingSource
        '
        Me.WorkOrderHeaderTableBindingSource.DataMember = "WorkOrderHeaderTable"
        Me.WorkOrderHeaderTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'SQLTFPOperationsDatabaseDataSet
        '
        Me.SQLTFPOperationsDatabaseDataSet.DataSetName = "SQLTFPOperationsDatabaseDataSet"
        Me.SQLTFPOperationsDatabaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'txtCustomerPO
        '
        Me.txtCustomerPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCustomerPO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomerPO.Location = New System.Drawing.Point(141, 245)
        Me.txtCustomerPO.MaxLength = 50
        Me.txtCustomerPO.Name = "txtCustomerPO"
        Me.txtCustomerPO.Size = New System.Drawing.Size(194, 20)
        Me.txtCustomerPO.TabIndex = 8
        Me.txtCustomerPO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'llCustomerID
        '
        Me.llCustomerID.AutoSize = True
        Me.llCustomerID.Location = New System.Drawing.Point(11, 172)
        Me.llCustomerID.Name = "llCustomerID"
        Me.llCustomerID.Size = New System.Drawing.Size(65, 13)
        Me.llCustomerID.TabIndex = 84
        Me.llCustomerID.TabStop = True
        Me.llCustomerID.Text = "Customer ID"
        '
        'Label703
        '
        Me.Label703.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label703.Location = New System.Drawing.Point(11, 245)
        Me.Label703.Name = "Label703"
        Me.Label703.Size = New System.Drawing.Size(107, 19)
        Me.Label703.TabIndex = 81
        Me.Label703.Text = "Cust PO #"
        Me.Label703.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(11, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 19)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Work Order #"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomerName
        '
        Me.cboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerName.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerName.DisplayMember = "CustomerName"
        Me.cboCustomerName.DropDownWidth = 300
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(14, 202)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(321, 21)
        Me.cboCustomerName.TabIndex = 7
        '
        'CustomerListBindingSource
        '
        Me.CustomerListBindingSource.DataMember = "CustomerList"
        Me.CustomerListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'cboDivisionID
        '
        Me.cboDivisionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDivisionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDivisionID.DataSource = Me.DivisionTableBindingSource
        Me.cboDivisionID.DisplayMember = "DivisionKey"
        Me.cboDivisionID.FormattingEnabled = True
        Me.cboDivisionID.Location = New System.Drawing.Point(141, 60)
        Me.cboDivisionID.Name = "cboDivisionID"
        Me.cboDivisionID.Size = New System.Drawing.Size(195, 21)
        Me.cboDivisionID.TabIndex = 3
        '
        'DivisionTableBindingSource
        '
        Me.DivisionTableBindingSource.DataMember = "DivisionTable"
        Me.DivisionTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(11, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 19)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Division ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomerID
        '
        Me.cboCustomerID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCustomerID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCustomerID.DataSource = Me.CustomerListBindingSource
        Me.cboCustomerID.DisplayMember = "CustomerID"
        Me.cboCustomerID.DropDownWidth = 300
        Me.cboCustomerID.FormattingEnabled = True
        Me.cboCustomerID.Location = New System.Drawing.Point(89, 169)
        Me.cboCustomerID.Name = "cboCustomerID"
        Me.cboCustomerID.Size = New System.Drawing.Size(246, 21)
        Me.cboCustomerID.TabIndex = 6
        '
        'dtpWorkOrderDate
        '
        Me.dtpWorkOrderDate.CalendarFont = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpWorkOrderDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpWorkOrderDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpWorkOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpWorkOrderDate.Location = New System.Drawing.Point(144, 94)
        Me.dtpWorkOrderDate.Name = "dtpWorkOrderDate"
        Me.dtpWorkOrderDate.Size = New System.Drawing.Size(192, 21)
        Me.dtpWorkOrderDate.TabIndex = 4
        Me.dtpWorkOrderDate.Value = New Date(2013, 9, 12, 11, 52, 5, 0)
        '
        'Label701
        '
        Me.Label701.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label701.Location = New System.Drawing.Point(11, 93)
        Me.Label701.Name = "Label701"
        Me.Label701.Size = New System.Drawing.Size(107, 19)
        Me.Label701.TabIndex = 82
        Me.Label701.Text = "Work Order Date"
        Me.Label701.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboShipMethod
        '
        Me.cboShipMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipMethod.DropDownWidth = 300
        Me.cboShipMethod.FormattingEnabled = True
        Me.cboShipMethod.Items.AddRange(New Object() {"COLLECT", "PREPAID", "PREPAID/ADD", "PREPAID/NOADD", "THIRD PARTY", "OTHER"})
        Me.cboShipMethod.Location = New System.Drawing.Point(522, 53)
        Me.cboShipMethod.MaxLength = 50
        Me.cboShipMethod.Name = "cboShipMethod"
        Me.cboShipMethod.Size = New System.Drawing.Size(194, 21)
        Me.cboShipMethod.TabIndex = 10
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(392, 52)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 20)
        Me.Label10.TabIndex = 85
        Me.Label10.Text = "Ship Method"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboShipVia
        '
        Me.cboShipVia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipVia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipVia.DataSource = Me.ShipMethodBindingSource
        Me.cboShipVia.DisplayMember = "ShipMethID"
        Me.cboShipVia.DropDownWidth = 300
        Me.cboShipVia.FormattingEnabled = True
        Me.cboShipVia.Location = New System.Drawing.Point(522, 20)
        Me.cboShipVia.MaxLength = 50
        Me.cboShipVia.Name = "cboShipVia"
        Me.cboShipVia.Size = New System.Drawing.Size(194, 21)
        Me.cboShipVia.TabIndex = 9
        '
        'ShipMethodBindingSource
        '
        Me.ShipMethodBindingSource.DataMember = "ShipMethod"
        Me.ShipMethodBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label709
        '
        Me.Label709.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label709.Location = New System.Drawing.Point(392, 19)
        Me.Label709.Name = "Label709"
        Me.Label709.Size = New System.Drawing.Size(89, 20)
        Me.Label709.TabIndex = 83
        Me.Label709.Text = "Ship Via"
        Me.Label709.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvWorkOrderLines
        '
        Me.dgvWorkOrderLines.AllowUserToAddRows = False
        Me.dgvWorkOrderLines.AllowUserToDeleteRows = False
        Me.dgvWorkOrderLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvWorkOrderLines.AutoGenerateColumns = False
        Me.dgvWorkOrderLines.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvWorkOrderLines.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvWorkOrderLines.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvWorkOrderLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.WorkOrderNumberColumn, Me.WorkOrderLineNumberColumn, Me.PartNumberColumn, Me.PartDescriptionColumn, Me.QuantityColumn, Me.UnitCostColumn, Me.SalesTaxColumn, Me.ExtendedAmountColumn, Me.LineCommentColumn, Me.LongDescriptionColumn, Me.CreditGLAccountColumn, Me.DebitGLAccountColumn, Me.DivisionIDColumn, Me.LineStatusColumn})
        Me.dgvWorkOrderLines.DataSource = Me.WorkOrderLineTableBindingSource
        Me.dgvWorkOrderLines.GridColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvWorkOrderLines.Location = New System.Drawing.Point(6, 4)
        Me.dgvWorkOrderLines.Name = "dgvWorkOrderLines"
        Me.dgvWorkOrderLines.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvWorkOrderLines.Size = New System.Drawing.Size(715, 496)
        Me.dgvWorkOrderLines.TabIndex = 21
        '
        'WorkOrderNumberColumn
        '
        Me.WorkOrderNumberColumn.DataPropertyName = "WorkOrderNumber"
        Me.WorkOrderNumberColumn.HeaderText = "WorkOrderNumber"
        Me.WorkOrderNumberColumn.Name = "WorkOrderNumberColumn"
        Me.WorkOrderNumberColumn.ReadOnly = True
        Me.WorkOrderNumberColumn.Visible = False
        '
        'WorkOrderLineNumberColumn
        '
        Me.WorkOrderLineNumberColumn.DataPropertyName = "WorkOrderLineNumber"
        Me.WorkOrderLineNumberColumn.HeaderText = "Line #"
        Me.WorkOrderLineNumberColumn.MaxInputLength = 100
        Me.WorkOrderLineNumberColumn.Name = "WorkOrderLineNumberColumn"
        Me.WorkOrderLineNumberColumn.ReadOnly = True
        Me.WorkOrderLineNumberColumn.Width = 60
        '
        'PartNumberColumn
        '
        Me.PartNumberColumn.DataPropertyName = "PartNumber"
        Me.PartNumberColumn.HeaderText = "Part #"
        Me.PartNumberColumn.Name = "PartNumberColumn"
        Me.PartNumberColumn.ReadOnly = True
        Me.PartNumberColumn.Width = 150
        '
        'PartDescriptionColumn
        '
        Me.PartDescriptionColumn.DataPropertyName = "PartDescription"
        Me.PartDescriptionColumn.HeaderText = "Description"
        Me.PartDescriptionColumn.Name = "PartDescriptionColumn"
        Me.PartDescriptionColumn.ReadOnly = True
        Me.PartDescriptionColumn.Width = 150
        '
        'QuantityColumn
        '
        Me.QuantityColumn.DataPropertyName = "Quantity"
        Me.QuantityColumn.HeaderText = "Quantity"
        Me.QuantityColumn.Name = "QuantityColumn"
        Me.QuantityColumn.Width = 80
        '
        'UnitCostColumn
        '
        Me.UnitCostColumn.DataPropertyName = "UnitCost"
        Me.UnitCostColumn.HeaderText = "Unit Cost"
        Me.UnitCostColumn.Name = "UnitCostColumn"
        Me.UnitCostColumn.Width = 80
        '
        'SalesTaxColumn
        '
        Me.SalesTaxColumn.DataPropertyName = "SalesTax"
        Me.SalesTaxColumn.HeaderText = "SalesTax"
        Me.SalesTaxColumn.Name = "SalesTaxColumn"
        Me.SalesTaxColumn.ReadOnly = True
        Me.SalesTaxColumn.Visible = False
        '
        'ExtendedAmountColumn
        '
        Me.ExtendedAmountColumn.DataPropertyName = "ExtendedAmount"
        Me.ExtendedAmountColumn.HeaderText = "Ext. Amt."
        Me.ExtendedAmountColumn.Name = "ExtendedAmountColumn"
        Me.ExtendedAmountColumn.ReadOnly = True
        Me.ExtendedAmountColumn.Width = 80
        '
        'LineCommentColumn
        '
        Me.LineCommentColumn.DataPropertyName = "LineComment"
        Me.LineCommentColumn.HeaderText = "Comment"
        Me.LineCommentColumn.Name = "LineCommentColumn"
        '
        'LongDescriptionColumn
        '
        Me.LongDescriptionColumn.DataPropertyName = "LongDescription"
        Me.LongDescriptionColumn.HeaderText = "LongDescription"
        Me.LongDescriptionColumn.Name = "LongDescriptionColumn"
        Me.LongDescriptionColumn.Visible = False
        '
        'CreditGLAccountColumn
        '
        Me.CreditGLAccountColumn.DataPropertyName = "CreditGLAccount"
        Me.CreditGLAccountColumn.HeaderText = "CreditGLAccount"
        Me.CreditGLAccountColumn.Name = "CreditGLAccountColumn"
        Me.CreditGLAccountColumn.Visible = False
        '
        'DebitGLAccountColumn
        '
        Me.DebitGLAccountColumn.DataPropertyName = "DebitGLAccount"
        Me.DebitGLAccountColumn.HeaderText = "DebitGLAccount"
        Me.DebitGLAccountColumn.Name = "DebitGLAccountColumn"
        Me.DebitGLAccountColumn.Visible = False
        '
        'DivisionIDColumn
        '
        Me.DivisionIDColumn.DataPropertyName = "DivisionID"
        Me.DivisionIDColumn.HeaderText = "DivisionID"
        Me.DivisionIDColumn.Name = "DivisionIDColumn"
        Me.DivisionIDColumn.Visible = False
        '
        'LineStatusColumn
        '
        Me.LineStatusColumn.DataPropertyName = "LineStatus"
        Me.LineStatusColumn.HeaderText = "Line Status"
        Me.LineStatusColumn.Name = "LineStatusColumn"
        Me.LineStatusColumn.ReadOnly = True
        '
        'WorkOrderLineTableBindingSource
        '
        Me.WorkOrderLineTableBindingSource.DataMember = "WorkOrderLineTable"
        Me.WorkOrderLineTableBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtLongDescription
        '
        Me.txtLongDescription.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.txtLongDescription.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLongDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLongDescription.Enabled = False
        Me.txtLongDescription.Location = New System.Drawing.Point(24, 90)
        Me.txtLongDescription.MaxLength = 50
        Me.txtLongDescription.Multiline = True
        Me.txtLongDescription.Name = "txtLongDescription"
        Me.txtLongDescription.ReadOnly = True
        Me.txtLongDescription.Size = New System.Drawing.Size(311, 44)
        Me.txtLongDescription.TabIndex = 14
        Me.txtLongDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdAddLine
        '
        Me.cmdAddLine.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddLine.Location = New System.Drawing.Point(187, 374)
        Me.cmdAddLine.Name = "cmdAddLine"
        Me.cmdAddLine.Size = New System.Drawing.Size(71, 30)
        Me.cmdAddLine.TabIndex = 19
        Me.cmdAddLine.Text = "Add Line"
        Me.cmdAddLine.UseVisualStyleBackColor = True
        '
        'cmdClearLine
        '
        Me.cmdClearLine.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClearLine.Location = New System.Drawing.Point(264, 374)
        Me.cmdClearLine.Name = "cmdClearLine"
        Me.cmdClearLine.Size = New System.Drawing.Size(71, 30)
        Me.cmdClearLine.TabIndex = 20
        Me.cmdClearLine.Text = "Clear"
        Me.cmdClearLine.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(22, 148)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(269, 19)
        Me.Label7.TabIndex = 89
        Me.Label7.Text = "Line Instructions / Comments (500 Character MAX)"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtLineInstructions
        '
        Me.txtLineInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLineInstructions.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLineInstructions.Location = New System.Drawing.Point(21, 170)
        Me.txtLineInstructions.MaxLength = 500
        Me.txtLineInstructions.Multiline = True
        Me.txtLineInstructions.Name = "txtLineInstructions"
        Me.txtLineInstructions.Size = New System.Drawing.Size(314, 94)
        Me.txtLineInstructions.TabIndex = 15
        Me.txtLineInstructions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtExtendedCost
        '
        Me.txtExtendedCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExtendedCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtExtendedCost.Location = New System.Drawing.Point(173, 337)
        Me.txtExtendedCost.MaxLength = 50
        Me.txtExtendedCost.Name = "txtExtendedCost"
        Me.txtExtendedCost.ReadOnly = True
        Me.txtExtendedCost.Size = New System.Drawing.Size(162, 20)
        Me.txtExtendedCost.TabIndex = 18
        Me.txtExtendedCost.TabStop = False
        Me.txtExtendedCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(23, 338)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 19)
        Me.Label6.TabIndex = 87
        Me.Label6.Text = "Extended Cost"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUnitCost
        '
        Me.txtUnitCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnitCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUnitCost.Location = New System.Drawing.Point(173, 308)
        Me.txtUnitCost.MaxLength = 50
        Me.txtUnitCost.Name = "txtUnitCost"
        Me.txtUnitCost.ReadOnly = True
        Me.txtUnitCost.Size = New System.Drawing.Size(162, 20)
        Me.txtUnitCost.TabIndex = 17
        Me.txtUnitCost.TabStop = False
        Me.txtUnitCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(23, 309)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 19)
        Me.Label5.TabIndex = 85
        Me.Label5.Text = "Unit Cost"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtQuantity
        '
        Me.txtQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtQuantity.Location = New System.Drawing.Point(173, 279)
        Me.txtQuantity.MaxLength = 50
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(162, 20)
        Me.txtQuantity.TabIndex = 16
        Me.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(23, 280)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 19)
        Me.Label4.TabIndex = 83
        Me.Label4.Text = "Quantity"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartNumber
        '
        Me.cboPartNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPartNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPartNumber.DataSource = Me.ItemListBindingSource
        Me.cboPartNumber.DisplayMember = "ItemID"
        Me.cboPartNumber.DropDownWidth = 250
        Me.cboPartNumber.FormattingEnabled = True
        Me.cboPartNumber.Location = New System.Drawing.Point(66, 30)
        Me.cboPartNumber.Name = "cboPartNumber"
        Me.cboPartNumber.Size = New System.Drawing.Size(270, 21)
        Me.cboPartNumber.TabIndex = 12
        '
        'ItemListBindingSource
        '
        Me.ItemListBindingSource.DataMember = "ItemList"
        Me.ItemListBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label704
        '
        Me.Label704.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label704.Location = New System.Drawing.Point(22, 29)
        Me.Label704.Name = "Label704"
        Me.Label704.Size = New System.Drawing.Size(104, 20)
        Me.Label704.TabIndex = 9
        Me.Label704.Text = "Part #"
        Me.Label704.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPartDescription
        '
        Me.cboPartDescription.DataSource = Me.ItemListBindingSource
        Me.cboPartDescription.DisplayMember = "ShortDescription"
        Me.cboPartDescription.DropDownWidth = 400
        Me.cboPartDescription.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboPartDescription.FormattingEnabled = True
        Me.cboPartDescription.Location = New System.Drawing.Point(22, 57)
        Me.cboPartDescription.Name = "cboPartDescription"
        Me.cboPartDescription.Size = New System.Drawing.Size(313, 21)
        Me.cboPartDescription.TabIndex = 13
        '
        'cmdClearAll
        '
        Me.cmdClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClearAll.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClearAll.Location = New System.Drawing.Point(393, 771)
        Me.cmdClearAll.Name = "cmdClearAll"
        Me.cmdClearAll.Size = New System.Drawing.Size(71, 40)
        Me.cmdClearAll.TabIndex = 38
        Me.cmdClearAll.Text = "Clear All"
        Me.cmdClearAll.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(826, 771)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(71, 40)
        Me.cmdSave.TabIndex = 39
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPrint.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrint.Location = New System.Drawing.Point(980, 771)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(71, 40)
        Me.cmdPrint.TabIndex = 41
        Me.cmdPrint.Text = "Print Work Order"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(1057, 771)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(71, 40)
        Me.cmdExit.TabIndex = 42
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdDelete
        '
        Me.cmdDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDelete.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelete.Location = New System.Drawing.Point(903, 771)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(71, 40)
        Me.cmdDelete.TabIndex = 40
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.cmdPostWorkOrder)
        Me.GroupBox3.Location = New System.Drawing.Point(393, 606)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(222, 75)
        Me.GroupBox3.TabIndex = 36
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Post Work Order"
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(8, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 38)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "Post Work Order (relieves Inventory)"
        '
        'cmdPostWorkOrder
        '
        Me.cmdPostWorkOrder.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPostWorkOrder.ForeColor = System.Drawing.Color.Blue
        Me.cmdPostWorkOrder.Location = New System.Drawing.Point(134, 19)
        Me.cmdPostWorkOrder.Name = "cmdPostWorkOrder"
        Me.cmdPostWorkOrder.Size = New System.Drawing.Size(71, 40)
        Me.cmdPostWorkOrder.TabIndex = 37
        Me.cmdPostWorkOrder.Text = "Post"
        Me.cmdPostWorkOrder.UseVisualStyleBackColor = True
        '
        'DivisionTableTableAdapter
        '
        Me.DivisionTableTableAdapter.ClearBeforeFill = True
        '
        'CustomerListTableAdapter
        '
        Me.CustomerListTableAdapter.ClearBeforeFill = True
        '
        'ShipMethodTableAdapter
        '
        Me.ShipMethodTableAdapter.ClearBeforeFill = True
        '
        'ItemListTableAdapter
        '
        Me.ItemListTableAdapter.ClearBeforeFill = True
        '
        'txtHeaderComment
        '
        Me.txtHeaderComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHeaderComment.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHeaderComment.Location = New System.Drawing.Point(33, 38)
        Me.txtHeaderComment.MaxLength = 500
        Me.txtHeaderComment.Multiline = True
        Me.txtHeaderComment.Name = "txtHeaderComment"
        Me.txtHeaderComment.Size = New System.Drawing.Size(425, 165)
        Me.txtHeaderComment.TabIndex = 32
        Me.txtHeaderComment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(33, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(269, 19)
        Me.Label8.TabIndex = 90
        Me.Label8.Text = "Header Comments / Instructions"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCountryName
        '
        Me.cboCountryName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCountryName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCountryName.DataSource = Me.CountryCodesBindingSource
        Me.cboCountryName.DisplayMember = "Country"
        Me.cboCountryName.FormattingEnabled = True
        Me.cboCountryName.Location = New System.Drawing.Point(73, 454)
        Me.cboCountryName.Name = "cboCountryName"
        Me.cboCountryName.Size = New System.Drawing.Size(172, 21)
        Me.cboCountryName.TabIndex = 7
        '
        'CountryCodesBindingSource
        '
        Me.CountryCodesBindingSource.DataMember = "CountryCodes"
        Me.CountryCodesBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'txtState
        '
        Me.txtState.BackColor = System.Drawing.Color.White
        Me.txtState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtState.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtState.Location = New System.Drawing.Point(73, 411)
        Me.txtState.Name = "txtState"
        Me.txtState.ReadOnly = True
        Me.txtState.Size = New System.Drawing.Size(99, 20)
        Me.txtState.TabIndex = 5
        Me.txtState.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCity
        '
        Me.txtCity.BackColor = System.Drawing.Color.White
        Me.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCity.Location = New System.Drawing.Point(73, 372)
        Me.txtCity.MaxLength = 100
        Me.txtCity.Name = "txtCity"
        Me.txtCity.ReadOnly = True
        Me.txtCity.Size = New System.Drawing.Size(273, 20)
        Me.txtCity.TabIndex = 4
        Me.txtCity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCountry
        '
        Me.txtCountry.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.txtCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCountry.ForeColor = System.Drawing.Color.Black
        Me.txtCountry.Location = New System.Drawing.Point(251, 455)
        Me.txtCountry.MaxLength = 50
        Me.txtCountry.Name = "txtCountry"
        Me.txtCountry.ReadOnly = True
        Me.txtCountry.Size = New System.Drawing.Size(95, 20)
        Me.txtCountry.TabIndex = 8
        Me.txtCountry.TabStop = False
        Me.txtCountry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtZip
        '
        Me.txtZip.BackColor = System.Drawing.Color.White
        Me.txtZip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtZip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtZip.Location = New System.Drawing.Point(213, 410)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.ReadOnly = True
        Me.txtZip.Size = New System.Drawing.Size(133, 20)
        Me.txtZip.TabIndex = 6
        Me.txtZip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(21, 372)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(62, 18)
        Me.Label11.TabIndex = 94
        Me.Label11.Text = "City"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(21, 411)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 18)
        Me.Label12.TabIndex = 93
        Me.Label12.Text = "State"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(21, 454)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 18)
        Me.Label13.TabIndex = 92
        Me.Label13.Text = "Country"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(177, 411)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(30, 18)
        Me.Label14.TabIndex = 95
        Me.Label14.Text = "Zip"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAddress2
        '
        Me.txtAddress2.BackColor = System.Drawing.Color.White
        Me.txtAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddress2.Location = New System.Drawing.Point(21, 256)
        Me.txtAddress2.MaxLength = 100
        Me.txtAddress2.Multiline = True
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.ReadOnly = True
        Me.txtAddress2.Size = New System.Drawing.Size(325, 75)
        Me.txtAddress2.TabIndex = 3
        Me.txtAddress2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(21, 235)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(89, 18)
        Me.Label17.TabIndex = 108
        Me.Label17.Text = "Address 2"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(21, 94)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(89, 18)
        Me.Label16.TabIndex = 107
        Me.Label16.Text = "Address 1"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboShipToID
        '
        Me.cboShipToID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboShipToID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboShipToID.DataSource = Me.AdditionalShipToBindingSource
        Me.cboShipToID.DisplayMember = "ShipToID"
        Me.cboShipToID.DropDownWidth = 300
        Me.cboShipToID.FormattingEnabled = True
        Me.cboShipToID.Location = New System.Drawing.Point(99, 18)
        Me.cboShipToID.MaxLength = 50
        Me.cboShipToID.Name = "cboShipToID"
        Me.cboShipToID.Size = New System.Drawing.Size(247, 21)
        Me.cboShipToID.TabIndex = 0
        '
        'AdditionalShipToBindingSource
        '
        Me.AdditionalShipToBindingSource.DataMember = "AdditionalShipTo"
        Me.AdditionalShipToBindingSource.DataSource = Me.SQLTFPOperationsDatabaseDataSet
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(21, 19)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(89, 20)
        Me.Label15.TabIndex = 106
        Me.Label15.Text = "Ship To ID"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtShipToName
        '
        Me.txtShipToName.BackColor = System.Drawing.Color.White
        Me.txtShipToName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShipToName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtShipToName.Location = New System.Drawing.Point(99, 53)
        Me.txtShipToName.MaxLength = 100
        Me.txtShipToName.Name = "txtShipToName"
        Me.txtShipToName.ReadOnly = True
        Me.txtShipToName.Size = New System.Drawing.Size(247, 20)
        Me.txtShipToName.TabIndex = 1
        Me.txtShipToName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(21, 53)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(89, 18)
        Me.Label9.TabIndex = 103
        Me.Label9.Text = "Ship To Name"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAddress1
        '
        Me.txtAddress1.BackColor = System.Drawing.Color.White
        Me.txtAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAddress1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAddress1.Location = New System.Drawing.Point(21, 115)
        Me.txtAddress1.MaxLength = 100
        Me.txtAddress1.Multiline = True
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.ReadOnly = True
        Me.txtAddress1.Size = New System.Drawing.Size(325, 75)
        Me.txtAddress1.TabIndex = 2
        Me.txtAddress1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label18)
        Me.GroupBox5.Controls.Add(Me.cmdCreateSO)
        Me.GroupBox5.Location = New System.Drawing.Point(393, 687)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(222, 75)
        Me.GroupBox5.TabIndex = 34
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Create Sales Order"
        '
        'Label18
        '
        Me.Label18.ForeColor = System.Drawing.Color.Blue
        Me.Label18.Location = New System.Drawing.Point(6, 21)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(98, 38)
        Me.Label18.TabIndex = 56
        Me.Label18.Text = "Does not relieve inventory."
        '
        'cmdCreateSO
        '
        Me.cmdCreateSO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCreateSO.ForeColor = System.Drawing.Color.Blue
        Me.cmdCreateSO.Location = New System.Drawing.Point(134, 19)
        Me.cmdCreateSO.Name = "cmdCreateSO"
        Me.cmdCreateSO.Size = New System.Drawing.Size(71, 40)
        Me.cmdCreateSO.TabIndex = 35
        Me.cmdCreateSO.Text = "Create SO"
        Me.cmdCreateSO.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(33, 271)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(269, 19)
        Me.Label19.TabIndex = 105
        Me.Label19.Text = "Special Work / Shipping Instructions"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSpecialShippingInstructions
        '
        Me.txtSpecialShippingInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSpecialShippingInstructions.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSpecialShippingInstructions.Location = New System.Drawing.Point(33, 293)
        Me.txtSpecialShippingInstructions.MaxLength = 500
        Me.txtSpecialShippingInstructions.Multiline = True
        Me.txtSpecialShippingInstructions.Name = "txtSpecialShippingInstructions"
        Me.txtSpecialShippingInstructions.Size = New System.Drawing.Size(425, 173)
        Me.txtSpecialShippingInstructions.TabIndex = 33
        Me.txtSpecialShippingInstructions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'WorkOrderLineTableTableAdapter
        '
        Me.WorkOrderLineTableTableAdapter.ClearBeforeFill = True
        '
        'AdditionalShipToTableAdapter
        '
        Me.AdditionalShipToTableAdapter.ClearBeforeFill = True
        '
        'CountryCodesTableAdapter
        '
        Me.CountryCodesTableAdapter.ClearBeforeFill = True
        '
        'WorkOrderHeaderTableTableAdapter
        '
        Me.WorkOrderHeaderTableTableAdapter.ClearBeforeFill = True
        '
        'tabWorkOrderMain
        '
        Me.tabWorkOrderMain.Controls.Add(Me.tabLineItems)
        Me.tabWorkOrderMain.Controls.Add(Me.tabShippingData)
        Me.tabWorkOrderMain.Controls.Add(Me.tabInstructions)
        Me.tabWorkOrderMain.Location = New System.Drawing.Point(389, 41)
        Me.tabWorkOrderMain.Name = "tabWorkOrderMain"
        Me.tabWorkOrderMain.SelectedIndex = 0
        Me.tabWorkOrderMain.Size = New System.Drawing.Size(741, 526)
        Me.tabWorkOrderMain.TabIndex = 107
        '
        'tabLineItems
        '
        Me.tabLineItems.Controls.Add(Me.dgvWorkOrderLines)
        Me.tabLineItems.Location = New System.Drawing.Point(4, 22)
        Me.tabLineItems.Name = "tabLineItems"
        Me.tabLineItems.Padding = New System.Windows.Forms.Padding(3)
        Me.tabLineItems.Size = New System.Drawing.Size(733, 500)
        Me.tabLineItems.TabIndex = 0
        Me.tabLineItems.Text = "WO Line Items"
        Me.tabLineItems.UseVisualStyleBackColor = True
        '
        'tabShippingData
        '
        Me.tabShippingData.Controls.Add(Me.txtEstFreight)
        Me.tabShippingData.Controls.Add(Me.Label32)
        Me.tabShippingData.Controls.Add(Me.txtTotalShippingWeight)
        Me.tabShippingData.Controls.Add(Me.Label31)
        Me.tabShippingData.Controls.Add(Me.txtDateClosed)
        Me.tabShippingData.Controls.Add(Me.Label26)
        Me.tabShippingData.Controls.Add(Me.cboSalesperson)
        Me.tabShippingData.Controls.Add(Me.Label24)
        Me.tabShippingData.Controls.Add(Me.txtThirdPartyAddress)
        Me.tabShippingData.Controls.Add(Me.Label17)
        Me.tabShippingData.Controls.Add(Me.Label16)
        Me.tabShippingData.Controls.Add(Me.txtAddress1)
        Me.tabShippingData.Controls.Add(Me.cboShipToID)
        Me.tabShippingData.Controls.Add(Me.cboShipMethod)
        Me.tabShippingData.Controls.Add(Me.Label15)
        Me.tabShippingData.Controls.Add(Me.txtZip)
        Me.tabShippingData.Controls.Add(Me.Label10)
        Me.tabShippingData.Controls.Add(Me.txtShipToName)
        Me.tabShippingData.Controls.Add(Me.Label9)
        Me.tabShippingData.Controls.Add(Me.txtCountry)
        Me.tabShippingData.Controls.Add(Me.txtAddress2)
        Me.tabShippingData.Controls.Add(Me.Label14)
        Me.tabShippingData.Controls.Add(Me.cboCountryName)
        Me.tabShippingData.Controls.Add(Me.cboShipVia)
        Me.tabShippingData.Controls.Add(Me.Label709)
        Me.tabShippingData.Controls.Add(Me.txtState)
        Me.tabShippingData.Controls.Add(Me.txtCity)
        Me.tabShippingData.Controls.Add(Me.Label11)
        Me.tabShippingData.Controls.Add(Me.Label12)
        Me.tabShippingData.Controls.Add(Me.Label13)
        Me.tabShippingData.Controls.Add(Me.Label25)
        Me.tabShippingData.Location = New System.Drawing.Point(4, 22)
        Me.tabShippingData.Name = "tabShippingData"
        Me.tabShippingData.Padding = New System.Windows.Forms.Padding(3)
        Me.tabShippingData.Size = New System.Drawing.Size(733, 500)
        Me.tabShippingData.TabIndex = 1
        Me.tabShippingData.Text = "Shipping Address"
        Me.tabShippingData.UseVisualStyleBackColor = True
        '
        'txtEstFreight
        '
        Me.txtEstFreight.BackColor = System.Drawing.Color.White
        Me.txtEstFreight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEstFreight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEstFreight.Location = New System.Drawing.Point(522, 389)
        Me.txtEstFreight.Name = "txtEstFreight"
        Me.txtEstFreight.Size = New System.Drawing.Size(188, 20)
        Me.txtEstFreight.TabIndex = 15
        Me.txtEstFreight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label32
        '
        Me.Label32.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(392, 390)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(124, 20)
        Me.Label32.TabIndex = 117
        Me.Label32.Text = "Est. Freight Charges"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalShippingWeight
        '
        Me.txtTotalShippingWeight.BackColor = System.Drawing.Color.White
        Me.txtTotalShippingWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalShippingWeight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalShippingWeight.Location = New System.Drawing.Point(522, 346)
        Me.txtTotalShippingWeight.Name = "txtTotalShippingWeight"
        Me.txtTotalShippingWeight.ReadOnly = True
        Me.txtTotalShippingWeight.Size = New System.Drawing.Size(188, 20)
        Me.txtTotalShippingWeight.TabIndex = 14
        Me.txtTotalShippingWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(392, 346)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(124, 20)
        Me.Label31.TabIndex = 115
        Me.Label31.Text = "Shipping Weight"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDateClosed
        '
        Me.txtDateClosed.BackColor = System.Drawing.Color.White
        Me.txtDateClosed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDateClosed.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDateClosed.Location = New System.Drawing.Point(522, 303)
        Me.txtDateClosed.Name = "txtDateClosed"
        Me.txtDateClosed.ReadOnly = True
        Me.txtDateClosed.Size = New System.Drawing.Size(188, 20)
        Me.txtDateClosed.TabIndex = 13
        Me.txtDateClosed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(392, 303)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(124, 20)
        Me.Label26.TabIndex = 113
        Me.Label26.Text = "Date Closed / Shipped"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSalesperson
        '
        Me.cboSalesperson.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSalesperson.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSalesperson.FormattingEnabled = True
        Me.cboSalesperson.Location = New System.Drawing.Point(470, 253)
        Me.cboSalesperson.Name = "cboSalesperson"
        Me.cboSalesperson.Size = New System.Drawing.Size(240, 21)
        Me.cboSalesperson.TabIndex = 12
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(392, 94)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(324, 18)
        Me.Label24.TabIndex = 110
        Me.Label24.Text = "Third Party Billing Address"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtThirdPartyAddress
        '
        Me.txtThirdPartyAddress.BackColor = System.Drawing.Color.White
        Me.txtThirdPartyAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtThirdPartyAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtThirdPartyAddress.Location = New System.Drawing.Point(391, 115)
        Me.txtThirdPartyAddress.MaxLength = 100
        Me.txtThirdPartyAddress.Multiline = True
        Me.txtThirdPartyAddress.Name = "txtThirdPartyAddress"
        Me.txtThirdPartyAddress.ReadOnly = True
        Me.txtThirdPartyAddress.Size = New System.Drawing.Size(325, 75)
        Me.txtThirdPartyAddress.TabIndex = 11
        Me.txtThirdPartyAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(392, 253)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(89, 20)
        Me.Label25.TabIndex = 112
        Me.Label25.Text = "Salesperson"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabInstructions
        '
        Me.tabInstructions.Controls.Add(Me.txtSpecialShippingInstructions)
        Me.tabInstructions.Controls.Add(Me.Label19)
        Me.tabInstructions.Controls.Add(Me.txtHeaderComment)
        Me.tabInstructions.Controls.Add(Me.Label8)
        Me.tabInstructions.Location = New System.Drawing.Point(4, 22)
        Me.tabInstructions.Name = "tabInstructions"
        Me.tabInstructions.Size = New System.Drawing.Size(733, 500)
        Me.tabInstructions.TabIndex = 2
        Me.tabInstructions.Text = "WO Instructions"
        Me.tabInstructions.UseVisualStyleBackColor = True
        '
        'cmdReIssueWO
        '
        Me.cmdReIssueWO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdReIssueWO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReIssueWO.Location = New System.Drawing.Point(543, 771)
        Me.cmdReIssueWO.Name = "cmdReIssueWO"
        Me.cmdReIssueWO.Size = New System.Drawing.Size(71, 40)
        Me.cmdReIssueWO.TabIndex = 108
        Me.cmdReIssueWO.Text = "Re-Issue WO"
        Me.cmdReIssueWO.UseVisualStyleBackColor = True
        '
        'gpxAddLineItem
        '
        Me.gpxAddLineItem.Controls.Add(Me.lblQOH)
        Me.gpxAddLineItem.Controls.Add(Me.txtLongDescription)
        Me.gpxAddLineItem.Controls.Add(Me.cboPartNumber)
        Me.gpxAddLineItem.Controls.Add(Me.Label4)
        Me.gpxAddLineItem.Controls.Add(Me.cboPartDescription)
        Me.gpxAddLineItem.Controls.Add(Me.Label5)
        Me.gpxAddLineItem.Controls.Add(Me.cmdClearLine)
        Me.gpxAddLineItem.Controls.Add(Me.txtLineInstructions)
        Me.gpxAddLineItem.Controls.Add(Me.Label6)
        Me.gpxAddLineItem.Controls.Add(Me.txtUnitCost)
        Me.gpxAddLineItem.Controls.Add(Me.txtExtendedCost)
        Me.gpxAddLineItem.Controls.Add(Me.Label7)
        Me.gpxAddLineItem.Controls.Add(Me.Label704)
        Me.gpxAddLineItem.Controls.Add(Me.txtQuantity)
        Me.gpxAddLineItem.Controls.Add(Me.cmdAddLine)
        Me.gpxAddLineItem.Location = New System.Drawing.Point(29, 395)
        Me.gpxAddLineItem.Name = "gpxAddLineItem"
        Me.gpxAddLineItem.Size = New System.Drawing.Size(354, 416)
        Me.gpxAddLineItem.TabIndex = 11
        Me.gpxAddLineItem.TabStop = False
        Me.gpxAddLineItem.Text = "Add Line"
        '
        'lblQOH
        '
        Me.lblQOH.Location = New System.Drawing.Point(89, 280)
        Me.lblQOH.Name = "lblQOH"
        Me.lblQOH.Size = New System.Drawing.Size(78, 20)
        Me.lblQOH.TabIndex = 90
        Me.lblQOH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxDeleteLine
        '
        Me.gpxDeleteLine.Controls.Add(Me.nbrLineNumber)
        Me.gpxDeleteLine.Controls.Add(Me.Label22)
        Me.gpxDeleteLine.Controls.Add(Me.cmdDeleteLine)
        Me.gpxDeleteLine.Location = New System.Drawing.Point(621, 606)
        Me.gpxDeleteLine.Name = "gpxDeleteLine"
        Me.gpxDeleteLine.Size = New System.Drawing.Size(193, 107)
        Me.gpxDeleteLine.TabIndex = 110
        Me.gpxDeleteLine.TabStop = False
        Me.gpxDeleteLine.Text = "Delete Line And Re-Order"
        '
        'nbrLineNumber
        '
        Me.nbrLineNumber.Location = New System.Drawing.Point(74, 25)
        Me.nbrLineNumber.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nbrLineNumber.Name = "nbrLineNumber"
        Me.nbrLineNumber.Size = New System.Drawing.Size(104, 20)
        Me.nbrLineNumber.TabIndex = 87
        Me.nbrLineNumber.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(9, 25)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(89, 20)
        Me.Label22.TabIndex = 86
        Me.Label22.Text = "Line #"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdDeleteLine
        '
        Me.cmdDeleteLine.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeleteLine.Location = New System.Drawing.Point(107, 64)
        Me.cmdDeleteLine.Name = "cmdDeleteLine"
        Me.cmdDeleteLine.Size = New System.Drawing.Size(71, 30)
        Me.cmdDeleteLine.TabIndex = 20
        Me.cmdDeleteLine.Text = "Delete"
        Me.cmdDeleteLine.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtWorkOrderTotal)
        Me.GroupBox4.Controls.Add(Me.Label30)
        Me.GroupBox4.Controls.Add(Me.txtTotalTax)
        Me.GroupBox4.Controls.Add(Me.Label29)
        Me.GroupBox4.Controls.Add(Me.txtTotalFreight)
        Me.GroupBox4.Controls.Add(Me.Label28)
        Me.GroupBox4.Controls.Add(Me.txtTotalExtendedCost)
        Me.GroupBox4.Controls.Add(Me.Label27)
        Me.GroupBox4.Location = New System.Drawing.Point(825, 606)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(300, 156)
        Me.GroupBox4.TabIndex = 111
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Work Order Totals"
        '
        'txtWorkOrderTotal
        '
        Me.txtWorkOrderTotal.BackColor = System.Drawing.Color.White
        Me.txtWorkOrderTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWorkOrderTotal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtWorkOrderTotal.Location = New System.Drawing.Point(142, 120)
        Me.txtWorkOrderTotal.Name = "txtWorkOrderTotal"
        Me.txtWorkOrderTotal.ReadOnly = True
        Me.txtWorkOrderTotal.Size = New System.Drawing.Size(139, 20)
        Me.txtWorkOrderTotal.TabIndex = 122
        Me.txtWorkOrderTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label30
        '
        Me.Label30.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(12, 120)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(124, 20)
        Me.Label30.TabIndex = 121
        Me.Label30.Text = "Work Order Total"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalTax
        '
        Me.txtTotalTax.BackColor = System.Drawing.Color.White
        Me.txtTotalTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalTax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalTax.Location = New System.Drawing.Point(142, 87)
        Me.txtTotalTax.Name = "txtTotalTax"
        Me.txtTotalTax.ReadOnly = True
        Me.txtTotalTax.Size = New System.Drawing.Size(139, 20)
        Me.txtTotalTax.TabIndex = 120
        Me.txtTotalTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(12, 87)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(124, 20)
        Me.Label29.TabIndex = 119
        Me.Label29.Text = "Total Sales Tax"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalFreight
        '
        Me.txtTotalFreight.BackColor = System.Drawing.Color.White
        Me.txtTotalFreight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalFreight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalFreight.Location = New System.Drawing.Point(142, 54)
        Me.txtTotalFreight.Name = "txtTotalFreight"
        Me.txtTotalFreight.ReadOnly = True
        Me.txtTotalFreight.Size = New System.Drawing.Size(139, 20)
        Me.txtTotalFreight.TabIndex = 118
        Me.txtTotalFreight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(12, 54)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(124, 20)
        Me.Label28.TabIndex = 117
        Me.Label28.Text = "Total Freight"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalExtendedCost
        '
        Me.txtTotalExtendedCost.BackColor = System.Drawing.Color.White
        Me.txtTotalExtendedCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalExtendedCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTotalExtendedCost.Location = New System.Drawing.Point(142, 21)
        Me.txtTotalExtendedCost.Name = "txtTotalExtendedCost"
        Me.txtTotalExtendedCost.ReadOnly = True
        Me.txtTotalExtendedCost.Size = New System.Drawing.Size(139, 20)
        Me.txtTotalExtendedCost.TabIndex = 116
        Me.txtTotalExtendedCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label27
        '
        Me.Label27.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(12, 21)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(124, 20)
        Me.Label27.TabIndex = 115
        Me.Label27.Text = "Total Extended Cost"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpxCloseWorkOrder
        '
        Me.gpxCloseWorkOrder.Controls.Add(Me.cmdCloseWorkOrder)
        Me.gpxCloseWorkOrder.Location = New System.Drawing.Point(621, 719)
        Me.gpxCloseWorkOrder.Name = "gpxCloseWorkOrder"
        Me.gpxCloseWorkOrder.Size = New System.Drawing.Size(193, 92)
        Me.gpxCloseWorkOrder.TabIndex = 112
        Me.gpxCloseWorkOrder.TabStop = False
        Me.gpxCloseWorkOrder.Text = "Close Work Order"
        '
        'cmdCloseWorkOrder
        '
        Me.cmdCloseWorkOrder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCloseWorkOrder.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCloseWorkOrder.ForeColor = System.Drawing.Color.Red
        Me.cmdCloseWorkOrder.Location = New System.Drawing.Point(65, 29)
        Me.cmdCloseWorkOrder.Name = "cmdCloseWorkOrder"
        Me.cmdCloseWorkOrder.Size = New System.Drawing.Size(71, 40)
        Me.cmdCloseWorkOrder.TabIndex = 39
        Me.cmdCloseWorkOrder.Text = "Close WO"
        Me.cmdCloseWorkOrder.UseVisualStyleBackColor = True
        '
        'cmdUploadViewDocs
        '
        Me.cmdUploadViewDocs.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUploadViewDocs.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUploadViewDocs.Location = New System.Drawing.Point(468, 771)
        Me.cmdUploadViewDocs.Name = "cmdUploadViewDocs"
        Me.cmdUploadViewDocs.Size = New System.Drawing.Size(71, 40)
        Me.cmdUploadViewDocs.TabIndex = 113
        Me.cmdUploadViewDocs.Text = "Upload / View Docs"
        Me.cmdUploadViewDocs.UseVisualStyleBackColor = True
        '
        'WorkOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1142, 823)
        Me.Controls.Add(Me.cmdUploadViewDocs)
        Me.Controls.Add(Me.gpxCloseWorkOrder)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.gpxDeleteLine)
        Me.Controls.Add(Me.gpxAddLineItem)
        Me.Controls.Add(Me.cmdReIssueWO)
        Me.Controls.Add(Me.tabWorkOrderMain)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmdClearAll)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "WorkOrder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TFP Corporation Work Order"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.WorkOrderHeaderTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SQLTFPOperationsDatabaseDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DivisionTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ShipMethodBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvWorkOrderLines, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WorkOrderLineTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.CountryCodesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdditionalShipToBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.tabWorkOrderMain.ResumeLayout(False)
        Me.tabLineItems.ResumeLayout(False)
        Me.tabShippingData.ResumeLayout(False)
        Me.tabShippingData.PerformLayout()
        Me.tabInstructions.ResumeLayout(False)
        Me.tabInstructions.PerformLayout()
        Me.gpxAddLineItem.ResumeLayout(False)
        Me.gpxAddLineItem.PerformLayout()
        Me.gpxDeleteLine.ResumeLayout(False)
        CType(Me.nbrLineNumber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.gpxCloseWorkOrder.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboWorkOrderNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboDivisionID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdGenerateNewWO As System.Windows.Forms.Button
    Private WithEvents cboShipMethod As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerPO As System.Windows.Forms.TextBox
    Friend WithEvents llCustomerID As System.Windows.Forms.LinkLabel
    Friend WithEvents Label703 As System.Windows.Forms.Label
    Friend WithEvents cboShipVia As System.Windows.Forms.ComboBox
    Friend WithEvents Label709 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents cboCustomerID As System.Windows.Forms.ComboBox
    Friend WithEvents dtpWorkOrderDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label701 As System.Windows.Forms.Label
    Friend WithEvents dgvWorkOrderLines As System.Windows.Forms.DataGridView
    Friend WithEvents cmdClearAll As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdPostWorkOrder As System.Windows.Forms.Button
    Friend WithEvents cboPartNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label704 As System.Windows.Forms.Label
    Friend WithEvents cboPartDescription As System.Windows.Forms.ComboBox
    Friend WithEvents txtExtendedCost As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtUnitCost As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdAddLine As System.Windows.Forms.Button
    Friend WithEvents cmdClearLine As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtLineInstructions As System.Windows.Forms.TextBox
    Friend WithEvents txtLongDescription As System.Windows.Forms.TextBox
    Friend WithEvents SQLTFPOperationsDatabaseDataSet As MOS09Program.SQLTFPOperationsDatabaseDataSet
    Friend WithEvents DivisionTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DivisionTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.DivisionTableTableAdapter
    Friend WithEvents CustomerListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CustomerListTableAdapter
    Friend WithEvents ShipMethodBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ShipMethodTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ShipMethodTableAdapter
    Friend WithEvents ItemListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemListTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.ItemListTableAdapter
    Friend WithEvents txtHeaderComment As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboCountryName As System.Windows.Forms.ComboBox
    Friend WithEvents txtState As System.Windows.Forms.TextBox
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents txtCountry As System.Windows.Forms.TextBox
    Friend WithEvents txtZip As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtShipToName As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cboShipToID As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmdCreateSO As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtSpecialShippingInstructions As System.Windows.Forms.TextBox
    Friend WithEvents txtSalesOrderNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents WorkOrderLineTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents WorkOrderLineTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.WorkOrderLineTableTableAdapter
    Friend WithEvents AdditionalShipToBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AdditionalShipToTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.AdditionalShipToTableAdapter
    Friend WithEvents CountryCodesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CountryCodesTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.CountryCodesTableAdapter
    Friend WithEvents WorkOrderHeaderTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents WorkOrderHeaderTableTableAdapter As MOS09Program.SQLTFPOperationsDatabaseDataSetTableAdapters.WorkOrderHeaderTableTableAdapter
    Friend WithEvents txtPromiseDate As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents tabWorkOrderMain As System.Windows.Forms.TabControl
    Friend WithEvents tabLineItems As System.Windows.Forms.TabPage
    Friend WithEvents tabShippingData As System.Windows.Forms.TabPage
    Friend WithEvents tabInstructions As System.Windows.Forms.TabPage
    Friend WithEvents cmdReIssueWO As System.Windows.Forms.Button
    Friend WithEvents gpxAddLineItem As System.Windows.Forms.GroupBox
    Friend WithEvents gpxDeleteLine As System.Windows.Forms.GroupBox
    Friend WithEvents nbrLineNumber As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmdDeleteLine As System.Windows.Forms.Button
    Friend WithEvents txtWOStatus As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lblQOH As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtThirdPartyAddress As System.Windows.Forms.TextBox
    Friend WithEvents cboSalesperson As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtDateClosed As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtWorkOrderTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtTotalTax As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtTotalFreight As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtTotalExtendedCost As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents ReOpenWorkOrderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseWorkOrderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtTotalShippingWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents gpxCloseWorkOrder As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCloseWorkOrder As System.Windows.Forms.Button
    Friend WithEvents WorkOrderNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WorkOrderLineNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartNumberColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PartDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents QuantityColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UnitCostColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesTaxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ExtendedAmountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineCommentColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LongDescriptionColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitGLAccountColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DivisionIDColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LineStatusColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtEstFreight As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents cmdUploadViewDocs As System.Windows.Forms.Button
End Class

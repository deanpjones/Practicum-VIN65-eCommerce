namespace EpicorEagleMySQLView
{
    partial class frmTableResults
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

 


#region Windows Form Designer generated code

/// <summary>
/// Required method for Designer support - do not modify
/// the contents of this method with the code editor.
/// </summary>
private void InitializeComponent()
        {
            this.dgvTableResults = new System.Windows.Forms.DataGridView();
            this.lblTableNames = new System.Windows.Forms.Label();
            this.cboTableNames = new System.Windows.Forms.ComboBox();
            this.txtLimit = new System.Windows.Forms.TextBox();
            this.lblLimit = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvSearch = new System.Windows.Forms.DataGridView();
            this.txtLikeFilter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.cboCustomQuery = new System.Windows.Forms.ComboBox();
            this.btnExecuteCustomQuery = new System.Windows.Forms.Button();
            this.dgvCustomQuery = new System.Windows.Forms.DataGridView();
            this.txtCustomQuery = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.dgvInventoryRaw = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableResults)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomQuery)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryRaw)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTableResults
            // 
            this.dgvTableResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableResults.Location = new System.Drawing.Point(6, 54);
            this.dgvTableResults.Name = "dgvTableResults";
            this.dgvTableResults.RowTemplate.Height = 24;
            this.dgvTableResults.Size = new System.Drawing.Size(1311, 508);
            this.dgvTableResults.TabIndex = 0;
            // 
            // lblTableNames
            // 
            this.lblTableNames.AutoSize = true;
            this.lblTableNames.Location = new System.Drawing.Point(6, 3);
            this.lblTableNames.Name = "lblTableNames";
            this.lblTableNames.Size = new System.Drawing.Size(92, 17);
            this.lblTableNames.TabIndex = 1;
            this.lblTableNames.Text = "Table Names";
            // 
            // cboTableNames
            // 
            this.cboTableNames.FormattingEnabled = true;
            this.cboTableNames.Location = new System.Drawing.Point(6, 24);
            this.cboTableNames.Name = "cboTableNames";
            this.cboTableNames.Size = new System.Drawing.Size(210, 24);
            this.cboTableNames.TabIndex = 2;
            this.cboTableNames.SelectedIndexChanged += new System.EventHandler(this.cboTableNames_SelectedIndexChanged);
            // 
            // txtLimit
            // 
            this.txtLimit.Location = new System.Drawing.Point(231, 24);
            this.txtLimit.Name = "txtLimit";
            this.txtLimit.Size = new System.Drawing.Size(100, 22);
            this.txtLimit.TabIndex = 3;
            // 
            // lblLimit
            // 
            this.lblLimit.AutoSize = true;
            this.lblLimit.Location = new System.Drawing.Point(228, 4);
            this.lblLimit.Name = "lblLimit";
            this.lblLimit.Size = new System.Drawing.Size(37, 17);
            this.lblLimit.TabIndex = 1;
            this.lblLimit.Text = "Limit";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1331, 597);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtLimit);
            this.tabPage1.Controls.Add(this.dgvTableResults);
            this.tabPage1.Controls.Add(this.lblTableNames);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.lblCount);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lblLimit);
            this.tabPage1.Controls.Add(this.cboTableNames);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1323, 568);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ByTable";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(528, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "lblTableColumnNo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(528, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "# Columns";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(419, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "lblTableRowNo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(419, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "# Rows";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(337, 20);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(76, 17);
            this.lblCount.TabIndex = 1;
            this.lblCount.Text = "lblTableNo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(337, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "# Tables";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvSearch);
            this.tabPage2.Controls.Add(this.txtLikeFilter);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1323, 568);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Search";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvSearch
            // 
            this.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearch.Location = new System.Drawing.Point(6, 57);
            this.dgvSearch.Name = "dgvSearch";
            this.dgvSearch.RowTemplate.Height = 24;
            this.dgvSearch.Size = new System.Drawing.Size(1311, 508);
            this.dgvSearch.TabIndex = 8;
            // 
            // txtLikeFilter
            // 
            this.txtLikeFilter.Location = new System.Drawing.Point(6, 29);
            this.txtLikeFilter.Name = "txtLikeFilter";
            this.txtLikeFilter.Size = new System.Drawing.Size(100, 22);
            this.txtLikeFilter.TabIndex = 7;
            this.txtLikeFilter.TextChanged += new System.EventHandler(this.txtLikeFilter_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "LIKE filter";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.cboCustomQuery);
            this.tabPage3.Controls.Add(this.btnExecuteCustomQuery);
            this.tabPage3.Controls.Add(this.dgvCustomQuery);
            this.tabPage3.Controls.Add(this.txtCustomQuery);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1323, 568);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Custom";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "Table Names";
            // 
            // cboCustomQuery
            // 
            this.cboCustomQuery.FormattingEnabled = true;
            this.cboCustomQuery.Location = new System.Drawing.Point(10, 24);
            this.cboCustomQuery.Name = "cboCustomQuery";
            this.cboCustomQuery.Size = new System.Drawing.Size(210, 24);
            this.cboCustomQuery.TabIndex = 14;
            this.cboCustomQuery.SelectedIndexChanged += new System.EventHandler(this.cboCustomQuery_SelectedIndexChanged);
            // 
            // btnExecuteCustomQuery
            // 
            this.btnExecuteCustomQuery.Location = new System.Drawing.Point(1199, 78);
            this.btnExecuteCustomQuery.Name = "btnExecuteCustomQuery";
            this.btnExecuteCustomQuery.Size = new System.Drawing.Size(118, 23);
            this.btnExecuteCustomQuery.TabIndex = 12;
            this.btnExecuteCustomQuery.Text = "Execute";
            this.btnExecuteCustomQuery.UseVisualStyleBackColor = true;
            this.btnExecuteCustomQuery.Click += new System.EventHandler(this.btnExecuteCustomQuery_Click);
            // 
            // dgvCustomQuery
            // 
            this.dgvCustomQuery.AllowUserToAddRows = false;
            this.dgvCustomQuery.AllowUserToDeleteRows = false;
            this.dgvCustomQuery.AllowUserToOrderColumns = true;
            this.dgvCustomQuery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomQuery.Location = new System.Drawing.Point(7, 106);
            this.dgvCustomQuery.Name = "dgvCustomQuery";
            this.dgvCustomQuery.ReadOnly = true;
            this.dgvCustomQuery.RowTemplate.Height = 24;
            this.dgvCustomQuery.Size = new System.Drawing.Size(1316, 456);
            this.dgvCustomQuery.TabIndex = 11;
            // 
            // txtCustomQuery
            // 
            this.txtCustomQuery.Location = new System.Drawing.Point(7, 78);
            this.txtCustomQuery.Name = "txtCustomQuery";
            this.txtCustomQuery.Size = new System.Drawing.Size(1186, 22);
            this.txtCustomQuery.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Custom Query";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgvInventory);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1323, 568);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Inventory";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvInventory
            // 
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Location = new System.Drawing.Point(7, 54);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.RowTemplate.Height = 24;
            this.dgvInventory.Size = new System.Drawing.Size(1311, 508);
            this.dgvInventory.TabIndex = 11;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.dgvInventoryRaw);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1323, 568);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Inventory(raw)";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // dgvInventoryRaw
            // 
            this.dgvInventoryRaw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventoryRaw.Location = new System.Drawing.Point(6, 54);
            this.dgvInventoryRaw.Name = "dgvInventoryRaw";
            this.dgvInventoryRaw.RowTemplate.Height = 24;
            this.dgvInventoryRaw.Size = new System.Drawing.Size(1311, 508);
            this.dgvInventoryRaw.TabIndex = 12;
            // 
            // frmTableResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 621);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmTableResults";
            this.Text = "MySQL Data";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableResults)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearch)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomQuery)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryRaw)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTableResults;
        private System.Windows.Forms.Label lblTableNames;
        private System.Windows.Forms.ComboBox cboTableNames;
        private System.Windows.Forms.TextBox txtLimit;
        private System.Windows.Forms.Label lblLimit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvSearch;
        private System.Windows.Forms.TextBox txtLikeFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnExecuteCustomQuery;
        private System.Windows.Forms.DataGridView dgvCustomQuery;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCustomQuery;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboCustomQuery;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dgvInventoryRaw;
    }
}


namespace AppleDailyReportTool.ui
{
    partial class FormDataBase
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
            this.label1 = new System.Windows.Forms.Label();
            this.textHawbNo = new System.Windows.Forms.TextBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.dgvHawbTb = new System.Windows.Forms.DataGridView();
            this.HawbNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HawbTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shipper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SapPlantCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCTN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPlt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvApplePoTb = new System.Windows.Forms.DataGridView();
            this.HAWBNo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApplePo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ctn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Plt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Volume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PNContained = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerPoid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHawbTb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplePoTb)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "HawbNo";
            // 
            // textHawbNo
            // 
            this.textHawbNo.Location = new System.Drawing.Point(85, 14);
            this.textHawbNo.Name = "textHawbNo";
            this.textHawbNo.Size = new System.Drawing.Size(143, 21);
            this.textHawbNo.TabIndex = 1;
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(283, 12);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(75, 23);
            this.searchBtn.TabIndex = 2;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            // 
            // dgvHawbTb
            // 
            this.dgvHawbTb.AllowUserToOrderColumns = true;
            this.dgvHawbTb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHawbTb.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HawbNo,
            this.HawbTitle,
            this.AppleId,
            this.Shipper,
            this.SapPlantCode,
            this.ORG,
            this.COC,
            this.POE,
            this.TotalCTN,
            this.TotalPlt,
            this.TotalWeight,
            this.TotalVolume});
            this.dgvHawbTb.Location = new System.Drawing.Point(12, 62);
            this.dgvHawbTb.Name = "dgvHawbTb";
            this.dgvHawbTb.RowTemplate.Height = 23;
            this.dgvHawbTb.Size = new System.Drawing.Size(1244, 240);
            this.dgvHawbTb.TabIndex = 3;
            // 
            // HawbNo
            // 
            this.HawbNo.DataPropertyName = "HAWBNo";
            this.HawbNo.Frozen = true;
            this.HawbNo.HeaderText = "HawbNo";
            this.HawbNo.Name = "HawbNo";
            this.HawbNo.ReadOnly = true;
            // 
            // HawbTitle
            // 
            this.HawbTitle.DataPropertyName = "HAWBTitle";
            this.HawbTitle.Frozen = true;
            this.HawbTitle.HeaderText = "HawbTitle";
            this.HawbTitle.Name = "HawbTitle";
            this.HawbTitle.ReadOnly = true;
            // 
            // AppleId
            // 
            this.AppleId.DataPropertyName = "AppleId";
            this.AppleId.Frozen = true;
            this.AppleId.HeaderText = "AppleId";
            this.AppleId.Name = "AppleId";
            this.AppleId.ReadOnly = true;
            // 
            // Shipper
            // 
            this.Shipper.DataPropertyName = "Shipper";
            this.Shipper.Frozen = true;
            this.Shipper.HeaderText = "Shipper";
            this.Shipper.Name = "Shipper";
            this.Shipper.ReadOnly = true;
            // 
            // SapPlantCode
            // 
            this.SapPlantCode.DataPropertyName = "SapPlantCode";
            this.SapPlantCode.Frozen = true;
            this.SapPlantCode.HeaderText = "SapPlantCode";
            this.SapPlantCode.Name = "SapPlantCode";
            this.SapPlantCode.ReadOnly = true;
            // 
            // ORG
            // 
            this.ORG.DataPropertyName = "Org";
            this.ORG.Frozen = true;
            this.ORG.HeaderText = "ORG";
            this.ORG.Name = "ORG";
            this.ORG.ReadOnly = true;
            // 
            // COC
            // 
            this.COC.DataPropertyName = "Coc";
            this.COC.Frozen = true;
            this.COC.HeaderText = "COC";
            this.COC.Name = "COC";
            this.COC.ReadOnly = true;
            // 
            // POE
            // 
            this.POE.DataPropertyName = "Poe";
            this.POE.Frozen = true;
            this.POE.HeaderText = "POE";
            this.POE.Name = "POE";
            this.POE.ReadOnly = true;
            // 
            // TotalCTN
            // 
            this.TotalCTN.DataPropertyName = "TotalCtn";
            this.TotalCTN.Frozen = true;
            this.TotalCTN.HeaderText = "TotalCTN";
            this.TotalCTN.Name = "TotalCTN";
            this.TotalCTN.ReadOnly = true;
            // 
            // TotalPlt
            // 
            this.TotalPlt.DataPropertyName = "TotalPlt";
            this.TotalPlt.Frozen = true;
            this.TotalPlt.HeaderText = "TotalPlt";
            this.TotalPlt.Name = "TotalPlt";
            this.TotalPlt.ReadOnly = true;
            // 
            // TotalWeight
            // 
            this.TotalWeight.DataPropertyName = "TotalWeigth";
            this.TotalWeight.Frozen = true;
            this.TotalWeight.HeaderText = "TotalWeight(KG)";
            this.TotalWeight.Name = "TotalWeight";
            this.TotalWeight.ReadOnly = true;
            // 
            // TotalVolume
            // 
            this.TotalVolume.DataPropertyName = "TotalVolumn";
            this.TotalVolume.Frozen = true;
            this.TotalVolume.HeaderText = "TotalVolume(CBM)";
            this.TotalVolume.Name = "TotalVolume";
            this.TotalVolume.ReadOnly = true;
            // 
            // dgvApplePoTb
            // 
            this.dgvApplePoTb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplePoTb.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HAWBNo2,
            this.ApplePo,
            this.ShipTo,
            this.Ctn,
            this.Plt,
            this.Weight,
            this.Volume,
            this.PNContained,
            this.CustomerPoid});
            this.dgvApplePoTb.Location = new System.Drawing.Point(12, 325);
            this.dgvApplePoTb.Name = "dgvApplePoTb";
            this.dgvApplePoTb.RowTemplate.Height = 23;
            this.dgvApplePoTb.Size = new System.Drawing.Size(1061, 287);
            this.dgvApplePoTb.TabIndex = 4;
            // 
            // HAWBNo2
            // 
            this.HAWBNo2.DataPropertyName = "HAWBNo";
            this.HAWBNo2.Frozen = true;
            this.HAWBNo2.HeaderText = "HAWBNo";
            this.HAWBNo2.Name = "HAWBNo2";
            this.HAWBNo2.ReadOnly = true;
            // 
            // ApplePo
            // 
            this.ApplePo.DataPropertyName = "ApplePo";
            this.ApplePo.Frozen = true;
            this.ApplePo.HeaderText = "ApplePo";
            this.ApplePo.Name = "ApplePo";
            this.ApplePo.ReadOnly = true;
            // 
            // ShipTo
            // 
            this.ShipTo.DataPropertyName = "ShipTo";
            this.ShipTo.Frozen = true;
            this.ShipTo.HeaderText = "ShipTo";
            this.ShipTo.Name = "ShipTo";
            this.ShipTo.ReadOnly = true;
            // 
            // Ctn
            // 
            this.Ctn.DataPropertyName = "Ctn";
            this.Ctn.Frozen = true;
            this.Ctn.HeaderText = "Ctn";
            this.Ctn.Name = "Ctn";
            this.Ctn.ReadOnly = true;
            // 
            // Plt
            // 
            this.Plt.DataPropertyName = "Plt";
            this.Plt.Frozen = true;
            this.Plt.HeaderText = "Plt";
            this.Plt.Name = "Plt";
            this.Plt.ReadOnly = true;
            // 
            // Weight
            // 
            this.Weight.DataPropertyName = "Weight";
            this.Weight.Frozen = true;
            this.Weight.HeaderText = "Weight";
            this.Weight.Name = "Weight";
            this.Weight.ReadOnly = true;
            // 
            // Volume
            // 
            this.Volume.DataPropertyName = "Volume";
            this.Volume.Frozen = true;
            this.Volume.HeaderText = "Volume";
            this.Volume.Name = "Volume";
            this.Volume.ReadOnly = true;
            // 
            // PNContained
            // 
            this.PNContained.DataPropertyName = "PNContained";
            this.PNContained.Frozen = true;
            this.PNContained.HeaderText = "PNContained";
            this.PNContained.Name = "PNContained";
            this.PNContained.ReadOnly = true;
            // 
            // CustomerPoid
            // 
            this.CustomerPoid.DataPropertyName = "CustomerPoid";
            this.CustomerPoid.Frozen = true;
            this.CustomerPoid.HeaderText = "CustomerPoid";
            this.CustomerPoid.Name = "CustomerPoid";
            this.CustomerPoid.ReadOnly = true;
            // 
            // FormDataBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 624);
            this.Controls.Add(this.dgvApplePoTb);
            this.Controls.Add(this.dgvHawbTb);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.textHawbNo);
            this.Controls.Add(this.label1);
            this.Name = "FormDataBase";
            this.Text = "SearchDataBase";
            this.Load += new System.EventHandler(this.FormDataBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHawbTb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplePoTb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textHawbNo;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.DataGridView dgvHawbTb;
        private System.Windows.Forms.DataGridViewTextBoxColumn HawbNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HawbTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shipper;
        private System.Windows.Forms.DataGridViewTextBoxColumn SapPlantCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORG;
        private System.Windows.Forms.DataGridViewTextBoxColumn COC;
        private System.Windows.Forms.DataGridViewTextBoxColumn POE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCTN;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPlt;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalVolume;
        private System.Windows.Forms.DataGridView dgvApplePoTb;
        private System.Windows.Forms.DataGridViewTextBoxColumn HAWBNo2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApplePo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ctn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Plt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Volume;
        private System.Windows.Forms.DataGridViewTextBoxColumn PNContained;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerPoid;
    }
}
namespace XtraEditorsBindingSample.Forms
{
    partial class TripXtraForm
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
            this.dataLayoutControlExt1 = new XtraEditorsBinding.DataLayoutControl.DataLayoutControlExt();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControlExt1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControlExt1
            // 
            this.dataLayoutControlExt1.BindingDataProvider = null;
            this.dataLayoutControlExt1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControlExt1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControlExt1.Name = "dataLayoutControlExt1";
            this.dataLayoutControlExt1.Root = this.layoutControlGroup1;
            this.dataLayoutControlExt1.Size = new System.Drawing.Size(918, 433);
            this.dataLayoutControlExt1.TabIndex = 0;
            this.dataLayoutControlExt1.Text = "dataLayoutControlExt1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(180, 120);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // TripXtraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 433);
            this.Controls.Add(this.dataLayoutControlExt1);
            this.Name = "TripXtraForm";
            this.Text = "TripXtraForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControlExt1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private XtraEditorsBinding.DataLayoutControl.DataLayoutControlExt dataLayoutControlExt1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
    }
}
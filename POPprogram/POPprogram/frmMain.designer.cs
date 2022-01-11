
namespace POPprogram
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.flpMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.menuImageList = new System.Windows.Forms.ImageList(this.components);
            this.selmenuImageList = new System.Windows.Forms.ImageList(this.components);
            this.lblID = new System.Windows.Forms.Label();
            this.tabMenu = new POPprogram.csTabControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.AutoSize = false;
            this.mnuMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mnuMain.Font = new System.Drawing.Font("나눔고딕 ExtraBold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.mnuMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Padding = new System.Windows.Forms.Padding(0);
            this.mnuMain.Size = new System.Drawing.Size(1595, 45);
            this.mnuMain.TabIndex = 1;
            this.mnuMain.Text = "menuStrip1";
            // 
            // flpMenu
            // 
            this.flpMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.flpMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpMenu.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.flpMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(182)))), ((int)(((byte)(190)))));
            this.flpMenu.Location = new System.Drawing.Point(0, 45);
            this.flpMenu.Margin = new System.Windows.Forms.Padding(0);
            this.flpMenu.Name = "flpMenu";
            this.flpMenu.Size = new System.Drawing.Size(200, 985);
            this.flpMenu.TabIndex = 3;
            // 
            // menuImageList
            // 
            this.menuImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("menuImageList.ImageStream")));
            this.menuImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.menuImageList.Images.SetKeyName(0, "Data-Export.png");
            this.menuImageList.Images.SetKeyName(1, "Calendar -01 .png");
            this.menuImageList.Images.SetKeyName(2, "Chart-Type.png");
            this.menuImageList.Images.SetKeyName(3, "Computer-Desktop.png");
            this.menuImageList.Images.SetKeyName(4, "Cube.png");
            this.menuImageList.Images.SetKeyName(5, "Cupboard - 04.png");
            this.menuImageList.Images.SetKeyName(6, "Despeckle.png");
            this.menuImageList.Images.SetKeyName(7, "Drop box.png");
            this.menuImageList.Images.SetKeyName(8, "Equalizer.png");
            this.menuImageList.Images.SetKeyName(9, "Flow-Cart.png");
            // 
            // selmenuImageList
            // 
            this.selmenuImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("selmenuImageList.ImageStream")));
            this.selmenuImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.selmenuImageList.Images.SetKeyName(0, "Data-Export.png");
            this.selmenuImageList.Images.SetKeyName(1, "Calendar_01.png");
            this.selmenuImageList.Images.SetKeyName(2, "Chart-Type.png");
            this.selmenuImageList.Images.SetKeyName(3, "Computer-Desktop.png");
            this.selmenuImageList.Images.SetKeyName(4, "Cube.png");
            this.selmenuImageList.Images.SetKeyName(5, "Cupboard - 04.png");
            this.selmenuImageList.Images.SetKeyName(6, "Despeckle.png");
            this.selmenuImageList.Images.SetKeyName(7, "Drop box.png");
            this.selmenuImageList.Images.SetKeyName(8, "Equalizer.png");
            this.selmenuImageList.Images.SetKeyName(9, "Flow-Cart.png");
            // 
            // lblID
            // 
            this.lblID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblID.AutoSize = true;
            this.lblID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblID.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(182)))), ((int)(((byte)(190)))));
            this.lblID.Location = new System.Drawing.Point(1508, 19);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(25, 19);
            this.lblID.TabIndex = 21;
            this.lblID.Text = "ID";
            this.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabMenu
            // 
            this.tabMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabMenu.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabMenu.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tabMenu.Location = new System.Drawing.Point(200, 45);
            this.tabMenu.Margin = new System.Windows.Forms.Padding(0);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.SelectedIndex = 0;
            this.tabMenu.Size = new System.Drawing.Size(1395, 30);
            this.tabMenu.TabIndex = 23;
            this.tabMenu.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            this.tabMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabMenu_MouseDown);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Industry - 01.png");
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(133, 45);
            this.pictureBox2.TabIndex = 25;
            this.pictureBox2.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1595, 1030);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.tabMenu);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.flpMenu);
            this.Controls.Add(this.mnuMain);
            this.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMain";
            this.Text = "NiceMES";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MdiChildActivate += new System.EventHandler(this.frmMain_MdiChildActivate);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.FlowLayoutPanel flpMenu;
        public System.Windows.Forms.Label lblID;
        private csTabControl tabMenu;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ImageList menuImageList;
        private System.Windows.Forms.ImageList selmenuImageList;
    }
}
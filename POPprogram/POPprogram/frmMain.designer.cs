
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.lOT생성ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lOT조회ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lOT작업시작ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.검사데이터ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.자재사용ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.작업완료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.불량등록ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.생산비가동등록ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.mnuMain.Font = new System.Drawing.Font("여기어때 잘난체 OTF", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lOT생성ToolStripMenuItem,
            this.lOT조회ToolStripMenuItem,
            this.lOT작업시작ToolStripMenuItem,
            this.검사데이터ToolStripMenuItem,
            this.자재사용ToolStripMenuItem,
            this.작업완료ToolStripMenuItem,
            this.불량등록ToolStripMenuItem,
            this.생산비가동등록ToolStripMenuItem});
            this.mnuMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(1396, 45);
            this.mnuMain.TabIndex = 1;
            this.mnuMain.Text = "menuStrip1";
            // 
            // lOT생성ToolStripMenuItem
            // 
            this.lOT생성ToolStripMenuItem.Name = "lOT생성ToolStripMenuItem";
            this.lOT생성ToolStripMenuItem.Size = new System.Drawing.Size(187, 41);
            this.lOT생성ToolStripMenuItem.Text = "LOT 생성";
            // 
            // lOT조회ToolStripMenuItem
            // 
            this.lOT조회ToolStripMenuItem.Name = "lOT조회ToolStripMenuItem";
            this.lOT조회ToolStripMenuItem.Size = new System.Drawing.Size(187, 41);
            this.lOT조회ToolStripMenuItem.Text = "LOT 조회";
            // 
            // lOT작업시작ToolStripMenuItem
            // 
            this.lOT작업시작ToolStripMenuItem.Name = "lOT작업시작ToolStripMenuItem";
            this.lOT작업시작ToolStripMenuItem.Size = new System.Drawing.Size(187, 41);
            this.lOT작업시작ToolStripMenuItem.Text = "작업 시작";
            // 
            // 검사데이터ToolStripMenuItem
            // 
            this.검사데이터ToolStripMenuItem.Name = "검사데이터ToolStripMenuItem";
            this.검사데이터ToolStripMenuItem.Size = new System.Drawing.Size(224, 41);
            this.검사데이터ToolStripMenuItem.Text = "검사 데이터";
            // 
            // 자재사용ToolStripMenuItem
            // 
            this.자재사용ToolStripMenuItem.Name = "자재사용ToolStripMenuItem";
            this.자재사용ToolStripMenuItem.Size = new System.Drawing.Size(187, 41);
            this.자재사용ToolStripMenuItem.Text = "자재 사용";
            // 
            // 작업완료ToolStripMenuItem
            // 
            this.작업완료ToolStripMenuItem.Name = "작업완료ToolStripMenuItem";
            this.작업완료ToolStripMenuItem.Size = new System.Drawing.Size(187, 41);
            this.작업완료ToolStripMenuItem.Text = "작업 완료";
            // 
            // 불량등록ToolStripMenuItem
            // 
            this.불량등록ToolStripMenuItem.Name = "불량등록ToolStripMenuItem";
            this.불량등록ToolStripMenuItem.Size = new System.Drawing.Size(187, 41);
            this.불량등록ToolStripMenuItem.Text = "불량 등록";
            // 
            // 생산비가동등록ToolStripMenuItem
            // 
            this.생산비가동등록ToolStripMenuItem.Name = "생산비가동등록ToolStripMenuItem";
            this.생산비가동등록ToolStripMenuItem.Size = new System.Drawing.Size(224, 41);
            this.생산비가동등록ToolStripMenuItem.Text = "비가동 등록";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1396, 824);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmMain";
            this.Text = "메인 화면";
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem lOT생성ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lOT조회ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lOT작업시작ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 검사데이터ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 자재사용ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 작업완료ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 불량등록ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 생산비가동등록ToolStripMenuItem;
    }
}
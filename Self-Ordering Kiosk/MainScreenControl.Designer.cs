namespace Self_Ordering_Kiosk
{
    partial class MainScreenControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreenControl));
            ofertySpecjalneToolStripMenuItem = new ToolStripMenuItem();
            hamburgeryToolStripMenuItem = new ToolStripMenuItem();
            dodatkiToolStripMenuItem = new ToolStripMenuItem();
            napojeToolStripMenuItem = new ToolStripMenuItem();
            koszykToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            tableForProductsControl1 = new TableForProductsControl();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ofertySpecjalneToolStripMenuItem
            // 
            ofertySpecjalneToolStripMenuItem.BackColor = Color.FromArgb(255, 128, 0);
            ofertySpecjalneToolStripMenuItem.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point);
            ofertySpecjalneToolStripMenuItem.Margin = new Padding(0, 0, 3, 0);
            ofertySpecjalneToolStripMenuItem.Name = "ofertySpecjalneToolStripMenuItem";
            ofertySpecjalneToolStripMenuItem.Size = new Size(200, 46);
            ofertySpecjalneToolStripMenuItem.Text = "Oferty specjalne";
            ofertySpecjalneToolStripMenuItem.Click += ofertySpecjalneToolStripMenuItem_Click;
            // 
            // hamburgeryToolStripMenuItem
            // 
            hamburgeryToolStripMenuItem.AutoSize = false;
            hamburgeryToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            hamburgeryToolStripMenuItem.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point);
            hamburgeryToolStripMenuItem.Margin = new Padding(0, 0, 3, 0);
            hamburgeryToolStripMenuItem.Name = "hamburgeryToolStripMenuItem";
            hamburgeryToolStripMenuItem.Size = new Size(200, 46);
            hamburgeryToolStripMenuItem.Text = "Hamburgery";
            hamburgeryToolStripMenuItem.Click += hamburgeryToolStripMenuItem_Click;
            // 
            // dodatkiToolStripMenuItem
            // 
            dodatkiToolStripMenuItem.AutoSize = false;
            dodatkiToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            dodatkiToolStripMenuItem.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point);
            dodatkiToolStripMenuItem.Margin = new Padding(0, 0, 3, 0);
            dodatkiToolStripMenuItem.Name = "dodatkiToolStripMenuItem";
            dodatkiToolStripMenuItem.Size = new Size(200, 46);
            dodatkiToolStripMenuItem.Text = "Dodatki";
            dodatkiToolStripMenuItem.Click += dodatkiToolStripMenuItem_Click;
            // 
            // napojeToolStripMenuItem
            // 
            napojeToolStripMenuItem.AutoSize = false;
            napojeToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            napojeToolStripMenuItem.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point);
            napojeToolStripMenuItem.Margin = new Padding(0, 0, 3, 0);
            napojeToolStripMenuItem.Name = "napojeToolStripMenuItem";
            napojeToolStripMenuItem.Size = new Size(200, 46);
            napojeToolStripMenuItem.Text = "Napoje";
            napojeToolStripMenuItem.Click += napojeToolStripMenuItem_Click;
            // 
            // koszykToolStripMenuItem
            // 
            koszykToolStripMenuItem.AutoSize = false;
            koszykToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            koszykToolStripMenuItem.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point);
            koszykToolStripMenuItem.Image = (Image)resources.GetObject("koszykToolStripMenuItem.Image");
            koszykToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            koszykToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            koszykToolStripMenuItem.Name = "koszykToolStripMenuItem";
            koszykToolStripMenuItem.Padding = new Padding(0);
            koszykToolStripMenuItem.Size = new Size(260, 46);
            koszykToolStripMenuItem.Text = "Koszyk        ";
            koszykToolStripMenuItem.TextAlign = ContentAlignment.MiddleRight;
            koszykToolStripMenuItem.TextImageRelation = TextImageRelation.Overlay;
            koszykToolStripMenuItem.Click += koszykToolStripMenuItem_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.AutoSize = false;
            menuStrip1.GripMargin = new Padding(2);
            menuStrip1.Items.AddRange(new ToolStripItem[] { ofertySpecjalneToolStripMenuItem, hamburgeryToolStripMenuItem, dodatkiToolStripMenuItem, napojeToolStripMenuItem, koszykToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1084, 50);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // tableForProductsControl1
            // 
            tableForProductsControl1.Dock = DockStyle.Bottom;
            tableForProductsControl1.Location = new Point(0, 61);
            tableForProductsControl1.Name = "tableForProductsControl1";
            tableForProductsControl1.Size = new Size(1084, 550);
            tableForProductsControl1.TabIndex = 1;
            // 
            // MainScreenControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(tableForProductsControl1);
            Controls.Add(menuStrip1);
            Name = "MainScreenControl";
            Size = new Size(1084, 611);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ToolStripMenuItem ofertySpecjalneToolStripMenuItem;
        private ToolStripMenuItem hamburgeryToolStripMenuItem;
        private ToolStripMenuItem dodatkiToolStripMenuItem;
        private ToolStripMenuItem napojeToolStripMenuItem;
        private ToolStripMenuItem koszykToolStripMenuItem;
        private MenuStrip menuStrip1;
        private TableForProductsControl tableForProductsControl1;
    }
}

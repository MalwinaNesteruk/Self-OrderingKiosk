using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Self_Ordering_Kiosk
{
    public partial class MainScreenControl : UserControl
    {
        public MainScreenControl()
        {
            InitializeComponent();
        }

        private void ofertySpecjalneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofertySpecjalneToolStripMenuItem.BackColor = Color.FromArgb(255, 128, 0);
            hamburgeryToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            dodatkiToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            napojeToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            koszykToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
        }

        private void hamburgeryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofertySpecjalneToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            hamburgeryToolStripMenuItem.BackColor = Color.FromArgb(255, 128, 0);
            dodatkiToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            napojeToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            koszykToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
        }

        private void dodatkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofertySpecjalneToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            hamburgeryToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            dodatkiToolStripMenuItem.BackColor = Color.FromArgb(255, 128, 0);
            napojeToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            koszykToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
        }

        private void napojeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofertySpecjalneToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            hamburgeryToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            dodatkiToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            napojeToolStripMenuItem.BackColor = Color.FromArgb(255, 128, 0);
            koszykToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
        }

        private void koszykToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofertySpecjalneToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            hamburgeryToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            dodatkiToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            napojeToolStripMenuItem.BackColor = SystemColors.ActiveCaption;
            koszykToolStripMenuItem.BackColor = Color.FromArgb(255, 128, 0);
        }
    }
}

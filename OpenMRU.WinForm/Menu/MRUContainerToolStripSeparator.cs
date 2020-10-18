using System.Drawing;
using System.Windows.Forms;

namespace OpenMRU.WinForm.Menu
{
    public class MRUContainerToolStripSeparator : ToolStripMenuItem
    {
        private Font font;
        private Brush brush;

        public void SetTextPresentation (Font font, Brush brush)
        {
            this.font = font;
            this.brush = brush;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawString(this.Text, font, brush, 3, 6);
        }

        public MRUContainerToolStripSeparator()
        {
            this.Enabled = false;
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Talepler
{
    public class CustomTabControl : TabControl
    {
        private const int CLOSE_BUTTON_WIDTH = 15;
        private const int CLOSE_BUTTON_MARGIN = 8;
        private const int TEXT_MARGIN = 8;
        private const int TAB_PADDING = 8;
        private readonly Color CLOSE_BUTTON_COLOR = Color.FromArgb(153, 153, 153);
        private readonly Color TAB_TEXT_COLOR = Color.Black;
        private readonly Color TAB_BACKGROUND_COLOR = Color.White;
        private readonly Color TAB_BORDER_COLOR = Color.LightGray;

        public CustomTabControl()
        {
            DrawMode = TabDrawMode.OwnerDrawFixed;
            Padding = new Point(CLOSE_BUTTON_WIDTH, 5);
            
            ItemSize = new Size(160, 35);
            SizeMode = TabSizeMode.Fixed;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (TabPages.Count == 0) return;

            var currentTab = TabPages[e.Index];
            var tabBounds = GetTabRect(e.Index);
            
            using (var pen = new Pen(TAB_BORDER_COLOR))
            {
                e.Graphics.FillRectangle(new SolidBrush(TAB_BACKGROUND_COLOR), tabBounds);
                e.Graphics.DrawRectangle(pen, tabBounds);
            }

            DrawTabText(e.Graphics, currentTab.Text, tabBounds);
            DrawCloseButton(e.Graphics, tabBounds);
        }

        private void DrawTabText(Graphics g, string text, Rectangle tabBounds)
        {
            var textBounds = new Rectangle(
                tabBounds.Left + TEXT_MARGIN,
                tabBounds.Top + TEXT_MARGIN,
                tabBounds.Width - CLOSE_BUTTON_WIDTH - (TEXT_MARGIN * 2) - CLOSE_BUTTON_MARGIN,
                tabBounds.Height - (TEXT_MARGIN * 2)
            );

            TextRenderer.DrawText(g, text, Font, textBounds, TAB_TEXT_COLOR, 
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
        }

        private void DrawCloseButton(Graphics g, Rectangle tabBounds)
        {
            var closeButtonBounds = GetCloseButtonBounds(tabBounds);

            using (var brush = new SolidBrush(CLOSE_BUTTON_COLOR))
            using (var pen = new Pen(brush, 2))
            {
                // Çarpı işaretini çiz
                g.DrawLine(pen,
                    closeButtonBounds.Left + 3,
                    closeButtonBounds.Top + 3,
                    closeButtonBounds.Right - 3,
                    closeButtonBounds.Bottom - 3);

                g.DrawLine(pen,
                    closeButtonBounds.Right - 3,
                    closeButtonBounds.Top + 3,
                    closeButtonBounds.Left + 3,
                    closeButtonBounds.Bottom - 3);
            }
        }

        private Rectangle GetCloseButtonBounds(Rectangle tabBounds)
        {
            return new Rectangle(
                tabBounds.Right - CLOSE_BUTTON_WIDTH - CLOSE_BUTTON_MARGIN,
                tabBounds.Top + (tabBounds.Height - CLOSE_BUTTON_WIDTH) / 2,
                CLOSE_BUTTON_WIDTH,
                CLOSE_BUTTON_WIDTH
            );
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            for (int i = 0; i < TabPages.Count; i++)
            {
                var tabBounds = GetTabRect(i);
                var closeButtonBounds = GetCloseButtonBounds(tabBounds);

                if (closeButtonBounds.Contains(e.Location))
                {
                    TabPages.RemoveAt(i);
                    if (i > 0) SelectedIndex = i - 1;
                    break;
                }
            }
        }
    }
} 
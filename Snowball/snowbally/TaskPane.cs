using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Snowball;

namespace Snowball
{
    namespace XPControls
    {
        class TaskPane : XPanel
        {
            public void addPanel()
            {
                Pane Pan = new Pane();
              
            }
        }
        class Pane : XPanel
        {
            public string Title
            {
                get
                {
                    return this.Titlx.Text;
                }
                set
                {
                    this.Titlx.Text = value;
                }
            }
            private XPanel topPanel;
            private Labelx Titlx;
            private XPanel ContentPanel;
            public Pane()
            {
                topPanel = new XPanel();
                Titlx = new Labelx();
                topPanel.Parent = this;
                Titlx.Parent = topPanel;
                ContentPanel = new XPanel();
                ContentPanel.Parent = this.Parent;
                ContentPanel.Dock = DockStyle.Top;
                topPanel.Dock = DockStyle.Top;
            }
        }
    }
}

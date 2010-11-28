using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snowball
{
    public partial class interbook : UserControl
    {
        public void addPage()
        {
            interpage Page = new interpage(this);
            interpage Node = this.Tail;
            while (Node.NextPage != null)
            {
                Node = Node.NextPage;
            }
            Node.NextPage = Page;
            Page.PreviousPage = Node;
            this.Head = Page;
        }
        public interpage getPageAt(int index)
        {
            interpage Node = this.Tail;
            if (index > 0)
            {
                for (int i = 0; i < index; i++)
                {
                    if (Node.NextPage != null)
                    {
                        Node = Node.NextPage;
                    }
                }
            }
            else
            {
                Node = this.Tail;
            }
            return Node;
        }
        public void setActivePageAt(int index)
        {
            interpage Node = new interpage();
            Node = this.Tail;
            int i = 0;
                for (i = 0; i <= index; i++)
                {
                    if (Node.NextPage != null)
                    {
                        
                        Node.Visible = false;
                        Node = Node.NextPage;
                    }
                }

            this.currentPage = index;
            Node.Visible = true;
        }
       
        public void xnextPage()
        {
            int x = this.currentPage;
            setActivePageAt(x+1);
        }
        public void xpreviousPage()
        {
            int x = this.currentPage;
            setActivePageAt(x-1);
        }
 
        public interpage Tail=null;
        public interpage Head=null;
        public int currentPage=0;
        public interbook()
        {
            
            this.Tail = new interpage(this);
            this.Tail.Visible = true;
           
      
            this.Head = this.Tail;
            InitializeComponent();
          
        }

        private void xPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void display_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            xpreviousPage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            xnextPage();
        }

        private void lnkPrevious_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            xpreviousPage();
        }

        private void lnkNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            xnextPage();
        }
    }
    public class interpage : XPanel
    {
        public interpage()
        {
   
            Dock = DockStyle.Fill;
            this.Visible = false;
        }
        public interpage(interbook Parentx)
        {
            this.Parent = Parentx.display;
            Dock = DockStyle.Fill;
            this.Visible = false;
        }
        public interpage PreviousPage;
        public interpage NextPage;
    }
}

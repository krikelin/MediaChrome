using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snowball
{
    public partial class frmConfirm : Form
    {
        public String LinkText
        {
            get
            {
                return this.linkLabel1.Text;
            }
            set
            {
                this.linkLabel1.Text = value;
            }
        }
        public String Title
        {
            get
            {
                return this.Text;
            }
            set
            {
                this.Text = value;
                this.label1.Text = value;
            }
        }
        public String Description
        {
            get
            {
                return this.label2.Text;
            }
            set
            {
                this.label2.Text = value;
            }
        }
        public frmConfirm()
        {
            InitializeComponent();
        }
        public delegate void X();
        public event X linkLabel1_Click;
        private void frmConfirm_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1_Click();
        }
    }
}

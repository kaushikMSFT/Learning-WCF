// © 2007 Michele Leroux Bustamante. All rights reserved 
// Book: Learning WCF, O'Reilly
// Book Blog: www.thatindigogirl.com
// Michele's Blog: www.dasblonde.net
// IDesign: www.idesign.net
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace ProfileClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            localhost.ProfileServiceClient proxy = new localhost.ProfileServiceClient();
            CultureInfo c = this.comboBox1.SelectedItem as CultureInfo;
            if (c!=null)
            {
                proxy.SetCulturePreference(c.Name);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            localhost.ProfileServiceClient proxy = new localhost.ProfileServiceClient();

            CultureInfo c = new CultureInfo(proxy.GetCulturePreference());
            string s = string.Format("{0}, ({1})", c.DisplayName, c.Name);
            MessageBox.Show(s);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            this.comboBox1.Items.AddRange(cultures);
        }
    }
}
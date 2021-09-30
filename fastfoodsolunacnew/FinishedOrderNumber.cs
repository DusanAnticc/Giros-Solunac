using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace fastfoodsolunacnew
{
    public partial class FinishedOrderNumber : Form
    {
        Timer formCloser = new Timer();

        public FinishedOrderNumber(int number)
        {
            InitializeComponent();
            var area = Screen.AllScreens[1].WorkingArea;
            //this.Location = Screen.AllScreens[0].WorkingArea.Location;
            var location = area.Location;

            location.Offset((area.Width - Width) / 2 , (area.Height - Height) / 2);
            Location = location;


            button1.Text = number.ToString();
            formCloser.Interval = 5000;
            formCloser.Enabled = true;
            formCloser.Tick += new EventHandler(formClose_Tick);            
        }

        private void formClose_Tick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}

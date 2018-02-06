using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserLayer
{
    public partial class ProveedoresLayer : Form
    {
        public ProveedoresLayer()
        {
            InitializeComponent();
            pictureBox1.Controls.Add(pictureBox2);
            pictureBox1.Dock = DockStyle.Top;
            pictureBox2.Location = new Point(20, 10);
            pictureBox2.BackColor = Color.Transparent;
        }
    }
}

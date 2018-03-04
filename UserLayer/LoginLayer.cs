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
    public partial class LoginLayer : Form
    {
        public LoginLayer()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable Data = StructLayer.UsuariosStruct.Login(usuariotxt.Text,passwordtxt.Text);

            //Validar el usuario
            if (Data.Rows.Count == 0)
            {
                MessageBox.Show("Usuario no Existente, No tiene acceso","Tool Crib Assistant",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else
            {
                MainLayer FlatLayer = new MainLayer();
                FlatLayer.idusuario = Data.Rows[0][0].ToString();
                FlatLayer.Nombre = Data.Rows[0][1].ToString();
                FlatLayer.Acceso = Data.Rows[0][2].ToString();

                FlatLayer.Show();
                this.Hide();
            }
        }
    }
}

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
    public partial class MainLayer : Form
    {
        private int childFormNumber = 0;
        public string idusuario = "";
        public string Nombre = "";
        public string Acceso = "";
        public MainLayer()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArticuloLayer layer = ArticuloLayer.GetInstancia();
            layer.MdiParent = this;
            layer.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            layer.Dock = DockStyle.Fill;
            layer.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProveedoresLayer layer = new ProveedoresLayer();
            layer.MdiParent = this;
            layer.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            layer.Dock = DockStyle.Fill;
            layer.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MaquinaLayer layer = new MaquinaLayer();
            layer.MdiParent = this;
            layer.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            layer.Dock = DockStyle.Fill;
            layer.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UsuarioLayer layer = new UsuarioLayer();
            layer.MdiParent = this;
            layer.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            layer.Dock = DockStyle.Fill;
            layer.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CentroCostoLayer layer = new CentroCostoLayer();
            layer.MdiParent = this;
            layer.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            layer.Dock = DockStyle.Fill;
            layer.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RequisitoresLayer layer = new RequisitoresLayer();
            layer.MdiParent = this;
            layer.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            layer.Dock = DockStyle.Fill;
            layer.Show();
        }

        private void MainLayer_Load(object sender, EventArgs e)
        {
            GestionUsuario();
        }

        private void GestionUsuario()
        {
            //Control de Accesos
            if(Acceso == "Administrador")
            {
                MessageBox.Show("Bienvenido "+Nombre,"Tool-Crib Management Assistant");
            }
            else if(Acceso == "Financieros")
            {
                MessageBox.Show("Bienvenido " + Nombre, "Tool-Crib Management Assistant");
            }
            else if (Acceso == "Tool-Crib")
            {
                MessageBox.Show("Bienvenido " + Nombre, "Tool-Crib Management Assistant");
            }
            else
            {
                MessageBox.Show("Fuck off " + Nombre, "Tool-Crib Management Assistant");
            }
        }
    }
}

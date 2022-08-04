using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Lista_de_produtoss
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
     (
         
         int nLeftRect,
         int nTopRect,
         int nRightRect,
         int nBottomRect,
         int nWidthEllipse,
         int nHeightEllipse


     );

        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        Point DragCursor;
        Point DragForm;
        bool Dragging;

        private void add_produto_Click(object sender, EventArgs e)
        {
            list_produtos.Items.Add(txb_produtos.Text);
            contador.Text = list_produtos.Items.Count.ToString();

            txb_produtos.Clear();
        }

        private void remove_produto_Click(object sender, EventArgs e)
        {
            if (list_produtos.SelectedIndex != -1)
            {
                list_produtos.Items.RemoveAt(list_produtos.SelectedIndex);
            }

            else
            {
                MessageBox.Show("SELECIONE UM ALIMENTO", "MESAGEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            contador.Text = list_produtos.Items.Count.ToString();
        }

        private void btn_limpar_Click(object sender, EventArgs e)
        {
            list_produtos.Items.Clear();
            contador.Text = list_produtos.Items.Count.ToString();
        }

        private void btn_alterar_Click(object sender, EventArgs e)
        {
            if (list_produtos.SelectedIndex > -1)
            {
                list_produtos.Items[list_produtos.SelectedIndex] = txb_produtos.Text;
            }

            else
            {
                MessageBox.Show("SELECIONE UM ALIMENTO", "MESAGEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            contador.Text = list_produtos.Items.Count.ToString();
        }

        private void txb_produtos_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txb_produtos_Click(object sender, EventArgs e)
        {
            txb_produtos.Clear();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Dragging = true;
            DragCursor = Cursor.Position;
            DragForm = this.Location;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            Dragging = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Dragging == true)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(DragCursor));
                this.Location = Point.Add(DragForm, new Size(dif));
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
    
}

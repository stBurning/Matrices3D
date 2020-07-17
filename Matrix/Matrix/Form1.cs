using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            try {
                Matrix A = new Matrix();
                A[0, 0] = Double.Parse(A00.Text); A[0, 1] = Double.Parse(A01.Text); A[0, 2] = Double.Parse(A02.Text);
                A[1, 0] = Double.Parse(A10.Text); A[1, 1] = Double.Parse(A11.Text); A[1, 2] = Double.Parse(A12.Text);
                A[2, 0] = Double.Parse(A20.Text); A[1, 2] = Double.Parse(A21.Text); A[2, 2] = Double.Parse(A22.Text);

                Matrix B = new Matrix();
                B[0, 0] = Double.Parse(B00.Text); B[0, 1] = Double.Parse(B01.Text); B[0, 2] = Double.Parse(B02.Text);
                B[1, 0] = Double.Parse(B10.Text); B[1, 1] = Double.Parse(B11.Text); B[1, 2] = Double.Parse(B12.Text);
                B[2, 0] = Double.Parse(B20.Text); B[1, 2] = Double.Parse(B21.Text); B[2, 2] = Double.Parse(B22.Text);

                Matrix C = new Matrix();
                C[0, 0] = Double.Parse(C00.Text); C[0, 1] = Double.Parse(C01.Text); C[0, 2] = Double.Parse(C02.Text);
                C[1, 0] = Double.Parse(C10.Text); C[1, 1] = Double.Parse(C11.Text); C[1, 2] = Double.Parse(C12.Text);
                C[2, 0] = Double.Parse(C20.Text); C[1, 2] = Double.Parse(C21.Text); C[2, 2] = Double.Parse(C22.Text);

                var det = (A * B).det() / (B * C).det();
                textBox1.Text = det.ToString();

            } catch(Exception ex) {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}

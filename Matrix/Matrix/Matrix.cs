using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix {
    public class Matrix {
        /****/
        private double[,] data;

        public const int Dimention = 3;

        public Matrix(double[,] data) {

            if (data == null || data.GetLength(0) != Dimention || data.GetLength(1) != Dimention)
                throw new Exception("Неверный формат входных данных");
            this.data = new double[Dimention, Dimention];
            for (int i = 0; i < Dimention; i++) {
                for (int j = 0; j < Dimention; j++) {
                    this.data[i, j] = data[i, j];
                }
            }
        }
        public Matrix(double[][] data) {

            if (data == null || data.GetLength(0) != Dimention || data[0].GetLength(0) != Dimention)
                throw new Exception("Неверный формат входных данных");
            this.data = new double[Dimention, Dimention];
            for (int i = 0; i < Dimention; i++) {
                for (int j = 0; j < Dimention; j++) {
                    this.data[i, j] = data[i][j];
                }
            }
        }
        public Matrix() {
            //Нулевая матрица
            this.data = new double[Dimention, Dimention];
            for (int i = 0; i < Dimention; i++) {
                for (int j = 0; j < Dimention; j++) {
                    this.data[i, j] = 0;
                }
            }
        }

        public static Matrix E() {
            //Матричная единица
            var matrix = new Matrix();
            matrix[0, 0] = 1;
            matrix[1, 1] = 1;
            matrix[2, 2] = 1;
            return matrix;

        }

        public double this[int i, int j] {
            //Чтение и запись (i, j) элемента матрицы
            get { return data[i,j]; }
            set { data[i,j] = value; }
        }
        public static Matrix operator +(Matrix left, Matrix right) {
            //Сложение матриц
            var toReturn = new Matrix();
            for (int i = 0; i < Dimention; i++) {
                for (int j = 0; j < Dimention; j++) {
                    toReturn[i, j] = left[i, j] + right[i, j];
                }
            }
            return toReturn;
        }

        public static Matrix operator -(Matrix left, Matrix right) {
            //Разность матриц
            var toReturn = new Matrix();
            for (int i = 0; i < Dimention; i++) {
                for (int j = 0; j < Dimention; j++) {
                    toReturn[i, j] = left[i, j] - right[i, j];
                }
            }
            return toReturn;
        }

        public static Matrix operator *(Matrix left, Matrix right) {
            //Произведение матриц
            var toReturn = new Matrix();
            for (int i = 0; i < Dimention; i++) {
                for (int j = 0; j < Dimention; j++) {
                    for (int k = 0; k < Dimention; k++) {
                        toReturn[i, j] += left[i, k] * right[k, j];
                    }
                }
            } return toReturn;
        }
        public static Matrix operator *(Matrix matrix, double lambda) {
            //Умножение матрицы на число
            var toReturn = new Matrix();
            for (int i = 0; i < Dimention; i++) {
                for (int j = 0; j < Dimention; j++) {        
                    toReturn[i, j] = matrix[i, j] * lambda;
                }
            } return toReturn;
        }
        public static Matrix operator *(double lambda, Matrix matrix) {
            return matrix * lambda;
        }

        public double det() {
            //Определитель для матрицы 3-его порядка. Разложение по первой строке.
            return data[0, 0] * (data[1, 1] * data[2, 2] - data[1, 2] * data[2, 1]) -
                   data[0, 1] * (data[1, 0] * data[2, 2] - data[1, 2] * data[2, 0]) +
                   data[0, 2] * (data[1, 0] * data[2, 1] - data[1, 1] * data[2, 0]);
        }

        public override string ToString() {
            return String.Format(
                      "{0:f2}, {1:f2}, {2:f2}\n" +
                      "{3:f2}, {4:f2}, {5:f2}\n" +
                      "{6:f2}, {7:f2}, {8:f2}\n", 
                      data[0, 0], data[0, 1], data[0, 2], 
                      data[1, 0], data[1, 1], data[1, 2], 
                      data[2, 0], data[2, 1], data[2, 2]);

            
        }
    }
}

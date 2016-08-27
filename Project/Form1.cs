using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Form1 : Form
    {
        int numIterations , rowCountPoint;
        static public double c, f , alpha0, alpha1, beta0, beta1;
        int[] points;
        int min = 1000000000;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            numIterations = int.Parse(txtNumIteration.Text);
            c = double.Parse(txtC.Text);
            f = double.Parse(txtF.Text);
            alpha0 = double.Parse(txtAlpha0.Text);
            alpha1 = double.Parse(txtAlpha1.Text);
            beta0 = double.Parse(txtBeta0.Text);
            beta1 = double.Parse(txtBeta1.Text);

            rowCountPoint = pointsDGV.RowCount - 1;
            points = new int[rowCountPoint]; 

            for (int i = 0; i < rowCountPoint; i++) //fill the array of points
                points[i] = int.Parse(pointsDGV.Rows[i].Cells[0].Value.ToString());

            for (int i = 0; i < rowCountPoint; i++) // choose the min n
            {
                if (points[i] < min)
                    min = points[i];
            }

            for (int i = 0; i < rowCountPoint; i++) 
            {
                Processing p = new Processing(points[i]); 
                p.IntializeMatrix(points[i]); 

                for (int j = 0; j < numIterations; j++)
                {
                    p.doTheJob(points[i]); 
                    p.update();
                    
                    if (points[i] == min)
                    {
                        if (j == numIterations - 1)
                        {
                            for (int row = 0; row < points[i] + 2; row++)
                            {
                                for (int col = 0; col < points[i] + 2; col++)
                                {
                                    listView1.Items.Add(p.oldMatrix[row][col].ToString());
                                }
                                listView1.Items.Add("Row ");
                            }
                        }
                    }
                }
            }
        }
    }
}

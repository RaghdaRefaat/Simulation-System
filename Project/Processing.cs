using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Processing
    {
        public double[][] oldMatrix;
        double[][] newMatrix;
        int dimension;   
        double deltaS , deltaT;

        public Processing(int n)
        {
            dimension = n + 2;
            deltaS = 1.0/(n + 1);
            deltaT = (Math.Pow(deltaS,2)) / (4 * Form1.c);
 
            oldMatrix = new double[dimension][]; 
            newMatrix = new double[dimension][]; 
            for (int i = 0; i < dimension ; i++)
            {
                oldMatrix[i] = new double[dimension];
                newMatrix[i] = new double[dimension];
            }
        }
        
        public void IntializeMatrix(int n)
        { 
            for (int i = 1; i <= n; i++) //intialize the entire matrix
                for (int j = 1; j <= n; j++)
                    oldMatrix[i][j] = Form1.f;  

            for (int i = 0; i < dimension; i++) //intialize the boundries
            {
                oldMatrix[i][0] = Form1.alpha0;
                oldMatrix[i][dimension - 1] = Form1.alpha1;
                oldMatrix[0][i] = Form1.beta0;
                oldMatrix[dimension - 1][i] = Form1.beta1;
            }
        }

        public void doTheJob(int n)
        {
            for (int i = 0; i < dimension; i++) //intialize the boundries
            {
                newMatrix[i][0] = Form1.alpha0;
                newMatrix[i][dimension - 1] = Form1.alpha1;
                newMatrix[0][i] = Form1.beta0;
                newMatrix[dimension - 1][i] = Form1.beta1;
            }

            for (int i = 1; i <= n; i++) // fill the entire matrix
            {
                for (int j = 1; j <= n; j++)
                {
                    newMatrix[i][j] = oldMatrix[i][j] + Form1.c * (deltaT / (Math.Pow(deltaS,2))) *
                        (oldMatrix[i - 1][j] + oldMatrix[i + 1][j] + oldMatrix[i][j - 1]
                        + oldMatrix[i][j + 1] - 4 * (oldMatrix[i][j])); // heat equation
                }
            }
        }

        public void update()
        {
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    oldMatrix[i][j] = newMatrix[i][j];
                    newMatrix[i][j] = 0;
                }
            }
        }

    }
}

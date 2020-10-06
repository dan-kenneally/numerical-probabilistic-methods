using System;
using System.IO;

namespace ConsoleApp2
{
    class brownianmotion
    {
        static void Main(string[] args)
        {
            // creating empty matrix of length 1000
            double[] e = new double[1000];
            //running that matrix through function
            generateWalk(e, 1000, 10, 1);
            //and outputting to the file "1walkarray
            outputToFile("1walkarray", e);
            // creating another empty matrix of length 1000
            double[] k = new double[1000];
            //running that matrix through function
            ensembledata(k, 1000, 1000, 10, 1);
            //and outputting to the file "1000walkarray"
            outputToFile("1000walkarray", k);
            // create variables that are passed through the function
            double kmean = 0;
            double kvar = 0;
            meanvar(k, ref kmean, ref kvar);
            Console.WriteLine("for  1000 random walks with sigma= 1 mean is {0} var is {1}", kmean, kvar);
            //creating loop to go through all values of sigma
             for (int s = 2; s < 10; s++)
            {
                ensembledata(k, 1000, 1000, 10, s);
                double smean = 0;
                double svar = 0;
                meanvar(k, ref smean, ref svar);
                Console.WriteLine("for  1000 random walks with sigma= {0} mean is {1} var is {2}",s, smean, svar);
            }
        }
        public static void outputToFile(string filename, double[] data)
        {
            // creates new file called "filename.csv" and stored Z drive 
            StreamWriter sw = new StreamWriter(string.Format(@"Z:\{0}.csv", filename));
            // create loop that goes through each index of the data set and prints it in the file
            for (int x = 0; x < data.Length; x++)
            {
                string xs = Convert.ToString(data[x]);
                sw.Write("{0},", xs);
            }
            sw.Close();
        }
        // create random seed
        public static Random rnd = new Random();
        public static void generateWalk(double[] data, int n, double T, double sigma)
        {
            // gets values of Delta
            double delta_t = T / n;
            double Delta = sigma * Math.Sqrt(delta_t);
            // creates function with input d and output d or -d both with probability 0.5
            double x(double d)
            {
                if (rnd.Next(2) == 1)
                {
                    return -1 * d;
                }
                else
                {
                    return d;
                }
            }
            // setting first index of array equal to 0
            data[0] = 0;
            //runs loop that finds position of walk at each step and stores it in the array at that stpes index
            for (int c = 1; c < n; c++)
            {
                data[c] = data[c - 1] + x(Delta);
            }
        }
        public static void ensembledata(double[] data, int nperwalk, int nens, double T, double sigma)
        {
            // creates loop that generates nens random walks and stores the final position of each walk in the data array
            for (int a = 0; a < nens; a++)
            {
                double[] myArray;
                myArray = new double[nperwalk];
                generateWalk(myArray, nperwalk, T, sigma);
                data[a] = myArray[nperwalk - 1];
            }
        }
        public static void meanvar(double[] data, ref double mean, ref double var)
        {
            double sum = 0;
            // adds every element in data together
            foreach (double d in data)
            {
                sum +=d;
            }
            // gets mean
            mean = sum / data.Length;
            double sum_of_dif = 0;
            // gets sum of the square of the difference between every element and the mean
            foreach (double d in data)
            {
                double f =(d - mean) * (d - mean);
                sum_of_dif +=f;
            }
            //gets variance
            var = sum_of_dif/ data.Length;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


/**
 * @author $Harsh-shah, frah-abdo
 *
 */
namespace KnapsackProblem
{

    /*public class Algo : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        static void Main()
        {
            Console.WriteLine("Hello, World!");
            int[] W = new int[] { 15, 10, 2, 4 };
            int[] V = new int[] { 30, 25, 2, 6 };
            int M = 37;
            int n = V.Length;

            KnapsackGreProc(W, V, M, n);

        }

        private double weight;
        private double value;
        private double cost;

        public KnapsackPackage(double weight, double value)
        {
            this.weight = weight;
            this.value = value;

            this.cost = (double)value / weight;
        }

        public double Weight
        {
            get { return weight; }
        }

        public double Value
        {
            get { return value; }
        }

        public double Cost
        {
            get { return cost; }
        }


        public static void KnapsackGreProc(int[] W, int[] V, int M, int n)
        {
            KnapsackPackage[] packs = new KnapsackPackage[n];
            for (int k = 0; k < n; k++)
                packs[k] = new KnapsackPackage(W[k], V[k]); //Initialize weight and value for each knapsack package.

            Array.Sort<KnapsackPackage>(packs, new Comparison<KnapsackPackage>(
                (kPackA, kPackB) => kPackB.Cost.CompareTo(kPackA.Cost)));
            //Sort knapsack packages by cost with descending order.


            double remain = M;
            double result = 0d;

            int i = 0;
            bool stopProc = false;

            while (!stopProc)
            {
                if (packs[i].Weight <= remain)
                {
                    //If select package i.
                    remain -= packs[i].Weight;
                    result += packs[i].Value;

                    Console.WriteLine("Pack " + i + " - Weight " + packs[i].Weight + " - Value " + packs[i].Value);
                }

                if (packs[i].Weight > remain)
                {
                    i++; //If select the number of package i is enough.
                }

                if (i == n)
                {
                    stopProc = true;    //Stop when browsing all packages.
                }
            }

            Console.WriteLine("Max Value:\t" + result);
        }
    }*/
}
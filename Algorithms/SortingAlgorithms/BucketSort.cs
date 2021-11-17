using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.SortingAlgorithms
{
    //Space: O(n + k), k is number of buckets
    //Time: 
    //Distribution Best: O(n) Worst: O(n)
    //Iterating buckets Best: O(k) Worst: O(k)
    //Sorting: Best: O(1) Worst: O(n^2) depends on the underling sorting algorithm.
    //Total: Best: O(n + k) Worst: O(n^2)
    //The more buckets you allocate, the closer it gets to linear time.
    public class BucketSort : Sort
    {
        public void SortAsc(int[] numbers, int numOfBuckets)
        {
            if (numOfBuckets < 1)
                throw new InvalidOperationException();

            var buckets = DistributeToBuckets(numbers, numOfBuckets);
            SortEachBucket(buckets);
            PutBack(buckets, numbers);
        }

        private List<int>[] DistributeToBuckets(int[] numbers, int numOfBuckets)
        {
            var buckets = new List<int>[numOfBuckets];
            for(int i = 0; i < numOfBuckets; i++)
                buckets[i] = new List<int>();

            foreach(var n in numbers)
            {
                var index = n / numOfBuckets;
                buckets[index].Add(n);
            }

            return buckets;
        }

        private void SortEachBucket(List<int>[] buckets)
        {
            foreach(var b in buckets)
                b.Sort();
        }

        private void PutBack(List<int>[] from, int[] to)
        {
            var index = 0;
            foreach(var bucket in from)
            {
                foreach(var item in bucket)
                    to[index++] = item;
            }
        }
    }
}

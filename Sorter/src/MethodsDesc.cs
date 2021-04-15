namespace Sorter
{
    public class MethodsDesc : IMethods
    {
        /// <summary>
        /// Swaps two integer values.
        /// </summary>
        /// <param name="a">The first integer variable</param>
        /// <param name="b">The second integer variable</param>
        private void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Sorts the data array using the bubble method and returns the number of inversions in the array.
        /// </summary>
        /// <param name="array">Integer data array.</param>
        /// <returns>Number of inversions in the array.</returns>
        public int BubbleSort(ref int[] array)
        {
            int arrayLenght = array.Length;
            int permutations = 0;
            bool swapped = false;

            for (int i = 0; i < arrayLenght - 1; i++)
            {
                for (int j = 0; j < arrayLenght - i - 1; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        permutations++;
                        swapped = true;
                    }
                }

                // IF no two elements were swapped by inner loop, then break
                if (!swapped) break;
            }

            return permutations;
        }

        /// <summary>
        /// Sorts the data array using the cocktail method and returns the number of inversions in the array.
        /// </summary>
        /// <param name="array">Integer data array.</param>
        /// <returns>Number of inversions in the array.</returns>
        public int CocktailSort(ref int[] array)
        {
            int arrayLenght = array.Length;
            int permutations = 0;
            bool swapped = false;

            for (int i = 0; i < arrayLenght / 2; i++)
            {
                // from left to right
                for (int j = i; j < arrayLenght - i - 1; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        permutations++;
                        swapped = true;
                    }
                }

                // from right to left
                for (int j = arrayLenght - 2 - i; j > i; j--)
                {
                    if (array[j - 1] < array[j])
                    {
                        Swap(ref array[j - 1], ref array[j]);
                        permutations++;
                        swapped = true;
                    }
                }

                // IF no two elements were swapped by inner loop, then break
                if (!swapped) break;
            }

            return permutations;
        }

        /// <summary>
        /// Sorts the data array using the insertion method and returns the number of inversions in the array.
        /// </summary>
        /// <param name="array">Integer data array.</param>
        /// <returns>Number of inversions in the array.</returns>
        public int InsertionSort(ref int[] array)
        {
            int permutations = 0;

            for (int i = 1; i < array.Length; i++)
            {
                int value = array[i];
                int j = i - 1;
                while (j >= 0 && array[j].CompareTo(value) < 0)
                {
                    Swap(ref array[j + 1], ref array[j]);
                    permutations++;
                    j--;
                }

                array[j + 1] = value;
            }

            return permutations;
        }

        /// <summary>
        /// Sorts the data array using the merge method and returns the number of inversions in the array.
        /// </summary>
        /// <param name="array">Integer data array.</param>
        /// <returns>Number of inversions in the array.</returns>
        public int MergeSort(ref int[] array)
        {
            int[] temp = new int[array.Length];
            return MergeSort(ref array, temp, 0, array.Length - 1);
        }

        ///<summary>
        /// An auxiliary recursive method that sort the input array and returns the number of inversions in the array.
        /// </summary>
        /// <param name="array">Integer data array.</param>
        /// <param name="temp">Auxiliary temporary array.</param>
        /// <param name="left">The first index of the temporary array.</param>
        /// <param name="right">The last index of the temporary array.</param>
        /// <returns>Number of inversions in the array.</returns>
        public int MergeSort(ref int[] array, int[] temp, int left, int right)
        {
            int permutations = 0;
            if (right > left)
            {
                int mid = (right + left) / 2;

                /* Inversion count will be the sum of inversions in left-part, right-part and number of inversions
                 in merging */
                permutations += MergeSort(ref array, temp, left, mid);
                permutations += MergeSort(ref array, temp, mid + 1, right);

                // Merge the two parts
                permutations += Merge(ref array, temp, left, mid + 1, right);
            }

            return permutations;
        }

        /// <summary>
        /// Merges two sorted arrays and returns inversion count in the arrays.
        /// </summary>
        /// <param name="array">Integer data array.</param>
        /// <param name="temp">Auxiliary temporary array.</param>
        /// <param name="left">The first index of the temporary array.</param>
        /// <param name="mid">The middle index of the temporary arrray.</param>
        /// <param name="right">The last index of the temporary array.</param>
        /// <returns>Number of inversions in the array.</returns>
        public int Merge(ref int[] array, int[] temp, int left, int mid, int right)
        {
            {
                int permutations = 0;
                int i = left; // i is index for left subarray
                int j = mid; // j is index for right subarray
                int k = left; // k is index for resultant merged subarray

                while (i <= mid - 1 && j <= right)
                {
                    if (array[i] >= array[j])
                    {
                        temp[k++] = array[i++];
                    }
                    else
                    {
                        temp[k++] = array[j++];
                        permutations += mid - i;
                    }
                }

                // Copy the remaining elements of left subarray (if there are any) to temp
                while (i <= mid - 1)
                    temp[k++] = array[i++];

                // Copy the remaining elements of right subarray (if there are any) to temp
                while (j <= right)
                    temp[k++] = array[j++];

                // Copy back the merged elements to original array
                for (i = left; i <= right; i++)
                    array[i] = temp[i];
                return permutations;
            }
        }

        /// <summary>
        /// Sorts the data array using the selection method and returns the number of inversions in the array.
        /// </summary>
        /// <param name="array">Integer data array.</param>
        /// <returns>Number of inversions in the array.</returns>
        public int SelectionSort(ref int[] array)
        {
            int arrayLength = array.Length;
            int permutations = 0;

            for (int i = 0; i < arrayLength - 1; i++)
            {
                // Find the minimum element in unsorted array
                int minIndex = i;
                for (int j = i + 1; j < arrayLength; j++)
                    if (array[j] > array[minIndex])
                        minIndex = j;

                Swap(ref array[minIndex], ref array[i]);
                permutations++;
            }

            return permutations;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2
{
    public class SortEmployees
    {
        static public int Partition(Employee[] employees, int left, int right)
        {
            char pivot = employees[left].Name;
            while (true)
            {
                while (employees[left].Name < pivot)
                    left++;

                while (employees[right].Name > pivot)
                    right--;

                if (left < right)
                {
                    Employee temp = employees[right];
                    employees[right] = employees[left];
                    employees[left] = temp;
                }
                else
                {
                    return right;
                }
            }
        }

        static public void QuickSort_Recursive(Employee[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                    QuickSort_Recursive(arr, left, pivot - 1);

                if (pivot + 1 < right)
                    QuickSort_Recursive(arr, pivot + 1, right);
            }
        }

    }
}

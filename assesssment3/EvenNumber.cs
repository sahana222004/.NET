using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assesssment3
{
     class EvenNumber
    {
       List<int> A1 = new List<int>();
        List<int> A2 = new List<int>();

         public List<int> StoreEvenNumbers(int N)
        {
            A1.Clear();
            for (int i = 2; i <= N; i += 2)
            {
                A1.Add(i);
            }
            return A1;
        }

        
         public List<int> PrintEvenNumbers()
        {
            A2.Clear();
            foreach (int num in A1)
            {
                A2.Add(num * 2);
            }
            return A2;
        }

        
        public int RetrieveEvenNumber(int N)
        {
            return A1.Contains(N) ? N : 0;
        }
    }
}

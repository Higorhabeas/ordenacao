using System.Diagnostics;
using System;
class Program {
    static void Main(String[] args) {

        //Random random = new Random();
        //int tamanhoVetor = 1000000;

        //int[]vetorAleatorio = new int[tamanhoVetor];

        //for (int i = 0; i < tamanhoVetor; i++){
           // vetorAleatorio[i] = random.Next(1,1000000);
       // }
        
        //foreach (int valor in vetorAleatorio){
          //  Console.WriteLine(valor);
        //}
        //BubbleSort(vetorAleatorio);
        //SelectionSort(vetorAleatorio);
        //InsertionSort(vetorAleatorio);

        //Console.WriteLine("\nVetor ordenado:");
        //for (int i = 0; i < vetorAleatorio.Length; i++)
        //{
            //Console.Write(vetorAleatorio[i] + " ");
        //}

         int[] arr = { 12, 11, 13, 5, 6, 7 };
        Console.WriteLine("Array original:");
        PrintArray(arr);

        Sort(arr, 0, arr.Length - 1);

        Console.WriteLine("Array ordenado:");
        PrintArray(arr);

        Console.ReadLine();
        
    
    }

    static void BubbleSort(int[] v)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        int tamanho = v.Length;
        for (int i = 0; i < tamanho - 1; i++)
        {
            for (int j = 0; j < tamanho - 1 - i; j++)
            {
                if (v[j] > v[j + 1])
                {
                    int temp = v[j];
                    v[j] = v[j + 1];
                    v[j + 1] = temp;
                }
            }
        }
        stopwatch.Stop();
        long tempoDecorridoEmMilissegundos = stopwatch.ElapsedMilliseconds;
        Console.WriteLine("Tempo decorrido: " + tempoDecorridoEmMilissegundos + " milissegundos");
    }

    static void SelectionSort(int[] v2)
    {
        int n = v2.Length;

        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < n; j++)
            {
                if (v2[j] < v2[minIndex])
                {
                    minIndex = j;
                }
            }

            int temp = v2[i];
            v2[i] = v2[minIndex];
            v2[minIndex] = temp;
        }
    }

     static void InsertionSort(int[] v3)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        int n = v3.Length;

        for (int i = 1; i < n; i++)
        {
            int chave = v3[i];
            int j = i - 1;

            // Move os elementos do vetor que são maiores do que a chave
            // para uma posição à frente da sua posição atual
            while (j >= 0 && v3[j] > chave)
            {
                v3[j + 1] = v3[j];
                j--;
            }

            v3[j + 1] = chave;
        }
        stopwatch.Stop();
        long tempoDecorridoEmMilissegundos = stopwatch.ElapsedMilliseconds;
        Console.WriteLine("Tempo decorrido: " + tempoDecorridoEmMilissegundos + " milissegundos");
    }

    public static void Merge(int[] arr, int left, int middle, int right)
    {
        int n1 = middle - left + 1;
        int n2 = right - middle;

        int[] leftArr = new int[n1];
        int[] rightArr = new int[n2];

        for (int i = 0; i < n1; i++)
        {
            leftArr[i] = arr[left + i];
        }

        for (int j = 0; j < n2; j++)
        {
            rightArr[j] = arr[middle + 1 + j];
        }

        int k = left;
        int iIdx = 0, jIdx = 0;

        while (iIdx < n1 && jIdx < n2)
        {
            if (leftArr[iIdx] <= rightArr[jIdx])
            {
                arr[k] = leftArr[iIdx];
                iIdx++;
            }
            else
            {
                arr[k] = rightArr[jIdx];
                jIdx++;
            }
            k++;
        }

        while (iIdx < n1)
        {
            arr[k] = leftArr[iIdx];
            iIdx++;
            k++;
        }

        while (jIdx < n2)
        {
            arr[k] = rightArr[jIdx];
            jIdx++;
            k++;
        }
    }

    public static void Sort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int middle = (left + right) / 2;

            Sort(arr, left, middle);
            Sort(arr, middle + 1, right);

            Merge(arr, left, middle, right);
        }
    }

   

    public static void PrintArray(int[] arr)
    {
        foreach (var num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}
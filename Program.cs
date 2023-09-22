using System.Diagnostics;
class Program {
    static void Main(String[] args) {

        Random random = new Random();
        int tamanhoVetor = 1000000;

        int[]vetorAleatorio = new int[tamanhoVetor];

        for (int i = 0; i < tamanhoVetor; i++){
            vetorAleatorio[i] = random.Next(1,1000000);
        }
        
        //foreach (int valor in vetorAleatorio){
          //  Console.WriteLine(valor);
        //}
        BubbleSort(vetorAleatorio);
        //SelectionSort(vetorAleatorio);
        //InsertionSort(vetorAleatorio);

        //Console.WriteLine("\nVetor ordenado:");
        //for (int i = 0; i < vetorAleatorio.Length; i++)
        //{
            //Console.Write(vetorAleatorio[i] + " ");
        //}

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
}
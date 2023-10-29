using System.Diagnostics;
using System;
class Program {
    static void Main(String[] args) {

       Random random = new Random();
        int tamanhoVetor = 50000;

        int[]vetorAleatorio = new int[tamanhoVetor];

       for (int i = 0; i < tamanhoVetor; i++){
           vetorAleatorio[i] = random.Next(1,5000);
      }

       // tempo para vetor do tamanho 500: 0 milissegundos
        // tempo para vetor do tamanho 1000: 0 milissegundos 
        // tempo para vetor do tamanho 5000: 0 milissegundos 
        // tempo para vetor do tamanho 100000: 1 milissegundos   
        // tempo para vetor do tamanho 5000000: 56 milissegundos     

        //foreach (int valor in vetorAleatorio){
          //  Console.WriteLine(valor);
        //}
        //BubbleSort(vetorAleatorio);
        SelectionSort(vetorAleatorio);
        //InsertionSort(vetorAleatorio);

        //Console.WriteLine("\nVetor ordenado:");
        //for (int i = 0; i < vetorAleatorio.Length; i++)
        //{
            //Console.Write(vetorAleatorio[i] + " ");
        //}

        //int[]  vetorAleatorio= { 3,6,1,2,3,6,4,2,3,1};
        //Console.WriteLine("vetor original:");
        //Printvetor(vetorAleatorio);

        Sort(vetorAleatorio, 0, vetorAleatorio.Length - 1);// chamada para Mergesort

        //Console.WriteLine("vetor ordenado:");
        //Printvetor(vetor);


        
        //ContOrdena(vetorAleatorio);
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
            int menorValorIndex = i;

            for (int j = i + 1; j < n; j++)
            {
                if (v2[j] < v2[menorValorIndex])
                {
                    menorValorIndex = j;
                }
            }

            int temp = v2[i];
            v2[i] = v2[menorValorIndex];
            v2[menorValorIndex] = temp;
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

    public static void Merge(int[] vetor, int esquerda, int meio, int direita){
        int n1 = meio - esquerda + 1; //determenorValora o tamanho do subvetor
        int n2 = direita - meio; //determenorValora o tamanho do subvetor

        int[] esquerdavetor = new int[n1];
        int[] direitavetor = new int[n2];

        for (int i = 0; i < n1; i++){ //preenche o vetor a esquerda

            esquerdavetor[i] = vetor[esquerda + i];
        }

        for (int j = 0; j < n2; j++){ //preenche o vetor a direita

            direitavetor[j] = vetor[meio + 1 + j];
        }

        int k = esquerda; //inicia o k com a posição inicio da esquerda
        int iIdx = 0, jIdx = 0;

        while (iIdx < n1 && jIdx < n2){
            //compara o top da pilha da esquerda e da direita e ordena
            if (esquerdavetor[iIdx] <= direitavetor[jIdx]){

                vetor[k] = esquerdavetor[iIdx];
                iIdx++;
            }
            else{

                vetor[k] = direitavetor[jIdx];
                jIdx++;
            }
            k++;
        }

        // preenche com os demais elementos que sobraram na esquerda
        while (iIdx < n1){

            vetor[k] = esquerdavetor[iIdx];
            iIdx++;
            k++;
        }

        //preeche com os demais elementos que sobraram na direita
        while (jIdx < n2){

            vetor[k] = direitavetor[jIdx];
            jIdx++;
            k++;
        }
        Printvetor(vetor);
    }

    public static void Sort(int[] vetor, int esquerda, int direita){

        if (esquerda < direita){

            int meio = (esquerda + direita) / 2;

            Sort(vetor, esquerda, meio);
            Sort(vetor, meio + 1, direita);

            Merge(vetor, esquerda, meio, direita);
        }
    }

   

    public static void Printvetor(int[] vetor)
    {
        foreach (var num in vetor)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }

    static void ContOrdena(int[] vetor)
    {
         Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        int maiorValor = vetor[0];
        int menorValor = vetor[0];

        // Encontra o valor máximo e mínimo no vetor
        for (int i = 1; i < vetor.Length; i++)
        {
            if (vetor[i] > maiorValor)
                maiorValor = vetor[i];
            if (vetor[i] < menorValor)
                menorValor = vetor[i];
        }

        int intervalo = maiorValor - menorValor + 1;

        // Cria um vetor de contagem
        int[] vetorCont = new int[intervalo];
        int[] vetorSaida = new int[vetor.Length];

        // Inicializa o vetor de contagem
        for (int i = 0; i < intervalo; i++)
        {
            vetorCont[i] = 0;
        }

        // Preenche o vetor de contagem
        for (int i = 0; i < vetor.Length; i++)
        {
            vetorCont[vetor[i] - 1]++;
        }
        // Cria o vetor de posição
        int[] vetorPos = new int[intervalo];
        // Preenche as posições coforme posições anteriores
        for (int i = 1; i < intervalo; i++)
        {
            vetorPos[i] = vetorPos[i - 1] + vetorCont[i - 1];
        }

        
        // Posiciona o elemento do vetor original no vetor saida conferme o vetor posição e soma 1 na posição
        for (int h = 0; h < vetor.Length; h++){
            vetorSaida[vetorPos[vetor[h]- 1]] = vetor[h]; 
            vetorPos[vetor[h]-1]++;
        }

       
        for (int i = 0; i < vetor.Length; i++)
        {
            vetor[i] = vetorSaida[i];
        }

         stopwatch.Stop();
        long tempoDecorridoEmMilissegundos = stopwatch.ElapsedMilliseconds;
        Console.WriteLine("Tempo decorrido: " + tempoDecorridoEmMilissegundos + " milissegundos");

        Console.WriteLine("vetor ordenado:");
        Printvetor(vetorSaida);
    }


}
﻿using System.Diagnostics;
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

         int[] vetor = { 12, 11, 13, 5, 6, 7 };
        Console.WriteLine("vetor original:");
        Printvetor(vetor);

        Sort(vetor, 0, vetor.Length - 1);

        Console.WriteLine("vetor ordenado:");
        Printvetor(vetor);

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

    public static void Merge(int[] vetor, int esquerda, int meio, int direita){
        int n1 = meio - esquerda + 1; //determina o tamanho do subvetor
        int n2 = direita - meio; //determina o tamanho do subvetor

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

    public static void OrdenaCont(int[]vetor){
        
        int maiorValor =0;
        for (int i = 0; i < vetor.Length; i++){

            if(maiorValor < vetor[i]){

                maiorValor=vetor[i];
            }
        }

        int[] vetorAux = new int[maiorValor];

        for (int l = 0; l < vetor.Length; l++){
            vetorAux[vetor[l]] += 1; 
        }

        int[] vetorPosicao = new int[vetorAux.Length];

        for (int j = 0; j < vetor.Length; j++){
                        
        }
    }


}
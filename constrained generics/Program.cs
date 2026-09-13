using constrained_generics.Entities;
using constrained_generics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace constrained_generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Cria a lista vazia que vai armazenar os objetos do tipo Product.
            List<Product> list = new List<Product>();

            // Solicita ao usuário a quantidade de produtos que serão digitados.
            Console.Write("Enter N ");
            int n = int.Parse(Console.ReadLine());

            // Loop para ler a entrada de cada um dos 'n' produtos.
            for (int i = 0; i < n; i++)
            {
                // Lê a linha digitada no formato "Nome, Preço" (ex: TV, 900.00) e divide pela vírgula.
                string[] vect = Console.ReadLine().Split(',');

                string name = vect[0];

                // Converte o texto do preço para double usando CultureInfo.InvariantCulture
                // para aceitar o ponto (.) como separador decimal, independentemente da região da máquina.
                double price = double.Parse(vect[1], CultureInfo.InvariantCulture);

                // Instancia um novo produto com os dados lidos e adiciona à lista.
                list.Add(new Product(name, price));
            }

            // Instancia o serviço que contém a operação genérica de busca por valor máximo.
            CalculationService calculationService = new CalculationService();

            // Chama o método Max passando a lista de produtos.
            // O C# infere automaticamente que 'T' é do tipo 'Product' porque Product implementa IComparable.
            Product max = calculationService.Max(list);

            // Exibe o produto mais caro encontrado.
            // Ao passar a variável 'max' dentro do WriteLine, o C# chama automaticamente o método max.ToString().
            Console.WriteLine("Max:");
            Console.WriteLine(max);


            Console.ReadLine();
        }
    }
}
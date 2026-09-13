using System;
using System.Globalization;

namespace constrained_generics.Entities
{
    // A classe Product implementa a interface IComparable.
    // Isso permite que objetos do tipo Product sejam comparados entre si 
    // e usados em métodos genéricos que exigem a restrição "where T : IComparable".
    internal class Product : IComparable
    {
        public string Name { get; set; }
        public double Price { get; set; }

        // Construtor para inicializar as propriedades da classe.
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        // Sobrescreve o método ToString para formatar a exibição do produto.
        // Usa CultureInfo.InvariantCulture para garantir que o preço seja formatado com ponto decimal.
        public override string ToString()
        {
            return Name
                + ", "
                + Price.ToString("F2", CultureInfo.InvariantCulture);
        }

        // Implementação obrigatória da interface IComparable.
        // Define a regra de comparação entre dois produtos (neste caso, com base no preço).
        public int CompareTo(object obj)
        {
            // Validação de tipo (defesa de código): garante que o objeto recebido seja do tipo Product.
            if (!(obj is Product))
            {
                throw new ArgumentException("Comparing erro: argument is not a product");
            }

            // Realiza o "cast" explícito e seguro do objeto genérico para a classe Product.
            Product other = obj as Product;

            // Delega a comparação para o tipo double da propriedade Price.
            // Retorna:
            //   > 0  -> Se este preço for maior que o preço do 'other'
            //  == 0  -> Se os preços forem iguais
            //   < 0  -> Se este preço for menor que o preço do 'other'
            return Price.CompareTo(other.Price);
        }
    }
}
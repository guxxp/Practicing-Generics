using System;
using System.Collections.Generic;

namespace constrained_generics.Services
{
    // Classe de serviço responsável por realizar cálculos genéricos.
    internal class CalculationService
    {
        // Encontra e retorna o maior elemento de uma lista genérica.
        // 
        // A restrição "where T : IComparable" garante que o tipo T implemente a 
        // interface IComparable. Isso obriga que os objetos passados tenham o método 
        // CompareTo(), permitindo a comparação física entre eles (ex: números, strings, classes customizadas).
        public T Max<T>(List<T> list) where T : IComparable
        {
            // Validação de segurança: lança uma exceção se a lista estiver vazia,
            // pois não é possível determinar o maior valor de uma coleção sem elementos.
            if (list.Count == 0)
            {
                throw new ArgumentException("The list can not be empty");
            }

            // Define o primeiro elemento da lista como o valor máximo inicial para comparação.
            T max = list[0];

            // Percorre a lista a partir do segundo elemento (índice 1).
            for (int i = 1; i < list.Count; i++)
            {
                // O método CompareTo retorna:
                //   > 0 : Se list[i] for MAIOR que max.
                //  == 0 : Se list[i] for IGUAL a max.
                //   < 0 : Se list[i] for MENOR que max.
                if (list[i].CompareTo(max) > 0)
                {
                    // Atualiza a variável 'max' caso um elemento maior seja encontrado.
                    max = list[i];
                }
            }

            // Retorna o maior elemento encontrado após verificar toda a lista.
            return max;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace example_with_Generics.Entities
{
    // Classe genérica que armazena até 10 elementos do tipo T.
    // Uso típico: criar uma instância, adicionar elementos, imprimir ou obter o primeiro.
    internal class PrintService<T>
    {
        // Array interno com capacidade fixa de 10 elementos.
        private T[] _value = new T[10];
        // Contador de elementos atualmente armazenados no array.
        private int _count = 0;

        // Adiciona um valor ao serviço.
        // Lança InvalidOperationException se a capacidade máxima for atingida.
        public void AddValue(T value)
        {
            if (_count == 10) throw new InvalidOperationException("PrintService is full");
            _value[_count] = value;
            _count++;
        }

        // Retorna o primeiro elemento armazenado.
        // Lança InvalidOperationException se nenhum elemento estiver presente.
        public T First()
        {
            if (_count == 0) throw new InvalidOperationException("PrintService is empty");
            return _value[0];

        }

        // Imprime todos os elementos no formato [a,b,c].
        // Evita vírgula após o último elemento.
        public void Print()
        {
            Console.Write("[");
            for (int i = 0; i < _count - 1; i++)
            {
                // Para todos, exceto o último, imprime o valor seguido de vírgula.
                Console.Write(_value[i] + ",");
            }
            if (_count > 0)
            {
                // Imprime o último (ou único) elemento sem vírgula final.
                Console.Write(_value[_count - 1]);

            }
            Console.Write("] ");


        }

    }
}

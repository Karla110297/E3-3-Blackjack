using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_3_Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Blackjack J1 = new Blackjack();// classe blackjack
            Stack<string> Baraja = new Stack<string>();//crea la pila vacia

            Baraja = J1.InsertarCartas();//llama a la función para insertar los elementos que existen en una baraja normal
            

            J1.Jugar(Baraja);//empieza el juego
           
           

           
            Console.ReadKey();
        }

    }
}

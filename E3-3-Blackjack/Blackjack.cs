using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E3_3_Blackjack
{
    class Blackjack
    {
        public Blackjack() { }//constructor


        public Stack<string> InsertarCartas()//metodo
        {
            Stack<string> Cartas = new Stack<string>();//crea un stack

            string[] figura = { "Corazones", "Trevoles", "Diamantes", "Espadas" };

            //el sig. for llena el stack

            for (int j = 0; j < 4; j++)//para cambiar el tipo de figura de las letras o numeros a agregar
            {
                for (int i = 0; i < 12; i++)//para agregar ya sea la letra o el numero
                {
                    if (i == 0)
                    {
                        Cartas.Push("A " + figura[j]);
                    }
                    else if (i == 9)
                    {
                        Cartas.Push("J " + figura[j]);
                    }
                    else if (i == 10)
                    {
                        Cartas.Push("Q " + figura[j]);
                    }
                    else if (i == 11)
                    {
                        Cartas.Push("K " + figura[j]);
                    }
                    else
                    {
                        Cartas.Push(Convert.ToString(i + 1) + " " + figura[j]);
                    }

                }
            }

            return Cartas;//Regresa la pila ya llenada

        }

        public Stack<string> MezclaCartas(Stack<string> Pila)//metodo para revolver los elementos de la pila
        {

            String[] arreglo = Pila.ToArray(); //pasa la pila a un arreglo

            Pila.Clear();//limpia pila
            Random r = new Random();


            for (int i = 0; i < arreglo.Length; i++)//para agregar elemento de arreglo a la pila de forma aleatoria
            {
                int x = r.Next(0, arreglo.Length);

                while (Pila.Contains(arreglo[x]))//Si el elemento ya esta en la pila se repite el ciclo hasta agragar un elemento diferente del arreglo a la pila
                {

                    x = r.Next(0, arreglo.Length);

                }

                Pila.Push(arreglo[x]);//inserta el elemento

            }

            return Pila;//Regresa la pila ya llenada

        }

        public int ValorCarta(string carta)//metodo para asignarle valor a una carta
        {

            string[] figura = { "Corazones", "Trevoles", "Diamantes", "Espadas" };

            for (int j = 0; j < 4; j++)//para cambiar el tipo de figura 
            {
                for (int i = 0; i < 12; i++)//para agregar cambiar el numero
                {
                    //los if siguientes son condicionales de igualdad con los que si el valor es igual se da un determinado valor a la carta
                    if (carta == (Convert.ToString(i) + " " + figura[j]))
                    {
                        return Convert.ToInt32(i);
                    }
                    else if (carta == ("A " + figura[j]))
                    {
                        Console.WriteLine("El valor de A quiere que sea 1 o 11");//pide a usuario a elegir el valor de A que prefiera
                        string x = Console.ReadLine();
                        switch (x)
                        {

                            case "1":
                                return 1;
                               
                            case "11":
                                return 11;
                               
                            default:
                                break;
                        }
                    }
                    else if (carta == ("J " + figura[j]) || carta == ("Q " + figura[j]) || carta == ("K " + figura[j]))
                    {
                        return 10;
                    }


                }

            }


            return 0;

        }
        
        public void Jugar(Stack<string> Baraja) { 

        int suma = 0;//variable para totalidad de puntos acumulados
        int puntos = 0;//variable para la asignacion de valor de la carta

        int cont = 0;//contador del qhile que indica los intentos que lleva el usuario

            while (cont< 5 &&  suma<21)//maximo 5 intentos es decir maximo 5 cartas y que la suma sea menor a 21
            {
                Console.WriteLine("Presiona una tecla para seleccionar una carta");//selecciona la carta 

                Console.ReadKey();
                
                    Baraja = MezclaCartas(Baraja);//llama a mezclar la baraja

                    string cartaTomada = Baraja.Peek();//ultima carta del stack
                    puntos = ValorCarta(cartaTomada);
                
                
                    Console.WriteLine(cartaTomada+ " vale {0} puntos",puntos );// da a usuario a conocer la carta que le toco y su valor

                    suma +=puntos;
                    Console.WriteLine( "En total llevas {0} puntos", suma);// da a conocer la totalidad de puntos que lleva

                    Baraja.Pop();// se elimina la carta tomada de la pila de baraja
                

                cont++;

                if (suma == 21)
                {
                    Console.WriteLine("Has ganado");//si es igual a 21 le dice que ha ganado
                }else if (suma > 21||cont==5)
                {
                    Console.WriteLine("Has perdido");// si ya ha hecho los 5 intentos o se ha pasado de 21 puntos se indica que ha perdido el juego
                }
                Console.WriteLine();
            }
        }






    }

}




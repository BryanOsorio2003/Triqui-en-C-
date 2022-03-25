using System;

namespace Triqui
{
    class Program
    {
        static void Main(string[] args)

        {
            Random rand = new Random();
            char[][] tictactoe = new char[][] { new char[] { ' ', ' ', ' ' }, new char[] { ' ', ' ', ' ' }, new char[] { ' ', ' ', ' ' } };
            char ganador = ' ';
            bool juega_cpu = rand.Next(2) == 1;
            int i, j, turnos;
            for (turnos = 0; turnos < 9 && ganador != 'O' && ganador != 'X'; turnos++)
            {
                if (juega_cpu)
                {
                    do
                    {
                        i = rand.Next(3);
                        j = rand.Next(3);
                    } while (tictactoe[i][j] != ' ');
                    tictactoe[i][j] = 'O';
                }
                else
                {
                    imprimirCuadricula(tictactoe);
                    do
                    {
                        i = leerNumero("rengl\u00F3n");
                        j = leerNumero("columna");
                        if (tictactoe[i][j] != ' ')
                            Console.WriteLine("La casilla seleccionada ya est\u00E1 ocupada.\n");
                    } while (tictactoe[i][j] != ' ');
                    tictactoe[i][j] = 'X';
                }
                for (i = 0; ganador == ' ' && i < 3; i++)
                    if (tictactoe[i][0] != ' ' && tictactoe[i][0] == tictactoe[i][1] && tictactoe[i][1] == tictactoe[i][2])
                        ganador = tictactoe[i][0];
                for (i = 0; ganador == ' ' && i < 3; i++)
                    if (tictactoe[0][i] != ' ' && tictactoe[0][i] == tictactoe[1][i] && tictactoe[1][i] == tictactoe[2][i])
                        ganador = tictactoe[0][i];
                if (ganador == ' ' && tictactoe[0][0] != ' ' && tictactoe[0][0] == tictactoe[1][1] && tictactoe[1][1] == tictactoe[2][2])
                    ganador = tictactoe[0][0];
                if (ganador == ' ' && tictactoe[0][2] != ' ' && tictactoe[0][2] == tictactoe[1][1] && tictactoe[1][1] == tictactoe[2][0])
                    ganador = tictactoe[0][2];
                juega_cpu = !juega_cpu;
            }
            imprimirCuadricula(tictactoe);
            switch (ganador)
            {
                case 'O': Console.WriteLine("La computadora ha ganado."); break;
                case 'X': Console.WriteLine("Felicitaciones! has ganado."); break;
                case ' ': Console.WriteLine("Empate."); break;
            }
            Console.Write("\nPresione una tecla para terminar . . . ");
            Console.ReadKey();
        }

        static void imprimirCuadricula(char[][] tictactoe)
        {
            int i, j;
            Console.Clear();
            Console.WriteLine("      \u2554{0}{0}{0}{1}{0}{0}{0}{1}{0}{0}{0}\u2557", '\u2550', '\u2566');
            Console.WriteLine("      {0} 1 {0} 2 {0} 3 {0}", '\u2551');
            Console.WriteLine("      \u255A{0}{0}{0}{1}{0}{0}{0}{1}{0}{0}{0}\u255D", '\u2550', '\u2569');
            Console.WriteLine();
            Console.WriteLine("{1}{0}{3}   {1}{0}{0}{0}{2}{0}{0}{0}{2}{0}{0}{0}{3}", '\u2550', '\u2554', '\u2566', '\u2557');
            for (i = 0; i < tictactoe.Length; i++)
            {
                if (i != 0)
                    Console.WriteLine("{1}{0}{3}   {1}{0}{0}{0}{2}{0}{0}{0}{2}{0}{0}{0}{3}", '\u2550', '\u2560', '\u256C', '\u2563');
                Console.Write("{0}{1}{0}   {0}", '\u2551', i + 1);
                for (j = 0; j < tictactoe[i].Length; j++)
                    Console.Write(" " + tictactoe[i][j] + " \u2551");
                Console.WriteLine();
            }
            Console.WriteLine("{1}{0}{3}   {1}{0}{0}{0}{2}{0}{0}{0}{2}{0}{0}{0}{3}\n", '\u2550', '\u255A', '\u2569', '\u255D');
        }

        static int leerNumero(String variable)
        {
            char tecla;
            Console.Write("Seleccione el n\u00FAmero de " + variable + ": ");
            do
                tecla = Console.ReadKey(true).KeyChar;
            while (tecla != '1' && tecla != '2' && tecla != '3');
            Console.WriteLine(tecla);
            return tecla - '0' - 1;


        }
    }
}

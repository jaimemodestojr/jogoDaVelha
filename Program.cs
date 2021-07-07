using System;
using System.Threading;

namespace jogoDaVelha
{
    class Program

    {
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int jogador = 1;     // O jogador 1 é o padrão, isto é, ele sempre começa e, segundo as regras do jogo, é o O
        static int escolha;
        static int juiz = 0; /* O juiz decide se o jogo está ainda rodando (quando é 0),
                              se algum dos jogadores ganhou (quando é 1) e se deu velha (empate, quando é -1) */
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();

                Console.WriteLine("Bem-vindo ao Jogo da Velha! \n" +
                "Jogador 1: O VS Jogador 2: X \n");

                if (jogador % 2 == 0)
                {
                    Console.WriteLine("Tentativa do jogador 2: \n");
                }
                else
                {
                    Console.WriteLine("Tentativa do jogador 1: \n");
                }

                tabuleiro();

                escolha = int.Parse(Console.ReadLine());

                if (arr[escolha] != 'O' && arr[escolha] != 'X')
                {
                    if (jogador % 2 == 0)
                    {
                        arr[escolha] = 'X';
                        jogador++;
                    }

                    else
                    {
                        arr[escolha] = 'O';
                        jogador++;
                    }
                }

                else
                {
                    Console.WriteLine("Jogada inválida, por favor, espere o tabuleiro ser recarregado: \n");
                    Thread.Sleep(2000);
                }

                juiz = ChecagemGanhador();

            } while (juiz != 1 && juiz != -1);

            Console.Clear(); /* Cheguei a essa lógica no jogo da velha, e concluí que ela poderia ser 
                              aplicada também no meu Menu CRUD, gerando uma tela de execução mais limpa */
            tabuleiro(); // Chama o tabuleiro

            if (juiz == 1)
            {
                Console.WriteLine("O Jogador {0} venceu!", (jogador % 2) + 1);
            }

            else 
            {
                Console.WriteLine("Deu velha!");
            }

            Console.ReadLine();
        }

        private static void tabuleiro()

        {

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);

            Console.WriteLine("_____|_____|_____ ");

            Console.WriteLine("     |     |      ");

            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);

            Console.WriteLine("     |     |      ");

        }

        private static int ChecagemGanhador()
        {
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }

            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }

            else if (arr[6] == arr[7] && arr[7] == arr[8])
            {
                return 1;
            }

            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }

            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }

            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }

            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }

            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }

            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }

            {
                return 0;
            }

        }

    }

}

/* Sugestões de melhoria posteriores:
 - Não precisar preencher o tabuleiro com números de 1 a 9;
 - Reexecutar o jogo, ao final de cada partida, quando for afirmativa a resposta para a pergunta "Deseja jogar novamente?";
 - Adicionar um modo de jogo vs a máquina, com uma I.A., mesmo que seja uma I.A. simples. */
 
using System;
using System.Collections.Generic;

namespace Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();

        static void Main(string[] args)
        {
            string opcaoUsuario;
            do
            {
                opcaoUsuario = ObterOpcaoUsuario();

                switch ( opcaoUsuario)
                {
                    /// TODO: Listar
                    case "1":
                        ListarContas();
                        break;
                    /// TODO: Nova Conta
                    case "2":
                        InserirConta();
                        break;
                    /// TODO: Tranferir
                    case "3":
                        Tranferir();
                        break;
                    /// TODO: Sacar
                    case "4":
                        Sacar();
                        break;
                    /// TODO: Depositar
                    case "5":
                        Depositar();
                        break;
                    /// TODO: Limpa Tela
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine( "Opção inezistente!" );
                        return;
                }

            } while ( !opcaoUsuario.Equals("X") );
        }

        private static void Tranferir ()
        {
            Console.WriteLine( "\nDigite o identificador da sua conta:" );
            int.TryParse( Console.ReadLine() , out int indiceContaSacar );

            Console.WriteLine( "\nDigite o valor a ser depositado: " );
            double.TryParse( Console.ReadLine() , out double valor );

            Console.WriteLine( "\nDigite o identificador da conta destino:" );
            int.TryParse( Console.ReadLine() , out int indiceContaDestino );

            listContas [ indiceContaSacar ].Transferir( valor,  listContas [ indiceContaDestino ]);
        }

        private static void Depositar ()
        {
            Console.WriteLine( "\nDigite o identificador da conta:" );
            int.TryParse( Console.ReadLine() , out int indiceConta );

            Console.WriteLine( "\nDigite o valor a ser depositado: " );
            double.TryParse( Console.ReadLine() , out double valor );

            listContas [ indiceConta ].Depositar( valor );
        }

        private static void Sacar ()
        {
            Console.WriteLine( "\nDigite o identificador da conta:" );
            int.TryParse( Console.ReadLine() , out int indiceConta );

            Console.WriteLine( "\nDigite o valor a ser sacado: " );
            double.TryParse( Console.ReadLine() , out double valor );

            listContas [ indiceConta ].Sacar( valor );
        }

        private static void ListarContas ()
        {
            if ( listContas.Count > 0 )
            {
                foreach ( Conta list in listContas )
                {
                    Console.WriteLine( $"\n Identificador: {listContas.IndexOf(list)} da Conta \n {list}" );
                }
                return;
            }
            else Console.WriteLine( "Nenhuma conta cadastrada!" );
        }

        private static void InserirConta ()
        {
            Console.WriteLine( "\nDigite 1 para conta Fisica ou 2 para Juridica:" );
            int.TryParse( Console.ReadLine() , out int entradatipoConta );

            Console.WriteLine( "\nDigite o Nome do cliente:" );
            string entradaNome = Console.ReadLine();

            Console.WriteLine( "\nDigite o Saldo inicial:" );
            double.TryParse( Console.ReadLine() , out double entradaSaldo );

            Console.WriteLine( "\nDigite o Credito inicial:" );
            double.TryParse( Console.ReadLine() , out double entradaCredito );

            Conta novaConta = new Conta( 
                TipoConta: ( Enum.TipoConta ) entradatipoConta,
                Nome: entradaNome,
                Saldo: entradaSaldo, 
                Credito: entradaCredito 
                );

            listContas.Add( novaConta );
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine( "\nBank - online ..." );
            Console.WriteLine( "Informe a opção desejada:" );
            Console.WriteLine( "1 - Listar contas" );
            Console.WriteLine( "2 - Inserir nova conta" );
            Console.WriteLine( "3 - Transferir" );
            Console.WriteLine( "4 - Sacar" );
            Console.WriteLine( "5 - Depositar" );
            Console.WriteLine( "C - Limpar Tela" );
            Console.WriteLine( "X - Sair \n" );

            return Console.ReadLine().ToUpper();
        }
    }
}

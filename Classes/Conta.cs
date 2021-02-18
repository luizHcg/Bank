using Bank.Enum;
using System;

namespace Bank
{
    class Conta
    {
        public Conta (TipoConta TipoConta, string Nome, double Saldo, double Credito)
        {
            this.TipoConta = TipoConta;
            this.Nome = Nome;
            this.Saldo = Saldo;
            this.Credito = Credito;
        }

        private TipoConta TipoConta {get;set;}
        private string Nome { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }

        public bool Sacar (double valorSaque)
        {
            bool saldo = ( this.Saldo - valorSaque ) < (this.Credito * -1);

            if ( saldo ) { Console.WriteLine( "Saldo insuficiente!" ); 
                return false; 
            };

            this.Saldo -= valorSaque;
            Console.WriteLine( $"Saldo atual da conta de {this.Nome} é {this.Saldo}" );
            return saldo;
        }

        public void Depositar( double valorDeposito )
        {
            this.Saldo += valorDeposito;
            Console.WriteLine( $"Saldo atual da conta de {this.Nome} é {this.Saldo}" );

        }

        public void Transferir ( double valorTransferencia, Conta contaDestino)
        {
            if (Sacar(valorTransferencia))
            {
                contaDestino.Depositar( valorTransferencia );
            }
        }

        public override string ToString ()
        {
            return $"TipoConta: {this.TipoConta} \n Nome: {this.Nome} \n Saldo: {this.Saldo} \n Credito: {this.Credito}";
        }
    }
}

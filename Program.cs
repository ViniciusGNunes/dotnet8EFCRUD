using dotnet8EFCRUD.Data;
using dotnet8EFCRUD.Services;
using Microsoft.Identity.Client;
using System;

namespace dotnet8EFCRUD{
    public class Program{
        public static void Main(String[] args){
            try{

            var context = new ProjectDataContext();

            bool breaker = true;

            do{
            Console.WriteLine("Selecione uma tabela: ");
            Console.WriteLine("1 - Funcionario");
            Console.WriteLine("2 - Produto");
            Console.Write("Resposta: ");
            int opt1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch(opt1){
                case 0:
                    breaker = false;
                    break;
                case 1:
                    FuncionarioService.Seletor(context, breaker);
                    break;
                case 2:
                    ProdutoService.Seletor(context, breaker);
                    break;
                default:
                    break;
            }
            }while(breaker);
            }catch(FormatException e)
            {
                Console.WriteLine($"Entrada inválida: {e.Message}");
            }
        }
    }
}

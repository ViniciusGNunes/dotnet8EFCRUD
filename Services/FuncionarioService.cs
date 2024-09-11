using dotnet8EFCRUD.Data;
using dotnet8EFCRUD.Models;
using Microsoft.IdentityModel.Tokens;

namespace dotnet8EFCRUD.Services{
    public static class FuncionarioService{

        public static void Seletor(ProjectDataContext context, bool breaker){
            Console.WriteLine("Selecione o que fazer: ");
            Console.WriteLine("1 - Criar novo item");
            Console.WriteLine("2 - Listar Item específico");
            Console.WriteLine("3 - Listar Itens");
            Console.WriteLine("4 - Alterar item");
            Console.WriteLine("5 - Deletar item");
            Console.Write("Resposta: ");
            int opt2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

                switch(opt2){
                case 0:
                    breaker = false;
                    break;
                case 1:
                    CreateFuncionario(context);
                    break;
                case 2:
                    ReadOneUser(context);
                    break;
                case 3:
                    ReadUsers(context);
                    break;
                case 4:
                    UpdateFuncionario(context);
                    break;
                case 5:
                    DeleteEmployee(context);
                    break;
                default:
                    break;
            }
        }

            // Create
            public static void CreateFuncionario(ProjectDataContext context){

            var Func = new Funcionario();

            Console.Write("Insira o nome do novo Funcionário: ");
            string nome = Console.ReadLine()!;

            Console.Write("Insira a idade do novo Funcionário: ");
            int idade = Convert.ToInt32(Console.ReadLine());

            Console.Write("Insira o Salário do novo Funcionário: ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());

            Func.Name = nome;
            Func.Idade = idade;
            Func.Salary = salary;

            context.Funcionarios.Add(Func);
            context.SaveChanges();

            Console.WriteLine();
            Console.WriteLine("Funcionário Criado!\n");
        }

        // Read 

        public static void ReadOneUser(ProjectDataContext context){

            Console.Write("Insira o Id do funcionário que deseja ler: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Funcionario func = context.Funcionarios.FirstOrDefault(x=>x.Id == id)!;
            if(func == null){
                Console.WriteLine("Esse funcionário não existe");
            }
            else{
            ReadUser(func);
            }
        }

        public static void ReadUsers(ProjectDataContext context){
            var funcionarios = context.Funcionarios.ToList();

            if(funcionarios.IsNullOrEmpty()){
                Console.WriteLine("Não existem funcionários");
            }
            else{
                foreach(var func in funcionarios){
                    ReadUser(func);
                }
            }
        }

        public static void ReadUser(Funcionario func){
            Console.WriteLine($"Id: {func.Id}");
            Console.WriteLine($"Nome: {func.Name}");
            Console.WriteLine($"Idade: {func.Idade}");
            Console.WriteLine($"Salario: {func.Salary}\n");
        }

        // Update

        public static void UpdateFuncionario(ProjectDataContext context){
            Console.Write("Insira o ID do funcionário que você deseja alterar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Funcionario func = context.Funcionarios.FirstOrDefault(x => x.Id == id)!;

            Console.Write("Qual o novo nome do funcionário: ");
            string name = Console.ReadLine();
            Console.Write("Insira o novo salário do funcionário: ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());

            func.Name = name;
            func.Salary = salary;

            context.Funcionarios.Update(func);

            context.SaveChanges();

            func = context.Funcionarios.FirstOrDefault(x=> x.Id == id);
            Console.WriteLine("\nInformações do Funcionário: ");

            ReadUser(func!);
        }

        // Delete

        public static void DeleteEmployee(ProjectDataContext context){
            Console.Write("Insira o Id do funcionário a ser deletado: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var func = context.Funcionarios.FirstOrDefault(x => x.Id == id);
            if (func == null){
                Console.WriteLine("\nEsse funcionário não existe!\n");
            }
            else
            {
                context.Funcionarios.Remove(func);

                Console.WriteLine("\nFuncionário removido!\n");

                context.SaveChanges();
            }
        }
    }
}
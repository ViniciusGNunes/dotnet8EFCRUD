using dotnet8EFCRUD.Data;
using dotnet8EFCRUD.Models;
using Microsoft.IdentityModel.Tokens;

namespace dotnet8EFCRUD{
    public static class ProdutoService{
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
                        CreateProduto(context);
                        break;
                    case 2:
                        ReadOneProduct(context);
                        break;
                    case 3:
                        ReadProducts(context);
                        break;
                    case 4:
                        UpdateProduct(context);
                        break;
                    case 5:
                        DeleteProduto(context);
                        break;
                default:

                    break;
            }
        }

        //Create
        public static void CreateProduto(ProjectDataContext context){
            Console.Write("Insira o Nome do Produto: ");
            string nome = Console.ReadLine();
            Console.Write("Insira o Preço do Produto: ");
            decimal preco = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Insira a quantidade deste produto no estoque: ");
            int qtd = Convert.ToInt32(Console.ReadLine());

            Produto prod = new Produto();
                prod.Name = nome;
                prod.Price = preco;
                prod.QuantityOnStock = qtd;
            
            context.Produtos.Add(prod);
            context.SaveChanges();

            Console.WriteLine();
            Console.WriteLine("Produto Adicionado!\n");
        }

        //Read
        
        public static void ReadOneProduct(ProjectDataContext context){
            Console.Write("Insira o Id do produto que deseja ler: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Produto prod = context.Produtos.FirstOrDefault(x=> x.Id == id);
            if(prod == null){
                Console.WriteLine("Esse Produto não existe.");
            }
            ReadProduct(prod);

        }

        public static void ReadProducts(ProjectDataContext context){
            var produtos = context.Produtos.ToList();

            if(produtos.IsNullOrEmpty()){
                Console.WriteLine("Não existem Produtos catalogados!");
            }
            else{
                foreach(var prod in produtos){
                    ReadProduct(prod);
                }
            }
        }

        public static void ReadProduct(Produto prod){
            Console.WriteLine($"Id: {prod.Id}");
            Console.WriteLine($"Nome: {prod.Name}");
            Console.WriteLine($"Preço: {prod.Price}");
            Console.WriteLine($"Quantidade no estoque: {prod.QuantityOnStock}\n");
        }

        //Update
        public static void UpdateProduct(ProjectDataContext context){
            Console.Write("Insira o ID do produto que você deseja alterar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Produto prod = context.Produtos.FirstOrDefault(x => x.Id == id);

            Console.Write("Insira o novo nome do produto: ");
            string nome = Console.ReadLine();
            Console.Write("Insira o nove preço do produto: ");
            decimal preco = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Insira a quantidade do produto em estoque: ");
            int qtd = Convert.ToInt32(Console.ReadLine());

            prod.Name = nome;
            prod.Price = preco;
            prod.QuantityOnStock = qtd;

            context.Produtos.Update(prod);

            context.SaveChanges();

            prod = context.Produtos.FirstOrDefault(x => x.Id == id);

            Console.WriteLine("\nInformações do Produto: ");

            ReadProduct(prod);
        }

        //Delete
        public static void DeleteProduto(ProjectDataContext context){
            Console.Write("Insira o Id do produto a ser deletado: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var prod = context.Produtos.FirstOrDefault(x => x.Id == id);
            if(prod == null){
                Console.WriteLine("\nEsse produto não está catalogado!\n");
            }
            else{
                context.Produtos.Remove(prod);

                context.SaveChanges();            

                Console.WriteLine("\nProduto removido!\n");
            }
        }
    }
}
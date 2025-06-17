namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        // *IMPLEMENTADO*
        public void AdicionarVeiculo()
        {
            Console.WriteLine("\nDigite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(placa))
            {
                if (veiculos.Any(v => v.ToUpper() == placa.ToUpper()))
                {
                    Console.WriteLine($"Veículo: {placa}, já se encontra estacionado!");
                }
                else
                {
                    veiculos.Add(placa.ToUpper());
                    Console.WriteLine($"Veículo: {placa} foi estacionado com sucesso!");
                }
            }
            else
            {
                Console.WriteLine("Atenção: Dados inválidos, digite novamente!");
            }
        }

        // *IMPLEMENTADO*
        public void AtualizarVeiculo()
        {
            Console.WriteLine("Digite a placa que deseja atualizar!");
            string placaAntiga = Console.ReadLine();

            if (veiculos.Any(v => v.ToUpper() == placaAntiga.ToUpper()))
            {
                Console.WriteLine("Digite a nova placa:");
                string novaPlaca = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(novaPlaca))
                {
                    Console.WriteLine("Atenção: Dados inválidos, digite novamente!");
                    return;
                }
                else
                {
                    int indice = veiculos.FindIndex(v => v.ToUpper() == placaAntiga.ToUpper());
                    veiculos[indice] = novaPlaca.ToUpper();
                    Console.WriteLine($"Veículo: {novaPlaca} atualizado com sucesso!");
                }
            }
            else
            {
                Console.WriteLine("Atenção: Veículo não encontrado!");
            }
        }

        // *IMPLEMENTADO*
        public void RemoverVeiculo()
        {
            Console.WriteLine("\nDigite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = precoInicial + precoPorHora * horas;
                veiculos.Remove(placa.ToUpper());

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        // *IMPLEMENTADO*
        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("\nOs veículos estacionados são:");
                Console.WriteLine("--------------------------------");

                for (int i = 0; i < veiculos.Count; i++)
                {
                    Console.WriteLine($"Posição: {i + 1} = Veículo: {veiculos[i]}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}

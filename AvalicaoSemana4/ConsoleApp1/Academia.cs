namespace pessoa;


    public class Academia
    {
        private List<Treinador> treinadores;
        private List<Cliente> clientes;

        public Academia()
        {
            treinadores = new List<Treinador>();
            clientes = new List<Cliente>();
        }

        public void CadastrarTreinador(Treinador treinador)
        {
            if (!treinadores.Any(t => t.CPF == treinador.CPF || t.CREF == treinador.CREF))
            {
                treinadores.Add(treinador);
            }
            else
            {
                throw new InvalidOperationException("CPF ou CREF já cadastrado para outro treinador.");
            }
        }

        public void CadastrarCliente(Cliente cliente)
        {
            if (!clientes.Any(c => c.CPF == cliente.CPF))
            {
                clientes.Add(cliente);
            }
            else
            {
                throw new InvalidOperationException("CPF já cadastrado para outro cliente.");
            }
        }

        public List<Treinador> ObterTreinadoresPorIdade(int idadeMinima, int idadeMaxima)
        {
            return treinadores.Where(t => t.Idade >= idadeMinima && t.Idade <= idadeMaxima).ToList();
        }

        public List<Cliente> ObterClientesPorIdade(int idadeMinima, int idadeMaxima)
        {
            return clientes.Where(c => c.Idade >= idadeMinima && c.Idade <= idadeMaxima).ToList();
        }

        public List<Cliente> ObterClientesPorIMC(double valorMinimo)
        {
            return clientes.Where(c => c.CalcularIMC() > valorMinimo).OrderBy(c => c.CalcularIMC()).ToList();
        }

        public List<Cliente> ObterClientesOrdemAlfabetica()
        {
            return clientes.OrderBy(c => c.Nome).ToList();
        }

        public List<Cliente> ObterClientesPorIdadeDecrescente()
        {
            return clientes.OrderByDescending(c => c.Idade).ToList();
        }

        public List<Pessoa> ObterAniversariantesDoMes(int mes)
        {
            var aniversariantes = treinadores.Concat<Pessoa>(clientes)
                                            .Where(p => p.DataNascimento.Month == mes)
                                            .ToList();// Validar CPF com 11 dígitos
            return aniversariantes;
        }


    }
    




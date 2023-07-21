using TravelNet.Domain.Enums;
using TravelNet.Domain.Validations;
using TravelNet.Domain.Validations.Interfaces;

namespace TravelNet.Domain.Entities.ProdutoContext
{
    public sealed class Produto : BaseEntity, IContract
    {
        public Produto(DateTime? createAt, DateTime? updateAt, bool ativo, decimal valor, Item item, string descricao, string nome, Guid clienteId)
               : base(createAt, updateAt)
        {
            Ativo = ativo;
            Valor = valor;
            Item = item;
            Descricao = descricao;
            Nome = nome;
            ClienteId = clienteId;
        }

        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public Item Item { get; private set; }
        public string Descricao { get; private set; }
        public string Nome { get; private set; }
        public Guid ClienteId { get; private set; }
        public ICollection<Categoria>? Categorias { get; set; }

        public void Desativar() => Ativo = false;
        public void AlterarItem(Item item) => Item = item;
        public static void AlterarDescricao(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao))
                _ = "Descricao Ivalida";
        }

        public void SetDescricao(string descricao)
        {
            SetDescricao(descricao);
        }

        public override bool Validation()
        {
            var contracts = new ContractValidations<Produto>()
                 .DescriptionIsOk(Descricao, 10, 100, "Descricao deve conter entre 10 e 100 caracterer", "Descricao")
                 .NomeIsOk(Nome, 50, 5, "Nome deve ter entre 5 e 50 caracteres", nameof(Nome));

            return contracts.IsValid();
        }

    }
}

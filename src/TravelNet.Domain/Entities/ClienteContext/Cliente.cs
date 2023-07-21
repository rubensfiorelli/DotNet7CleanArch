using TravelNet.Domain.Entities.ProdutoContext;
using TravelNet.Domain.Validations;

namespace TravelNet.Domain.Entities.ClienteContext
{
    public sealed class Cliente : BaseEntity
    {
        public Cliente(DateTime? createAt, DateTime? updateAt, string nome, string sobrenome,
            DateTime nascimento, string cPF, string email, string whatsApp, string descricao,
            string passaporte) : base(createAt, updateAt)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Nascimento = nascimento;
            CPF = cPF;
            Email = email;
            WhatsApp = whatsApp;
            Descricao = descricao;
            Passaporte = passaporte;
        }

        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public DateTime Nascimento { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public string WhatsApp { get; private set; }
        public string Descricao { get; private set; }
        public string Passaporte { get; private set; }
        public ICollection<Produto>? Produtos { get; set; }

        public void SetDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public override bool Validation()
        {
            var contracts = new ContractValidations<Produto>()
                 .DescriptionIsOk(Descricao, 10, 100, "Descricao deve conter entre 10 e 100 caracterer", nameof(Descricao))
                 .NomeIsOk(Nome, 50, 5, "Nome deve ter entre 5 e 50 caracteres", nameof(Nome))
                 .SobrenomeIsOk(Sobrenome, 50, 6, "Sobrenome deve ter entre 6 e 50 caracteres", nameof(Sobrenome))
                 .PassaporteIsOk(Passaporte, 7, 7, "Passaporte invalido", nameof(Passaporte))
                 .EmailIsValid(Email, "Email nao pode ser em branco ou formato invalido", nameof(Email))
                 .WhatsAppIsOk(WhatsApp, 12, 12, "O numero whatsApp é invalido", nameof(WhatsApp));

            return contracts.IsValid();
        }
    }
}

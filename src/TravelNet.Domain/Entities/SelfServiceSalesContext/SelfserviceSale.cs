using TravelNet.Domain.Entities.ProdutoContext;
using TravelNet.Domain.Enums;

using TravelNet.Domain.Validations;
using TravelNet.Domain.Validations.Interfaces;

namespace TravelNet.Domain.Entities.SelfServiceSalesContext
{
    public sealed class SelfServiceSale : BaseEntity, IContract
    {
        public SelfServiceSale(DateTime? createAt, DateTime? updateAt, string descricao, Guid categoriaId,
            Guid companhiaAereaId, DateTime dataEmissao, Destino destino, DateTime saida, DateTime chegada,
            Guid vooId) : base(createAt, updateAt)
        {
            CategoriaId = categoriaId;
            CompanhiaAereaId = companhiaAereaId;
            DataEmissao = dataEmissao;
            Destino = destino;
            Saida = saida;
            Chegada = chegada;
            VooId = vooId;

        }

        public Guid CategoriaId { get; private set; }
        public Categoria? Categoria { get; set; }
        public Guid CompanhiaAereaId { get; private set; }
        public CompanhiaAerea? CompanhiaAerea { get; set; }
        public string Descricao { get; private set; }
        public DateTime DataEmissao { get; private set; }
        public Destino Destino { get; private set; }
        public DateTime Saida { get; private set; }
        public DateTime Chegada { get; private set; }
        public Guid VooId { get; private set; }


        public static void GuidIsValid(object guid)
        {
            if (guid is not Guid)
                _ = "Id invalido";
        }


        public override bool Validation()
        {
            var contracts = new ContractValidations<Produto>()
               .DescriptionIsOk(Descricao, 10, 100, "Descricao deve conter entre 10 e 100 caracterer", "Descricao")
               .GuidIsValid(Id, "Id nao valido", "ID da Venda");


            return contracts.IsValid();
        }

        public static void UpdateSelfServiceSale(DateTime? createAt, DateTime? updateAt, string descricao, Guid categoriaId,
            Guid companhiaAereaId, DateTime dataEmissao, Destino destino, DateTime saida, DateTime chegada,
            Guid vooId)
        {

        }
    }


}

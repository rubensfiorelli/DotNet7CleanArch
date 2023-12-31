﻿using TravelNet.Domain.Validations;
using TravelNet.Domain.Validations.Interfaces;

namespace TravelNet.Domain.Entities.ProdutoContext
{
    public sealed class Categoria : BaseEntity, IContract
    {
        public Categoria(DateTime? createAt, DateTime? updateAt, string descricao, string nome, Guid produtoId)
            : base(createAt, updateAt)
        {
            Descricao = descricao;
            Nome = nome;
            ProdutoId = produtoId;
        }

        public Guid ProdutoId { get; private set; }
        public string Descricao { get; private set; }
        public string Nome { get; private set; }

        public static void GuidIsValid(object guid)
        {
            if (guid is not Guid)
                _ = "Id invalido";
        }

        public void SetDescricao(string descricao)
        {
            SetDescricao(descricao);
        }


        public override bool Validation()
        {
            var contracts = new ContractValidations<Categoria>()
                 .DescriptionIsOk(Descricao, 10, 100, "Descricao deve conter entre 10 e 100 caracterer", "Descricao")
                 .NomeIsOk(Nome, 50, 5, "Nome deve ter entre 5 e 50 caracteres", nameof(Nome));

            return contracts.IsValid();
        }
    }
}

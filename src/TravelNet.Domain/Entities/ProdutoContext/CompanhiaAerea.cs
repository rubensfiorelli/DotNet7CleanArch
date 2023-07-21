﻿using TravelNet.Domain.Validations;
using TravelNet.Domain.Validations.Interfaces;

namespace TravelNet.Domain.Entities.ProdutoContext
{
    public sealed class CompanhiaAerea : BaseEntity, IContract
    {
        public CompanhiaAerea(DateTime? createAt, DateTime? updateAt, string descricao, string nome, Guid categoriaId, string voo)
               : base(createAt, updateAt, descricao, nome)
        {
            Ativa = true;
            CategoriaId = categoriaId;
            Voo = voo;
        }

        public bool Ativa { get; private set; }
        public string Voo { get; private set; }
        public Guid CategoriaId { get; private set; }
        public Categoria? Categoria { get; set; }

        public void Desativar() => Ativa = false;


        public static void GuidIsValid(object guid)
        {
            if (guid is not Guid)
                _ = "Id invalido";
        }

        public override void SetDescricao(string descricao)
        {
            base.SetDescricao(descricao);
        }

        public static void UpdateCompanhiaAerea(string descricao, string nome, string voo)
        {
            if (string.IsNullOrWhiteSpace(descricao) || string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(voo))
                _ = "Dados invalidos";
        }

        public override bool Validation()
        {
            var contracts = new ContractValidations<CompanhiaAerea>()
                 .DescriptionIsOk(Descricao, 10, 100, "Descricao deve conter entre 10 e 100 caracterer", "Descricao")
                 .NomeIsOk(Nome, 50, 5, "Nome deve ter entre 5 e 50 caracteres", nameof(Nome));

            return contracts.IsValid();
        }
    }
}

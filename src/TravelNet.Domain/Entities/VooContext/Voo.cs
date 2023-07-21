namespace TravelNet.Domain.Entities.VooContext
{
    public sealed class Voo : BaseEntity
    {
        public Voo(DateTime? createAt, DateTime? updateAt, string descricao) : base(createAt, updateAt)
        {
        }

        public override bool Validation()
        {
            throw new NotImplementedException();
        }
    }
}

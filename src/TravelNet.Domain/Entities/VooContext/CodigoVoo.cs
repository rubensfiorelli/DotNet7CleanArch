namespace TravelNet.Domain.Entities.VooContext
{
    public sealed class CodigoVoo : BaseEntity
    {
        public CodigoVoo(DateTime? createAt, DateTime? updateAt, string voo) : base(createAt, updateAt)
        {
            Voo = voo;
        }

        public string Voo { get; private set; }


        public override bool Validation()
        {
            throw new NotImplementedException();
        }
    }
}

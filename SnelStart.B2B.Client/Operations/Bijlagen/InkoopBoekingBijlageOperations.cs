namespace SnelStart.B2B.Client.Operations
{
    internal class InkoopBoekingBijlageOperations : CrudOperationsWithParentBase<InkoopBoekingBijlageContentModel>, IInkoopBoekingBijlageOperations
    {
        public InkoopBoekingBijlageOperations(ClientState clientState)
            : base(clientState, "inkoopboekingen", "bijlagen")
        { }
    }
}
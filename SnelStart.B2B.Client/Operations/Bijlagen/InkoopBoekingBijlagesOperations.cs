namespace SnelStart.B2B.Client.Operations
{
    internal class InkoopBoekingBijlagesOperations : CrudOperationsWithParentBase<InkoopBoekingBijlageContentModel>, IInkoopBoekingBijlagesOperations
    {
        public InkoopBoekingBijlagesOperations(ClientState clientState)
            : base(clientState, "inkoopboekingen", "bijlagen")
        { }
    }
}
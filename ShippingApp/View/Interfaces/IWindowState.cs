namespace ShippingApp.View.Interfaces
{
    interface IWindowState
    {
        /***
        In case you`d like to manage the VISIBILITY of elements RATHER than creating multiple pages(one for admin view, one for employee view)
        */
        bool VisibleForAll { get; }
    }
}

namespace ConcurrencyPatterns.WPF.Models.SingeltonModel;

public class SingletonObjectBadExampleModel : SingletonObjectModel
{
    public override SingletonObjectModel Instance
    {
        get
        {
            RaiseEvent("Entered getter method");
            if (_instance is null)
            {
                RaiseEvent("Instance is null");
                _instance = new SingletonObjectBadExampleModel();
                RaiseEvent("Instance is set");
            }
            RaiseEvent("Instance is get");
            return _instance;
        }
    }
}

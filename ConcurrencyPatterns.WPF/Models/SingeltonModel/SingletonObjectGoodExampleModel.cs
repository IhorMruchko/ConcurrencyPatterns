namespace ConcurrencyPatterns.WPF.Models.SingeltonModel;

public class SingletonObjectGoodExampleModel : SingletonObjectModel
{
    public override SingletonObjectModel Instance
    {
        get
        {
            RaiseEvent("Enter getter method");
            if (_instance is null)
            {
                RaiseEvent("Instance is null");
                lock(this)
                {
                    if (_instance is null)
                    {
                        RaiseEvent("Instance is null under lock");
                        _instance = new SingletonObjectGoodExampleModel();
                        RaiseEvent("Instance is set under lock");
                    }
                }
            }
            RaiseEvent("Instance is get");
            return _instance;
        }
    }
}

namespace ConcurrencyPatterns.WPF.Models.GuardedSuspensionModel;

public class GuardedSuspensionBadExampleModel : GuardedSuspensionObjectModel
{
    public GuardedSuspensionBadExampleModel(int upperLimit) : base(upperLimit)
    {
    }

    public override void Remove()
    {
        while (CurrentAmount <= 0)
        {

        }

        CurrentAmount -= 1;
        RaiseEvent($"Removed. Current amount = {CurrentAmount}");
    }

    public override void Add()
    {
        while (CurrentAmount >= UpperLimit)
        {

        }

        CurrentAmount += 1;
        RaiseEvent($"Added. Current amount = {CurrentAmount}");
    }
}

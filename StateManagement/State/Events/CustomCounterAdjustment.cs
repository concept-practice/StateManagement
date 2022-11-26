namespace StateManagement.State.Events
{
    public class CustomCounterAdjustment : IAction
    {
        public CustomCounterAdjustment(int amount)
        {
            Amount = amount;
        }

        public int Amount { get; }
    }
}

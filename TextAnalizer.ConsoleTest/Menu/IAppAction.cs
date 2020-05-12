namespace TextAnalizer.ConsoleTest.Menu
{
    public interface IAppAction
    {
        public string Name { get; }
        public abstract string GetText();
    }
}

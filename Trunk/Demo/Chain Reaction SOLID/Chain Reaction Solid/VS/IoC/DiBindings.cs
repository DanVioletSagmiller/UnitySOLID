namespace IoC
{
    public class DiBindings : IBindingConfiguration
    {
        public int Order
        {
            get
            {
                return int.MinValue;
            }
        }

        public void Setup()
        {
            Di.Bind<ICleanup>().AsSingleton<Cleanup>();
        }
    }
}

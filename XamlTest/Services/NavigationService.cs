using Microsoft.Practices.ServiceLocation;
using XamlTest.Controls;

namespace XamlTest.Services
{
    class NavigationService
    {
        public void SomeFunction()
        {
            // This line causes the designer to have problems instantiating UserControls inside
            //  other controls. Comment out this line to get the design-time view working.
            // Note: on the very first compile of the project, it will work. After that, any rebuild
            //  will cause errors in the designer. Runtime always works fine.
            ServiceLocator.Current.GetInstance(null);
            
            // This line doesn't cause any problems.
            ServiceLocator.Current.GetInstance<string>();
        }

    }
}

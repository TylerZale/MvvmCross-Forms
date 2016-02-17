using MvvmCross.Core.ViewModels;

namespace Example.ViewModels
{
    /// <summary>
    /// This view model needs to be in a seperate assembly from the views because the non-mobile platforms cannot use Xamarin.forms
    /// </summary>
    public class AboutViewModel 
        : MvxViewModel
    {
    }
}
